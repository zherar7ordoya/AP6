#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#include <ctype.h>

#define PERM 0644
#define BUFSIZE 512

int main(int argc, char *argv[])
{
    if (link(argv[1], argv[2]) == -1)
    {
        printf("No puede realizar el link \n");
        exit(1);
    }
    printf("Observar el resultado con el comando ls -li \n");
    printf("¿Qué relación existe entre los números de los inodos? \n");
    exit(0);

    return 0;
}
