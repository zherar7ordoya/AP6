// Modifique el siguiente programa para identificar el hijo y el padre. Lograr que el padre muestre su identificador y el identificador de su padre, y que el hijo muestre su identificador y el identificador de su padre.

#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>

int main()  {
         pid_t pid;

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
