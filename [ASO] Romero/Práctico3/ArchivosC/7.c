#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#include <ctype.h>

#define PERM 0644
#define BUFSIZE 512

int main(int argc, char *argv[])
{
    if (unlink(argv[1]) == -1)
    {
        printf("No se puede realizar Unlink. \n");
        exit(1);
    }
    printf("Observar el resultado con el comando ls -li. \n");
    exit(0);

    return 0;
}
