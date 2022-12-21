using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public abstract class Modelo : IAuditable, IComparable 
    {
        public Modelo(string codigo)
        {
            Codigo = codigo;
        }
        ~Modelo()
        {

        }       
        
        
        public string Codigo { get; set; }       
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public bool Activo { get; set; }        
        public decimal PrecioPublico { get; set; }
        
        public override string ToString()
        {
            return $"{Codigo}-{Descripcion}";
        }
        public override bool Equals(object obj)
        {
            if (string.IsNullOrWhiteSpace(this.Codigo))
                return false;
            else if (obj == null || !(obj is Modelo))
                return false;
            return this.Codigo.Equals(((Modelo)obj).Codigo);
        }
        public override int GetHashCode()
        {
            return Codigo != null ? Codigo.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Modelo)obj).ToString());
        }

                
    }
}
