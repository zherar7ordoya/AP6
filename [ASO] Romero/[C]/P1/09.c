#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/wait.h>

int main(int argc, char **argv)
{
    int var = 5;
    pid_t pid;
    pid = fork();

    if (pid > 0) // PADRE
    {
        pid = fork();
        if (pid > 0) // ABUELO
        {
            printf("\nSOY EL ABUELO %d \n", getpid());
            printf("\n");
        }
        else // HIJO 2
        {
            var += 2; // 7
            printf("VAR-7 %d hijo 2  %d del padre %d \n", var, getpid(), getppid());
            pid = fork();
            if (pid == 0) // 2DO NIETO
            {
                var += 2; // 9
                printf("VAR-9 %d nieto 2 %d del padre %d \n", var, getpid(), getppid());
                printf("\n");
            }
            wait(NULL);
        }
    }
    else // 1ER HIJO
    {
        var++; // 6
        printf("VAR-6 %d hijo 1  %d del padre %d \n", var, getpid(), getppid());
        pid = fork();
        if (pid > 0) 
        {
            // Zona muerta.
        }
        else // 1ER NIETO
        {
            var += 2; // 8
            printf("VAR-8 %d nieto 1 %d del padre %d \n", var, getpid(), getppid());
        }
        wait(NULL);
    }
    wait(NULL);
    system("ps -l");
    exit(0);
}
