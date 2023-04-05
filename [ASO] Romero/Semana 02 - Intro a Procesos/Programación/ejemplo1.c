#include <unistd.h>
#include <stdio.h>

int var = 22;

int main(void)
{
    pid_t pidC;
    printf( "** proc. PID = %d comienza ** \n", getpid() );
    pidC = fork();
    printf( "** proc. PID = %d ejecutándose ** \n", getpid() );

    if(pidC > 0)
    {
        var = 44;
    }
    else if(pidC==0)
    {
        var = 33;
    }
    else /* ERROR */
    {

    }

    while(1)
    {
        sleep(2);
        printf( "** proc. PID = %d, var = %d ** \n", getpid(), var );
    }

    return 0;
}