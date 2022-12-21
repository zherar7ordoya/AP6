using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public class Marca : IComparable, IAuditable
    {

        public Marca()
        {            
        }
        ~Marca()
        {

        }       
                      
        
        public string Descripcion { get; set; }
        public bool Activa { get; set; }

        public override string ToString()
        {
            return $"{Descripcion}";
        }
        public override bool Equals(object obj)
        {
            if (this.Descripcion == null)
                return false;
            else if (obj == null || !(obj is Marca))
                return false;
            return this.Descripcion.EqualsAICI(((Marca)obj).Descripcion);
        }
        public override int GetHashCode()
        {
            return Descripcion != null ? Descripcion.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Marca)obj).ToString());
        }
    }
}
