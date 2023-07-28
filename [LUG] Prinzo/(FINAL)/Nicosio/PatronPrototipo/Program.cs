using static System.Console;

AdministraPrototipos administrador = new();
Persona uno = (Persona)administrador.ObtenPrototipo("Persona");
Persona dos = (Persona)administrador.ObtenPrototipo("Persona");

WriteLine(uno);
WriteLine(dos);
WriteLine("=============");

uno.Nombre = "Ana";
dos.Nombre = "Chepe";

WriteLine(uno);
WriteLine(dos);
WriteLine("=============");

Auto auto1 = new("Nissan", 25000);
administrador.AdicionaPrototipo("Auto", auto1);

Auto auto2 = (Auto)administrador.ObtenPrototipo("Auto");
auto2.Modelo = "Honda";

WriteLine(auto1);
WriteLine(auto2);
WriteLine("=============");

Valores valores = (Valores)administrador.ObtenPrototipo("Valores");
WriteLine(valores);





class AdministraPrototipos
{
    private Dictionary<string, IPrototipo> prototipos = new Dictionary<string, IPrototipo>();

    public AdministraPrototipos()
    {
        Persona persona = new("Ciudadano", 18);
        prototipos.Add("Persona", persona);
        Valores valores = new(1);
        prototipos.Add("Valores", valores);
    }

    public void AdicionaPrototipo(string llave, IPrototipo prototipo)
    {
        prototipos.Add(llave, prototipo);
    }

    public object ObtenPrototipo(string llave)
    {
        return prototipos[llave].Clona();
    }
}




interface IPrototipo
{
    object Clona();
}

class Valores : IPrototipo
{
    private double sumatoria;
    private int m = 1;

    public double Sumatoria { get => sumatoria; set => sumatoria = value; }
    public int M { get => m; set => m = value; }

    public Valores()
    {

    }
    public Valores(int m)
    {
        this.m = m;
        for (int n=0; n < 90; n++)
        {
            sumatoria += Math.Sin(n * 0.0175);
        }
    }

    public override string ToString()
    {
        return string.Format($"{sumatoria * m}");
    }

    public object Clona()
    {
        Valores clon = new();
        clon.M = this.m;
        clon.Sumatoria = this.sumatoria;
        return clon;
    }
}




class Persona : IPrototipo
{
    private string nombre;
    private int edad;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Edad { get => edad; set => edad = value; }

    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    public override string ToString()
    {
        return string.Format($"{nombre}, {edad}");
    }

    public object Clona()
    {
        Persona clon = new(nombre, edad);
        return clon;
    }
}




class Auto : IPrototipo
{
    private string modelo;
    private int costo;

    public string Modelo { get => modelo; set => modelo = value; }
    public int Costo { get => costo; set => costo = value; }

    public Auto(string modelo, int costo)
    {
        this.modelo = modelo;
        this.costo = costo;
    }

    public override string ToString()
    {
        return string.Format($"Auto: {modelo}, {costo}");
    }

    public object Clona()
    {
        Auto clon = new(modelo, costo);
        return clon;
    }
}
