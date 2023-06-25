using System;
using System.Windows.Forms;
using BLL;
using BEL;

namespace GUI
{
    public partial class MainForm : Form
    {
        private ITransportAgency transportAgency;

        public MainForm()
        {
            InitializeComponent();
            transportAgency = new TransportAgency(); // Instancia de la capa de lógica de negocio
        }

        private void btnRentVehicle_Click(object sender, EventArgs e)
        {
            // Lógica para registrar el alquiler de un vehículo por un cliente
            // utilizando los datos de los controles en el formulario
        }

        private void btnReturnVehicle_Click(object sender, EventArgs e)
        {
            // Lógica para registrar la devolución de un vehículo por un cliente
            // utilizando los datos de los controles en el formulario
        }

        private void btnMostRentedVehicles_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar los vehículos más alquilados en un DataGridView
        }

        private void btnLeastRentedVehicles_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar los vehículos menos alquilados en un DataGridView
        }

        private void btnTotalRevenueByVehicleType_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar el monto total recaudado por tipo de vehículo
        }
    }
}
