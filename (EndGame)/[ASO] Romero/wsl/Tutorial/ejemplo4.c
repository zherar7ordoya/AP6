// ÁRBOL EXPONENCIAL

#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>

void main()
{
    fork();
    fork();
    fork();
    printf("Soy el proceso %d\n", getpid());
    while(1);
}