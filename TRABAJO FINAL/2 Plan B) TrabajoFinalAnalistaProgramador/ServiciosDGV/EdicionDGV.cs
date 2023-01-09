using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ServiciosDGV
{
    public class EdicionDGV
    {
        public void EditarDGV(DataGridView pDgv)
        {
            try
            {
                //Establezco el modo de seleccion.
                pDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //Desabilito la multiseleccion.
                pDgv.MultiSelect = false;
                //Propiedad readOnly en true.
                pDgv.ReadOnly = true;
                //Le saco los bordes.
                pDgv.BorderStyle = BorderStyle.None;
                pDgv.EnableHeadersVisualStyles = false;
                pDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                //Establezco color de fondo.
                pDgv.BackgroundColor = Color.LightGray;
                //Cambio color de encabezado de columna.
                pDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
                //Color de letra.
                pDgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                //Caracteristicas de letra.
                pDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //Alineacion del texto del encabezado de columna.
                pDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Bordes.
                pDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                //Altura del encabezado.
                pDgv.ColumnHeadersHeight = 28;
                //Oculto la cabecera de las filas.
                pDgv.RowHeadersVisible = false;
                //Fuente de las celdas.
                pDgv.DefaultCellStyle.Font = new Font("Century Gothic", 10);
                //Color cuando selecciono la fila.
                pDgv.DefaultCellStyle.SelectionBackColor = Color.Gray;
                //Coloco ancho de la columna y fila que se adapte de acuerdo al texto.
                pDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                pDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
