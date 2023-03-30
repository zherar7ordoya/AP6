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
        P(semid, 2);        // Sección de entrada.
        printf(" C \t\n");  // Sección crítica.
        sleep(1);           // Visibilizador.
        V(semid, 0);        // Sección de salida.
    }

    exit(0);
}