#include <unistd.h>
#include <sys/sem.h>
#include <sys/ipc.h>

int P (int semid, int sem)
{
    struct sembuf buf;
    buf.sem_num = sem;
    buf.sem_op = -1;
    buf.sem_flg = 0;
    semop(semid, &buf, 1);
}

int V (int semid, int sem)
{
    struct sembuf buf;
    buf.sem_num = sem;
    buf.sem_op = 1;
    buf.sem_flg = 0;
    semop(semid, &buf, 1);
}