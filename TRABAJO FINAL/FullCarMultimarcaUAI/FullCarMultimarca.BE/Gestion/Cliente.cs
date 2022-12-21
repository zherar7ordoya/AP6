using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Gestion
{
    public class Cliente : IAuditable, IComparable
    {

        public Cliente()
        {

        }
        ~Cliente()
        {
            _contactos = null;
        }

        private List<Contacto> _contactos = new List<Contacto>();        
                
        public string CUIT { get; set; }        
        public string Nombre { get; set; }        
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }        
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }


        //Métodos para manipular la lista de contactos;
        //Se dejan en la BE para respetar encapsulamiento
        public List<Contacto> ObtenerContactos()
        {
            return _contactos;
        }     
        public void AgregarContacto(TipoContacto tipo, string valor)
        {
            if (!_contactos.Any(t => t.Tipo.Equals(tipo)
                            && t.Valor.EqualsAICI(valor)))
            {
                _contactos.Add(new Contacto(this) { Tipo = tipo, Valor = valor }) ;
            }
        }
        public void EliminarContacto(Contacto contacto)
        {
            if (_contactos.Any(t => t.Tipo.Equals(contacto.Tipo) 
                             && t.Valor.EqualsAICI(contacto.Valor)))
            {
                _contactos.Remove(contacto);
            }
        }    


        public override string ToString()
        {
            return $"({CUIT}) {Apellido}, {Nombre}";
        }
        public override bool Equals(object obj)
        {
            if (this.CUIT == null)
                return false;
            else if (obj == null || !(obj is Cliente))
                return false;
            return this.CUIT == ((Cliente)obj).CUIT;
        }
        public override int GetHashCode()
        {
            return CUIT != null ? CUIT.GetHashCode() : base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Cliente)obj).ToString());
        }
    }
}
