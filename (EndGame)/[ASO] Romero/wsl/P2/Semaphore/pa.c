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
        P(semid, 0);
        printf(" Sección crítica del proceso PA. \n");
        sleep(1);
        V(semid, 1);
    }

    exit(0);
}
