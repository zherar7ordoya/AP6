#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main(void)
{
    pid_t pid;
    pid = fork();
    if (pid < 0)
    {
        printf("Ha ocurrido un error\n");
        exit(pid);
    }
    else if (pid > 0) // soy el padre
    {
        printf("soy el padre %d mi padre es el shell %d mi hijo es pid = %d\n",
            getpid(),
            getppid(),
            pid);
        exit(pid);
    }
    else // soy el hijo
    {
        printf("soy el hijo y voy hacer un nieto contenido de la variable pid = %d\n",
            pid);
        pid = fork();
        if (pid == 0) // soy el nieto
        {
            printf("soy el nieto %d mi padre es %d  pid = %d\n",
                getpid(),
                getppid(),
                pid);
            exit(pid);
        }
        else // soy el primer hijo padre del nieto
        {
            printf("soy el primer hijo padre del nieto %d mi hijo es pid = %d\n",
                getpid(),
                pid);
            exit(pid);
        }
        exit(pid);
    }
}
