#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

int main()
{
    fork();
    fork();
    printf("Soy el proceso % d\n", getpid());
    exit(0);
}
