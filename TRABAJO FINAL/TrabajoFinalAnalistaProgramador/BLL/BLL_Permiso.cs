using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using MPP;
using PermisoComposite;

namespace BLL
{
    public class BLL_Permiso : Iabmc<PermisoComposite.Permiso>
    {
        MPP_Permiso oMPPPermiso;

        public BLL_Permiso()
        {
            oMPPPermiso = new MPP_Permiso();
        }

        //Metodo Alta.
        public void Alta(Permiso oPermiso)
        {
            try
            {
                oMPPPermiso.Alta(oPermiso);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            
        }

        //Metodo Baja.
        public void Baja(Permiso oPermiso)
        {
            try
            {
                oMPPPermiso.Baja(oPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<Permiso> Consultar(string pNombre)
        {
            try
            {
                return oMPPPermiso.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }         
        }

        //Metodo Listar.
        public List<Permiso> Listar()
        {
            try
            {
                return oMPPPermiso.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); } 
        }

        //Metodo Modificar.
        public void Modificar(Permiso oPermiso)
        {
            try
            {
                oMPPPermiso.Modificar(oPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no se creen permisos iguales.
        public bool ValidarPermisosCreacion(Permiso oPermiso)
        {
            try
            {
                return oMPPPermiso.ValidarPermisosCreacion(oPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para evitar que se repitan Id.
        public bool ValidarId(Permiso oPermiso)
        {
            try
            {
                return oMPPPermiso.ValidarId(oPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Asignar permiso.
        public void AsignarPermiso(Permiso oPermiso)
        {
            try
            {
                oMPPPermiso.AsignarPermisos(oPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo cargar permisos.
        public List<Permiso> CargarPermisos(string id)
        {
            try
            {
                return oMPPPermiso.CargarPermisos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar permisos compuestos.
        public List<Permiso> ListarPermisosCompuestos(string id)
        {
            try
            {
                return oMPPPermiso.ListarPermisosCompuestos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Quitar permiso.
        public void QuitarPermiso(Permiso oPermiso, string idPermiso)
        {
            try
            {
                oMPPPermiso.QuitarPermiso(oPermiso, idPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Quitar permiso compuesto.
        public void QuitarPermisoCompuesto(Permiso oPermiso, string idPermiso)
        {
            try
            {
                oMPPPermiso.QuitarPermisoCompuesto(oPermiso, idPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Validar permisos, para evitar que se asignen permisos repetidos.
        public bool ValidarPermisos(Permiso oPermiso, string idPermiso)
        {
            try
            {
                return oMPPPermiso.ValidarPermisos(oPermiso, idPermiso);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
