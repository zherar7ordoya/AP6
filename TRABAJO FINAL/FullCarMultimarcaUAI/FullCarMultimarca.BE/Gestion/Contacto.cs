using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public class Contacto
    {
        public Contacto(Cliente cli)
        {
            Cliente = cli;
        }
        ~Contacto()
        {

        }

        
        public Cliente Cliente { get; set; }
        public TipoContacto Tipo { get; set; }
        public string Valor { get; set; }     
     
        public override string ToString()
        {
            return $"{Valor}";
        }
        public override bool Equals(object obj)
        {
            if (String.IsNullOrEmpty(this.Valor) || this.Cliente ==  null || this.Tipo == null)
                return false;
            else if (obj == null || !(obj is Contacto))
                return false;
            return this.Valor.EqualsAICI(((Contacto)obj).Valor) 
                && this.Tipo.Equals(((Contacto)obj).Tipo);
        }
        public override int GetHashCode()
        {
            return Valor != null ? Valor.GetHashCode() : base.GetHashCode();
        }

    }


}
