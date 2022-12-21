using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Ventas
{
    public class Operacion : IComparable, IAuditable
    {

        public Operacion(Unidad unidad)
        {
            Unidad = unidad;
        }
        public Operacion()
        {

        }
        ~Operacion()
        {
            _formasDePago = null;
        }

        private List<OperacionFormaPago> _formasDePago = new List<OperacionFormaPago>();
        
        public virtual int? Numero { get; set; }
        public Unidad Unidad { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario UsuarioVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoOperacion Estado { get; set; }
        public bool EsOferta { get; set; }
        public decimal Pauta { get; set; }
        public decimal PrecioPublico { get; set; }
        public bool PatentaEmpresa { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal PorcentajeGastoGestoria { get; set; }                
        public bool Anulada { get; set; } = false;
        public string NotaRechazo { get; set; }
        public Usuario AutorizadaPor { get; set; }
        public DateTime? AutorizadaEl { get; set; }
        public bool Liquidada { get; set; }

        //Propiedades calculadas
        public decimal GastoGestoria { 
            get
            {
                if (PatentaEmpresa)
                    return Decimal.Round(PrecioUnidad * PorcentajeGastoGestoria, 2);
                else
                    return 0;
            }
               
        }
        public decimal GastoFinanciacion
        {
            get
            {
                return Decimal.Round(_formasDePago.Where(fp => fp.FormaPago is FormaPagoCredito).Sum(fp => fp.Importe * (fp.ArancelGasto/100)) , 2);
            }
        }
        public decimal GastoUsado
        {
            get
            {
                return Decimal.Round(_formasDePago.Where(fp => fp.FormaPago is FormaPagoUsado).Sum(fp => fp.Importe * (fp.ArancelGasto / 100)), 2);
            }
        }
        public decimal PrecioFinal {
            get
            {
                return Decimal.Round(
                  PrecioUnidad
                + GastoFinanciacion
                + GastoGestoria
                + GastoUsado, 2);
            }
        }
        public decimal Descalce {
            get
            {
                return PrecioPublico - PrecioUnidad;
            }
        }
        public decimal Descuento {
            get
            {
                return Descalce / PrecioPublico;
            }
        }


        //Los métodos para manipular la colección de formas de pago se colocan
        //en esta capa para respetar encapsulamiento
        public List<OperacionFormaPago> ObtenerFormasDePago()
        {
            return _formasDePago;
        }      
        public void AgregarFormaDePago(FormaPago fPago, bool modificable, decimal importe, decimal arancelGasto)
        {
            if (!_formasDePago.Any(t => t.FormaPago.Equals(fPago)))
            {
                var opFPago = new OperacionFormaPago(this, fPago)
                {
                    Modificable = modificable,
                    Importe = importe,
                    ArancelGasto = arancelGasto
                };

                _formasDePago.Add(opFPago);
            }
        }
        public void EliminarFormaDePago(OperacionFormaPago fPago)
        {
            if (_formasDePago.Any(t => t.FormaPago.Equals(fPago.FormaPago)))
            {
                _formasDePago.Remove(fPago);               
            }
        }      
      


        public override string ToString()
        {
            return $"OP- {this.Numero?.ToString().PadLeft(8, '0')}";
        }
        public override bool Equals(object obj)
        {
            if (this.Numero == null)
                return false;
            else if (obj == null || !(obj is Operacion))
                return false;
            return this.Numero == ((Operacion)obj).Numero;
        }
        public override int GetHashCode()
        {
            return Numero != null ? Numero.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Operacion)obj).ToString());
        }

        public enum EstadoOperacion
        {            
            Pendiente,
            Autorizada,
            Rechazada
        }

    }
}
