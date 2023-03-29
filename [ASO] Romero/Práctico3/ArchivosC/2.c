#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#define PERM 0644

int main(int argc, char *argv[])
{
    int fd;
    if ((fd = creat(argv[1], PERM)) == -1)
    {
        printf("No puede crear archivo %s", argv[1]);
        exit(1);
    }
    printf("Archivo %s creado exitosamente.\n", argv[1]);
    printf("Verifique la existencia del archivo con ls -l.\n");
    printf("En el momento de observar los permisos del archivo, ");
    printf("tenga en cuenta el umask.\n");
    close(fd);
    exit(0);

    return 0;
}
