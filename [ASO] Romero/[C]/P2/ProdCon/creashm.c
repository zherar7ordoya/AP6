/**
 * Código en lenguaje C para crear memoria compartida en el Sistema Operativo
 * Linux Debian (video "Productor Consumidor 01": https://youtu.be/IfvSCxe2NZQ).
 */

#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>

int main (void)
{
    int shmidbuffer = shmget(0xa, 5, IPC_CREAT | IPC_EXCL | 0600);
    int shmidcontador = shmget(0xb, sizeof(int), IPC_CREAT | IPC_EXCL | 0600);

    printf("shmidbuffer   \t %d \n", shmidbuffer);
    printf("shmidcontador \t %d \n", shmidcontador);

    exit(0);
}