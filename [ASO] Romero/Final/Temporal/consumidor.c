#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#define BUFFER_SIZE 5


int main() {
   int shmidbuffer= shmget (0xa,0,0);
   int shmidcontador= shmget (0xb,0,0);
   int sale =0;
   
   printf("consumidor\n");
   printf("shmidbuffer %d\n", shmidbuffer);
   printf("shmidcontador%d\n", shmidcontador);
   printf("......................\n");
   
   char * dirbuffer = (char *) shmat (shmidbuffer, 0, 0);
   int *dircontador = (int *) shmat (shmidcontador, 0, 0);
    
    while (1) {
        while (*dircontador == 0);
        *dircontador = *dircontador - 1 ;
        printf("Consumidor:%c %d \n", dirbuffer[sale],*dircontador);
        sale = (sale + 1) % BUFFER_SIZE;
       
        }
    shmdt(dirbuffer);
    shmdt(dircontador);
    exit(0); 
    }