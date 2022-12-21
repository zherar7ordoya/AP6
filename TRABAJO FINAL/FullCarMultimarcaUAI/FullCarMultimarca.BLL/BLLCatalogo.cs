using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.MPP;
using FullCarMultimarca.MPP.Seguridad;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    public class BLLCatalogo
    {

        private BLLCatalogo()
        {
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLCatalogo _bllCatalogo = null;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLCatalogo ObtenerInstancia()
        {
            if (_bllCatalogo == null)
                _bllCatalogo = new BLLCatalogo();
            return _bllCatalogo;
        }
        ~BLLCatalogo()
        {
            _bllCatalogo = null;
            _logger = null;
        }

        public IList<VistaCatalogo> ObtenerCatalogosBackup()
        {
            return ConstruirVista(MPPCatalogo.ObtenerInstancia().ObtenerCatalogosBackup());
        }
        public Catalogo Leer(Catalogo catalogo)
        {
            Catalogo cat = MPPCatalogo.ObtenerInstancia().Leer(catalogo);
            if (cat == null)
                throw new NegocioException("No se encontró el catálogo");
            return cat;
        }

        public void CrearBackup(string descripcion)
        {
            //Primero verificamos que la base no esté corrupta, dado que si lo está no debemos permitirle crear un backup
            BLLProteccion.ObtenerInstancia().VerificarProteccionDeDatos();

            DateTime fyh = DateTime.Now;
            Catalogo catalogo = new Catalogo
            {
                FechaYHora = fyh,
                Creador = Ticket.UsuarioLogueado.Logon,
                NombreArchivo = $"{fyh:yyyyMMdd HHmmss}-FullCarMultimarca.xml",
                Descripcion = descripcion
            };

            MPPCatalogo.ObtenerInstancia().CrearBackup(catalogo);

            _logger.GenerarLog($"Backup del día {catalogo.FechaYHora:dd/MM/yyyy HH:mm:ss} generado.");
        }
        public void EliminarBackup(Catalogo catalogo)
        {
            MPPCatalogo.ObtenerInstancia().EliminarBackup(catalogo);

            _logger.GenerarLog($"Backup del día {catalogo.FechaYHora:dd/MM/yyyy HH:mm:ss} eliminado.");
        }
        public void RestaurarBackup(Catalogo catalogo)
        {
            MPPCatalogo.ObtenerInstancia().RestaurarBackup(catalogo);

            _logger.GenerarLog($"Se restauró el Backup del día {catalogo.FechaYHora:dd/MM/yyyy HH:mm:ss}.");
        }

        private IList<VistaCatalogo> ConstruirVista(IList<Catalogo> source)
        {
            IList<VistaCatalogo> lista = new List<VistaCatalogo>();
            VistaCatalogo destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaCatalogo();                
                destItem.FechaYHora = sourceItem.FechaYHora;
                destItem.NombreArchivo = sourceItem.NombreArchivo;
                destItem.Creador = sourceItem.Creador;
                destItem.Descripcion = sourceItem.Descripcion;

                lista.Add(destItem);
            }
            return lista;
        }
    }
}
