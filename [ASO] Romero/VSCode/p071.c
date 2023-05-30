// COMPILAR: gcc -pthread -o p71 p71.c
// EJECUTAR: ./p71

/* Este programa utiliza la consola de forma concurrente para que dos hilos
presenten información, la consola no está preparada para ello siendo un recurso
non preemptive, lo que generará comportamientos indeseados.
Daniel Sol Llaven 2015-04-13
*/

#include <stdlib.h>
#include <pthread.h>
#include <stdio.h>
#include <unistd.h>

// Generamos un arreglo, un contador por hilo.
long contador[2];

// Firma correcta para pthread_create
void *salidaContador(void *id_pt)
{
    // Tomamos el valor referido por el parámetro
    int id = *(int *)id_pt;
    // Lo decrementamos para facilitar cálculos posteriores
    id--;

    for (contador[id] = 0l; contador[id] < 100000; contador[id]++)
    {
        // Todo en la misma línea,
        printf("%s Contador % d: % 07ld, % 07ld\r"
               // Indentamos salida de un hilo
               ,
               (id == 1 ? "\t\t\t\t" : "")
               // Contador y valor que lleva
               ,
               id + 1, contador[id]
               // Diferencia con el otro
               ,
               contador[id] - contador[1 - id]);
    }
    // Para satisfacer la firma retorno válido
    return NULL;
}
int main()
{
    // Para la información del hilo
    pthread_t id_hs;
    // Para valores de retorno
    int val_ret;
    // Para pasar el número de contador como parámetro
    int id = 1;

    // Creamos un hilo secundario para contador 1
    val_ret = pthread_create(&id_hs, NULL, &salidaContador, (void *)&id);
    if (val_ret)
    {
        printf("Error en la creación del hilo: % d\n", val_ret);
        exit(1);
    }

    printf("\nCreados los hilos\n");

    // Descomentar para que funcione
    sleep(0);

    // Cambiamos el valor del parámetro a pasar
    id = 2;

    // Invocamos en el hilo principal
    salidaContador((void *)&id);

    // Esperamos terminación
    val_ret = pthread_join(id_hs, NULL);

    if (val_ret)
        printf("Error al término del hilo: %d\n", val_ret);
    printf("\nTerminaron los hilos\n");
    exit(0);
}