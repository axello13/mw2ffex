// mw2ffex.cpp : Defines the entry point for the console application.
//
#include <mw2ffex.h>
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <stdint.h>
#include <string.h>
#include <sys/stat.h>
#include <errno.h>

#define PADDING '/xFF' // padding/seperator used by IW in the ff

int freadstr(FILE* fid, register char* str, size_t max_size);
char * getAssetType(int type);
FILE* fopen_mkdir(const char* name, const char* mode);
typedef struct {
	int sizeOfFF;
	char data[36];
} ff_header;

typedef struct {
	int index1;
	int padding1;
	int index2;
	int padding2;
	int index3;
	int padding3;
} ff_index;

typedef struct {
	char string[32];
} ff_string_index;

typedef struct {
	int type;
	int pading;
} ff_asset_index;

typedef struct {
	int type;
	char name[64];
	int data1;
	int data2;
	int data3;
} ff_asset;

int main(int argc, char* argv[])
{
	ff_header header;
	ff_index index;
	ff_asset_index * assets;
	ff_string_index * strings;
	ff_asset * realassets;
	FILE *fp;
	FILE *fpout;
	uint8_t temp = 255;
	uint32_t version = 0;
	int i=0,j = 0;
	char * fileName = "fastfiles/common.ff";
	char * fileNameExtracted = (char*)malloc(strlen(fileName)+14);
	char * fileNameLog = (char*)malloc(strlen(fileName)+8);
	char * outFolder = "fastfiles/common/";
	strcpy(fileNameExtracted,fileName);
	strcat(fileNameExtracted,"-extracted.dat");
	strcpy(fileNameLog,fileName);
	strcat(fileNameLog,"-log.log");

	fp = fopen(fileName,"rb");
	fseek(fp,8,0);
	fread(&version,sizeof(uint32_t),1,fp);
	if(version != 276)
	{
		fclose(fp);
		printf("This is not a MW2 Fastfile!\n");
		return -1;
	} else { printf("This is a MW2 Fastfile\n"); }
	fclose(fp);
	fp=NULL;

	extract_fastfile(fileName, fileNameExtracted);

	fp = fopen(fileNameExtracted,"rb");
	if(fp == NULL) { printf("FAILED TO OPEN FILE\n"); system("PAUSE"); return -1; }
	fpout = fopen(fileNameLog, "w");
	if(fpout == NULL) { printf("FAILED TO OPEN FILE\n"); system("PAUSE"); return -1; }
	fread(&header,sizeof(header),1,fp);
	printf("Read header of FF. Size is 0x%x\n", header.sizeOfFF);
	fread(&index,sizeof(index),1,fp);
	printf("Read index. %d entries in 1st index.\n%d entries in second index.\n%d entires in thrid index.\n", index.index1, index.index2, index.index3);
	while (temp == 255) {
		fread(&temp, sizeof(char), 1,fp);
		//printf(".");
		i++;
	}
	printf("Read %d bytes of padding.\n", i);
	/*for(i=0; i<30; i++)
	{
		fread(&temp,sizeof(uint8_t),1,fp);
		printf("0x%x\n",temp);
	}
	system("pause");*/
	strings = (ff_string_index*) malloc(sizeof(ff_string_index)*index.index1+1);
	printf("Allocated memory for strings index\n");
	fseek(fp,-1,SEEK_CUR);
	fprintf(fpout,"---------------PRE ASSET STRINGS---------------\n");
	for(i=0; i<index.index1-1; i++)
	{
		freadstr(fp,strings[i].string,40);
		fprintf(fpout,"%s\n",strings[i].string);
	}
	printf("Read pre asset string table.... Now at pos 0x%x\n",ftell(fp));

	printf("Allocating memory for asset index\n");
	fprintf(fpout,"---------------INDEX---------------\n");
	assets = (ff_asset_index*) malloc(sizeof(ff_asset_index)*index.index2+1);
	for(i=0; i<index.index2; i++)
	{
		fread(&assets[i],sizeof(ff_asset_index),1,fp);
		fprintf(fpout,"read %s (0x%x)\n",getAssetType(assets[i].type),assets[i].type);
	}
	printf("read index\n");
	printf("Allocating memory for assets\n");
	fprintf(fpout,"---------------ASSETS---------------\n");
	realassets = (ff_asset*)malloc(sizeof(ff_asset)*index.index2-1);
	fseek(fp,4,SEEK_CUR);
	loadAsset(fp,fpout,assets[0].type,realassets,0,outFolder);
	for(i=1; i<index.index2; i++)
	{
		j=0;	
		do {
			fread(&temp,sizeof(char),1,fp);
			if(temp == 255) {
				j++;
			} else if(j > 0) {
				j=0;
			}
		} while(j < 24);
		if(j == -1)
		{
			printf("couldn't find any more entires even though we havent read specefied ammount\n");
			system("pause");
			return 1;
		}
		i=loadAsset(fp,fpout,assets[i].type,realassets,i,outFolder);
	}
	system("pause");
	fclose(fp);
	fclose(fpout);
	return 0;
}

int freadstr(FILE* fid, register char* str, size_t max_size)
{
    int c, count = 0;
    do {
        c = fgetc(fid);
        if (c == EOF) {
            clearerr(fid);
            return -1;
        } else {
            *str = (char) c;
            count++;
        }
    } while ((*str++ != '\0') && (count < max_size));
    return count;
}

int loadAsset(FILE * fp, FILE * fpout, int type, ff_asset * assets, int i, char * assetFolder)
{
	int startloc = ftell(fp);
	int * temp;
	int j;
	FILE * assetFile;
	char * assetFileName;
	char * tempchar;
	switch(type)
	{
	case 0x25:
		fread(&assets[i].data1,sizeof(int),1,fp);
		fread(&assets[i].data2,sizeof(int),1,fp);
		fseek(fp,4,SEEK_CUR);
		freadstr(fp,assets[i].name,40);
		printf("stringtable (0x%x) called %s with size %dx%d at 0x%x\n",type,assets[i].name,assets[i].data1,assets[i].data2,startloc);
		fprintf(fpout,"stringtable (0x%x) called %s with size %dx%d at 0x%x\n",type,assets[i].name,assets[i].data1,assets[i].data2,startloc);
		assetFileName = (char*)malloc(strlen(assetFolder)+strlen(assets[i].name)+5);
		memset(assetFileName,0,strlen(assetFolder)+strlen(assets[i].name)+5);
		strcat(assetFileName,assetFolder);
		strcat(assetFileName,assets[i].name);
		printf("Saving csv as %s\n",assetFileName);
		assetFile = fopen_mkdir(assetFileName,"w");
		if(assetFile == NULL) 
		{
			system("pause");
		}
		tempchar = (char*)malloc(128);
		fseek(fp,(assets[i].data1*assets[i].data2)*8,SEEK_CUR);
		for(j=0; j<(assets[i].data1*assets[i].data2)/2;j++)
		{
			freadstr(fp,tempchar,128);
			fprintf(assetFile,"%s",tempchar);
			if(j != ((assets[i].data1*assets[i].data2)/2)-1) {
				fprintf(assetFile,",");
			}
			if((j % assets[i].data1) == 0 && j != 0) {
				fprintf(assetFile,"\n");
			}
		}
		fclose(assetFile);
		break;
	case 0x2:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fseek(fp,8,SEEK_CUR);
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		fprintf(fpout,"xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;

	case 0x24:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fseek(fp,8,SEEK_CUR);
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		fprintf(fpout,"xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;

	case 0x1b:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fseek(fp,8,SEEK_CUR);
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		fprintf(fpout,"xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;

	case 0x1f:
		printf("rawfile (0x%x) called %s at 0x%x\n",type, assets[i].name,startloc);
		fprintf(fpout, "rawfile (0x%x) called %s at 0x%x\n",type, assets[i].name,startloc);
		assetFileName = (char*)malloc(strlen(assetFolder)+strlen(assets[i].name)+5);
		memset(assetFileName,0,strlen(assetFolder)+strlen(assets[i].name)+5);
		strcat(assetFileName,assetFolder);
		strcat(assetFileName,assets[i].name);
		extract_rawfile(fp,assetFileName);
		break;
	default:
		printf("unimplemented asset - %s (0x%x) at 0x%x\n",getAssetType(type),type,startloc);
		fprintf(fpout,"unimplemented asset - %s (0x%x) at 0x%x\n",getAssetType(type),type,startloc);
		break;
	}
	return i;
}

char * getAssetType(int type)
{
	char ret[47][32] = {
		"xmodelpieces", 
		"physpreset", 
		"xanim",
		"xmodel",
		"material",
		"pixelshader",
		"techset",
		"image",
		"sndcurve",
		"loaded_sound",
		"col_map_sp",
		"col_map_mp",
		"com_map",
		"game_map_sp",
		"game_map_mp",
		"map_ents",
		"gfx_map",
		"lightdef",
		"ui_map",
		"font",
		"menufile",
		"menu",
		"localize",
		"weapon",
		"snddriverglobals",
		"impactfx",
		"aitype",
		"mptype",
		"character",
		"xmodelalias",
		"rawfile",
		"stringtable",
		"unknown(0x20)",
		"unknown(0x21)",
		"unknown(0x22)",
		"unknown(0x23)",
		"xanim",
		"stringtable",
		"unknown(0x26)",
		"unknown(0x27)",
		"unknown(0x28))",
		"unknown(0x29)",
		"unknown(0x2a)",
		"unknown(0x2b)",
		"unknown(0x2c)",
		"unknown(0x2d)",
		"unknown(0x2e)",
	};
	return ret[type];
}