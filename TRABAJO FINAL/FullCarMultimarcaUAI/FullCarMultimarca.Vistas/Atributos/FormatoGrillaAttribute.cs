using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas.Atributos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormatoGrillaAttribute : Attribute
    {

        public FormatoGrillaAttribute(string formato)
        {
            _formato = formato;
        }

        private string _formato;

        public string Formato
        {
            get { return _formato; }
        }

    }
}
