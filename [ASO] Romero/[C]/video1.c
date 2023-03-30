#include <stdlib.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <stdio.h>
#include <unistd.h>

int main() 
{
    pid_t pid;
    /* fork: un proceso hijo */
    pid = fork();

    
    if (pid<0) 
    { /* Error */
        fprintf(stderr, "Falló el fork");
        exit(-1);
    }
    else if(pid==0)
    { /* Proceso hijo */
        execlp("/bin/ls", "ls", NULL);
    }
    else 
    {   /* Proceso padre */
        wait (NULL);
        printf("Concluyó hijo");
        exit(0);
    }
}