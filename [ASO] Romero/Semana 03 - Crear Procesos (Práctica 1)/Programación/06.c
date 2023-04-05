#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main()
{
    int pid;
    pid = getpid();

    printf("\nID del presente proceso (padre): %d\n", pid);
    printf("\n[ Clonación... ] \n");

    pid = fork();

    if (pid < 0) // Falla durante el clonado.
    {
        exit(-1);
    }
    else if (pid == 0) // Proceso hijo.
    {
        printf("\nID del presente proceso (hijo): %d\n", getpid());
        printf("\nPROCESO HIJO COMPLETADO\n");
    }
    else // Proceso padre.
    {
        printf("\nID del presente proceso (padre): %d\n", getpid());
        sleep(5);
        printf("\nEl proceso padre está ejecutándose...\n");
        printf("\n[ Zombificación... ] \n");
        int bandera = 1;
        while (1) // Área zombie;
        {
            if (bandera == 1) {
                system("ps -l");
                bandera++;
                printf("\nCTRL+C para volver al bash.\n");
            }
        }
    }
    return 0;
}
