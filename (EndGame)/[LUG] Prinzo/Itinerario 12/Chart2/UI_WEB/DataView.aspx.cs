﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace UI_WEB
{
    public partial class DataView : System.Web.UI.Page
    {
        DataSet Ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearDataset();
            cargargraficoDS();
        }

        void cargargraficoDS()
        {
            //instancio una vista del DS
            System.Data.DataView Dvista = new System.Data.DataView(Ds.Tables[0]);
            //bindeo los valores con la serie del chart
            Chart1.Series[0].Points.DataBindXY(Dvista, "Nombre", Dvista, "Saldo");
            //digo q tipo de grafico quiero (bar= narras)
            Chart1.Series[0].ChartType = SeriesChartType.Bar;
            //y si lo quiero en 3D
            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }


        void CrearDataset()
        {

            //DESDE ADO.NET SE PUEDE INSTANCIAR UN DATATABLE FUERA DE UN DATASET
            DataTable Dt = new DataTable("Persona");

            //LAS COLUMNAS SE PUEDEN INSTANCIAR FUERA DEL DATATABLE Y AGREGAR LUEGO
            DataColumn Dcolum = new DataColumn("Id", typeof(System.Int32));
            Dt.Columns.Add(Dcolum);
            //O SE PUEDEN AGREGAR DIRECTAMENTE
            Dt.Columns.Add("Nombre", typeof(System.String));
            Dt.Columns.Add("Apellido", typeof(System.String));
            Dt.Columns.Add("Direccion", typeof(System.String));
            Dt.Columns.Add("Saldo", typeof(System.Double));
            Ds.Tables.Add(Dt);

            //LLENAMOS LA TABLA PERSONA
            var _with2 = Ds.Tables["Persona"].Rows;
            _with2.Add(1, "Jose", "San Martín", "Libertador 1212", 9000);
            _with2.Add(2, "Pedro", "Rivadavia", "Rivadavia 2150", 30000);
            _with2.Add(3, "Domingo", "Sarmiento", "Sarmiento 2500", 18000);
            _with2.Add(4, "Laura", "O Higgins", "O Higgins 710", 25000);
            _with2.Add(5, "Sofia", "Bolivar", "Bolivar 2100", 65000);

        }
    }
}