using static System.Console;

List<int> Americana = new();
List<int> Italiana = new();
List<int> Mexicana = new();

List<int> Carnes = new();
List<int> Sopas = new();
List<int> Ensaladas = new();

List<int> Rapida = new();

CFlyweightFactory factory = new();

int i = factory.Adiciona("Hamburguesa");
Americana.Add(i);
Carnes.Add(i);
Rapida.Add(i);

i = factory.Adiciona("Wisconsin Cheese");
Americana.Add(i);
Ensaladas.Add(i);

i = factory.Adiciona("Antipasto");
Italiana.Add(i);
Ensaladas.Add(i);

i = factory.Adiciona("Tacos al Pastor");
Mexicana.Add(i);
Carnes.Add(i);
Rapida.Add(i);

i = factory.Adiciona("Coditos");
Mexicana.Add(i);
Sopas.Add(i);

i = factory.Adiciona("Nopales");
Mexicana.Add(i);
Ensaladas.Add(i);

i = factory.Adiciona("Pizza");
Italiana.Add(i);
Rapida.Add(i);


foreach (int n in Rapida)
{
    CReceta receta = (CReceta)factory[n];
    receta.CalculaCosto();
    receta.Muestra();
}

WriteLine("*********************");

foreach (int n in Americana)
{
    CReceta receta = (CReceta)factory[n];
    receta.Muestra();
}

WriteLine("*********************");

foreach (int n in Ensaladas)
{
    CReceta receta = (CReceta)factory[n];
    receta.CalculaCosto();
    receta.Muestra();
}

WriteLine("*********************");

for (int m = 0; m < factory.Conteo; m++)
{
    CReceta receta = (CReceta)factory[m];
    receta.Muestra();
}




interface IFlyweight
{
    void ColocaNombre(string pNombre);
    void CalculaCosto();
    void Muestra();
    string ObtieneNombre();
}




class CReceta : IFlyweight
{
    private string nombre;
    private double costo;
    private double venta;

    public void CalculaCosto()
    {
        foreach (char letra in nombre)
        {
            costo += (int)letra;
            venta = costo * 1.30;
        }
    }

    public void ColocaNombre(string pNombre)
    {
        nombre = pNombre;
    }

    public void Muestra()
    {
        WriteLine($"{nombre} cuesta {venta.ToString("C")}");
    }

    public string ObtieneNombre()
    {
        return nombre;
    }
}




class CFlyweightFactory
{
    private List<IFlyweight> flyweights = new();
    private int conteo = 0;

    public int Conteo { get => conteo; set => conteo = value; }

    public int Adiciona(string pNombre)
    {
        bool existe = false;

        foreach(IFlyweight fly in flyweights)
        {
            if (fly.ObtieneNombre() == pNombre) { existe = true; }
        }
        if (existe)
        {
            WriteLine("Receta ya existe");
            return -1;
        }
        else
        {
            CReceta receta = new();
            receta.ColocaNombre(pNombre);
            flyweights.Add(receta);
            conteo = flyweights.Count;
            return conteo - 1;
        }
    }


    public IFlyweight this[int index]
    {
        get { return flyweights[index]; }
    }

}
