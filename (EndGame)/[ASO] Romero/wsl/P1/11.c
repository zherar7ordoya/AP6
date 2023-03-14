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
        printf("\nPROCESO PADRE %d\n", getpid());
        wait(NULL);
    }
    else
    {
        printf("\nPROCESO HIJO  %d\n", getpid());

        printf("\nLlamada a PS usando SYSTEM\n");
        system("ps -l");

        printf("\nLlamada a PS usando EXECLP\n");
        execlp("ps","ps", "-l", NULL);
    }
    printf("\n");
    exit(0);
}