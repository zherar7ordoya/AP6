using static System.Console;


/* CLIENTE */

// Interfaz que el cliente conoce
ITarget calcu = new CCalcu();
int resultado = calcu.Suma(4, 3);
WriteLine($"El resultado es {resultado}");
WriteLine("*****************");

// Hacemos uso del adaptador
calcu = new CAdaptador();
resultado = calcu.Suma(5, 6);
WriteLine($"El resultado es {resultado}");
WriteLine("--------*--------");





// Esta es la inferfaz que conoce el cliente
interface ITarget
{
    int Suma(int a, int b);
}




// Clase original con la que trabaja el cliente
class CCalcu : ITarget
{
    public int Suma(int a, int b)
    {
        return a + b;
    }
}



// Esta es la clase que deseamos adaptar
// (el cliente no la puede usar directamente)
class CCalculadoraArray
{
    public double suma(int[] operandos)
    {
        double r = 0;

        for (int n = 0; n < operandos.Length; n++)
        {
            r += operandos[n];
        }

        return r;
    }
}




// El adaptador usa la interfaz ITarget
// (que es conocida por el cliente)
// Comunica al cliente con la clase adaptada
class CAdaptador : ITarget
{
    CCalculadoraArray adaptado = new();

    public int Suma(int a, int b)
    {
        int[] operadores = { a, b };
        double resultado = adaptado.suma(operadores);
        return (int)resultado;
    }
}