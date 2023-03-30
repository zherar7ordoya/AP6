#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(void)
{
    int var = 5;
    pid_t pid;
    pid = fork();

    printf("%d: Soy Main(1). Variable = %d \n", getpid(), var);

    if (pid == 0)
    {
        printf("%d: Soy Hijo.    Variable = %d \n", getpid(), var);
        var--;
        printf("%d: Variable decrementada = %d \n", getpid(), var);
    }

    printf("%d: Soy Main(2). Variable = %d \n", getpid(), var);

    if (pid > 0)
    {
        printf("%d: Soy Padre.   Variable = %d \n", getpid(), var);
        var++;
        printf("%d: Variable incrementada = %d \n", getpid(), var);
    }

    printf("%d: Soy Main(3). Variable = %d \n", getpid(), var);

    exit(0);
}
