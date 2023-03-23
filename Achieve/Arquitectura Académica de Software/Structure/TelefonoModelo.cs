using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class TelefonoModelo : IID, ICloneable
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public bool Activo { get; set; }

        
        // Constructores
        public TelefonoModelo() { }

        public TelefonoModelo(int id, string numero)
        {
            Id = id;
            Numero = numero;
        }


        // Implementaciones
        public int RetornaId() { return Id; }

        public object Clone() { return MemberwiseClone(); }
    }
}
