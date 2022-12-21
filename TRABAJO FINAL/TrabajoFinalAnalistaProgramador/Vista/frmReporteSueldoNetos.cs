using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Microsoft.Reporting.WinForms;
using BLL;

namespace Vista
{
    public partial class frmReporteSueldoNetos : Form
    {
        BLL_SueldoNeto oBLLSueldoNeto;
        BLL_Empleado oBLLEmpleado;
        BLL_Gerente oBLLGerente;
        public List<E_SueldoNeto> sueldos = new List<E_SueldoNeto>();

        public frmReporteSueldoNetos()
        {
            oBLLSueldoNeto = new BLL_SueldoNeto();
            oBLLEmpleado = new BLL_Empleado();
            oBLLGerente = new BLL_Gerente();
            InitializeComponent();
        }

        private void frmReporteSueldoNetos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboApellidoEmpleado();
                CargarComboApellidoGerente();
                CargarComboNombreEmpleado();
                CargarComboNombreGerente();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_GenerarReporte_Click(object sender, EventArgs e)
        {
            //Instacio dos objetos.
            E_Empleado oEmpleado = new E_Empleado();
            E_Empleado oGerente = new E_Empleado();

            try
            {
                //Asigno el valor a las propiedades de los objetos.
                oEmpleado.Nombre = cb_NombreEmpleado.Text;
                oEmpleado.Apellido = cb_ApellidoEmpleado.Text;
                oGerente.Nombre = cb_NombreGerente.Text;
                oGerente.Apellido = cb_ApellidoGerente.Text;
                //Creo un vector para los parametros.
                ReportParameter[] parameters = new ReportParameter[4];
                //Asigno valor a cada uno de los parametros.
                parameters[0] = new ReportParameter("parametro_Empleado", oEmpleado.Nombre);
                parameters[1] = new ReportParameter("parametro_Empleado2", oEmpleado.Apellido);
                parameters[2] = new ReportParameter("parametro_Gerente", oGerente.Nombre);
                parameters[3] = new ReportParameter("parametro_Gerente2", oGerente.Apellido);
                //Hago visible el reporte.
                report_Sueldo.Visible = true;
                //Establezco los datasources.
                report_Sueldo.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", sueldos));
                report_Sueldo.LocalReport.DataSources.Add(new ReportDataSource("DataSet5", parameters));
                report_Sueldo.LocalReport.DataSources.Add(new ReportDataSource("DataSet6", parameters));
                report_Sueldo.LocalReport.SetParameters(parameters);
                //Refresco.
                this.report_Sueldo.RefreshReport();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboNombreEmpleado()
        {
            try
            {
                //Establezco una instancia de BLL con el metodo listar.
                cb_NombreEmpleado.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor que muestro.
                cb_NombreEmpleado.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void CargarComboApellidoEmpleado()
        {
            try
            {
                //Establezco una instancia de BLL con el metodo listar.
                cb_ApellidoEmpleado.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor que muestro.
                cb_ApellidoEmpleado.DisplayMember = "Apellido";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void CargarComboNombreGerente()
        {
            try
            {
                //Establezco una instancia de BLL con el metodo listar.
                cb_NombreGerente.DataSource = oBLLGerente.Listar();
                //Establezco el valor que muestro.
                cb_NombreGerente.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void CargarComboApellidoGerente()
        {
            try
            {
                //Establezco una instancia de BLL con el metodo listar.
                cb_ApellidoGerente.DataSource = oBLLGerente.Listar();
                //Establezco el valor que muestro.
                cb_ApellidoGerente.DisplayMember = "Apellido";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }
    }
}
