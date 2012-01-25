/* Based off of offzip.*/

#include <mw2ffex.h>
#include <zlib.h>
#include <sign_ext.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <ctype.h>

#define INSZ            0x800   // the amount of bytes we want to decompress each time
#define OUTSZ           0x10000 // the buffer used for decompressing the data
#define FBUFFSZ         0x40000 // this buffer is used for reading, faster
#define FCLOSE(X)       { if(X) fclose(X); X = NULL; }

#define Z_INIT_ERROR    -1000
#define Z_END_ERROR     -1001
#define Z_RESET_ERROR   -1002

z_stream    z;
uint32_t offset      = 0,
         filebuffoff = 0,
         filebuffsz  = 0;
int zipwbits    = 15,
    minzip      = 32;
uint8_t *in,
        *out,
        *filebuff = NULL;


int buffread(FILE *fd, uint8_t *buff, int size);
void buffseek(FILE *fd, int len, int mode);
void buffinc(int increase);
int unzip(FILE *fd, FILE **fdo, uint32_t *inlen, uint32_t *outlen, uint8_t *dumpname);
uint32_t get_num(uint8_t *str);
void zlib_err(int err);
FILE *save_file(char *fname);
void myfw(uint8_t *buff, int size, FILE *fd);
void std_err(void);


int extract_fastfile(char * infilename, char * outfilename) {
    FILE *fd,
         *fdo  = NULL;

    uint32_t inlen,
             outlen;
    int i,
        files;

    char *file_input,
         *file_output,
         *file_offset;

    setbuf(stdout, NULL);
    setbuf(stderr, NULL);
    file_input  = infilename;
    file_output = outfilename;
    file_offset = "0x15";

    printf("Extracting fastfile: %s\n", file_input);
    fd = fopen(file_input, "rb");
    if(!fd) std_err();

    if(minzip > INSZ) minzip = INSZ;
    if(minzip < 1)    minzip = 1;

    in       = malloc(INSZ);
    out      = malloc(OUTSZ);
    filebuff = malloc(FBUFFSZ);
    if(!in || !out || !filebuff) std_err();

    offset = get_num(file_offset);  // do not skip, needed for buffseek
    buffseek(fd, offset, SEEK_SET);

    z.zalloc = (alloc_func)0;
    z.zfree  = (free_func)0;
    z.opaque = (voidpf)0;
    if(inflateInit2(&z, zipwbits) != Z_OK) zlib_err(Z_INIT_ERROR);

    fdo = save_file(file_output);
    unzip(fd, &fdo, &inlen, &outlen, NULL);
    FCLOSE(fdo)

    printf("\n"
        "%u bytes compressed\n"
        "%u bytes extracted\n",
        inlen, outlen);

    FCLOSE(fdo)
    FCLOSE(fd)
    inflateEnd(&z);
    free(in);
    free(out);
    free(filebuff);
    return(0);
}



int buffread(FILE *fd, uint8_t *buff, int size) {
    int     len,
            rest,
            ret;

    rest = filebuffsz - filebuffoff;

    ret = size;
    if(rest < size) {
        ret = size - rest;
        memmove(filebuff, filebuff + filebuffoff, rest);
        len = fread(filebuff + rest, 1, FBUFFSZ - rest, fd);
        filebuffoff = 0;
        filebuffsz  = rest + len;
        if(len < ret) {
            ret = rest + len;
        } else {
            ret = size;
        }
    }

    memcpy(buff, filebuff + filebuffoff, ret);
    return(ret);
}



void buffseek(FILE *fd, int off, int mode) {
    if(fseek(fd, off, mode) < 0) std_err();
    filebuffoff = 0;
    filebuffsz  = 0;
    offset      = ftell(fd);
}



void buffinc(int increase) {
    filebuffoff += increase;
    offset      += increase;
}

int unzip(FILE *fd, FILE **fdo, uint32_t *inlen, uint32_t *outlen, uint8_t *dumpname) {
    uint32_t     oldsz = 0,
            oldoff,
            len;
    int     ret   = -1,
            zerr  = Z_OK;

    if(dumpname && !dumpname[0]) dumpname = NULL;
    oldoff = offset;
    inflateReset(&z);
    for(; (len = buffread(fd, in, INSZ)); buffinc(len)) {
        z.next_in   = in;
        z.avail_in  = len;
        do {
            z.next_out  = out;
            z.avail_out = OUTSZ;
            zerr = inflate(&z, Z_SYNC_FLUSH);

            if(dumpname) {
                sprintf(dumpname + strlen(dumpname), ".%s", sign_ext(out, z.total_out - oldsz));
                *fdo = save_file(dumpname);
                dumpname = NULL;
            }
			myfw(out, z.total_out - oldsz, *fdo);
			oldsz = z.total_out;

            if(zerr != Z_OK) {      // inflate() return value MUST be handled now
                if(zerr == Z_STREAM_END) {
                    ret = 0;
                } else {
                    zlib_err(zerr);
                }
                break;
            }
            ret = 0;    // it's better to return 0 even if the z stream is incomplete... or not?
        } while(z.avail_in);

        if(zerr != Z_OK) break;     // Z_STREAM_END included, for avoiding "goto"
    }

    *inlen  = z.total_in;
    *outlen = z.total_out;
    if(!ret) {
        oldoff += z.total_in;
    } else {
        oldoff++;
    }
    buffseek(fd, oldoff, SEEK_SET);
    return(ret);
}



uint32_t get_num(uint8_t *str) {
    uint32_t     offsetx;

    if((str[0] == '0') && (tolower(str[1]) == 'x')) {
        sscanf(str + 2, "%x", &offsetx);
    } else {
        sscanf(str, "%u", &offsetx);
    }
    return(offsetx);
}



void zlib_err(int zerr) {
    switch(zerr) {
        case Z_DATA_ERROR:
            fprintf(stderr, "\n"
                "- zlib Z_DATA_ERROR, the data in the file is not in zip format\n"
                "  or uses a different windowBits value (-z). Try to use -z %d\n",
                -zipwbits);
            break;
        case Z_NEED_DICT:
            fprintf(stderr, "\n"
                "- zlib Z_NEED_DICT, you need to set a dictionary (option not available)\n");
            break;
        case Z_MEM_ERROR:
            fprintf(stderr, "\n"
                "- zlib Z_MEM_ERROR, insufficient memory\n");
            break;
        case Z_BUF_ERROR:
            fprintf(stderr, "\n"
                "- zlib Z_BUF_ERROR, the output buffer for zlib decompression is not enough\n");
            break;
        case Z_INIT_ERROR: {
            fprintf(stderr, "\nError: zlib initialization error (inflateInit2)\n");
            exit(1);
            break;
        }
        case Z_END_ERROR: {
            fprintf(stderr, "\nError: zlib free error (inflateEnd)\n");
            exit(1);
            break;
        }
        case Z_RESET_ERROR: {
            fprintf(stderr, "\nError: zlib reset error (inflateReset)\n");
            exit(1);
            break;
        }
        default: {
            fprintf(stderr, "\nError: zlib unknown error %d\n", zerr);
            exit(1);
            break;
        }
    }
}



FILE *save_file(char *fname) {
    FILE    *fd;
    fd = fopen(fname, "wb");
    if(!fd) std_err();
    return(fd);
}



void myfw(uint8_t *buff, int size, FILE *fd) {
    if(!fd) return;
    if(size <= 0) return;
    if(fwrite(buff, 1, size, fd) != size) {
        fprintf(stderr, "\nError: problems during files writing, check permissions and disk space\n");
        exit(1);
    }
}


void std_err(void) {
    perror("\nError");
    exit(1);
}


