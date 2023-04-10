using Abstract;

using Presenter;

using ReaLTaiizor.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ClienteVista :  MaterialForm, IClienteVista
    {
        ClientePresentador _presentador;

        public event EventHandler<EventArgs> GetAllClientes;
        public event EventHandler<EventArgs> GetCliente;
        public event EventHandler<EventArgs> AddCliente;
        public event EventHandler<EventArgs> RemoveCliente;
        public event EventHandler<EventArgs> UpdateCliente;

        public ClienteVista()
        {
            InitializeComponent();
        }

        private void ClienteVista_Load(object sender, EventArgs e)
        {
            _presentador = new ClientePresentador(this);
            CargarGrilla();
            //ClientesCtrl.DataSource = GetAllClientes;
        }

        private void CargarGrilla()
        {
            ClientesCtrl.DataSource = null;
            ClientesCtrl.DataSource = _presentador.CargarClientes();
        }

        private void ClientesCtrl_RowEnter(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        public string BarraEstado
        {
            set { EstadoCtrl.Text = value; }
        }

        public bool CambioDetectado { get; set; }

        public int Id
        {
            get { return int.Parse(IdCtrl.Text); }
            set { IdCtrl.Text = value.ToString(); }
        }

        public string Nombre
        {
            get { return NombreCtrl.Text; }
            set { NombreCtrl.Text = value; }
        }

        public DateTime FechaAlta
        {
            get { return DateTime.Parse(FechaAltaCtrl.Text); }
            set { FechaAltaCtrl.Value = value; }
        }

        public bool Activo
        {
            get { return ActivoCtrl.Checked; }
            set { ActivoCtrl.Checked = value; }
        }

        public List<ITelefonoModelo> Telefonos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        


        public object Clone()
        {
            throw new NotImplementedException();
        }

        
    }
}
