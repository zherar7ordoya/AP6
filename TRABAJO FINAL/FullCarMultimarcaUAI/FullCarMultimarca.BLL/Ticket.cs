using FullCarMultimarca.BE.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    public static class Ticket
    {
        /// <summary>
        /// Caché del usuario logueado, este se comparte entre las diferentes capas para mostrar, gestionar y auditar
        /// </summary>        
        private static Usuario m_UsuarioLogueado;
        public static EventHandler OnUsarioLogueadoCambiado;
        public static Usuario UsuarioLogueado
        {
            get { return m_UsuarioLogueado; }
            set
            {
                m_UsuarioLogueado = value;
                OnUsarioLogueadoCambiado?.Invoke(m_UsuarioLogueado, null);
            }
        }


        /// <summary>
        /// Caché de los permisos de usuario
        /// </summary>
        private static IList<Permiso> m_PermisosHabilitados = new List<Permiso>();
        public static IList<Permiso> ObtenerPermisos()
        {
            return m_PermisosHabilitados;
        }
        public static bool TienePermiso(string codigo)
        {
            return m_PermisosHabilitados.Any(p => p.Codigo.Equals(codigo));
        }
        public static void AgregarPermiso(Permiso permiso)
        {
            if(!m_PermisosHabilitados.Contains(permiso))
                m_PermisosHabilitados.Add(permiso);
        }
        public static void LimpiarCachePermisos()
        {            
            m_PermisosHabilitados.Clear();
        }
    }
}
