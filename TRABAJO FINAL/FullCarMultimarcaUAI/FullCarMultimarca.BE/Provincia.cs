using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE
{
    public class Provincia
    {
        public Provincia()
        {

        }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            if (String.IsNullOrEmpty(this.Nombre))
                return false;
            else if (obj == null || !(obj is Provincia))
                return false;
            return this.Nombre.Equals(((Provincia)obj).Nombre);               
        }
        public override int GetHashCode()
        {
            return Nombre != null ? Nombre.GetHashCode() : base.GetHashCode();
        }
    }
}
