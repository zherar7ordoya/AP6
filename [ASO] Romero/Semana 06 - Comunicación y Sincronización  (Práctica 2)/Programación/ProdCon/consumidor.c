#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#define BUFFER_SIZE 5

int main(void)
{
    int shmidbuffer = shmget(0xa, 0, 0);
    int shmidcontador = shmget(0xb, 0, 0);
    int sale = 0;

    printf("\nCONSUMIDOR \n");
    printf("shmidbuffer   \t %d \n", shmidbuffer);
    printf("shmidcontador \t %d \n", shmidcontador);
    printf("------------------ \n\n");

    char *dirbuffer = (char *)shmat(shmidbuffer, 0, 0);
    int *dircontador = (int *)shmat(shmidcontador, 0, 0);

    while (1)
    {
        while (*dircontador == 0);
        *dircontador = *dircontador - 1;
        printf("\t %c \t %d \n", dirbuffer[sale], *dircontador);
        sale = (sale + 1) % BUFFER_SIZE;
        sleep(1);
    }

    shmdt(dirbuffer);
    shmdt(dircontador);
    exit(0);
}