using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        public List<Telefono> Telefonos { get; set; }
    }
}
