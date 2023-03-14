#include <stdio.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <unistd.h>

int main()
{
    if (fork() == 0)
        printf("\nSoy el hijo (%d) y digo: ¡Hola!\n", getpid());
    else
    {
        printf("\nSoy el padre (%d) y digo: ¡Hola!\n", getpid());
        wait(NULL);
        printf("\nPROCESO HIJO TERMINADO\n");
    }
    printf("\nSoy %d y digo: ¡Chau!\n", getpid());
    return 0;
}