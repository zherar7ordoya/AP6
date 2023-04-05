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
        printf("El proceso hijo está durmiendo...\n");
        sleep(5);
        printf("\nID del padre del huérfano %d: %d\n", getpid(), getppid());
        system("ps -l");
    }
    else // Proceso padre.
    {
        printf("\nPROCESO PADRE COMPLETADO\n");
    }
    return 0;
}
