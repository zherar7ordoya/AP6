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
    int shmidcontador = shmget(0xb, 0, 0);
    int sale = 0;
    int *dircontador = (int *)shmat(shmidcontador, 0, 0);

    while(1)
    {
        while (*dircontador == 0)
        {
            *dircontador--;
            printf("Consumiendo: %d \n", *dircontador);
            sale = (sale + 1) % BUFSIZE;
        }
    }
    shmdt(dircontador);
    exit(0);
    // *------------------------------*

    return 0;
}
