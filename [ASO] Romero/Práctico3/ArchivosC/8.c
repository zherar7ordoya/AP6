#include <stdio.h>
#include <stdlib.h>

#include <fcntl.h>  // PARA APERTURA
#include <unistd.h> // PARA CIERRE

#include <ctype.h>
#include <dirent.h>

#include <sys/stat.h>
#include <sys/types.h>

#define PERM 0644
#define BUFSIZE 512

int main(int argc, char *argv[])
{
    // *--------------------------*


    DIR *d;
    struct dirent *dir;

    struct stat inodo;

    d = opendir(argv[1]);
    if (d)
    {
        while ((dir = readdir(d)) != NULL)
        {
            printf("Nombre: %s", dir->d_name);
            stat(dir->d_name, &inodo);
            printf("\t Inodo: %ld \n", inodo.st_ino);
        }
        closedir(d);
    }
    // *--------------------------*

    return 0;
}
