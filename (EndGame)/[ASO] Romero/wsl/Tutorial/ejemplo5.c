// ÁRBOL EXPONENCIAL

#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>

void main()
{
    for (int i = 0; i < 3; i++)
    {
        if (fork() == 0)
        {
            break;
        }
    }
    printf("Soy el proceso %d\n", getpid());
    while(1);
}