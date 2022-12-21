using FullCarMultimarca.BE;
using FullCarMultimarca.Vistas.Atributos;
using FullCarMultimarca.BE.Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI
{
    /// <summary>
    /// Clase que proporciona diversos servicios a la interfaz gráfica
    /// </summary>
    public class UtilUI
    {
        private UtilUI()
        {

        }

        private static UtilUI _serviciosUI = null;

        public static UtilUI ObtenerInstancia()
        {
            if (_serviciosUI == null)
                _serviciosUI = new UtilUI();
            return _serviciosUI;
        }
        ~UtilUI()
        {
            _serviciosUI = null;
        }

        public void AbrirOTraerAlFrente(Form parent, Form fAAbrir)
        {
            if (fAAbrir != null)
            {
                fAAbrir.MdiParent = parent;
                fAAbrir.Show();
                fAAbrir.BringToFront();
            }

        }
        public void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, IList<Permiso> permisosHabilitados)
        {
            //Variable utilizada para mostrar/ocultar items del menu que no tienen hijos visibles
            bool tieneVisibles = false;
            CambiarVisibilidadMenu(dropDownItems, ref tieneVisibles, permisosHabilitados);
        }
        public void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, ref bool tieneVisibles, IList<Permiso> permisosHabilitados)
        {
            foreach (object obj in dropDownItems)
            {
                ToolStripMenuItem subMenu = obj as ToolStripMenuItem;
                if (subMenu != null)
                {
                    if (subMenu.HasDropDown)
                    {
                        tieneVisibles = false;
                        CambiarVisibilidadMenu(subMenu.DropDownItems, ref tieneVisibles, permisosHabilitados);                     
                    }
                    bool visible = false;
                    string tag = subMenu.Tag as string;
                    if (!string.IsNullOrEmpty(tag) && (tag.Equals("SP") || permisosHabilitados.Any(p => p.Codigo.Equals(tag))))
                    {
                        visible = true; //Si el tag no tiene permiso asignado (SP=Sin Permiso), o el permiso asignado es parte de los permisos del usuario del Ticket, ponemos visible = true.
                        tieneVisibles = true;
                    }

                    if (string.IsNullOrWhiteSpace(tag) && tieneVisibles) //Si el tag no tiene nada (o null), es porque es porque contiene subItems, ergo tenemos que decidir si mostrarlo o no.
                        subMenu.Visible = true;
                    else
                        subMenu.Visible = visible;


                }
            }
        }       
        public void CerrarTodosLosFormsHijos(Form parent)
        {
            foreach (Form frm in parent.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }
        }
    
        public void CargarComboDesdeEnum(ComboBox cb, System.Type en)
        {
            CargarComboDesdeEnum(cb, en, false, "");
        }
        public void CargarComboDesdeEnum(ComboBox cb, System.Type en, bool agregarTextoNull, string textoNull)
        {
            if (!en.IsEnum)
            {
                throw new ArgumentException("El parámetro en debe ser una enumeración");
            }
            cb.Items.Clear();
            if (agregarTextoNull) cb.Items.Add(textoNull);
            foreach (Enum item in Enum.GetValues(en))
            {
                cb.Items.Add(item);
            }
        }
        public void CargarComboDesdeList<T>(ComboBox cb, IEnumerable<T> lista) where T : class
        {
            CargarComboDesdeList(cb, lista, false, "");
        }
        public void CargarComboDesdeList<T>(ComboBox cb, IEnumerable<T> lista, bool agregarTextoNull, string textoNull) where T : class
        {
            cb.Items.Clear();
            if (agregarTextoNull) cb.Items.Add(textoNull);
            foreach (var item in lista)
            {
                cb.Items.Add(item);
            }
        }

        public void EstablecerControlesSoloLectura(Control control, bool soloLectura, ArrayList controlesAExcluirDelProcesamiento)
        {
            if (controlesAExcluirDelProcesamiento.Contains(control))
            {
                return;
            }
            if (control is TextBox)
            {
                (control as TextBox).ReadOnly = soloLectura;
                return;
            }
            if (control is ComboBox)
            {
                (control as ComboBox).Enabled = !soloLectura;
                return;
            }           
            if (control is DateTimePicker)
            {
                (control as DateTimePicker).Enabled = !soloLectura;
                return;
            }
            if (control is CheckBox)
            {
                (control as CheckBox).Enabled = !soloLectura;
                return;
            }
            if (control is Button)
            {
                (control as Button).Enabled = !soloLectura;
                return;
            }
            if (control is NumericUpDown)
            {
                (control as NumericUpDown).ReadOnly = soloLectura;
                return;
            }
            if (control is MaskedTextBox)
            {
                (control as MaskedTextBox).ReadOnly = soloLectura;
                return;
            }         
            foreach (Control c in control.Controls)
            {
                EstablecerControlesSoloLectura(c, soloLectura, controlesAExcluirDelProcesamiento);
            }
        }

        /// <summary>
        /// Brinda formato a la grilla desde el tipo indicado.
        /// </summary>
        /// <param name="dgv">La grilla a dar formato</param>
        /// <param name="tipo">El tipo de dato para determina por reflexión sus propiedades</param>
        public void LayoutGrilla(DataGridView dgv, Type tipo)
        {

            if (dgv.DataSource == null || dgv.Columns.Count == 0)
                return;

            //Recorro las propiedades del tipo por reflexión                      
            object[] attrArray;
            TituloGrillaAttribute definicionAttr;
            NoVisibleEnGrillaAttribute noVisibleAttr;
            FormatoGrillaAttribute formatoAttr = null;
            AnchoGrillaAttribute anchoAttr = null;

            foreach (PropertyInfo property in tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                //para las colecciones no hago nada, no se representan en la grilla
                if (property.PropertyType.Name.Contains("IList"))
                {
                    continue;
                }
                //verificamos si no lo debemos mostrar, lo ocultamos y seguimos                
                attrArray = property.GetCustomAttributes(typeof(NoVisibleEnGrillaAttribute), true);
                if (attrArray.Length > 0) // el atributo existe
                {
                    noVisibleAttr = attrArray[0] as NoVisibleEnGrillaAttribute;
                    dgv.Columns[property.Name].Visible = false;
                    continue;
                }
                //Obtengo el atributo buscando de la propiedad en cuestión.
                attrArray = property.GetCustomAttributes(typeof(TituloGrillaAttribute), true);
                if (attrArray.Length > 0) // el atributo existe
                {
                    definicionAttr = attrArray[0] as TituloGrillaAttribute;
                    dgv.Columns[property.Name].HeaderText = definicionAttr.Titulo;
                }
                //Obtengo el atributo buscando de la propiedad en cuestión.
                attrArray = property.GetCustomAttributes(typeof(AnchoGrillaAttribute), true);
                if (attrArray.Length > 0) // el atributo existe
                {
                    anchoAttr = attrArray[0] as AnchoGrillaAttribute;
                    dgv.Columns[property.Name].Width = anchoAttr.Ancho;
                }
                formatoAttr = null;
                attrArray = property.GetCustomAttributes(typeof(FormatoGrillaAttribute), true);
                if (attrArray.Length > 0) //la columna tiene formato establecido
                {
                    formatoAttr = attrArray[0] as FormatoGrillaAttribute;
                }

                //Alineación para numéricos (default a la derecha)
                if (property.PropertyType.FullName.Contains("Int32"))
                {
                    dgv.Columns[property.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv.Columns[property.Name].DefaultCellStyle.Format = formatoAttr != null ? formatoAttr.Formato : "N0";
                }
                else if (property.PropertyType.FullName.Contains("Decimal") || property.PropertyType.FullName.Contains("Double"))
                {
                    dgv.Columns[property.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv.Columns[property.Name].DefaultCellStyle.Format = formatoAttr != null ? formatoAttr.Formato : "N2";
                }
                else if (property.PropertyType.FullName.Contains("DateTime"))
                {
                    dgv.Columns[property.Name].DefaultCellStyle.Format = formatoAttr != null ? formatoAttr.Formato : "dd/MM/yyyy";
                }
            }

        }
        public T ObtenerObjetoDesdeGrilla<T>(DataGridView grilla)
        {
            //Obtenemos el objeto seleccionado en la grilla, de haber uno. Se usa Generics
            if (grilla?.SelectedRows.Count > 0)
            {
                return (T)grilla.SelectedRows[0]?.DataBoundItem;
                //return (T)grillaDatos.CurrentRow?.DataBoundItem;
            }
            else
                return default;
        }      

        public string ObtenerCarpetaTemporal()
        {
            return Path.GetTempPath();
        }

        //Convierte y devuelve un mapa de bits del control recibido por parámetro
        public Bitmap CrearImagenDesdePantalla(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }
        //Image to byte[]   
        public byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }

        //internal static string EscapeLikeValue(string valueWithoutWildcards)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < valueWithoutWildcards.Length; i++)
        //    {
        //        char c = valueWithoutWildcards[i];
        //        if (c == '*' || c == '%' || c == '[' || c == ']')
        //            sb.Append("[").Append(c).Append("]");
        //        else if (c == '\'')
        //            sb.Append("''");
        //        else
        //            sb.Append(c);
        //    }
        //    return sb.ToString();
        //}

    }
}
