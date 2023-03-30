#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main()  {
         pid_t pid;

         system("ps");
         pid = fork();

         if (pid == 0) // *-------------------------------------=> Proceso Hijo.
         {
             printf("PID = 0 (%d) implica un proceso tipo HIJO\n", pid);
         }
         else if (pid > 0) // *--------------------------------=> Proceso Padre.
         {
             printf("PID > 0 (%d) implica un proceso tipo PADRE\n", pid);
         }
         else // *=> Desde el proceso Padre: Error (el Hijo no pudo ser creado).
         {
             printf("\nPID < 0 (%d) implica ERROR (padre aviso que hijo no pudo ser creado\n", pid);
         }
         exit(0);
    }   
