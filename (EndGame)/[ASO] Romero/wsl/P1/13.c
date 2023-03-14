#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>
int main(int argc, char *argv[])
{
    freopen("13.txt", "w", stdout);
    pid_t pid;
    int n;
    for (n = 0; n < atoi(argv[1]); n++)
    {
        pid = fork();
        if (pid == 0)
        {
            break;
        }
    }
    printf("\nPadre: %d \t Yo: %d \t Hijo: %d \t Ciclo: %d \n", getppid(), getpid(), pid, n);
    if (n == atoi(argv[1]))
    {
        system("ps -l");
    }
    exit(0);
}