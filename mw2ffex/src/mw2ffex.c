// mw2ffex.cpp : Defines the entry point for the console application.
//
#include <mw2ffex.h>
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <stdint.h>
#include <string.h>

#define PADDING '/xFF' // padding/seperator used by IW in the ff

int freadstr(FILE* fid, register char* str, size_t max_size);
char * getAssetType(int type);
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
	uint8_t temp = 255;
	uint32_t version = 0;
	int i=0,j = 0;
	char * fileName = "common.ff";
	char * fileNameExtracted = (char*)malloc(strlen(fileName)+14);
	strcpy(fileNameExtracted,fileName);
	strcat(fileNameExtracted,"-extracted.dat");

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

	fread(&header,sizeof(header),1,fp);
	printf("Read header of FF. Size is 0x%x\n", header.sizeOfFF);
	fread(&index,sizeof(index),1,fp);
	printf("Read index. %d entries in 1st index.\n%d entries in second index.\n%d entires in thrid index.\n", index.index1, index.index2, index.index3);
	while (temp == 255) {
		fread(&temp, sizeof(char), 1,fp);
		printf(".");
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
	for(i=0; i<index.index1-1; i++)
	{
		freadstr(fp,strings[i].string,40);
		//printf("%s\n",strings[i].string);
	}
	printf("Read pre asset string table\nNow at pos 0x%x\n",ftell(fp));

	printf("Allocating memory for asset index\n");
	assets = (ff_asset_index*) malloc(sizeof(ff_asset_index)*index.index2+1);
	for(i=0; i<index.index2; i++)
	{
		fread(&assets[i],sizeof(ff_asset_index),1,fp);
		//printf("read index of type %s \n", getAssetType(assets[i].type));
		//printf("read index of type 0x%x \n", assets[i].type);
	}
	printf("read index\n");
	printf("Allocating memory for assets\n");
	realassets = (ff_asset*)malloc(sizeof(ff_asset)*index.index2-1);

	/*for(i=0;i<30;i++)
	{
		fread(&temp,sizeof(char),1,fp);
		printf("0x%x\n",temp);
	}*/
	fseek(fp,4,SEEK_CUR);
	loadAsset(fp,assets[0].type,realassets,0);
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
		i=loadAsset(fp,assets[i].type,realassets,i);
	}
	system("pause");
	fclose(fp);
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

int loadAsset(FILE * fp, int type, ff_asset * assets,int i)
{
	int startloc = ftell(fp);
	int temp;
	switch(type)
	{
	case 0x25:
		fread(&assets[i].data1,sizeof(int),1,fp);
		fread(&assets[i].data2,sizeof(int),1,fp);
		fseek(fp,4,SEEK_CUR);
		freadstr(fp,assets[i].name,40);
		printf("stringtable (0x%x) called %s with size %dx%d at 0x%x\n",type,assets[i].name,assets[i].data1,assets[i].data2,startloc);
		break;
	case 0x2:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;

	case 0x24:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;

	case 0x1b:
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != 0) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		fread(&temp,sizeof(int),1,fp);
		if(temp != -1) { i--; break; }
		freadstr(fp,assets[i].name,64);
		printf("xanim (0x%x) called %s at 0x%x\n",type,assets[i].name,startloc);
		break;
	default:
		printf("unimplemented asset - %s (0x%x) at 0x%x\n",getAssetType(type),type,startloc);
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

