#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
int main()
{
    fork();
    printf("Quien soy, el padre o el hijo\n");
    exit(0);
}
