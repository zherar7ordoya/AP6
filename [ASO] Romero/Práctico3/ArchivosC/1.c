#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE
int main(int argc, char *argv[])
{
    int fd;

    if ((fd = open(argv[1], O_RDONLY)) == -1)
    {
        printf("No puede abrir archivo %s", argv[1]);
        exit(1);
    }

    printf("Archivo %s fue abierto exitosamente.\n", argv[1]);
    printf("Su descriptor de archivo fue %d.\n", fd);
    close(fd);
    exit(0);

    return 0;
}