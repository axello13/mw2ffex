// mw2ffex.cpp : Defines the entry point for the console application.
//
#include <mw2ffex.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <stdint.h>

#define PADDING '/xFF' // padding/seperator used by IW in the ff

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
	int pading;
	int type;
} ff_asset_index;

int main(int argc, char* argv[])
{
	ff_header header;
	ff_index index;
	ff_asset_index assetind;
	ff_string_index * strings;
	FILE *fp;
	uint8_t temp = 255;
	int i=0,j = 0;

	extract_fastfile("common.ff", "common.ff-extracted.dat");
	fp = fopen("common.ff-extracted.dat","rb");
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
	
	strings = (ff_string_index*) malloc(sizeof(ff_string_index)*index.index1+1);
	printf("Allocated memory for strings\n");
	for(i=0; i<index.index1; i++)
	{
		freadstr(fp,strings[i].string,40);
		printf("%s\n",strings[i].string);
	}
	printf("Read pre asset string table\n");

	for(i=0; i<index.index2; i++)
	{
		fread(
	}
	system("pause");
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

