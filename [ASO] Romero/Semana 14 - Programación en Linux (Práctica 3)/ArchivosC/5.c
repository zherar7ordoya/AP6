#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#include <ctype.h>

#define PERM 0644
#define BUFSIZE 512

int main(int argc, char *argv[])
{
    int fd, posicion;
    char buf[BUFSIZE];
    if ((fd = open(argv[1], O_RDONLY)) == -1)
    {
        printf("No puede abrir archivo %s \n", argv[1]);
        exit(1);
    }
    printf("Lectura desde el byte %s en el archivo %s \n", argv[2], argv[1]);
    posicion = atoi(argv[2]);
    lseek(fd, posicion, 1);
    read(fd, buf, BUFSIZE);
    printf("%s", buf);
    close(fd);
    exit(0);

    return 0;
}
