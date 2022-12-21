
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Base
{
    public partial class FormListaBase : Form
    {
        protected FormListaBase()
        {
            InitializeComponent();
        }

        public EventHandler OnListaBaseCerrada;
            

        #region A IMPLEMENTAR POR SUS HEREDEROS

        protected virtual void ActualizarLista() { }
        protected virtual void IniciarFormulario() { }
        protected virtual void AgregarElemento() { }
        protected virtual void ModificarElemento() { }
        protected virtual void EliminarElemento() { }
        protected virtual void ProcesarCambioFila() { }
        protected virtual void ResetControles() { }
        protected virtual void ProcesarReordenamiento() { }
        protected virtual void ConfigurarIdioma() { }
        protected virtual void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            ckIncluirInactivos.Checked = false;
        }
      

        #endregion

        protected int _filaActiva = 0;        

        protected T ObtenerObjetoDesdeGrilla<T>()
        {
            //Obtenemos el objeto seleccionado en la grilla, de haber uno. Se usa Generics
            if (grillaDatos?.SelectedRows.Count > 0)
            {
                return (T)grillaDatos.SelectedRows[0]?.DataBoundItem;
                //return (T)grillaDatos.CurrentRow?.DataBoundItem;
            }
            else
                return default;
        }
        protected void RetenerPosicionGrilla()
        {
            if (grillaDatos?.SelectedRows.Count > 0)
            {
                _filaActiva = grillaDatos.SelectedRows[0].Index;
            }                
        }
        protected void RestaurarPosicionGrilla()
        {
            grillaDatos.ClearSelection();
            if (grillaDatos?.Rows?.Count > 0)
            {
                if(_filaActiva >= 0 && _filaActiva < grillaDatos.Rows.Count)
                {
                    grillaDatos.Rows[_filaActiva].Selected = true;                   
                }
                else 
                {
                    grillaDatos.Rows[grillaDatos.Rows.Count - 1].Selected = true;                    
                }
                grillaDatos.Select();
            }            
        }        
        protected void RefrescarGrilla()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                RetenerPosicionGrilla();
                ActualizarLista();                
                RestaurarPosicionGrilla();
                ActualizarCantidadElementos();
                if (txtCriterioBusqueda.Visible)
                    txtCriterioBusqueda.Select();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }       
        protected void ActualizarOrdenamiento<T>()
        {            
            if (grillaDatos.Tag != null && !String.IsNullOrWhiteSpace(grillaDatos.Tag.ToString()))
            {
                List<T> lista = grillaDatos.DataSource as List<T>;
                string[] condiciones = grillaDatos.Tag.ToString().Split('|');
                if (condiciones[1].Contains("ASC"))
                    lista = lista.OrderBy(x => GetPropValue(x, condiciones[0])).ToList();
                else
                    lista = lista.OrderByDescending(x => GetPropValue(x, condiciones[0])).ToList();
                grillaDatos.DataSource = lista;
            }            
        }
        protected void CargarCriteriosBusqueda(List<ConsultaCriterio> criterios)
        {
            if (criterios == null)
                return;

            cmbCampoBusqueda.DataSource = criterios;
            cmbCampoBusqueda.ValueMember = "PropertyMember";
            cmbCampoBusqueda.DisplayMember = "DisplayMember";

            if(cmbCampoBusqueda.Items.Count > 0)
                cmbCampoBusqueda.SelectedIndex = 0;
        }
        protected void ActualizarCantidadElementos()
        {
            if (grillaDatos != null && grillaDatos.Rows != null)
                lblRegistrosEncontrados.Text = $"Mostrando {grillaDatos.Rows.Count} registro(s).";
        }

        private object GetPropValue(object src, string propName)
        {
            //Obtiene el valor de la propiedad desde el source por reflexión.            
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }         


        private void grillaDatos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProcesarCambioFila();
            }
            catch
            {
               //Consumimos el error
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                EliminarElemento();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AgregarElemento();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ModificarElemento();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormListaBase_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                IniciarFormulario();
                //this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void grillaDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            try
            {              
                this.Cursor = Cursors.WaitCursor;
                ModificarElemento();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void grillaDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            try
            {                
                string col = grillaDatos.Columns[e.ColumnIndex].DataPropertyName;
                string order = "ASC";
                if (grillaDatos.Tag != null)
                    order = grillaDatos.Tag.ToString().Contains("ASC") ? "DESC" : "ASC";
                grillaDatos.Tag = col + "|" + order;
                ProcesarReordenamiento();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }     
        private void txtCriterioBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                    RefrescarGrilla();

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                RestablecerParametros();
                RefrescarGrilla();

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }



        /// <summary>
        /// Provee un método para refrescar la grilla ante un evento externo.
        /// </summary>     
        public void RefrescarGrillaDesdeSuscripcion(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        /// <summary>
        /// Cuando se cierra la lista base, notifica a quienes se hayan suscripto
        /// </summary>        
        private void FormListaBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnListaBaseCerrada?.Invoke(this, null);
        }
    }
}
