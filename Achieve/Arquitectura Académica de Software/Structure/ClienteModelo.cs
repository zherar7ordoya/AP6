using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class ClienteModelo : IID, ICloneable
    {
        public List<TelefonoModelo> Telefonos = new List<TelefonoModelo>();
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }

        
        // Constructores
        public ClienteModelo() { }

        public ClienteModelo(
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


        // Implementaciones (Interfaces)
        public int RetornaId() { return Id; }

        public object Clone()
        {
            ClienteModelo RetornoCliente = (ClienteModelo)MemberwiseClone();

            if (Telefonos != null) // *---------------------> Clonación Profunda
            {
                foreach (TelefonoModelo T in Telefonos)
                {
                    RetornoCliente.Telefonos.Add((TelefonoModelo)T.Clone());
                }
            }
            return RetornoCliente;
        }
    }
}
