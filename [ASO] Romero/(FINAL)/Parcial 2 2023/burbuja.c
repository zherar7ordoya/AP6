#include <stdio.h>

void ordenarBurbuja(int vector[], int longitud);

int main()
{
    int vector[5];
    int i;

    printf("Ingrese 5 numeros enteros:\n");

    for (i=0; i< 5;i++){
       scanf("%d", &vector[i]);
    }

    // Ordenamiento del vector utilizando el método de burbuja
    ordenarBurbuja(vector, 5);

    printf("\nValores ordenados:\n");
    for (i=0; i<5;i++){
        printf("%d\n", vector[i]);
    }
    return 0;
}

void ordenarBurbuja(int vector[], int longitud)
{
    int i, j, temp=0;

    for (i = 0; i < longitud -1 ; i++) {
        for (j = 0; j < longitud -1  ; j++) {
            if (vector[j] > vector[j + 1]) {
                temp = vector[j];
                vector[j] = vector[j + 1];
                vector[j + 1] = temp;
            }
        }
    }
}
