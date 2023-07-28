using static System.Console;




Singleton uno = Singleton.ObtieneInstancia();

uno.PoneDatos("Ana", 27);
uno.AlgunProceso();
WriteLine(uno);
WriteLine("=============================");

Singleton dos = Singleton.ObtieneInstancia();
WriteLine(dos);
WriteLine("=============================");




class Singleton
{
    private static Singleton instancia;
    private string nombre;
    private int edad;

    private Singleton()
    {
        nombre = "Sin asignar";
        edad = 99;
    }

    public static Singleton ObtieneInstancia()
    {
        if (instancia == null)
        {
            instancia = new();
            WriteLine("=============================");
            WriteLine("Creada");
            WriteLine("=============================");
        }
        return instancia;
    }

    public override string ToString()
    {
        return string.Format($"La persona {nombre} tiene edad: {edad}");
    }

    public void PoneDatos(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    public void AlgunProceso()
    {
        WriteLine($"{nombre} está trabajando en algo");
    }
}


