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

    int n = 0;
    int shmidcontador = shmget(0xb, 0, 0);
    int pone = 0;
    int *dircontador = (int *)shmat(shmidcontador, 0, 0);
    char texto[] = "";

    while(1)
    {
        while (*dircontador == BUFSIZE)
            ;

            FILE *fichero;
            texto[*dircontador] = n;
            int i = 0;
            fichero = fopen("buffer.txt", "wt");
            n++;
            *dircontador++;
            printf("Producción: %d \n", *dircontador);

            while (texto[i] != '\0')
            {
                fputc(texto[i], fichero);
                i++;
            }
            printf("Aleatorio: %s \n", texto);
            pone = (pone + 1) % BUFSIZE;
            fclose(fichero);

    }
    shmdt(dircontador);
    exit(0);

    // *------------------------------*

    return 0;
}
