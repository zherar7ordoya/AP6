#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/sem.h>
#include <sys/ipc.h>

int main (void)
{
    int semid = semget(0xa, 0, 0);
    printf("semid = %d \n", semid);
    semctl(semid, 0, SETVAL, 1);
    semctl(semid, 1, SETVAL, 0);
    semctl(semid, 2, SETVAL, 0);
    exit(0);
}