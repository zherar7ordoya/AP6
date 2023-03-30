/**
 * Programa para inicializar memoria compartida (https://youtu.be/IfvSCxe2NZQ).
 */

#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
    int shmidbuffer   = shmget(0xa, 0, 0);
    int shmidcontador = shmget(0xb, 0, 0);

    printf("shmidbuffer   \t %d \n", shmidbuffer);
    printf("shmidcontador \t %d \n", shmidcontador);

    char *dirbuffer  = (char *)shmat(shmidbuffer,   0, 0);
    int *dircontador = (int  *)shmat(shmidcontador, 0, 0);

    strcpy(dirbuffer, ".....");
    *dircontador = 0;

    exit(0);
}