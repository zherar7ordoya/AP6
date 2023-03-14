#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main()  {
         pid_t pid;

         pid = fork();

         if (pid == 0) // *-------------------------------------=> Proceso Hijo.
         {
             printf("PID = 0 (%d) HIJO EJECUTANDO PS\n", pid);
             printf("\n");
             system("ps -eo pid,ppid,comm");
         }
         else if (pid > 0) // *--------------------------------=> Proceso Padre.
         {
             printf("PID > 0 (%d) implica proceso PADRE\n", pid);
         }
         else // *=> Desde el proceso Padre: Error (el Hijo no pudo ser creado).
         {
             printf("\nPID < 0 (%d) implica ERROR\n", pid);
         }
         exit(0);
    }   
