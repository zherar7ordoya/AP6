#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/sem.h>
#include <sys/ipc.h>

int main (void)
{
    int semid = semget(0xa, 3, IPC_CREAT | IPC_EXCL | 0660);
    printf("semid = %d \n", semid);
    exit(0);
}