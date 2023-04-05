#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/sem.h>

void P(int, int);
void V(int, int);

int main(void)
{
    int semid = semget(0xa, 0, 0);

    while (1)
    {
        P(semid, 1);
        printf(" Sección crítica del proceso PB. \n");
        sleep(1);
        V(semid, 0);
    }

    exit(0);
}
