#ifndef MW2FFEX_H
#define MW2FFEX_H

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <ctype.h>
#include <direct.h>

int extract_fastfile(char * infilename, char * outfilename);
int extract_rawfile(FILE * fastfile, char * outfilename);

static FILE* fopen_mkdir(const char* name, const char* mode) {
	char* mname = strdup(name);
	int i;
	for(i=0; mname[i] != '\0'; i++) {
		if (i>0 && (mname[i] == '\\' || mname[i] == '/')) {
			char slash = mname[i];
			mname[i] = '\0';
			mkdir(mname);
			mname[i] = slash;
		}
	}
	free(mname);
	return fopen(name, mode);
}

static void std_err(void) {
    perror("\nError");
    exit(1);
}

static FILE *save_file(char *fname) {
    FILE    *fd;
    fd = fopen_mkdir(fname, "wb");
    if(!fd) std_err();
    return(fd);
}

#endif