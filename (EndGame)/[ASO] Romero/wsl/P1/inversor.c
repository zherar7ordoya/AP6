#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(int argc, char *argv[])
{
    pid_t pid, finalizado;
    int estado = 0;
    int i;

    for (i = 0; i < atoi(argv[1]); i++)
    {
        pid = fork();
        if (pid > 0)
        {
            break;
        }
    }

    printf("SOY %d PADRE DE %d \n", getpid(), pid);

    finalizado = wait(&estado);

    if (finalizado == -1)
    {
        printf("SOY EL ÚLTIMO PROCESO CREADO, ES DECIR, NO TENGO HIJOS (SOY %d HIJO DE %d) \n", getpid(), getppid());
    }
    else
    {
        printf("SOY EL PROCESO %d Y FINALIZÓ MI HIJO %d \n", getpid(), finalizado);
    }
}