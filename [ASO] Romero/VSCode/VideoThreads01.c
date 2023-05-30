// COMPILAR: gcc -pthread -o VideoThreads01 VideoThreads01.c
// EJECUTAR: ./VideoThreads01

#include <pthread.h>
#include <unistd.h>
#include <stdio.h>

void* MyTurn(void * arg)
{
    for (int i = 0; i < 8; i++)
    {
        sleep(1);
        printf("My Turn! %d \n", i);
    }
    return NULL;
}

void YourTurn()
{
    for (int i = 0; i < 3; i++)
    {
        sleep(2);
        printf("Your Turn! %d \n", i);
    }
}

int main()
{
    pthread_t newthread;
    pthread_create(&newthread, NULL, MyTurn, NULL);

    // MyTurn();
    YourTurn();

    // Wait for the thread to finish
    pthread_join(newthread, NULL);
}