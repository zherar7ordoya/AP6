using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public class Unidad : IAuditable, IComparable, ICloneable
    {
        public Unidad(Modelo modelo, ColorUnidad color)
        {
            Modelo = modelo;
            Color = color;
        }
        public Unidad()
        {

        }
        ~Unidad()
        {

        }
                

        public string Chasis { get; set; }
        public Modelo Modelo { get; set; }
        public ColorUnidad Color { get; set; }
        public bool Disponible { get; set; } = true;        
        public DateTime FechaCompra { get; set; }        
        public decimal ImporteCompra { get; set; }        
        public decimal? Oferta { get; set; }        
        public DateTime? VencimientoOferta { get; set; }
        public bool OfertaVigente {
            get {
                return Oferta.HasValue && Oferta > 0
               && VencimientoOferta.HasValue
               && VencimientoOferta >= DateTime.Today.Date;
            }
        }
        public int Antiguedad
        {
            get
            {
                return DateTime.Today.Subtract(FechaCompra).Days;
            }
        }


        public override string ToString()
        {
            return $"{Chasis}";
        }
        public override bool Equals(object obj)
        {
            if (this.Chasis == null)
                return false;
            else if (obj == null || !(obj is Unidad))
                return false;
            return this.Chasis == ((Unidad)obj).Chasis;
        }
        public override int GetHashCode()
        {
            return Chasis != null ? Chasis.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Unidad)obj).ToString());
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
