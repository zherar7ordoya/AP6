using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Liquidaciones
{
    public class LiquidacionVendedor
    {

        public LiquidacionVendedor(Liquidacion liquidacion, Usuario usrVendedor)
        {
            Liquidacion = liquidacion;
            UsuarioVendedor = usrVendedor;
        }
        ~LiquidacionVendedor()
        { }

        private IList<Operacion> _operaciones = new List<Operacion>();
                
        public Liquidacion Liquidacion { get; set; }        
        public Usuario UsuarioVendedor { get; set; }        
        public decimal PorcentajeComision { get; set; }
        public decimal PremioVolumen { get; set; }
        public decimal NetoAComisionar { get; set; }

        //Campos Calculados        
        public int CantidadOperaciones {
            get 
            { 
                return _operaciones.Count(); 
            }
        }                  
        public decimal Comision { 
            get
            {
                return Decimal.Round(NetoAComisionar * (PorcentajeComision), 2);
            }
        }      
        public decimal TotalACobrar
        {
            get 
            {
                return PremioVolumen + Comision;
            }
        }

        //La colección de operaciones se manipula en esta capa para mantener encapsulamiento
        public IList<Operacion> ObtenerOperaciones()
        {
            return _operaciones;
        }
        public void AgregarOperacion(Operacion operacion)
        {
            if (!_operaciones.Any(t => t.Numero.Equals(operacion.Numero)))
            {
                _operaciones.Add(operacion);
            }
        }

        public override string ToString()
        {
            return $"{UsuarioVendedor}";
        }
        public override bool Equals(object obj)
        {
            if (this.UsuarioVendedor == null)
                return false;
            else if (obj == null || !(obj is LiquidacionVendedor))
                return false;
            return this.UsuarioVendedor.Equals(((LiquidacionVendedor)obj).UsuarioVendedor);
        }
        public override int GetHashCode()
        {
            return UsuarioVendedor != null ? UsuarioVendedor.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.CompareTo((LiquidacionVendedor)obj);
        }
    }
}
