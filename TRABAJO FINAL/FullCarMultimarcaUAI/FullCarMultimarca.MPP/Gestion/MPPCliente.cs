using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Traductores;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP.Gestion
{
    public class MPPCliente : IMapping<Cliente>
    {
        private MPPCliente()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorCliente();
        }

        private static MPPCliente _mppCliente = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;


        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPCliente ObtenerInstancia()
        {
            if (_mppCliente == null)
                _mppCliente = new MPPCliente();
            return _mppCliente;
        }
        ~MPPCliente()
        {
            _mppCliente = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC

        public IList<Cliente> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Cliente"];
                var lista = new List<Cliente>();
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(HidratarObjeto(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public IList<Cliente> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                //Filtro
                string expression = "";
                if (!String.IsNullOrWhiteSpace(texto))
                {
                    string campo = Util.ObtenerCampoDesdePropiedad(_traductor.DiccionarioEquivalencias, propiedad);
                    expression += $"{campo} LIKE '%{Util.PrepararStringConsulta(texto)}%'";
                }

                DataRow[] dt = ds.Tables["Cliente"].Select(expression);
                var lista = new List<Cliente>();
                foreach (DataRow dr in dt)
                {
                    lista.Add(HidratarObjeto(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public Cliente Leer(Cliente objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Cliente"].AsEnumerable().FirstOrDefault(dr => dr["CUIT"].ToString().Equals(objeto.CUIT));
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

        public void Agregar(Cliente objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Cliente"];
                DataRow dr = dt.NewRow();
                dr["CUIT"] = objeto.CUIT;
                dr["Nombre"] = objeto.Nombre;
                dr["Apellido"] = objeto.Apellido;
                dr["Direccion"] = objeto.Direccion;
                dr["Localidad"] = objeto.Localidad;
                dr["CodigoPostal"] = objeto.CodigoPostal;
                dr["Provincia"] = objeto.Provincia;       

                dt.Rows.Add(dr);

                AgregarContactos(ds, dr, objeto);

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Cliente objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Cliente"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["CUIT"].ToString().Equals(valorAnterior.ToString()));
                if (dr == null)
                    throw new NegocioException("Cliente no encontrado");
                dr["CUIT"] = objeto.CUIT;
                dr["Nombre"] = objeto.Nombre;
                dr["Apellido"] = objeto.Apellido;
                dr["Direccion"] = objeto.Direccion;
                dr["Localidad"] = objeto.Localidad;
                dr["CodigoPostal"] = objeto.CodigoPostal;
                dr["Provincia"] = objeto.Provincia;

                EliminarContactos(dr);
                AgregarContactos(ds, dr, objeto);

                _datos.GuardarDatos(ds);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Cliente objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Cliente"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["CUIT"].ToString().Equals(objeto.CUIT));

                EliminarContactos(dr);

                if (dr != null)
                {
                    dr.Delete();
                }

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Cliente objeto)
        {
            try
            {
                var dtCli = _datos.ObtenerDatos().Tables["Cliente"];
                return dtCli.AsEnumerable().Any(u => u["CUIT"].ToString().Equals(objeto.CUIT));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Cliente cliente)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtOperaciones = ds.Tables["Operacion"];
                var rCliente = ds.Tables["Cliente"].AsEnumerable().FirstOrDefault(c => c["CUIT"].ToString().Equals(cliente.CUIT));
                return dtOperaciones.Select($"Cliente = '{Convert.ToInt32(rCliente["ClienteID"])}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion
      

        private void EliminarContactos(DataRow drCliente)
        {
            DataRow[] drContactos = drCliente.GetChildRows("DR_Cliente_Contacto");
            foreach(var dContacto in drContactos)
            {
                dContacto.Delete();
            }          
        }
        private void AgregarContactos(DataSet ds, DataRow parentRow, Cliente cliente)
        {
            DataTable dt = ds.Tables["Contacto"];
            DataRow dr;
            foreach(var contacto in cliente.ObtenerContactos())
            {
                var drTipoContacto = ds.Tables["TipoContacto"].AsEnumerable()
                    .FirstOrDefault(ts => ts["Descripcion"].ToString().EqualsAICI(contacto.Tipo.Descripcion));

                dr = dt.NewRow();
                dr["Tipo"] = drTipoContacto["TipoContactoID"];
                dr["Valor"] = contacto.Valor;                
                dr.SetParentRow(parentRow);
                dt.Rows.Add(dr);
            }        
        }        

        internal Cliente HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var cliente = new Cliente()
                {                    
                    CUIT = dr["CUIT"].ToString(),
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    Direccion = dr["Direccion"].ToString(),
                    Localidad = dr["Localidad"].ToString(),
                    CodigoPostal = dr["CodigoPostal"].ToString(),
                    Provincia = dr["Provincia"].ToString()                    
                };
                DataRow[] drContactos = dr.GetChildRows("DR_Cliente_Contacto");
                foreach(DataRow rContacto in drContactos)
                {
                    DataRow drTipoContacto = rContacto.GetParentRow("DR_Contacto_TipoContacto");
                    TipoContacto tContacto = MPPTipoContacto.ObtenerInstancia().HidratarObjeto(drTipoContacto);                 
                    cliente.AgregarContacto(tContacto, rContacto["Valor"].ToString());
                }               

                return cliente;
            }
        }

      

    }
}
