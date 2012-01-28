// mw2ffex.cpp : Defines the entry point for the console application.
//
#include <mw2ffex.h>
#include <bufferutil.h>
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

int main(int argc, char* argv[])
{
	ff_header header;
	ff_index index;
	ff_asset_index * assets;
	ff_string_index * strings;
	FILE *fp;
	uint8_t temp = 255;
	uint32_t version = 0;
	int i=0,j = 0;
	long fileLen = 0;
	char * buffer;
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
	// Get the length
    fseek(fp, 0, SEEK_END);
    fileLen=ftell(fp);

    fseek(fp, 0, SEEK_SET);

	// Allocate memory
    buffer = (char*)malloc(fileLen);

    if (!buffer)
    {
        fprintf(stderr, "Memory error!\n");
        fclose(fp);
        return -1;
    }

	// File to buffer
	fread(buffer, fileLen, 1, fp);
	printf("read %d bytes from %s into memory\n",fileLen,fileNameExtracted);
	fclose(fp);

	readBuffer(&header,sizeof(header),1,buffer);
	printf("Read header of FF. Size is 0x%x\n", header.sizeOfFF);
	readBuffer(&index,sizeof(index),1,buffer);
	printf("Read index. %d entries in 1st index.\n%d entries in second index.\n%d entires in thrid index.\n", index.index1, index.index2, index.index3);
	while (temp == 255) {
		readBuffer(&temp, sizeof(char), 1,buffer);
		printf(".");
		i++;
	}
	printf("Read %d bytes of padding.\n", i);
	
	strings = (ff_string_index*) malloc(sizeof(ff_string_index)*index.index1+1);
	printf("Allocated memory for strings\n");
	for(i=0; i<index.index1-1; i++)
	{
		bufferreadstr(fp,strings[i].string,40);
		printf("%s\n",strings[i].string);
	}
	printf("Read pre asset string table\n");

	assets = (ff_asset_index*) malloc(sizeof(ff_asset_index)*index.index2+1);
	/*for(i=0; i<index.index2-1; i++)
	{
		readBuffer(&assets[i],sizeof(ff_asset_index),1,fp);
		//printf("read index of type %s \n", getAssetType(assets[i].type));
		printf("read index of type 0x%x \n", assets[i].type);
	}
	/*for(i=0; i<30; i++)
	{
		fread(&temp,sizeof(uint8_t),1,fp);
		printf("0x%x\n",temp);
	}*/
	system("pause");
	free(buffer);
	return 0;
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
		"unknown(0x21)",
		"unknown(0x22)",
		"unknown(0x23)",
		"unknown(0x24)",
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
		"unknown(0x2f)"
	};
	return ret[type];
}

