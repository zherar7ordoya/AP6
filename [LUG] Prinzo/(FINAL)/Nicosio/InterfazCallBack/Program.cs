using System;
using static System.Console;

namespace InterfazCallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            CRefrigerador refrigerador = new CRefrigerador(500, -20);
            Random aleatorio = new Random();

            CRefrigeradorSink sink1 = new CRefrigeradorSink();
            CTiendaSink sink2 = new CTiendaSink();

            /* Ya tenemos el refrigerador y ya tenemos el sink. Lo único que
             * nos falta es llevar a cabo esa unión entre ambos de tal forma
             * que se puedan comunicar entre ellos. Esto se hará mediante el
             * método AgregarSink().
             * Al pasar el objeto "sink1", este ya queda en la lista de los
             * sinks que tiene la clase CRefrigerador y cuando suceda el even-
             * to, su método (el de la lista) va a ser invocado.
             */
            refrigerador.AgregarSink(sink1);
            refrigerador.AgregarSink(sink2);

            while (refrigerador.Kilos > 0 && sink1.Paro==false)
            {
                refrigerador.Trabajar(aleatorio.Next(1, 5));
            }
            ReadKey();
        }
    }
}
