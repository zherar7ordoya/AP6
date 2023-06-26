using static System.Console;


string dato;
int dinero;
IVehiculo vehiculo;

Write("Dinero disponible: ");
dato = ReadLine();
dinero = Convert.ToInt32(dato);

vehiculo = Creador.MetodoFabrica(dinero);

vehiculo.Enciende();
vehiculo.Acelera();
vehiculo.Frena();
vehiculo.Gira();





class Creador
{
    public static IVehiculo MetodoFabrica(int dinero)
    {
        IVehiculo vehiculo = null;
        if (dinero > 100000)
        {
            vehiculo = new Avioneta();
        }
        else if (dinero > 10000)
        {
            vehiculo = new Automovil();
        }
        else
        {
            vehiculo = new Bicicleta();
        }
        return vehiculo;
    }
}








interface IVehiculo
{
    void Enciende();
    void Acelera();
    void Frena();
    void Gira();
}




class Bicicleta : IVehiculo
{
    public void Acelera()
    {
        WriteLine("Pedalea más rápido");
    }

    public void Enciende()
    {
        WriteLine("Las bicicletas no necesitan encendido");
    }

    public void Frena()
    {
        WriteLine("Acciona el de la rueda trasera primero");
    }

    public void Gira()
    {
        WriteLine("Usa el manubrio");
    }
}






class Automovil : IVehiculo
{
    public void Acelera()
    {
        WriteLine("Con el pedal correspondiente");
    }

    public void Enciende()
    {
        WriteLine("Usa la llave");
    }

    public void Frena()
    {
        WriteLine("Con el pedal de freno");
    }

    public void Gira()
    {
        WriteLine("Usa el volante");
    }
}




class Avioneta : IVehiculo
{
    public void Acelera()
    {
        WriteLine("Usa la palanca");
    }

    public void Enciende()
    {
        WriteLine("Sigue el procedimiento");
    }

    public void Frena()
    {
        WriteLine("Una avioneta usa pedales para frenar");
    }

    public void Gira()
    {
        WriteLine("Usa el timón");
    }
}





