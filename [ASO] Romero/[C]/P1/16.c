#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(int argc, char *argv[])
{
    freopen("16.txt", "w", stdout);

    int N = atoi(argv[1]);
    pid_t PID[N];
    int i;
    int ID_SALIDA;

    for (i = 0; i < N; i++)
    {
        if ((PID[i] = fork()) == 0) // *-----------------------=> PROCESOS HIJOS
        {
            exit(100 + i);
        }
    }
    for (i = N - 1; i >= 0; i--)
    {
        pid_t ID_HIJO = waitpid(PID[i], &ID_SALIDA, 0);
        if (WIFEXITED(ID_SALIDA))
        {
            printf("\nHijo %d finalizado con código de salida %d del proceso padre %d.\n\n", ID_HIJO, WEXITSTATUS(ID_SALIDA), getpid());
            system("ps -l");
        }
        else
        {
            printf("[ PROCESO %d FINALIZACIÓN ANORMAL ]\n", ID_HIJO);
        }
    }
    exit(0);
}