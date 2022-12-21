using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Seguridad;

namespace FullCarMultimarca.BE.Liquidaciones
{
    public class Liquidacion : IComparable
    {

        public Liquidacion(string codigo)
        {
            Codigo = codigo;
        }
        ~Liquidacion()
        {
            _liquidacionVendedores = null;
        }

        private IList<LiquidacionVendedor> _liquidacionVendedores = new List<LiquidacionVendedor>();
               
        
        public string Codigo { get; set; }        
        public DateTime FechaLiquidacion { get; set; }        
        public string Comentarios { get; set; }

        //La colección de liquidación vendedor se manipula en esta capa para mantener encapsulamiento
        public IList<LiquidacionVendedor> ObtenerLiquidacionVendedores()
        {
            return _liquidacionVendedores;
        }      
        public void AgregarLiquidacionVendedor(Usuario usrVendedor)
        {
            if (!_liquidacionVendedores.Any(t => t.UsuarioVendedor.Equals(usrVendedor)))
            {
                var liqVendedor = new LiquidacionVendedor(this, usrVendedor);
                _liquidacionVendedores.Add(liqVendedor);
            }
        }

        public override string ToString()
        {
            return $"{Codigo} - {FechaLiquidacion:dd/MM/yyyy)}";
        }
        public override bool Equals(object obj)
        {
            if (this.Codigo == null)
                return false;
            else if (obj == null || !(obj is Liquidacion))
                return false;
            return this.Codigo.Equals(((Liquidacion)obj).Codigo);
        }
        public override int GetHashCode()
        {
            return Codigo != null ? Codigo.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Liquidacion)obj).ToString());
        }
    }
}
