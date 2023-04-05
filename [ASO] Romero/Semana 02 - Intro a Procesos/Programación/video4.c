#include <sys/types.h>
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

int main(void)
{
    pid_t pid = fork();
    if (pid==0) { printf("Hijo %d\t Padre %d\n", getpid(), getppid()); }
    else
    {
        if (pid>0) { printf("Padre %d\t Hijo %d\t Abuelo %d\n", getpid(), pid, getppid()); }
        else{ printf("Fork falló...\n"); }
    }
    return 0;
}