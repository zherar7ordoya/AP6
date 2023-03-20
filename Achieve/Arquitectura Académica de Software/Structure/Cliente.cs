using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Cliente : IID, ICloneable
    {
        // Atributos y Propiedades
        private List<Telefono> vTelefonos = new List<Telefono>();
        public List<Telefono> Telefonos { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        
                
        public object Clone()
        {
            Cliente RetornoCliente = (Cliente)MemberwiseClone();

            // Clonación Profunda
            if (Telefonos != null)
            {
                foreach (Telefono T in Telefonos)
                {
                    RetornoCliente.Telefonos.Add((Telefono)T.Clone());
                }
            }
            return RetornoCliente;
        }

        // Constructores
        public Cliente()
        {
        }

        public Cliente(
            int QueId,
            string QueNombre,
            DateTime QueFechaAlta,
            bool QueActivo)
        {
            Id = QueId;
            Nombre = QueNombre;
            FechaAlta = QueFechaAlta;
            Activo = QueActivo;
        }

        public int RetornaId()
        {
            return Id;
        }
    }
}
