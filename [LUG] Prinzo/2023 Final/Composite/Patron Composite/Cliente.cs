using static System.Console;

namespace PatronComposite
{
    class Cliente
    {
        static void Main()
        {
            IComponente<string> arbol = new Compuesto<string>("root");
            IComponente<string> trabajo = arbol;

            string opcion = string.Empty;

            while (opcion != "6")
            {
                WriteLine($"\nEstoy en {trabajo.Nombre}\n");
                WriteLine
                    (
                    "1) Adicionar Compuesto\n" +
                    "2) Adicionar Componente\n" +
                    "3) Borrar\n" +
                    "4) Buscar\n" +
                    "5) Mostrar\n" +
                    "6) Salir\n\n"
                    );

                opcion = ReadLine();
                WriteLine("*-----------------------*");

                string dato;

                if (opcion == "1")
                {
                    WriteLine("Nombre del Compuesto: ");
                    dato = ReadLine();
                    IComponente<string> c = new Compuesto<string>(dato);
                    trabajo.Adicionar(c);
                    trabajo = c;
                }
                if (opcion == "2")
                {
                    WriteLine("Nombre del Componente: ");
                    dato = ReadLine();
                    trabajo.Adicionar(new Componente<string>(dato));
                }
                if (opcion == "3")
                {
                    WriteLine("Elemento a Borrar: ");
                    dato = ReadLine();
                    trabajo = trabajo.Borrar(dato);
                }
                if (opcion == "4")
                {
                    WriteLine("Elemento a Buscar: ");
                    dato = ReadLine();
                    trabajo = arbol.Buscar(dato);
                }
                if (opcion == "5")
                {
                    WriteLine(arbol.Mostrar(0));
                }
            }
        }
    }
}
