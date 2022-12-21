using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.MPP.Traductores;

namespace FullCarMultimarca.MPP.Seguridad
{
    public class MPPPermiso : IMappingAsignable<Permiso>
    {
        private MPPPermiso()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorPermiso();
        }


        private static MPPPermiso _mppPermiso = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPPermiso ObtenerInstancia()
        {
            if (_mppPermiso == null)
                _mppPermiso = new MPPPermiso();
            return _mppPermiso;
        }
        ~MPPPermiso()
        {
            _mppPermiso = null;
            _datos = null;
            _traductor = null;
    }

        #region IMPLEMENTACION ABSTRACCION IABMC

        public IList<Permiso> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                var lista = new List<Permiso>();
                foreach (DataRow dr in ds.Tables["Permiso"].Rows)
                {
                    lista.Add(HidratarObjeto(dr));
                }
                return lista.OrderBy(p => p.Codigo)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public IList<Permiso> Buscar(string propiedad = "", string texto = "", bool incluirNODisponibles = true)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var lista = new List<Permiso>();

                //Filtro
                string expression = "Tipo = 'PermisoCompuesto'";
                if (!String.IsNullOrWhiteSpace(texto))
                {
                    string campo = Util.ObtenerCampoDesdePropiedad(_traductor.DiccionarioEquivalencias, propiedad);
                    expression += Util.AgregarOperadorAND(expression) + $"{campo} = '{texto}'";
                }

                DataRow[] drPermisosCompuestos = ds.Tables["Permiso"].Select(expression);

                foreach (DataRow dr in drPermisosCompuestos)
                {
                    lista.Add(HidratarObjeto(dr, dr.GetChildRows("DR_Permiso_Permiso_1")));
                }

                return lista.OrderBy(p => p.Codigo)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public Permiso Leer(Permiso objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Permiso"].AsEnumerable().FirstOrDefault(dr => dr["Codigo"].ToString().Equals(objeto.Codigo));
                if (row == default(DataRow))
                    return null;
                else
                    return HidratarObjeto(row);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        public void Agregar(Permiso objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermiso = ds.Tables["Permiso"];
                DataRow drPermiso = dtPermiso.NewRow();
                drPermiso["Codigo"] = objeto.Codigo.Trim();
                drPermiso["Tipo"] = objeto.GetType().Name;
                drPermiso["Descripcion"] = objeto.Descripcion;
                dtPermiso.Rows.Add(drPermiso);

                _datos.GuardarDatos(ds);
                                

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Permiso objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermiso = ds.Tables["Permiso"];

                DataRow rPermiso = dtPermiso.AsEnumerable().FirstOrDefault(u => u["Codigo"].ToString() == objeto.Codigo);
                if (rPermiso == null)
                    throw new NegocioException("Permiso no encontrado");
                rPermiso["Descripcion"] = objeto.Descripcion;

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Permiso objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermiso = ds.Tables["Permiso"];

                DataRow rPermiso = dtPermiso.AsEnumerable().FirstOrDefault(u => u["Codigo"].ToString() == objeto.Codigo);
                if (rPermiso != null)
                {
                    rPermiso.Delete();
                }

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Permiso objeto)
        {
            try
            {
                var dtPermisos = _datos.ObtenerDatos().Tables["Permiso"];
                return dtPermisos.AsEnumerable().Any(u => u["Codigo"].ToString().Trim().Equals(objeto.Codigo.Trim()));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Permiso permiso)
        {
            try
            {
                var dtUsuarios = _datos.ObtenerDatos().Tables["Usuario"];
                return dtUsuarios.Select($"CodigoPermiso = '{permiso.Codigo}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        #region IMPLEMENTACION ABSTRACCION IABMC ASIGNABLE

        public void Asignar(Permiso padre, Permiso hijo)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermisoPermiso = ds.Tables["PermisoPermiso"];
                DataRow dr = dtPermisoPermiso.NewRow();
                dr["CodigoPermiso1"] = padre.Codigo;
                dr["CodigoPermiso2"] = hijo.Codigo;
                dr["Otorgado"] = hijo.Otorgado;
                dtPermisoPermiso.Rows.Add(dr);

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Desasignar(Permiso padre, Permiso hijo)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermisoPermiso = ds.Tables["PermisoPermiso"];

                DataRow dr = dtPermisoPermiso.AsEnumerable().FirstOrDefault(pp => pp["CodigoPermiso1"].ToString().Trim().Equals(padre.Codigo.Trim())
                    && pp["CodigoPermiso2"].ToString().Trim().Equals(hijo.Codigo.Trim()));

                if (dr != null)
                    dr.Delete();

                _datos.GuardarDatos(ds);                               
             

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void ActualizarAsignacion(Permiso padre, Permiso hijo)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dtPermisoPermiso = ds.Tables["PermisoPermiso"];

                DataRow dr = dtPermisoPermiso.AsEnumerable().FirstOrDefault(pp => pp["CodigoPermiso1"].ToString().Trim().Equals(padre.Codigo.Trim())
                    && pp["CodigoPermiso2"].ToString().Trim().Equals(hijo.Codigo.Trim()));

                if (dr != null)
                {
                    dr["Otorgado"] = hijo.Otorgado;
                }


                _datos.GuardarDatos(ds);                               
              

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool ExisteAsignacion(Permiso padre, Permiso hijo)
        {
            try
            {
                var dtPermisoPermiso = _datos.ObtenerDatos().Tables["PermisoPermiso"];
                return dtPermisoPermiso.AsEnumerable().Any(u => u["CodigoPermiso1"].ToString().Trim().Equals(padre.Codigo.Trim()) 
                    && u["CodigoPermiso2"].ToString().Trim().Equals(hijo.Codigo.Trim()));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal Permiso HidratarObjeto(DataRow dr)
        {           
            if (dr == null)
                return null;
            else
            {
                Permiso permiso;
                string codigo = dr["Codigo"].ToString();
                if (dr["Tipo"].ToString().Equals(typeof(PermisoSimple).Name))
                {
                    permiso = new PermisoSimple(codigo);                    
                }
                else
                {
                    permiso = new PermisoCompuesto(codigo);                
                }
                permiso.Descripcion = dr["Descripcion"].ToString();

                return permiso;
            }
        }
        internal Permiso HidratarObjeto(DataRow dr, DataRow[] hijos)
        {
            Permiso permiso = HidratarObjeto(dr);
            foreach (DataRow hijo in hijos)
            {
                DataRow drPermiso = hijo.GetParentRow("DR_Permiso_Permiso_2");
                Permiso pHijo = HidratarObjeto(drPermiso);
                pHijo.Otorgado = Convert.ToBoolean(hijo["Otorgado"]);
                if (permiso is PermisoCompuesto)
                {                                        
                    (permiso as PermisoCompuesto).AgregarPermiso(pHijo);
                }
            }
            return permiso;
        }     
    }
}
