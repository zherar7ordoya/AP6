
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormPermisos : Form
    {
        private FormPermisos()
        {
            InitializeComponent();
        }
        private static FormPermisos _instancia;
        public static FormPermisos ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormPermisos();
            if (_instancia.IsDisposed)
                _instancia = new FormPermisos();
            return _instancia;
        }

        private IList<Permiso> _cachePermisosDisponibles;
        private IList<Permiso> _estructuraPermisos;

        private Permiso _padreSeleccionado = null;
        private Permiso _hijoSeleccionado = null;
        

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ResetPantalla();          
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void trvPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ProcesarSeleccionArbol(e.Node);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
           
        }
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                FormPermiso fPermiso = new FormPermiso();
                fPermiso.ShowDialog();
                ResetPantalla();
              
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
        private void btnEliminarCompuesto_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarPermisoCompuesto();
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
        private void btnEditarPermiso_Click(object sender, EventArgs e)
        {
            if (_padreSeleccionado == null)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                FormPermiso fPermiso = new FormPermiso(_padreSeleccionado);
                fPermiso.ShowDialog();
                ResetPantalla();

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
        private void btnAgregarPermisoSimple_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarPermiso();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                DesasignarPermiso();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarAsignacion();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
      

        private void LeerDatos()
        {
            _cachePermisosDisponibles = BLLPermiso.ObtenerInstancia().ObtenerPermisosDisponibles();
            _estructuraPermisos = BLLPermiso.ObtenerInstancia().ObtenerEstructuraPermisos();
        }        
        private void ArmarArbol()
        {
            var dicStatus = ObtenerStatusArbol();
            trvPermisos.Nodes.Clear();
            foreach (var permiso in _estructuraPermisos)
            {
                TreeNode nodo = trvPermisos.Nodes.Add(permiso.Codigo, $"{permiso.Codigo}-{permiso.Descripcion}");
                nodo.Tag = permiso;
                foreach (var pHijo in permiso.ObtenerPermisos())
                {
                    TreeNode nodoHijo = nodo.Nodes.Add(pHijo.Codigo,
                        $"{pHijo.Codigo}-{pHijo.Descripcion} {(pHijo.Otorgado ? "✅" : "❎")}");
                    nodoHijo.ForeColor = pHijo.Otorgado ? Color.Green : Color.Red;
                    nodoHijo.Tag = pHijo;
                }

                if (dicStatus.ContainsKey(permiso.Codigo) && dicStatus[permiso.Codigo])
                    nodo.Expand();
            }
        }
        private Dictionary<string,bool> ObtenerStatusArbol()
        {
            var dic = new Dictionary<string, bool>();
            foreach(TreeNode nodo in trvPermisos.Nodes)
            {
                dic.Add((nodo.Tag as Permiso).Codigo, nodo.IsExpanded);
            }
            return dic;
        }
        private void CargarComboPermisos()
        {
            if (_padreSeleccionado == null)
            {
                cmbPermiso.Items.Clear();
                cmbPermiso.Items.Add("<Seleccione...>");
                cmbPermiso.Enabled = false;
            }
            else
            {
                var listaFiltrada = _cachePermisosDisponibles
                    .Where(p => !_padreSeleccionado.ObtenerPermisos().Contains(p) && !_padreSeleccionado.Equals(p))
                    .ToList(); //Quitamos los permisos con los que ya cuenta, y a sí mismo ya que no se puede asignar.
                UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbPermiso, listaFiltrada, true, "<Seleccione...>");
                cmbPermiso.SelectedIndex = 0;
                cmbPermiso.Enabled = true;
            }

        }
        private void LimpiarControles(bool removerSeleccionPadre = false)
        {
            if (removerSeleccionPadre)
            {
                _padreSeleccionado = null;
                txtPCCodigo.Text = "";
                txtPCDescripcion.Text = "";
            }            

            _hijoSeleccionado = null;
            txtPermiso.Text = "";
            ckOtorgado.Checked = false;
            ckOtorgarNuevoPermiso.Checked = true;
            cmbPermiso.SelectedIndex = 0;
            
            
        }
        private void ResetPantalla(bool removerSeleccionPadre = false)
        {
            trvPermisos.AfterSelect -= trvPermisos_AfterSelect;
            LeerDatos();
            CargarComboPermisos();
            ArmarArbol();
            LimpiarControles(removerSeleccionPadre);
            trvPermisos.AfterSelect += trvPermisos_AfterSelect;
        }
        private void ProcesarSeleccionArbol(TreeNode nodo)
        {
            LimpiarControles();
            _padreSeleccionado = null;
            _hijoSeleccionado = null;
            var permiso = nodo?.Tag as Permiso;
            if (permiso != null)
            {
                var padre = nodo.Parent;
                if (padre == null) //Es Padre
                {
                    _padreSeleccionado = permiso;
                }
                else //Es Hijo
                {
                    _padreSeleccionado = padre.Tag as Permiso;
                    _hijoSeleccionado = permiso;

                }

                if (_padreSeleccionado == null)
                {
                    btnEditarPermiso.Enabled = false;
                    btnEliminarCompuesto.Enabled = false;
                    //cmbPermiso.Enabled = false;
                    ckOtorgarNuevoPermiso.Enabled = false;
                    btnAgregarPermisoSimple.Enabled = false;
                }
                else
                {
                    btnEditarPermiso.Enabled = true;
                    btnEliminarCompuesto.Enabled = true;
                    txtPCCodigo.Text = _padreSeleccionado.Codigo;
                    txtPCDescripcion.Text = _padreSeleccionado.Descripcion;
                    //cmbPermiso.Enabled = true;
                    ckOtorgarNuevoPermiso.Enabled = true;
                    btnAgregarPermisoSimple.Enabled = true;
                }

                if (_hijoSeleccionado == null)
                {
                    ckOtorgado.Enabled = false;
                    btnEliminarPermiso.Enabled = false;
                    btnActualizar.Enabled = false;
                }
                else
                {
                    ckOtorgado.Enabled = true;
                    btnEliminarPermiso.Enabled = true;
                    btnActualizar.Enabled = true;
                    txtPermiso.Text = _hijoSeleccionado.ToString();
                    ckOtorgado.Checked = _hijoSeleccionado.Otorgado;
                }
            }
            CargarComboPermisos();
        }
        private void AsignarPermiso()
        {
            if (_padreSeleccionado == null)
                return;

            Permiso permiso = cmbPermiso.SelectedItem as Permiso;
            if (permiso == null)
                return;

            if (_padreSeleccionado.ObtenerPermisos().Any(p => p.Codigo.Equals(permiso.Codigo)))
                throw new NegocioException($"El permiso que intenta asignar ya existe en el compuesto {_padreSeleccionado}.");
            permiso.Otorgado = ckOtorgarNuevoPermiso.Checked;
            BLLPermiso.ObtenerInstancia().AsignarPermiso(_padreSeleccionado, permiso);
            
            ResetPantalla();
        }
        private void DesasignarPermiso()
        {
            if (_padreSeleccionado == null)
                return;
            if (_hijoSeleccionado == null)
                return;

            BLLPermiso.ObtenerInstancia().DesasignarPermiso(_padreSeleccionado, _hijoSeleccionado);
            
            ResetPantalla();

        }
        private void ActualizarAsignacion()
        {
            if (_padreSeleccionado == null)
                return;
            if (_hijoSeleccionado == null)
                return;

            _hijoSeleccionado.Otorgado = ckOtorgado.Checked;
            BLLPermiso.ObtenerInstancia().ActualizarAsignacion(_padreSeleccionado, _hijoSeleccionado);
            ResetPantalla();

        }
        private void EliminarPermisoCompuesto()
        {
            if (_padreSeleccionado == null)
                return;

            DialogResult resu = MostrarMensaje.Pregunta($"¿Desea eliminar el permiso compuesto {_padreSeleccionado}?");
            if(resu == DialogResult.Yes)
            {
                BLLPermiso.ObtenerInstancia().Eliminar(_padreSeleccionado);
                ResetPantalla(true);
            }
        }
        
    }
}
