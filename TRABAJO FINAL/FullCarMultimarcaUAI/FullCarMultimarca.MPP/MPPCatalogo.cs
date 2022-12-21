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
using FullCarMultimarca.BE;
using FullCarMultimarca.Servicios;

namespace FullCarMultimarca.MPP
{
    public class MPPCatalogo
    {
        private MPPCatalogo()
        {
            _datos = CatalogoManejadorDatos.ObtenerInstancia();
        }

        private static MPPCatalogo _mppCatalogo = null;

        private IManejadorBackup _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPCatalogo ObtenerInstancia()
        {
            if (_mppCatalogo == null)
                _mppCatalogo = new MPPCatalogo();
            return _mppCatalogo;
        }
        ~MPPCatalogo()
        {
            _mppCatalogo = null;
            _datos = null;
        }

        public IList<Catalogo> ObtenerCatalogosBackup()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                var lista = new List<Catalogo>();
                foreach (DataRow dr in ds.Tables["Catalogo"].Rows)
                {
                    lista.Add(HidratarObjeto(dr));
                }
                return lista.OrderByDescending(p => p.FechaYHora)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public Catalogo Leer(Catalogo objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Catalogo"].AsEnumerable().FirstOrDefault(dr => Convert.ToDateTime(dr["FechaYHora"]).Equals(objeto.FechaYHora));
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
        public void CrearBackup(Catalogo objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Catalogo"];
                DataRow dr = dt.NewRow();
                dr["FechaYHora"] = objeto.FechaYHora;
                dr["Creador"] = objeto.Creador;
                dr["NombreArchivo"] = objeto.NombreArchivo;
                dr["Descripcion"] = objeto.Descripcion;
                dt.Rows.Add(dr);


                _datos.CrearBackup(objeto.NombreArchivo);
                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }       
        public void EliminarBackup(Catalogo objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Catalogo"];

                DataRow rCatalogo = dt.AsEnumerable().FirstOrDefault(u => Convert.ToDateTime(u["FechaYHora"]) == objeto.FechaYHora);
                if (rCatalogo != null)
                {
                    rCatalogo.Delete();
                }


                _datos.EliminarBackup(objeto.NombreArchivo);
                _datos.GuardarDatos(ds);
                               
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }       
        public void RestaurarBackup(Catalogo catalogo)
        {
            try
            {

                _datos.RestaurarBackup(catalogo.NombreArchivo);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        internal Catalogo HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                Catalogo catalogo = new Catalogo
                {                    
                    FechaYHora = Convert.ToDateTime(dr["FechaYHora"]),
                    Creador = dr["Creador"].ToString(),
                    NombreArchivo = dr["NombreArchivo"].ToString(),
                    Descripcion = dr["Descripcion"].ToString()
                };             

                return catalogo;
            }
        }
    }
}
