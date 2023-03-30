#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#define PERM 0644
#define BUFSIZE 512

int main(int argc, char *argv[])
{
    int fd, n;
    char buf[BUFSIZE];
    if ((fd = creat(argv[1], PERM)) == -1)
    {
        printf("No puede crear archivo %s", argv[1]);
        exit(1);
    }
    printf("Escriba lo que quiera guardar en el archivo %s \n", argv[1]);
    printf("Para terminar oprime CTRL-D \n");
    while ((n = read(0, buf, BUFSIZE)) > 0)
        write(fd, buf, n);
    printf("Archivo %s creado exitosamente \n", argv[1]);
    printf("Verifique el contenido del archivo \n");
    close(fd);
    exit(0);

    return 0;
}
