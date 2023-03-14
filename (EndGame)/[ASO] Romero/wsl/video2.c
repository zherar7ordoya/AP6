#include <stdio.h>
#include <unistd.h>

int main(void) 
{
    fork();
    printf("¿Quién escribió ésta línea en la terminal? ¿El padre o el hijo?\n");
    return 0;
}