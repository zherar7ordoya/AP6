#include <stdio.h>
#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <string.h>

int main (void) 
{
    pid_t pid;
    char comando[64];
    printf("msh$ ");
    memset(comando, '\0', 64);
    scanf("%s", comando);
    while (strcmp(comando, "salir"))
    {
        pid = fork();
        if (pid == 0)
        {
            execlp(comando, comando, NULL);
            printf("Comando no válido \n");
            exit(0);
        }
        else
        {
            if (pid > 0)
            {
                waitpid(pid, 0, 0);
                printf("msh$ ");
                memset(comando, '\0', 64);
                scanf("%s", comando);
            }
            else
            {
                perror("\nERROR DE CLONADO\n");
            }
        }
    }
    exit(0);
}