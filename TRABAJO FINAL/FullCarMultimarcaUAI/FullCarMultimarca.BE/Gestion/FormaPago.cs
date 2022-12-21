using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public abstract class FormaPago : IAuditable
    {
        public FormaPago()
        {
            
        }
        ~FormaPago()
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
            else if (obj == null || !(obj is FormaPago))
                return false;
            return this.Descripcion.EqualsAICI(((FormaPago)obj).Descripcion);
        }
        public override int GetHashCode()
        {
            return Descripcion != null ? Descripcion.GetHashCode() : base.GetHashCode();
        }
     
    }
}
