using static System.Console;

CProxy.ISujeto miProxy = new CProxy.ProxySencillo();

WriteLine("\n ***************************** \n");

miProxy.Peticion(1);

WriteLine("\n ***************************** \n");

miProxy.Peticion(2);

CProxy.ISujeto miProxySeguro = new CProxy.ProxySeguro();

WriteLine("\n ***************************** \n");

miProxySeguro.Peticion(1);

WriteLine("\n ***************************** \n");

miProxySeguro.Peticion(2);


///////////////////////////////////////////////////////////


public class CProxy
{
    public interface ISujeto
    {
        void Peticion(int pOpcion);
    }

    public class ProxySencillo : ISujeto
    {
        private CCocina? cocina;

        public void Peticion(int pOpcion)
        {
            if (cocina == null)
            {
                WriteLine("Activando Sujeto");
                cocina = new CCocina();
            }
            if (pOpcion == 1) { cocina.RecetaSecreta(); }
            if (pOpcion == 2) { cocina.Cocinar(5); }
        }
    }

    public class ProxySeguro : ISujeto
    {
        private CCocina? cocina;

        public void Peticion(int pOpcion)
        {
            string? password;

            WriteLine("Contraseña:");
            password = ReadLine();

            if (password == "abc123")
            {
                if (cocina == null)
                {
                    WriteLine("Activando Sujeto");
                    cocina = new CCocina();
                }
                if (pOpcion == 1) { cocina.RecetaSecreta(); }
                if (pOpcion == 2) { cocina.Cocinar(5); }
            }
            else { WriteLine("Acceso Denegado"); }
        }
    }

    private class CCocina
    {
        public void RecetaSecreta()
        {
            WriteLine("Pan");
            WriteLine("Aceite de Oliva");
            WriteLine("Especias");
            WriteLine("Jamón");
            WriteLine("Queso");
        }
        public void Cocinar(int n)
        {
            WriteLine("Cocinando {0} Recetas", n);
        }
    }

}

