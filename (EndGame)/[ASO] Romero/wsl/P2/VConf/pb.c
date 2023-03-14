#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/sem.h>
#include <sys/ipc.h>
#include "operipc.h"

int main(void)
{
    int semid = semget(0xa, 0, 0);
    printf("semid = %d \n", semid);

    while (1)
    {
        P(semid, 1);        // Sección de entrada.
        printf(" B \t\n");  // Sección crítica.
        sleep(1);           // Visibilizador.
        V(semid, 2);        // Sección de salida.
    }

    exit(0);
}