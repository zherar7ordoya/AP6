#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#define BUFFER_SIZE 5

char Produccion(void);

int main(void)
{
    int shmidbuffer = shmget(0xa, 0, 0);
    int shmidcontador = shmget(0xb, 0, 0);
    int pone = 0;

    printf("Productor\n");
    printf("shmidbuffer %d\n", shmidbuffer);
    printf("shmidcontador%d\n", shmidcontador);
    printf("......................\n");

    char *dirbuffer = (char *)shmat(shmidbuffer, 0, 0);
    int *dircontador = (int *)shmat(shmidcontador, 0, 0);

    while (1)
    {
        while (*dircontador == BUFFER_SIZE)
            ;
        dirbuffer[pone] = Produccion();
        *dircontador = *dircontador + 1;
        printf("Productor: %c %d \n", dirbuffer[pone], *dircontador);
        pone = (pone + 1) % BUFFER_SIZE;
        sleep(1);
    }

    shmdt(dirbuffer);
    shmdt(dircontador);
    exit(0);
}

char Produccion(void)
{
    static int letra = 'A';
    if (letra == 'Z')
        letra = 'A';
    else
        letra++;
    return letra;
}