#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/sem.h>
#include <sys/ipc.h>

int main (void)
{
    int semid = semget(0xa, 0, 0);
    printf("semid = %d \n", semid);
    printf("sem 0 = %d \n", semctl(semid, 0, GETVAL));
    printf("sem 1 = %d \n", semctl(semid, 1, GETVAL));
    printf("sem 2 = %d \n", semctl(semid, 2, GETVAL));
    exit(0);
}