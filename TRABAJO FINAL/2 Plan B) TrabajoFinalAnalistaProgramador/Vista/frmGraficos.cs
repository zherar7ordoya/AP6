using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using PermisoComposite;
using Entidad;

namespace Vista
{
    public partial class frmGraficos : Form
    {
        BLL_LogIn oBLLLogin;
        BLL_Articulo oBLLArticulo;
        BLL_SueldoNeto oBLLSueldoNeto;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_Permiso oBLLPermiso;
        string Accion;
        //Accion = A (grafico de articulo precio de venta mas caros).
        //Accion = B (grafico de articulo existencias mas elevadas).
        //Accion = C (grafico de articulo precio venta mas barato).
        //Accion = D (grafico de articulo con menos existencias).

        //Para esta parte del sistema, no puedo trabajar con el controlador. No me aparece el espacio de nombres para trabajar con chart.
        public frmGraficos()
        {
            InitializeComponent();
            oBLLArticulo = new BLL_Articulo();
            oBLLSueldoNeto = new BLL_SueldoNeto();
            oBLLLogin = new BLL_LogIn();
            oUsuario = new E_Usuario();
            oBLLUsuario = new BLL_Usuario();
            oBLLPermiso = new BLL_Permiso();
        }

        private void frmGraficos_Load(object sender, EventArgs e)
        {
            chart_ArticulosPVenta.Visible = false;
            rb_Torta.Visible = false;
            rb_Barras.Visible = false;
            lbl_TipoGrafico.Visible = false;
            VerificarPermisos();
        }

        private void VerificarPermisos()
        {
            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<RadioButton> listaRb = new List<RadioButton>() { rb_ArticulosCaro, rb_ArticuloBarato, rb_ArticuloExistencias, rb_ArticuloMenosExist };
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                lbl_UsuarioLog.Text = oUsuario.Nombre;
                //Verifico el pemriso que tiene ese usuario.
                oBLLUsuario.VerificarTipoUsuario(oUsuario);
                //Asigno a lista perfil, la carga de permiso.
                Perfil = oBLLPermiso.CargarPermisos(oUsuario.oPermiso.Id);

                //Recorro la lista de botones.
                foreach (RadioButton rb in listaRb)
                {
                    if (Perfil.Exists(x => x.Id == ((RadioButton)rb).Tag.ToString()))
                    {
                        rb.Visible = true;
                    }
                    else
                    {
                        rb.Visible = false;
                    }

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para crear Grafico top 3 de precio venta de articulos.
        private void CrearGraficoArtPVentaBarra()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoPVenta();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "precioVenta";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Column;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtPVentaTorta()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoPVenta();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "precioVenta";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Pie;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtExistenciasBarra()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoExistencias();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "Existencia";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Column;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtExistenciasBarra2()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoExistencias2();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "Existencia";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Column;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtExistenciasTorta()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoExistencias();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "Existencia";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Pie;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtExistenciasTorta2()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoExistencias2();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "Existencia";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Pie;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtPVentaBajoBarra()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoPVenta2();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "precioVenta";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Column;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CrearGraficoArtPVentaBajoTorta()
        {
            try
            {
                //Asiganmos el origen de datos.
                chart_ArticulosPVenta.DataSource = oBLLArticulo.ObtenerDatosGraficoPVenta2();
                //Establezco los valores de los ejes X e Y.
                chart_ArticulosPVenta.Series[0].XValueMember = "Descripcion";
                chart_ArticulosPVenta.Series[0].YValueMembers = "precioVenta";
                chart_ArticulosPVenta.DataBind();
                //Establezco el tipo de Grafico.
                chart_ArticulosPVenta.Series[0].ChartType = SeriesChartType.Pie;
                chart_ArticulosPVenta.Series[0].Color = Color.ForestGreen;
                chart_ArticulosPVenta.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_ArticulosCaro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(165, 118);
                rb_Torta.Location = new Point(165, 151);
                lbl_TipoGrafico.Location = new Point(162, 92);
                Accion = "A";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_Barras_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                switch(Accion)
                {
                    case "A":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtPVentaBarra();
                        break;
                    case "B":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtExistenciasBarra();
                        break;
                    case "C":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtPVentaBajoBarra();
                        break;
                    case "D":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtExistenciasBarra2();
                        break;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_Torta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                switch (Accion)
                {
                    case "A":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtPVentaTorta();
                        break;
                    case "B":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtExistenciasTorta();
                        break;
                    case "C":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtPVentaBajoTorta();
                        break;
                    case "D":
                        chart_ArticulosPVenta.Visible = true;
                        CrearGraficoArtExistenciasTorta2();
                        break;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }     
        }

        private void rb_ArticuloExistencias_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(606, 113);
                rb_Torta.Location = new Point(606, 146);
                lbl_TipoGrafico.Location = new Point(603, 87);
                Accion = "B";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_ArticuloBarato_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(384, 118);
                rb_Torta.Location = new Point(384, 151);
                lbl_TipoGrafico.Location = new Point(381, 92);
                Accion = "C";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_ArticuloMenosExist_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(886, 115);
                rb_Torta.Location = new Point(886, 148);
                lbl_TipoGrafico.Location = new Point(883, 89);
                Accion = "D";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_Sueldos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(1183, 118);
                rb_Torta.Location = new Point(1183, 151);
                lbl_TipoGrafico.Location = new Point(1180, 92);
                Accion = "E";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void rb_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rb_Barras.Visible = true;
                rb_Torta.Visible = true;
                lbl_TipoGrafico.Visible = true;
                rb_Barras.Location = new Point(1062, 97);
                rb_Torta.Location = new Point(1062, 130);
                lbl_TipoGrafico.Location = new Point(1059, 67);
                Accion = "F";
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
