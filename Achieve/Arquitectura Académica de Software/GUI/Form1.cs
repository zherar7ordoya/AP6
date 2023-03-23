using System.Configuration;


using Controller;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        readonly ClienteVista ControladorCliente;

        // Falla porque no puede acceder a DataAccess
        // readonly string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            ControladorCliente = new ClienteVista(this);
        }

        // --- WORKBENCH ------------------------------------------------------╗
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO => Actualizar BDD cuando modifico DGV (con/sin DataSet)
            string CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=UCEMA;Integrated Security=True";
            string consulta = "SELECT * FROM Cliente";
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                /** => https://stackoverflow.com/a/18151694/14009797
                 * You can't bind a datareader directly to a DataGridView in
                 * WinForms. Instead you could load a datatable with your reader
                 * and assign it to the datasource of the DataGridView.    */
                DataTable tabla = new DataTable();
                tabla.Load(lector);
                dataGridView1.DataSource = tabla;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexion.Close(); }
        }
        // --- WORKBENCH ------------------------------------------------------╝


        // TODO => Consultar a Cardacci sobre esto (Alta tiene como parámetro un
        // objeto Cliente, pero no se usa, y aquí, incluso para no usarlo,
        // necesito referenciarlo).
        private void Alta_Click(object sender, EventArgs e)
        {
            ControladorCliente.Alta();
        }


    }
}
