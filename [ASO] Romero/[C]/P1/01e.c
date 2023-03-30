#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

int main(void)
{
    fork();
    fork();
    fork();
    printf("Soy  el proceso %d mi padre es %d\n", getpid(), getppid());
    sleep(1);
    exit(0);
}
