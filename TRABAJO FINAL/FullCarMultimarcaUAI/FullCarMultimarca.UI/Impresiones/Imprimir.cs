using FullCarMultimarca.Vistas;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Impresiones
{
    public static class Imprimir
    {        
		
		/// <summary>
		/// Imprime el reporte
		/// </summary>		
		public static void ImprimirOperacion(VistaImpresionOperacion vistaImpresion, string impresora)
		{
			try
			{

				LocalReport report = ObtenerReporteParaOperacion(vistaImpresion);				
				ReportPrinter rprinter = new ReportPrinter();
				rprinter.ImprimirReporte(report, impresora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Guardar en la carpeta temporal el pdf y devuelve la ruta completa
		/// </summary>		
		public static string GuardarEnCarpetaTemporal(VistaImpresionOperacion vistaImpresion, string nombreArchivo)
        {
			try
			{
				LocalReport report = ObtenerReporteParaOperacion(vistaImpresion);
				ReportPrinter rprinter = new ReportPrinter();
				byte[] arr = rprinter.GenerarPDF(report);
				string path = Path.Combine(UtilUI.ObtenerInstancia().ObtenerCarpetaTemporal(), nombreArchivo);
				File.WriteAllBytes(path, arr);
				return path;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// Genera el reporte con sus parámetros
		/// </summary>		
		private static LocalReport ObtenerReporteParaOperacion(VistaImpresionOperacion vistaImpresion)
        {
			LocalReport report = new LocalReport();
			//report.LoadReportDefinition(rptStream);
			report.ReportEmbeddedResource = "FullCarMultimarca.UI.Impresiones.ImpresionOperacion.rdlc";
			IList<string> lista = report.GetDataSourceNames();

			//El data source necesita una lista
			IList<VistaImpresionOperacion> listaHeader = new List<VistaImpresionOperacion>();
			listaHeader.Add(vistaImpresion);

			ReportDataSource dataSource = new ReportDataSource();
			dataSource.Value = listaHeader;
			dataSource.Name = lista[0];
			report.DataSources.Add(dataSource);

			dataSource = new ReportDataSource();
			dataSource.Value = vistaImpresion.ObtenerFormasPago();
			dataSource.Name = lista[1];
			report.DataSources.Add(dataSource);

			return report;
		}

	}
}
