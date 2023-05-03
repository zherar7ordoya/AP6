/*El siguiente programa inicia un hilo secundario que incrementa 
  continuamente el valor de un contador, entre tanto, el hilo 
  principal se bloquea esperando una entrada por parte del usuario en 
  la consola y una vez que la recibe imprime el valor que alcanzó el 
  contador y termina el proceso.
  Para compilar y ligar, no olvide usar el parámetro -pthread de gcc
  Daniel Sol Llaven 2015-03-31
*/

#include <stdlib.h>
#include <pthread.h>
#include <stdio.h>

long contador;

void incrementaContador()
{
     while(1) contador++; // Loop infinito para incrementar el contador
}

int main()
{
      // Estructuras de datos usados por el hilo secundario
      pthread_t id_del_hilo; // Identificador del hilo
      int valor_retorno; // Valor de retorno de la creación
      void *argumentos = NULL; // Argumentos, no los hay para incrementaContador
      contador = 0;

      //Creación del hilo con atributos por defecto
      valor_retorno = pthread_create(&id_del_hilo, NULL, &incrementaContador, argumentos);

      if(valor_retorno)
      {
            // Recibe código de error en la creación del hilo
            printf("Error en la creación del hilo: %d\n", valor_retorno);
            exit(1); //Terminamos con código de error.
      }

      printf("\nHilo secundario creado...\n");

      // El hilo principal prosigue, espera un carácter en la entrada
      // estándar y al recibirlo procede a terminar el proceso
      getchar();
      printf("El contador llegó al valor: %ld\n", contador);
      exit(0); // Terminar el proceso termina todos los hilos secundarios
}