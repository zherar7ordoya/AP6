#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#define PERM 0644
#define BUFSIZE 128

int main(int argc, char *argv[])
{
    char buffer[BUFSIZE];
    int fd;
    if ((fd = open(argv[1], O_RDONLY)) < 0)
    {
        printf("No puede abrir archivo %s ", argv[1]);
        exit(1);
    }
    while ((read(fd, buffer, BUFSIZE)) > 0)
        printf("%s ", buffer);
    close(fd);
    exit(0);

    return 0;
}
