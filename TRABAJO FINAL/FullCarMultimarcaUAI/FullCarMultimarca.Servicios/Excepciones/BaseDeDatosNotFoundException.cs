using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class BaseDeDatosNotFoundException : NegocioException
    {
        public BaseDeDatosNotFoundException(string nombre) : base(nombre)
        {
            _nombreBase = nombre;
        }

        private string _nombreBase;        

        public override string Message => $"Base de datos {_nombreBase} NO encontrada.";



    }
}
