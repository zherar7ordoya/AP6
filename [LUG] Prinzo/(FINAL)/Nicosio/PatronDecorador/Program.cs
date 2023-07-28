using static System.Console;

IComponente miAuto = new CAuto("2018", "4 puertas", 1000);

WriteLine($"Costo: {miAuto.Costo()}");
WriteLine(miAuto.Funciona());
WriteLine(miAuto);

WriteLine("\n----------------------\n");

// Necesitamos typecast para usar un método de CAuto
((CAuto)miAuto).Puertas(true);

WriteLine("\n----------------------\n");

miAuto = new CSistemaSonido(miAuto);

// Comprobamos adicciones.
WriteLine($"Costo: {miAuto.Costo()}");
WriteLine(miAuto.Funciona());
WriteLine(miAuto);

WriteLine("\n----------------------\n");

miAuto = new CNitrogeno(miAuto);

// Comprobamos adicciones.
WriteLine($"Costo: {miAuto.Costo()}");
WriteLine(miAuto.Funciona());
WriteLine(miAuto);

// Necesitamos typecast para usar un método de CNitrogeno
((CNitrogeno)miAuto).UsaN();

WriteLine("\n----------------------\n");

miAuto = new CSuspension(miAuto);

// Comprobamos adicciones.
WriteLine($"Costo: {miAuto.Costo()}");
WriteLine(miAuto.Funciona());
WriteLine(miAuto);


public interface IComponente
{
    double Costo();
    string Funciona();
}


public class CAuto : IComponente
{
    private string modelo;
    private string caracteristicas;
    public double costo;

    public CAuto(
        string pModelo,
        string PCaract, 
        double pCosto)
    {
        this.modelo = pModelo;
        this.caracteristicas = PCaract;
        this.costo=pCosto;
    }

    public void Puertas(bool pEstado)
    {
        if (pEstado) { WriteLine("Puertas cerradas"); }
        else { WriteLine("Puertas abiertas"); }
    }

    public override string ToString()
    { return String.Format($"\nModelo {modelo}, {caracteristicas}"); }

    public double Costo()
    { return costo; }

    public string Funciona()
    { return "\nMotor operativo"; }
}


public class CNitrogeno : IComponente
{
    private IComponente decoramosA;

    public CNitrogeno(IComponente pComponente)
    {
        decoramosA = pComponente;
    }

    public override string ToString()
    {
        return "\nSistema de Nitrógeno" + decoramosA.ToString();
    }

    public double Costo()
    {
        return decoramosA.Costo() + 300;
    }

    public string Funciona()
    {
        return decoramosA.Funciona() + "\nNitrógeno operativo";
    }

    public void UsaN()
    {
        WriteLine("\nNitrógeno en uso");
    }
}


class CSistemaSonido : IComponente
{
    private IComponente decoramosA;

    public CSistemaSonido(IComponente pComponente)
    {
        decoramosA = pComponente;
    }

    public override string ToString()
    {
        return "\nRadio 350XZ+" + decoramosA.ToString();
    }

    public double Costo()
    {
        return decoramosA.Costo() + 300;
    }

    public string Funciona()
    {
        return decoramosA.Funciona() + "\nRadio operativa";
    }
}

class CSuspension : IComponente
{
    private IComponente decoramosA;

    public CSuspension(IComponente pComponente)
    {
        decoramosA = pComponente;
    }

    public override string? ToString()
    {
        return "\nSuspensión de alto desempeño" + decoramosA.ToString();
    }
    public double Costo()
    {
        return decoramosA.Costo() + 400;
    }

    public string Funciona()
    {
        return decoramosA.Funciona() + "\nSuspensión operativa";
    }
}

