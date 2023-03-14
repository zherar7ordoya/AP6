#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(int argc, char * argv[])
{
    freopen("12.txt", "w", stdout);

    pid_t pid;
    int n = atoi(argv[1]);

    for (int i = 0; i < n; i++)
    {
        pid = fork();
        if (pid > 0) 
        {
            break;
        }
    }
    printf("\nLISTADO\n");
    printf("ID proceso padre:  %d \n", getppid());
    printf("ID proceso actual: %d \n", getpid());
    printf("ID proceso hijo:   %d \n", pid);
    system("ps -l");
    exit(0);
}