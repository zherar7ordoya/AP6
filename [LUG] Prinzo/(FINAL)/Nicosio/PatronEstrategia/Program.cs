using static System.Console;

string? opcion;
double x, y, r;

while (true)
{
    TryAgain:
    WriteLine("1) Suma || 2) Resta || " +
    "3) Multplicación || 4) División || 5) Salir");
    opcion = ReadLine();
    if (opcion == null) { goto TryAgain; }
    if (opcion.Equals("5")) { break; }

    WriteLine("Valor de A:");
    x = Convert.ToDouble(ReadLine());

    WriteLine("Valor de B:");
    y = Convert.ToDouble(ReadLine());

    IOperacion operacion = opcion switch
    {
        "1" => new CSuma(),
        "2" => new CResta(),
        "3" => new CMultiplicacion(),
        "4" => new CDivision(),
        _ => throw new global::System.NotImplementedException()
    };
    r = operacion.Operacion(x, y);
    WriteLine($"Resultado: {r}");
}


#region CLASES E INTERFACES

internal interface IOperacion
{ double Operacion(double a, double b); }

class CSuma : IOperacion
{
    public double Operacion(double a, double b)
    { return a + b; }
}

class CResta : IOperacion
{
    public double Operacion(double a, double b)
    { return a - b; }
}

class CMultiplicacion : IOperacion
{
    public double Operacion(double a, double b)
    { return a * b; }
}

class CDivision : IOperacion
{
    public double Operacion(double a, double b)
    { return a / b; }
}

#endregion