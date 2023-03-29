#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#include <ctype.h>
#include <dirent.h>

#include <sys/stat.h>
#include <sys/types.h>

#include <sys/ipc.h>
#include <sys/shm.h>
#include <string.h>

#define PERM 0644
#define BUFSIZE 10

int main(int argc, char *argv[])
{
    // *------------------------------*
    int shmidcontador = shmget(0xb, sizeof(int), IPC_CREAT | IPC_EXCL | 0600);

    int pone = 0;

    printf("Contador: %d \n", shmidcontador);

    int *dircontador = (int *) shmat(shmidcontador, 0, 0);

    *dircontador = 0;

    exit(0);
    // *------------------------------*

    return 0;
}
