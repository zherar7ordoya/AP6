/**
 * LLAMADA AL SISTEMA FORK()
 * Programa en C que soluciona factoriales.
 * Uso: <nombre> <parámetro>
 * Ej.: factorial 5
 */

#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <string.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    printf("\nINICIA PROGRAMA\n\n");
    pid_t pid;

    // Verificaciones.----------------------------------------------------------
    if (argc != 2)     // Cantidad de argumentos: nombre de programa + parámetro
    {
        printf("Parámetro faltante o excedente\n");
        exit(0);
    }

    if (atoi(argv[1]) < 0)             // ATOI convierte un String en un Integer
    {
        printf("No ingrese números negativos (%d)\n\n", atoi(argv[1]));
        exit(0);
    }

    pid = fork();

    if (pid < 0)
    {
        printf("Error al crear a CHILD\n");
        exit(0);
    }

    // Proceso CHILD.-----------------------------------------------------------
    else if (pid == 0)
    {
        int parametro, auxiliar = 2;
        parametro = atoi(argv[1]);
        int multiplicatoria[parametro], sumatoria[parametro];
        multiplicatoria[0] = 1;

        // Generación de series factoriales
        for (int i = 1; i < parametro; i++)
        {
            multiplicatoria[i] = multiplicatoria[i - 1] * auxiliar;
            auxiliar++;
        }

        // Imprimir series y calcular sumatorias
        for (int j = 0; j < parametro; j++)
        {
            sumatoria[j] = 0;
            for (int i = 0; i <= j; i++)
            {
                printf(" %d ", multiplicatoria[i]);
                sumatoria[j] += multiplicatoria[i];
            }
            printf("\n");                         // Necesario, separa las filas
        }

        printf("\n Sumatoria de cada serie:\n");
        for (int i = 0; i < parametro; i++)
        {
            if (sumatoria[i] > 0) 
            {
                printf(" %d ", sumatoria[i]);
            }
        }
        exit(0);
    }

    // Proceso PARENT.----------------------------------------------------------
    else
    {
        wait(NULL);                                 // Esperar que CHILD termine
        printf("\n\nPROGRAMA TERMINADO\n\n");
    }
}
