using static System.Console;

#region MAIN

Dictionary<string, double> productos = new Dictionary<string, double>();

productos.Add("M101", 56.32);
productos.Add("M234", 23.88);
productos.Add("C654", 974.56);
productos.Add("M401", 43.28);
productos.Add("C345", 785.12);
productos.Add("D567", 432.56);
productos.Add("M103", 874.54);
productos.Add("D901", 23.18);
productos.Add("C732", 43.12);
productos.Add("M056", 21.42);

// 1er constructor
// CAbstraccion bridge = new(new CImplementacion3(), productos);

// 2do constructor
CAbstraccion bridge = new(3, productos);

bridge.MuestraTotales();
bridge.ListaProductos();

#endregion


interface IBridge
{
    void MuestraTotales(Dictionary<string, double> pProductos);
    void ListaProductos(Dictionary<string, double> pProductos);
}

class CAbstraccion
{
    readonly IBridge implementacion;
    Dictionary<string, double> productos;

    public CAbstraccion(IBridge pImp, Dictionary<string, double> pProd)
    {
        implementacion = pImp;
        productos = pProd;
    }

    public CAbstraccion(int pTipo, Dictionary<string, double> pProd)
    {
        implementacion = new CImplementacion1();
        if (pTipo == 1) { implementacion = new CImplementacion1(); }
        if (pTipo == 2) { implementacion = new CImplementacion2(); }
        if (pTipo == 3) { implementacion = new CImplementacion3(); }
        productos = pProd;
    }

    public void MuestraTotales()
    {
        implementacion.MuestraTotales(productos);
    }

    public void ListaProductos()
    {
        implementacion.ListaProductos(productos);
    }
}


class CImplementacion1 : IBridge
{
    public void ListaProductos(Dictionary<string, double> pProductos)
    {
        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            WriteLine(kvp.Key);
        }
    }

    public void MuestraTotales(Dictionary<string, double> pProductos)
    {
        double total = 0;
        int cantidad = 0;

        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            total += kvp.Value;
            cantidad++;
        }

        WriteLine
            (
            $"El total de {cantidad} productos es " +
            String.Format("{0:C0}", total)
            );
    }
}


class CImplementacion2 : IBridge
{
    public void ListaProductos(Dictionary<string, double> pProductos)
    {
        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            if (kvp.Key[0] == 'C') { ForegroundColor = ConsoleColor.Green; }
            if (kvp.Key[0] == 'M') { ForegroundColor = ConsoleColor.Yellow; }
            if (kvp.Key[0] == 'D') { ForegroundColor = ConsoleColor.Red; }

            WriteLine($"{kvp.Key} - {kvp.Value}");
        }
        ResetColor();
    }

    public void MuestraTotales(Dictionary<string, double> pProductos)
    {
        double total = 0;
        double totalm = 0;
        double totalc = 0;
        double totald = 0;
        int cantidad = 0;

        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            total += kvp.Value;

            if (kvp.Key[0] == 'C') { totalc += kvp.Value; }
            if (kvp.Key[0] == 'M') { totalm += kvp.Value; }
            if (kvp.Key[0] == 'C') { totald += kvp.Value; }

            cantidad++;
        }

        WriteLine($"El total de comida es " + String.Format("{0:C0}", totalc));
        WriteLine($"El total de medicamentos es " + String.Format("{0:C0}", totalm));
        WriteLine($"El total de deportes es " + String.Format("{0:C0}", totald));

        WriteLine
            (
            $"El total de {cantidad} productos es " +
            String.Format("{0:C0}", total)
            );
    }
}


class CImplementacion3 : IBridge
{
    public void ListaProductos(Dictionary<string, double> pProductos)
    {
        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            ForegroundColor = ConsoleColor.Green;
            if (kvp.Key[0] == 'C') { WriteLine($"{kvp.Key} - {kvp.Value}"); }
        }
        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            ForegroundColor = ConsoleColor.Yellow;
            if (kvp.Key[0] == 'M') { WriteLine($"{kvp.Key} - {kvp.Value}"); }
        }
        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            ForegroundColor = ConsoleColor.Red;
            if (kvp.Key[0] == 'D') { WriteLine($"{kvp.Key} - {kvp.Value}"); }
        }
        ResetColor();
    }

    public void MuestraTotales(Dictionary<string, double> pProductos)
    {
        double total = 0;
        double totalm = 0;
        double totalc = 0;
        double totald = 0;
        int cantidad = 0;

        foreach (KeyValuePair<string, double> kvp in pProductos)
        {
            total += kvp.Value;

            if (kvp.Key[0] == 'C') { totalc += kvp.Value; }
            if (kvp.Key[0] == 'M') { totalm += kvp.Value; }
            if (kvp.Key[0] == 'D') { totald += kvp.Value; }

            cantidad++;
        }

        WriteLine
            (
            $"El total de comida es         " +
            String.Format("{0:C0}", totalc) + "\t[ " +
            String.Format("{0:P2}", totalc / total) + " ]"
            );
        WriteLine
            (
            $"El total de medicamentos es   " +
            String.Format("{0:C0}", totalm) + "\t[ " +
            String.Format("{0:P2}", totalm / total) + " ]"
            );
        WriteLine
            (
            $"El total de deportes es       " +
            String.Format("{0:C0}", totald) + "\t[ " +
            String.Format("{0:P2}", totald / total) + " ]"
            );
        WriteLine
            (
            $"\nEl total de {cantidad} productos es   " +
            String.Format("{0:C0}", total) + "\n"
            );
    }
}