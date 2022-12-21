using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaLiquidacion
    {
        //Header
        public VistaLiquidacion()
        {           
        }

        private IList<VistaLiquidacionVendedor> _vendedores = new List<VistaLiquidacionVendedor>();


        public string Codigo { get; set ; }
        public string Fecha { get; set; }
        public string Comentarios { get; set; }
        public IList<VistaLiquidacionVendedor> ObtenerVendedores()
        {
            return _vendedores;
        }
        public void AgregarVendedor(VistaLiquidacionVendedor liqVend)
        {
            _vendedores.Add(liqVend);
        }

        public string TotalEnComisiones { get; set; }
        public string TotalEnPremioVolumen { get;  set; }
        public string TotalGeneral { get; set; }

    }
    public class VistaLiquidacionVendedor
    {
        public VistaLiquidacionVendedor()
        {
           
        }

        private IList<VistaLiquidacionOperacion> _operaciones = new List<VistaLiquidacionOperacion>();

        [TituloGrilla("Vendedor")]
        public string UsuarioVendedor { get; set; }
        //Campos Calculados
        [TituloGrilla("Q.\nOps"), FormatoGrilla("d0")]
        public int CantidadOperaciones { get; set; }        
        [TituloGrilla("Neto.\na Comisionar"), FormatoGrilla("c2")]
        public decimal NetoAComisionar { get; set; }
        [TituloGrilla("Porc.\nComisión"), FormatoGrilla("p2")]
        public decimal PorcentajeComision { get; set; }
        [TituloGrilla("Comisión"), FormatoGrilla("c2")]
        public decimal Comision { get; set; }              
        [TituloGrilla("Premio\nVolumen"), FormatoGrilla("c2")]
        public decimal PremioVolumen { get; set; }
        [TituloGrilla("Total\nA Cobrar"), FormatoGrilla("c2")]
        public decimal TotalACobrar { get; set; }
        
        public IList<VistaLiquidacionOperacion> ObtenerOperaciones()
        {
            return _operaciones;
        }
        public void AgegarOperacion(VistaLiquidacionOperacion liqOp)
        {
            _operaciones.Add(liqOp);
        }

    }
    public class VistaLiquidacionOperacion
    {
        public VistaLiquidacionOperacion()
        {
         
        }
       
        [TituloGrilla("Número")]
        public string Numero { get; set; }        
        [TituloGrilla("Descripción\nModelo")]
        public string DescModelo { get; set; }      
        [TituloGrilla("Precio\nUnidad"), FormatoGrilla("c2")]
        public decimal PrecioUnidad { get; set; }
        
    }
        

}
