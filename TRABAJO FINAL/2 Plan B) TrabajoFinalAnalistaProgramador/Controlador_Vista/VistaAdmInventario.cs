using BLL;
using Entidad;
using Microsoft.VisualBasic;
using PermisoComposite;
using ServiciosDGV;
using ServiciosI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Controlador_Vista
{
    public class VistaAdmInventario : Iabmc<E_Articulo>
    {
        System.Windows.Forms.Form frmAdmInventario;
        System.Windows.Forms.Form frmDefinirStocks;
        System.Windows.Forms.Form frmIngresoEgreso;
        System.Windows.Forms.Form frmTipoUbicacion;
        System.Windows.Forms.Form frmMovimiento;
        System.Windows.Forms.Form frmReporteArticulos;
        List<Control> ListaControles;
        BLL_Articulo oBLLArticulo;
        E_Articulo oArticulo;
        BLL_Marca oBLLMarca;
        BLL_Proveedor oBLLProveedor;
        BLL_Empleado oBLLEmpleado;
        EdicionDGV oEdicionDgv;
        BLL_LogIn oBLLLogin;
        BLL_Usuario oBLLUsuario;
        E_Usuario oUsuario;
        BLL_Permiso oBLLPermiso;
        string Accion;
        //Declaro variables.
        string _codigo; int _marca; string _descripcion; string _talle; int _existencia; int _stockMin; int _stockMax;
        decimal _precioCosto; decimal _precioVenta; decimal _precioPromo; string _observacion; int _empleado; int _idProveedor;
        bool _activo;

        public VistaAdmInventario(Form pForm, Form pForm2, Form pForm3, Form pForm4, Form pForm5, Form pForm6)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privadada referencia al formulario que llega al parámetro del constructor.
                frmAdmInventario = pForm;
                frmDefinirStocks = pForm2;
                frmIngresoEgreso = pForm3;
                frmTipoUbicacion = pForm4;
                frmMovimiento = pForm5;
                frmReporteArticulos = pForm6;
                //Recorro el frmAdmInventario en busca de controles.
                foreach (System.Windows.Forms.Control c in frmAdmInventario.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }
                //Recorro el FormIngresoEgreso.
                foreach (System.Windows.Forms.Control c in frmIngresoEgreso.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }
                //Instancio un control GroupBox encontrado en el frmIngresoEgreso para recorrerlo y encontrar los label que tiene dentro.
                GroupBox gbArticulo2 = (GroupBox)ListaControles.Find(x => x.Nombre == "gb_Articulo2").Puntero;
                //Recorro el Groupbox.
                foreach (System.Windows.Forms.Control c in gbArticulo2.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }


                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarArticulo").Puntero).Click += btn_GuardarArticulo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarArticulo").Puntero).Click += btn_CancelarArticulo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaArticulo").Puntero).Click += btn_AltaArticulo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaArticulo").Puntero).Click += btn_BajaArticulo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModArticulo").Puntero).Click += btn_ModArticulo_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_IncPrecioVenta").Puntero).Click += btn_IncPrecioVenta_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_RedPrecioVenta").Puntero).Click += btn_RedPrecioVenta_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ReporteArticulo").Puntero).Click += btn_ReporteArticulo_Click;
                ((DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero).CellFormatting += dgv_Articulos_CellFormatting;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_RegistrarMovimiento").Puntero).Click += btn_RegistrarMovimiento_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_IngresoEgreso").Puntero).Click += btn_IngresoEgreso_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_TipoUbicacion").Puntero).Click += btn_TipoUbicacion_Click;
                frmAdmInventario.Load += frmAdmInventario_Load;

                oBLLArticulo = new BLL_Articulo();
                oArticulo = new E_Articulo();
                oBLLMarca = new BLL_Marca();
                oBLLEmpleado = new BLL_Empleado();
                oEdicionDgv = new EdicionDGV();
                oBLLProveedor = new BLL_Proveedor();
                oBLLLogin = new BLL_LogIn();
                oBLLUsuario = new BLL_Usuario();
                oUsuario = new E_Usuario();
                oBLLPermiso = new BLL_Permiso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmAdmInventario_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboEmpleado();
                CargarComboMarca();
                CargarComboProveedor();
                VerificarPermisos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Alta articulo.
        private void btn_AltaArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Guardar articulo.
        private void btn_GuardarArticulo_Click(object sender, EventArgs e)
        {
            #region Validaciones
            //Valido que no quede en blanco el txt de codigo.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar el codigo del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que el codigo tenga 3 mayusculas, un guion y 3 numeros, por ejemplo, REM-001.
            Regex exp = new Regex("^[A-Z]{3}\\-[0-9]{3}$");
            if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero).Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de codigo. El codigo debe ser: AAA-123", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de descripcion.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar la descripcion del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de talle.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar el talle del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de precio de costo.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar el precio de costo del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido el formato de numero decimal con coma, para el precio de costo.
            Regex exp3 = new Regex("^[0-9]*\\,?[0-9]*$");

            if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero).Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de precio de costo. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayor a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de precio de promocion.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar el precio de promoción del articulo. Si no tiene ingresar 0.!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido el formato de numero decimal, para precio de promocion.
            if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero).Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de precio de promocion. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                if (Accion == "A")
                {
                    _codigo = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero).Text;
                    _descripcion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero).Text;
                    _marca = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero).SelectedValue.ToString());
                    _talle = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero).Text;
                    _existencia = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero).Text);
                    _stockMin = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero).Text);
                    _stockMax = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero).Text);
                    _precioCosto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero).Text);
                    _precioVenta = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero).Text);
                    _precioPromo = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero).Text);
                    _idProveedor = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero).SelectedValue.ToString());
                    _observacion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero).Text;
                    _empleado = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero).SelectedValue.ToString());

                    //Valido que no se ingresen codigos repetidos.
                    if(oBLLArticulo.ValidarCodigo(_codigo) == true)
                    {
                        Alta(oArticulo);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un artículo con el mismo codigo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                }
                else if (Accion == "M")
                {
                    _codigo = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero).Text;
                    _descripcion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero).Text;
                    _marca = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero).SelectedValue.ToString());
                    _talle = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero).Text;
                    _existencia = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero).Text);
                    _stockMin = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero).Text);
                    _stockMax = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero).Text);
                    _precioCosto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero).Text);
                    _precioVenta = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero).Text);
                    _precioPromo = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero).Text);
                    _idProveedor = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero).SelectedValue.ToString());
                    _observacion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero).Text;
                    _empleado = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero).SelectedValue.ToString());

                    Modificar(oArticulo);
                }
                //Desactivo el autogenerate por se me pierde el index.
                _dgv.AutoGenerateColumns = false;
                ActualizarGrilla();
                DesactivarComponentes();
                Limpiar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Baja articulo.
        private void btn_BajaArticulo_Click(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero;
            TextBox txtDescp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero;
            ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero;
            TextBox txtTalle = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero;
            TextBox txtExistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero;
            TextBox txtStockMin = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero;
            TextBox txtPrecioPromo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero;
            TextBox txtObservacion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

            try
            {
                //Establezco condicion.
                if (!(oArticulo.Codigo == ""))
                {
                    //Me aseguro que haya un articulo seleccionado.
                    if (_dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el articulo a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar el articulo.
                    oArticulo = (E_Articulo)_dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea dar de baja al articulo: " + oArticulo.Descripcion.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        E_Articulo oArticulo2 = new E_Articulo();
                        oArticulo2.Codigo = oArticulo.Codigo;
                        oArticulo2.Descripcion = oArticulo.Descripcion;
                        oArticulo2.oMarca.Codigo = oArticulo.oMarca.Codigo;
                        oArticulo2.Talle = oArticulo.Talle;
                        oArticulo2.Existencia = oArticulo.Existencia;
                        oArticulo2.stockMin = oArticulo.stockMin;
                        oArticulo2.stockMax = oArticulo.stockMax;
                        oArticulo2.precioCosto = oArticulo.precioCosto;
                        oArticulo2.precioVenta = oArticulo.precioVenta;
                        oArticulo2.precioPromocion = oArticulo.precioPromocion;
                        oArticulo2.oProveedor.Id = oArticulo.oProveedor.Id;
                        oArticulo2.Observacion = oArticulo.Observacion;
                        oArticulo2.oEmpleado.Dni = oArticulo.oEmpleado.Dni;
                        oArticulo2.Activo = true;
                        //Se elimina el articulo.
                        oBLLArticulo.Baja(oArticulo2);
                        //Limpio.
                        Limpiar();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Modificar articulo.
        private void btn_ModArticulo_Click(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero;
            TextBox txtDescp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero;
            ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;
            TextBox txtTalle = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero;
            TextBox txtExistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero;
            TextBox txtStockMin = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero;
            TextBox txtPrecioPromo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero;
            TextBox txtObservacion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero;

            ActivarComponentes();
            //Desactivo el txt de codigo.
            txtCodigo.Enabled = false;
            //Desactivo algunos botones para que no se puedan modificar.
            txtPrecioCosto.Enabled = false;
            txtPrecioVenta.Enabled = false;
            txtExistencia.Enabled = false;
            txtStockMin.Enabled = false;
            txtStockMax.Enabled = false;

            try
            {
                //Me aseguro que haya un articulo seleccionado.
                if (_dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un articulo a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo articulo de la grilla.
                oArticulo = (E_Articulo)_dgv.CurrentRow.DataBoundItem;
                //Paso valores.
                txtCodigo.Text = oArticulo.Codigo;
                txtDescp.Text = oArticulo.Descripcion;
                cbMarca.DisplayMember = oArticulo.oMarca.Codigo.ToString();
                txtTalle.Text = oArticulo.Talle;
                txtExistencia.Text = oArticulo.Existencia.ToString();
                txtStockMin.Text = oArticulo.stockMin.ToString();
                txtStockMax.Text = oArticulo.stockMax.ToString();
                txtPrecioCosto.Text = oArticulo.precioCosto.ToString();
                txtPrecioVenta.Text = oArticulo.precioVenta.ToString();
                txtPrecioPromo.Text = oArticulo.precioPromocion.ToString();
                cbProveedor.DisplayMember = oArticulo.oProveedor.Id.ToString();
                txtObservacion.Text = oArticulo.Observacion;
                cbEmpleado.Text = oArticulo.oEmpleado.Dni.ToString();
                //Establezco accion en Modificar.
                Accion = "M";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_CancelarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            string pDescripcion;
            pDescripcion = txtBusqueda.Text;

            try
            {
                if (txtBusqueda.Text == string.Empty)
                {
                    dgv.DataSource = oBLLArticulo.Listar();
                }
                else
                {
                    dgv.DataSource = Consultar(pDescripcion);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        
        //Boton IngresoEgreso de articulo.
        private void btn_IngresoEgreso_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;

            TextBox txtArticulo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Articulo").Puntero;
            TextBox txtExistActual = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            TextBox txtPrecioVentaAct = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaActual").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            Label lblCodigo = (Label)ListaControles.Find(x => x.Nombre == "lbl_Codigo2").Puntero;
            Label lblDesc = (Label)ListaControles.Find(x => x.Nombre == "lbl_Descripcion2").Puntero;
            Label lblMarca = (Label)ListaControles.Find(x => x.Nombre == "lbl_Marca2").Puntero;
            Label lblTalle = (Label)ListaControles.Find(x => x.Nombre == "lbl_Talle2").Puntero;
            Label lblExistencia = (Label)ListaControles.Find(x => x.Nombre == "lbl_Existencia2").Puntero;
            Label lblStockMin = (Label)ListaControles.Find(x => x.Nombre == "lbl_StockMin2").Puntero;
            Label lblStockMax = (Label)ListaControles.Find(x => x.Nombre == "lbl_StockMax2").Puntero;
            Label lblCosto = (Label)ListaControles.Find(x => x.Nombre == "lbl_PrecioCosto2").Puntero;
            Label lblPrecioVenta = (Label)ListaControles.Find(x => x.Nombre == "lbl_PrecioVenta2").Puntero;
            Label lblPromocion = (Label)ListaControles.Find(x => x.Nombre == "lbl_PrecioProm2").Puntero;
            Label lblEmpleado = (Label)ListaControles.Find(x => x.Nombre == "lbl_Empleado2").Puntero;
            Label lblProveedor = (Label)ListaControles.Find(x => x.Nombre == "lbl_Proveedor2").Puntero;

            try
            {
                //Obtengo articulo seleccionado de la grilla.
                oArticulo = (E_Articulo)dgv.CurrentRow.DataBoundItem;
                //Paso los valores para tener los datos del articulo en el nuevo form abierto.
                txtArticulo.Text = oArticulo.Codigo;
                txtExistActual.Text = oArticulo.Existencia.ToString();
                txtPrecioVentaAct.Text = oArticulo.precioVenta.ToString();
                txtPrecioCosto.Text = oArticulo.precioCosto.ToString();
                lblCodigo.Text = oArticulo.Codigo;
                lblDesc.Text = oArticulo.Descripcion;
                lblMarca.Text = oArticulo.oMarca.Codigo.ToString();
                lblTalle.Text = oArticulo.Talle;
                lblExistencia.Text = oArticulo.Existencia.ToString();
                lblStockMin.Text = oArticulo.stockMin.ToString();
                lblStockMax.Text = oArticulo.stockMax.ToString();
                lblCosto.Text = oArticulo.precioCosto.ToString();
                lblPrecioVenta.Text = oArticulo.precioVenta.ToString();
                lblPromocion.Text = oArticulo.precioPromocion.ToString();
                lblProveedor.Text = oArticulo.oProveedor.Id.ToString();
                lblEmpleado.Text = oArticulo.oEmpleado.Dni.ToString();

                ////Abro form.
                ////Oculto el frmAdmInventario.
                frmAdmInventario.Close();
                frmIngresoEgreso.Show();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_RegistrarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovimiento.ShowDialog();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Boton tipo articulo y ubicacion.
        private void btn_TipoUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmTipoUbicacion.ShowDialog();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ReporteArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteArticulos.ShowDialog();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento cell formatting del dgv, para pintarlo de acuerdo a distintas condiciones.
        private void dgv_Articulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;

            try
            {
                //Recorro el datagrid.
                foreach (DataGridViewRow row in dgv.Rows)
                {   //Si las existencias son igual al stock minimo, pinto la fila de color rojo, para advertir que se debe realizar el pedido del articulo.
                    if (Convert.ToInt32(row.Cells[4].Value) == Convert.ToInt32(row.Cells[5].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    //Si las existencias son menores al stock minimo y tengo un precio de promocion, pinto la fila de color amarillo, para advertir que el articulo esta en precio de promocion.
                    else if (Convert.ToInt32(row.Cells[4].Value) < Convert.ToInt32(row.Cells[5].Value) && Convert.ToInt32(row.Cells[9].Value) > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    //Si las existencias son menores al stock minimo, pinto fila de color rojo, para advertir que se debe realizar el pedido del articulo.
                    else if (Convert.ToInt32(row.Cells[4].Value) < Convert.ToInt32(row.Cells[5].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    //Si las existencias son mas mayores al stock minimo y no tengo un precio de promocion, pinto la fila de color normal.
                    else if (Convert.ToInt32(row.Cells[4].Value) > Convert.ToInt32(row.Cells[5].Value) && Convert.ToInt32(row.Cells[9].Value) == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    //Si las existencias son mas mayores al stock minimo y tengo un precio de promocion, pinto la fila de color amarillo, para advertir que el articulo esta en precio de promocion.
                    else if (Convert.ToInt32(row.Cells[4].Value) > Convert.ToInt32(row.Cells[5].Value) && Convert.ToInt32(row.Cells[9].Value) > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }           
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Incrementar precio de venta.
        private void btn_IncPrecioVenta_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo una variable string para asignarle el inputbox.
                string cadena;
                //Creo una variable decimal la cual va a tomar el valor de la cadena.
                decimal porcentaje = 0;
                //Valor que tiene el inputbox al iniciar.
                decimal defaultValue = 0;

                //Asigno a la variable el numero que quiero aumentar.
                cadena = (Interaction.InputBox("Ingrese el porcentaje que desea aumentar: ", "Aumento de precio", defaultValue.ToString()).ToString());

                //Si la cadena esta en blanco, retorno.
                if (cadena.ToString() == string.Empty)
                {
                    return;
                }
                //Asigno a la variablde decimal, el valor de la cadena.
                porcentaje = decimal.Parse(cadena);

                //Llamo al metodo de la BLL para incrementar el porcentaje ingresado.
                oBLLArticulo.IncrementarPrecioVenta(porcentaje);
                //Aviso.
                MessageBox.Show("Aumento de precio de venta realizada con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAdmInventario.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Reducir precio de venta.
        private void btn_RedPrecioVenta_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo una variable string para asignarle el inputbox.
                string cadena;
                //Creo una variable decimal la cual va a tomar el valor de la cadena.
                decimal porcentaje = 0;
                //Valor que tiene el inputbox al iniciar.
                decimal defaultValue = 0;

                //Asigno a la variable el numero que quiero reducir.
                cadena = (Interaction.InputBox("Ingrese el porcentaje que desea reducir: ", "Reduccion de precio", defaultValue.ToString()).ToString());

                //Si la cadena esta en blanco, retorno.
                if (cadena.ToString() == string.Empty)
                {
                    return;
                }
                //Asigno a la variablde decimal, el valor de la cadena.
                porcentaje = decimal.Parse(cadena);

                //Llamo al metodo de la BLL para reducir el porcentaje ingresado.
                oBLLArticulo.ReducirPrecioVenta(porcentaje);
                //Aviso.
                MessageBox.Show("Reducción de precio de venta realizada con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAdmInventario.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        //Metodos.
        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLArticulo.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaArticulo").Puntero;
            Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaArticulo").Puntero;
            Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModArticulo").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarArticulo").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarArticulo").Puntero;
            Button btnIngresoEgreso = (Button)ListaControles.Find(x => x.Nombre == "btn_IngresoEgreso").Puntero;
            Button btnStock = (Button)ListaControles.Find(x => x.Nombre == "btn_DefinirStocks").Puntero;
            Button btnTipoUbic = (Button)ListaControles.Find(x => x.Nombre == "btn_TipoUbicacion").Puntero;
            Button btnIncPrecio = (Button)ListaControles.Find(x => x.Nombre == "btn_IncPrecioVenta").Puntero;
            Button btnRedPrecio = (Button)ListaControles.Find(x => x.Nombre == "btn_RedPrecioVenta").Puntero;
            Button btnReporteArt = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteArticulo").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;

            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar, btnIngresoEgreso, btnStock, btnTipoUbic, btnIncPrecio, btnRedPrecio, btnReporteArt };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
                List<TextBox> listaTxt = new List<TextBox>() { txtBusqueda };
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                lblUsuario.Text = oUsuario.Nombre;
                //Verifico el pemriso que tiene ese usuario.
                oBLLUsuario.VerificarTipoUsuario(oUsuario);
                //Asigno a lista perfil, la carga de permiso.
                Perfil = oBLLPermiso.CargarPermisos(oUsuario.oPermiso.Id);

                //Recorro la lista de botones.
                foreach (Button boton in listaBotones)
                {
                    if (Perfil.Exists(x => x.Id == ((Button)boton).Tag.ToString()))
                    {
                        boton.Visible = true;
                       
                    }
                    else
                    {
                        boton.Visible = false;
                    }

                }
                //Recorro la lista de dgv.
                foreach (DataGridView d in listaDgv)
                {
                    if (Perfil.Exists(x => x.Id == ((DataGridView)d).Tag.ToString()))
                    {
                        d.Visible = true;
                    }
                    else
                    {
                        d.Visible = false;
                    }

                }
                //Recorro la lista de txt.
                foreach (TextBox t in listaTxt)
                {
                    if (Perfil.Exists(x => x.Id == ((TextBox)t).Tag.ToString()))
                    {
                        t.Visible = true;
                    }
                    else
                    {
                        t.Visible = false;
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void OrdenamientoExistencias()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLArticulo.ListarOrdenadoExistencias();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void OrdenamientoDescripcion()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLArticulo.ListarOrdenadoDescripcion();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void OrdenamientoPVenta()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLArticulo.ListarOrdenadoPVenta();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        private void ActivarComponentes()
        {
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero;
            TextBox txtDescp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero;
            ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;
            TextBox txtTalle = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero;
            TextBox txtPrecioPromo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero;
            TextBox txtObservacion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarArticulo").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarArticulo").Puntero;

            try
            {
                txtCodigo.Enabled = true;
                txtDescp.Enabled = true;
                cbMarca.Enabled = true;
                txtTalle.Enabled = true;
                txtPrecioCosto.Enabled = true; ;
                txtPrecioPromo.Enabled = true;
                txtObservacion.Enabled = true;
                cbEmpleado.Enabled = true;
                cbProveedor.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero;
            TextBox txtDescp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero;
            ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;
            TextBox txtTalle = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero;
            TextBox txtExistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero;
            TextBox txtStockMin = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero;
            TextBox txtPrecioPromo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero;
            TextBox txtObservacion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarArticulo").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarArticulo").Puntero;

            try
            {
                txtCodigo.Enabled = false;
                txtDescp.Enabled = false;
                cbMarca.Enabled = false;
                txtTalle.Enabled = false;
                txtExistencia.Enabled = false;
                txtStockMin.Enabled = false;
                txtStockMax.Enabled = false;
                txtPrecioCosto.Enabled = false;
                txtPrecioVenta.Enabled = false;
                txtPrecioPromo.Enabled = false;
                txtObservacion.Enabled = false;
                cbEmpleado.Enabled = false;
                cbProveedor.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoArt").Puntero;
            TextBox txtDescp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DescripcionArt").Puntero;
            ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;
            TextBox txtTalle = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TalleArt").Puntero;
            TextBox txtExistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciaArt").Puntero;
            TextBox txtStockMin = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMinArt").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMaxArt").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoArt").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaArt").Puntero;
            TextBox txtPrecioPromo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioPromArt").Puntero;
            TextBox txtObservacion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ObservacionArt").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

            try
            {
                txtCodigo.Text = string.Empty;
                txtDescp.Text = string.Empty;
                txtTalle.Text = string.Empty;
                txtExistencia.Text = Convert.ToInt32(0).ToString();
                txtStockMin.Text = Convert.ToInt32(0).ToString();
                txtStockMax.Text = Convert.ToInt32(0).ToString();
                txtPrecioCosto.Text = Convert.ToInt32(0).ToString();
                txtPrecioVenta.Text = Convert.ToInt32(0).ToString();
                txtPrecioPromo.Text = Convert.ToInt32(0).ToString();
                txtObservacion.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboMarca()
        {
            try
            {
                ComboBox cbMarca = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Marcas").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbMarca.DataSource = oBLLMarca.Listar();
                //Establezco el valor real.
                cbMarca.ValueMember = "Codigo";
                //Establezco el valor que muestro.
                cbMarca.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void CargarComboEmpleado()
        {
            try
            {
                ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbEmpleado.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor real.
                cbEmpleado.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbEmpleado.DisplayMember = "Dni";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }        
        }

        private void CargarComboProveedor()
        {
            try
            {
                ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedores").Puntero;

                //Establezco una instancia de BLL Descripcion con el metodo listar.
                cbProveedor.DataSource = oBLLProveedor.Listar();
                //Establezco el valor real.
                cbProveedor.ValueMember = "Id";
                //Establezco el valor que muestro.
                cbProveedor.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Alta(E_Articulo oArticulo)
        {
            try
            {
                oArticulo.Codigo = _codigo;
                oArticulo.Descripcion = _descripcion;
                oArticulo.oMarca.Codigo = _marca;
                oArticulo.Talle = _talle;
                oArticulo.Existencia = _existencia;
                oArticulo.stockMin = _stockMin;
                oArticulo.stockMax = _stockMax;
                oArticulo.precioCosto = _precioCosto;
                oArticulo.precioVenta = _precioVenta;
                oArticulo.precioPromocion = _precioPromo;
                oArticulo.oProveedor.Id = _idProveedor;
                oArticulo.Observacion = _observacion;
                oArticulo.oEmpleado.Dni = _empleado;

                oBLLArticulo.Alta(oArticulo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Articulo oArticulo)
        {
            try
            {
                //oArticulo.Codigo = _codigo;
                oArticulo.Descripcion = _descripcion;
                oArticulo.oMarca.Codigo = _marca;
                oArticulo.Talle = _talle;
                oArticulo.Existencia = _existencia;
                oArticulo.stockMin = _stockMin;
                oArticulo.stockMax = _stockMax;
                oArticulo.precioCosto = _precioCosto;
                oArticulo.precioVenta = _precioVenta;
                oArticulo.precioPromocion = _precioPromo;
                oArticulo.oProveedor.Id = _idProveedor;
                oArticulo.Observacion = _observacion;
                oArticulo.oEmpleado.Dni = _empleado;

                oBLLArticulo.Baja(oArticulo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Articulo oArticulo)
        {
            try
            {
                oArticulo.Codigo = _codigo;
                oArticulo.Descripcion = _descripcion;
                oArticulo.oMarca.Codigo = _marca;
                oArticulo.Talle = _talle;
                oArticulo.Existencia = _existencia;
                oArticulo.stockMin = _stockMin;
                oArticulo.stockMax = _stockMax;
                oArticulo.precioCosto = _precioCosto;
                oArticulo.precioVenta = _precioVenta;
                oArticulo.precioPromocion = _precioPromo;
                oArticulo.oProveedor.Id = _idProveedor;
                oArticulo.Observacion = _observacion;
                oArticulo.oEmpleado.Dni = _empleado;

                oBLLArticulo.Modificar(oArticulo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> Consultar(string pDescripcion)
        {
            try
            {
                return oBLLArticulo.Consultar(pDescripcion);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> Listar()
        {
            try
            {
                return oBLLArticulo.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}

