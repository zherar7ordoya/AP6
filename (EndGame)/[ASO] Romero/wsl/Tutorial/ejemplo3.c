#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>

void main()
{
    int pid = fork();
    switch ((pid))
    {
    case 0:
        printf("Proceso hijo %d de padre %d\n", getpid(), getppid());
        break;
    case -1:
        printf("Error");
        exit(1);
        break;
    default:
        printf("Proceso padre %d de padre %d\n", getpid(), getppid());
        break;
    }
}