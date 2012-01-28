#include <stdio.h>
#include <string.h>

long bufferReadingPos = 0;
int readBuffer(void * result, size_t size, size_t count, void * source)
{
	int i;
	for(i=0; i<count; i++)
	{
		memcpy(((char*)result+(i*size)),((char*)source+(i*size)+bufferReadingPos),size);
		bufferReadingPos+=size;
	}
	return 1;
}

int seekBuffer(size_t offset, size_t count)
{
	bufferReadingPos = offset+count;
	return bufferReadingPos;
}

int bufferreadstr(void * buffer,  char* str, size_t max_size)
{
	size_t count;
	strncpy(str,(char *)buffer+bufferReadingPos,max_size);
	count = strlen(str);
	if(count < 1) { count = 1; }
	//printf("count is %d\n",count);
	bufferReadingPos+=count;
	return 1;
}