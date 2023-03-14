#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main()
{
    pid_t pid;
    pid = fork();
    if (pid == 0)
    {
        printf("Soy el hijo %d del padre %d\n", getpid(), getppid());
        printf("¿Soy un Zombie?\n");
        system("ps -l");
        exit(0);
    }
    else if (pid > 0)
    {
        printf("\n[ SOY EL PADRE %d DEL HIJO %d ]\n", getpid(), pid);
        printf("\n[ PADRE %d ESPERANDO FINALIZADO DE HIJO %d ]\n\n", getpid(), pid);
        wait(&pid);
        printf("\n[ PADRE %d REPORTA FINALIZACIÓN DEL HIJO ]\n\n", getpid());
    }
    exit(0);
}