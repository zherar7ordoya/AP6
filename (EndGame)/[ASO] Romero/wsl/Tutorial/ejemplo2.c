#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>

void *separado(void *dato)
{
    char *texto = (char *) dato;
    struct timespec tiempo = { 1, 0 };
    while(1) 
    {
        printf("%s\n", texto); 
        // pthread_delay_np(&tiempo);
        // usleep(microseconds);
        usleep(1000000);
    }
}

int main(void)
{
    //while(1) { printf("Hola\n"); }
    //while(1) { printf("Chau\n"); }
    pthread_t proceso1;
    pthread_t proceso2;
    pthread_create(&proceso1, NULL, &separado, "Hola");
    pthread_create(&proceso2, NULL, &separado, "Chau");
    pthread_join(proceso1, NULL);
    pthread_join(proceso2, NULL);
    return 0;
}