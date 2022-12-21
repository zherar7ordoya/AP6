using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorOperacion : ITraductorEntidad
    {

        public TraductorOperacion()
        {
            DiccionarioEquivalencias.Add(nameof(Operacion.Numero).ObtenerFullNameMasPropiedad<Operacion>(), "Numero");
            DiccionarioEquivalencias.Add(nameof(Unidad.Chasis).ObtenerFullNameMasPropiedad<Unidad>(), "PARENT(DR_Operacion_Unidad).Chasis");
            DiccionarioEquivalencias.Add(nameof(Usuario.Logon).ObtenerFullNameMasPropiedad<Usuario>(), "PARENT(DR_Operacion_Vendedor).Logon");
            DiccionarioEquivalencias.Add(nameof(Cliente.CUIT).ObtenerFullNameMasPropiedad<Cliente>(), "PARENT(DR_Operacion_Cliente).CUIT");
            DiccionarioEquivalencias.Add(nameof(Cliente.Apellido).ObtenerFullNameMasPropiedad<Cliente>(), "PARENT(DR_Operacion_Cliente).Apellido");
            DiccionarioEquivalencias.Add(nameof(Cliente.Nombre).ObtenerFullNameMasPropiedad<Cliente>(), "PARENT(DR_Operacion_Cliente).Nombre");            
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
