using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaUsuario
    {

        public VistaUsuario()
        {

        }
                           
        public string Logon { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Bloqueado { get; set; } = false;
        [TituloGrilla("Usuario\nHabilitado")]
        public bool Activo { get; set; } = true;        
        [TituloGrilla("Ultimo cambio\nContraseña"), FormatoGrilla("dd/MM/yyyy HH:mm")]
        public DateTime? FechaUltimoCambioPassword { get; set; } = null;        
        [TituloGrilla("E-mail\nCorporativo")]
        public string Email { get; set; }
        [TituloGrilla("Permiso de usuario")]
        public string Permiso { get; set; }
    }
}
