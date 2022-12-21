using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.UI.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.UserControls
{
    public partial class BuscadorCliente : UserControl
    {
        public BuscadorCliente()
        {
            InitializeComponent();
        }

        private IAbmc<Cliente> _abmcCliente = BLLCliente.ObtenerInstancia();

        private IList<Cliente> _cacheClientes = new List<Cliente>();
        private Cliente _clienteSeleccionado = null;

        public IList<Cliente> CacheClientes
        {
            set {
                _cacheClientes = value;
                ActualizarComboClientes();
            }
            get { return _cacheClientes; }
        }
        public Cliente ClienteSeleccionado {
            get { return _clienteSeleccionado; }
            set {
                _clienteSeleccionado = value;
                txtClienteSeleccionado.Text = _clienteSeleccionado == null ? "" : _clienteSeleccionado.ToString();
            }
        }

        public void EstablecerSoloLectura()
        {
            txtFiltroBusquedaCliente.ReadOnly = true;
            txtFiltroBusquedaCliente.TabStop = false;
            cmbCliente.Enabled = false;
            cmbCliente.TabStop = false;
            btnAgregarCliente.Enabled = false;
        }



        private void txtFiltroBusquedaCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarComboClientes(txtFiltroBusquedaCliente.Text);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                var cli = cmbCliente.SelectedItem as Cliente;
                if (cli != null)
                    ClienteSeleccionado = cli;

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FormCliente fAltaCliente = new FormCliente();
                fAltaCliente.OnClienteCreado += ObtenerClienteCreado;
                fAltaCliente.ShowDialog();              

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnVerFichaCliente_Click(object sender, EventArgs e)
        {
            try
            {              

                if (_clienteSeleccionado != null)
                {
                    var fModf = new FormCliente(_clienteSeleccionado);
                    if (fModf.ShowDialog() != DialogResult.OK)
                        return;

                    //Actualizamos el cliente seleccionado ya que pudo cambiar
                    var nuevoClienteSeleccionado = _abmcCliente.Leer(_clienteSeleccionado);
                    if (nuevoClienteSeleccionado != null)
                    {
                        //Lo reemplazamos el el caché
                        var cliCache = _cacheClientes?.FirstOrDefault(c => c.Equals(nuevoClienteSeleccionado));
                        if (cliCache != null)
                        {
                            cliCache = nuevoClienteSeleccionado;
                            ActualizarComboClientes();
                        }
                        ClienteSeleccionado = nuevoClienteSeleccionado;
                    }

                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }            
        }
        private void ObtenerClienteCreado(object sender, CUITClienteEventArgs e)
        {
            try
            {
                //Obtenemos el último cliente cargado recibido por argumento de evento
                Cliente cliente = _abmcCliente.Leer(new Cliente { CUIT = e.CUIT});
                //Lo agregamos al caché
                if (cliente != null &&
                    !_cacheClientes.Any(c => c.Equals(cliente)))
                {
                    _cacheClientes.Add(cliente);
                    ActualizarComboClientes();
                    ClienteSeleccionado = cliente;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }

        private void ActualizarComboClientes(string textoBusqueda = "")
        {
            if (_cacheClientes == null)
                return;

            var cliLista = from cli in _cacheClientes select cli;                           
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
                cliLista = cliLista.Where(cli => cli.ToString().ToLower().Contains(textoBusqueda.ToLower()));
            cliLista = cliLista.OrderBy(cli => cli.ToString());
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbCliente, cliLista, true, "<Seleccione Cliente...>");
            cmbCliente.SelectedIndex = 0;
        }

        
    }
}
