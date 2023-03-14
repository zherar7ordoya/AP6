#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(int argc, char **argv)
{
    pid_t pid;
    pid = fork();

    if (pid > 0)
    {
        wait(NULL);
    }
    else
    {
        printf("\nSOY EL HIJO Y ME CONVIERTO\n\n");
        execlp(argv[1], argv[1], NULL);
    }
    printf("Presione ENTER para finalizar\n");
    char enter = 0;
    while (enter != '\r' && enter != '\n')
    {
        enter = getchar();
    }
    exit(0);
}