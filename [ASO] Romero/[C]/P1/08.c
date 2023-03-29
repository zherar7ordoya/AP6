#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main()
{
    pid_t pid;
    pid = fork();
    if (pid == 0)
        pid = fork();
    if (pid > 0)
        pid = fork();
    printf("%d hijo de %d\n", getpid(), getppid());
    sleep(1);
    exit(0);
}
