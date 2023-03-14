#include <stdio.h>
#include <stdlib.h>

#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/sem.h>

int main(void)
{
    int semid = semget(0xa, 0, 0);

    if (semid != -1)
    {
        printf("sem 0 = %d \n", semctl(semid, 0, GETVAL));
        printf("sem 1 = %d \n", semctl(semid, 1, GETVAL));
    }

    exit(0);
}