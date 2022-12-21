﻿using static System.Console;


Singleton uno = Singleton.ObtenInstancia();
uno.PonerDatos("Ana", 27);
uno.AlgunProceso();

Singleton dos = Singleton.ObtenInstancia();
WriteLine(dos);
ReadKey();


/* ---------------------->= [CLASE] <=---------------------- */

public class Singleton
{
    private static Singleton instancia;
    private string nombre;
    private int edad;

    private Singleton()
    {
        nombre = "Sin asignar";
        edad = 99;
    }

    public static Singleton ObtenInstancia()
    {
        if (instancia == null) instancia = new Singleton();
        WriteLine("Instancia creada.");
        return instancia;
    }

    public override string ToString() => string.Format("Persona {0} tiene {1} años", nombre, edad);

    public void PonerDatos(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    public void AlgunProceso() => WriteLine("{0} está trabajando en algo.", nombre);
}