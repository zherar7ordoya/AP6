using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ServiciosDGV;

namespace Controlador_Vista
{
    public class VistaIngresoEgreso
    {
        System.Windows.Forms.Form frmIngresoEgreso;
        List<Control> ListaControles;
        BLL_Articulo oBLLArticulo;
        E_Articulo oArticulo;
        E_Movimiento oMovimiento;
        EdicionDGV oEdicionDgv;
        BLL_Empleado oBLLEmpleado;

        public VistaIngresoEgreso(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privadada referencia al formulario que llega al parámetro del constructor.
                frmIngresoEgreso = pForm;
                //Recorro el form en buscar de controles.
                foreach (System.Windows.Forms.Control c in frmIngresoEgreso.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }
                //Establezco una instancia del gb encontrado para recorrerlo y encontrar los elementos que hay dentro.
                GroupBox gb = (GroupBox)ListaControles.Find(x => x.Nombre == "gb_Articulo2").Puntero;

                foreach (System.Windows.Forms.Control c in gb.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero).CheckedChanged += rb_Egreso_CheckedChanged;
                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero).CheckedChanged += rb_Ingreso_CheckedChanged;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioVenta").Puntero).Click += btn_CalcularPrecioVenta_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero).Click += btn_AceptarMovimiento_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero).Click += btn_Cancelar_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioCosto").Puntero).Click += btn_CalcularPrecioCosto_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_TerminarMovimiento").Puntero).Click += btn_TerminarMovimiento_Click;
                frmIngresoEgreso.Load += frmIngresoEgreso_Load;
                oBLLArticulo = new BLL_Articulo();
                oArticulo = new E_Articulo();
                oMovimiento = new E_Movimiento();
                oEdicionDgv = new EdicionDGV();
                oBLLEmpleado = new BLL_Empleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmIngresoEgreso_Load(object sender, EventArgs e)
        {
            try
            {
                DesactivarComponentes();
                CargarComboEmpleado();
                VerficarStocksCalculados();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento del rb egreso.
        private void rb_Egreso_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            Button btnCalcularPVenta = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioVenta").Puntero;
            TextBox txtPVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;

            try
            {
                txtGanancia.Text = Convert.ToInt32(0).ToString();
                txtIva.Text = Convert.ToInt32(0).ToString();
                txtFlete.Text = Convert.ToInt32(0).ToString();
                txtPVentaNuevo.Text = Convert.ToInt32(0).ToString(); 
                txtGanancia.Enabled = false;
                txtIva.Enabled = false;
                txtFlete.Enabled = false;
                txtPVentaNuevo.Enabled = false;
                btnCalcularPVenta.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Evento del rb ingreso.
        private void rb_Ingreso_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            Button btnCalcularPVenta = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioVenta").Puntero;
            TextBox txtPVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;

            try
            {
                txtGanancia.Enabled = true;
                txtIva.Enabled = true;
                txtFlete.Enabled = true;
                txtPVentaNuevo.Enabled = true;
                btnCalcularPVenta.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Boton calcular precio costo.
        private void btn_CalcularPrecioCosto_Click(object sender, EventArgs e)
        {
            RadioButton rbIngreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero;
            RadioButton rbEgreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtExistencias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            TextBox txtPrecioCostoUnitario = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtPrecioCostoNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoNuevo").Puntero;
            Label lblCosto = (Label)ListaControles.Find(x => x.Nombre == "lbl_PrecioCosto2").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero;

            #region Validaciones
            //Validaciones.
            if (rbIngreso.Checked == false && rbEgreso.Checked == false)
            {
                MessageBox.Show("Debe ingresar el tipo de accion a realizarse!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de cantidad.
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de articulos que se estan manejando en el movimiento!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }
            //Valido que la cantidad sea un numero entero.
            Regex exp = new Regex("^[0-9]+$");

            if (!exp.IsMatch(txtCantidad.Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de cantidad. Debe ser un numero entero y mayor a 0", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //Valido que no quede en blanco el txt de precio de costo.
            if (string.IsNullOrWhiteSpace(txtPrecioCostoUnitario.Text))
            {
                MessageBox.Show("Debe ingresar el precio de costo del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtPrecioCostoUnitario.Focus();
                return;
            }
            //Valido que la cantidad sea mayor a 0.
            if (int.Parse(txtCantidad.Text) < 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }
            //Valido el formato de numero decimal.
            Regex exp2 = new Regex("^[0-9]*\\,?[0-9]*$");

            if (!exp2.IsMatch(txtPrecioCostoUnitario.Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de precio de costo. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            try
            {
                if (rbIngreso.Checked == true)
                {
                    //Asigno al txt de precio de costo nuevo, el valor correspondiente al calculo de PPP.
                    txtPrecioCostoNuevo.Text = CalculoPPP(int.Parse(txtCantidad.Text), int.Parse(txtExistencias.Text), decimal.Parse(txtPrecioCostoUnitario.Text), decimal.Parse(lblCosto.Text)).ToString("N2");
                }
                else if (rbEgreso.Checked == true)
                {
                    //Valido que me quede al menos un articulo en el deposito, segun pedido de cliente del sistema, ya sea para tener de muestra, para control, etc.
                    if (txtCantidad.Text == txtExistencias.Text)
                    {
                        MessageBox.Show("No puede egresar la misma cantidad de articulos de las que hay en existencia. \n" +
                            "Realice el pedido al proveedor correspondiente de manera urgente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //Asigno al txt de precio de costo nuevo, el valor correspondiente al calculo de PPP.
                    txtPrecioCostoNuevo.Text = CalculoPPPEgreso(int.Parse(txtCantidad.Text), int.Parse(txtExistencias.Text), decimal.Parse(txtPrecioCostoUnitario.Text), decimal.Parse(lblCosto.Text)).ToString("N2");
                }

                btnAceptar.Enabled = true;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        private void btn_CalcularPrecioVenta_Click(object sender, EventArgs e)
        {
            RadioButton rbIngreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero;
            RadioButton rbEgreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero;
            TextBox txtPrecioVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtExistencias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            TextBox txtPrecioCostoUnitario = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtPrecioVentaActual = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaActual").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero;
            TextBox txtPrecioCostoNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoNuevo").Puntero;

            try
            {
                #region Validaciones
                
                //Valido que no quede en blanco el txt de IVA.
                if (string.IsNullOrWhiteSpace(txtIva.Text))
                {
                    MessageBox.Show("Debe ingresar el porcentaje de IVA!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtIva.Focus();
                    return;
                }
                //Valido el formato de numero decimal.
                Regex exp3 = new Regex("^[0-9]*\\,?[0-9]*$");

                if (!exp3.IsMatch(txtIva.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de porcentaje de IVA. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el porcentaje de flete.
                if (string.IsNullOrWhiteSpace(txtFlete.Text))
                {
                    MessageBox.Show("Debe ingresar el porcentaje de flete!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtFlete.Focus();
                    return;
                }
                //Valido el formato de numero decimal.
                Regex exp4 = new Regex("^[0-9]*\\,?[0-9]*$");

                if (!exp4.IsMatch(txtFlete.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de porcentaje de flete. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de porcentaje de ganancia.
                if (string.IsNullOrWhiteSpace(txtGanancia.Text))
                {
                    MessageBox.Show("Debe ingresar el porcentaje de ganancia!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtGanancia.Focus();
                    return;
                }
                //Valido el formato de numero decimal.
                Regex exp5 = new Regex("^[0-9]*\\,?[0-9]*$");

                if (!exp5.IsMatch(txtGanancia.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de porcentaje de ganancia. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (rbIngreso.Checked == true)
                {
                    //Asigno al txt de precio de venta nuevo, el valor correspondiente al calculo de precio de venta.
                    txtPrecioVentaNuevo.Text = CalculoPrecioVenta(decimal.Parse(txtPrecioCostoNuevo.Text), decimal.Parse(txtIva.Text), decimal.Parse(txtFlete.Text), decimal.Parse(txtGanancia.Text)).ToString();
                }

                //Activo el boton para aceptar el movimiento.
                btnAceptar.Enabled = true;
                //Desactivo los txt para mayor seguridad y a modo de validacion, para que al apretar el boton aceptar no tenga que volver a validar los mismos campos.
                DesactivarComponentes2();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            
        }
        //Boton Aceptar movimiento.
        private void btn_AceptarMovimiento_Click(object sender, EventArgs e)
        {
            TextBox txtArticulo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Articulo").Puntero;
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
            TextBox txtPrecioCostoUnitario = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtPrecioVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtExistencias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            RadioButton rbIngreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero;
            RadioButton rbEgreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero;
            TextBox txtPrecioCostoNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoNuevo").Puntero;
            Button btnTerminar = (Button)ListaControles.Find(x => x.Nombre == "btn_TerminarMovimiento").Puntero;

            try
            {
                //Asigno valores.
                oArticulo.Codigo = txtArticulo.Text;
                oArticulo.Descripcion = lblCodigo.Text;
                oArticulo.oMarca.Codigo = int.Parse(lblMarca.Text);
                oArticulo.Talle = lblTalle.Text;
                oArticulo.precioCosto = decimal.Parse(txtPrecioCostoNuevo.Text);
                oArticulo.precioVenta = decimal.Parse(txtPrecioVentaNuevo.Text);
                oArticulo.precioPromocion = decimal.Parse(lblPromocion.Text);
                oArticulo.oProveedor.Id = int.Parse(lblProveedor.Text);
                oArticulo.oEmpleado.Dni = int.Parse(lblEmpleado.Text);
                oArticulo.stockMin = int.Parse(lblStockMin.Text);
                oArticulo.stockMax = int.Parse(lblStockMax.Text);

                //Asigno a las variables, el valor de los txtCantidad y txtExistencias, para luego actualizar las existencias actuales.
                int cantidad = int.Parse(txtCantidad.Text);
                int existenciaAct = int.Parse(txtExistencias.Text);

                if (rbIngreso.Checked == true)
                {
                    //Si es un ingreso sumo la cantidad que ingresa mas las existencias actuales. 
                    txtExistencias.Text = (cantidad + existenciaAct).ToString();

                    //Verifico que no me pase del stock maximo calculado.
                    if (int.Parse(txtExistencias.Text) > oArticulo.stockMax)
                    {
                        //Si las existencias actuales son igual a 0.
                        if (int.Parse(txtExistencias.Text) == Convert.ToInt32(0))
                        {
                            //Actualizo el valor del txt en 0.
                            txtExistencias.Text = "0";
                        }
                        //Si las existencias son distinto de 0.
                        else if (int.Parse(txtExistencias.Text) != 0)
                        {
                            //Actualizo el txt de existencias actuales en el valor en el que estaban,
                            txtExistencias.Text = (existenciaAct).ToString();
                        }
                        //Doy aviso que se esta sobrepasando el stock maximo.
                        MessageBox.Show("Esta superando el stock maximo del articulo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Retorno.
                        return;
                    }
                }
                else if (rbEgreso.Checked == true)
                {
                    //Si es un egreso resto las existecias actuales menos la cantidad actual. HACER ESTE CALCULO EN LA BLL.
                    txtExistencias.Text = (existenciaAct - cantidad).ToString();

                    //Verifico que no me pase del stock minimo calculado.
                    if (int.Parse(txtExistencias.Text) < oArticulo.stockMin)
                    {
                        //Doy aviso que se esta sobrepasando el stock minimo.
                        MessageBox.Show("El articulo supero el stock minimo. Recuerde realizar el pedido al proveedor correspondiente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //Si el articulo llego a su stock minimo, doy aviso que se realice el pedido al proveedor correspondiente.
                    else if (int.Parse(txtExistencias.Text) == oArticulo.stockMin)
                    {
                        MessageBox.Show("El articulo ha llegado a su stock minimo. Recuerde realizar el pedido al proveedor correspondiente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Asigno el valor correspondiente a la existencia.
                oArticulo.Existencia = int.Parse(txtExistencias.Text);
                //Aviso que el movimiento se realizo con exito.
                MessageBox.Show("Movimiento realizado con exito!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Activo el boton terminar movimiento.
                btnTerminar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } 
        }

        //Refresco valores del objeto para que cuando cierre el form ingreso/egreso se me actualice correctamente la grilla de articulos.
        private void btn_TerminarMovimiento_Click(object sender, EventArgs e)
        {
            TextBox txtArticulo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Articulo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;
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
            Label lblProveedor = (Label)ListaControles.Find(x => x.Nombre == "lbl_Proveedor2").Puntero;
            Label lblEmpleado = (Label)ListaControles.Find(x => x.Nombre == "lbl_Empleado2").Puntero;
            TextBox txtPrecioCostoUnitario = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtPrecioVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;
            TextBox txtExistencias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            TextBox txtPrecioCostoNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoNuevo").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            TextBox txtPVentaActual = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaActual").Puntero;
            RadioButton rbIngreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero;
            RadioButton rbEgreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero;

            try
            {
                if(rbIngreso.Checked == true)
                {
                    //Asigno valores.
                    oArticulo.Codigo = txtArticulo.Text;
                    oArticulo.Descripcion = lblDesc.Text;
                    oArticulo.oMarca.Codigo = int.Parse(lblMarca.Text);
                    oArticulo.Talle = lblTalle.Text;
                    oArticulo.Existencia = int.Parse(txtExistencias.Text);
                    oArticulo.stockMin = int.Parse(lblStockMin.Text);
                    oArticulo.stockMax = int.Parse(lblStockMax.Text);
                    oArticulo.precioCosto = decimal.Parse(txtPrecioCostoNuevo.Text);
                    oArticulo.precioVenta = decimal.Parse(txtPrecioVentaNuevo.Text);
                    oArticulo.precioPromocion = decimal.Parse(lblPromocion.Text);
                    oArticulo.oProveedor.Id = int.Parse(lblProveedor.Text);
                    oArticulo.oEmpleado.Dni = int.Parse(lblEmpleado.Text);
                }
                else if(rbEgreso.Checked == true)
                {
                    //Asigno valores.
                    oArticulo.Codigo = txtArticulo.Text;
                    oArticulo.Descripcion = lblDesc.Text;
                    oArticulo.oMarca.Codigo = int.Parse(lblMarca.Text);
                    oArticulo.Talle = lblTalle.Text;
                    oArticulo.Existencia = int.Parse(txtExistencias.Text);
                    oArticulo.stockMin = int.Parse(lblStockMin.Text);
                    oArticulo.stockMax = int.Parse(lblStockMax.Text);
                    oArticulo.precioCosto = decimal.Parse(txtPrecioCostoNuevo.Text);
                    oArticulo.precioVenta = decimal.Parse(lblPrecioVenta.Text);
                    oArticulo.precioPromocion = decimal.Parse(lblPromocion.Text);
                    oArticulo.oProveedor.Id = int.Parse(lblProveedor.Text);
                    oArticulo.oEmpleado.Dni = int.Parse(lblEmpleado.Text);
                }

                //Modifico.
                oBLLArticulo.Modificar(oArticulo);
                //Aviso.
                MessageBox.Show("Movimiento terminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cierro form.               
                frmIngresoEgreso.Close();                
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Cancelar.
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;

            try
            {
                Limpiar();
                btnAceptar.Enabled = false;
                txtCantidad.Enabled = true;
                txtPrecioCosto.Enabled = true;
                txtFlete.Enabled = true;
                txtGanancia.Enabled = true;
                txtIva.Enabled = true;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void DesactivarComponentes()
        {
            TextBox txtArticulo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Articulo").Puntero;
            TextBox txtExistencias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ExistenciasActuales").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaActual").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero;
            Button btnTerminar = (Button)ListaControles.Find(x => x.Nombre == "btn_TerminarMovimiento").Puntero;

            try
            {
                txtArticulo.Enabled = false;
                txtExistencias.Enabled = false;
                txtPrecioVenta.Enabled = false;
                btnAceptar.Enabled = false;
                btnTerminar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboEmpleado()
        {
            try
            {
                ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

                //Establezco una instancia de BLL Descripcion con el metodo listar.
                cbEmpleado.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor real.
                cbEmpleado.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbEmpleado.DisplayMember = "Dni";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes2()
        {
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;

            try
            {
                txtCantidad.Enabled = false;
                txtPrecioCosto.Enabled = false;
                txtIva.Enabled = false;
                txtFlete.Enabled = false;
                txtGanancia.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtPrecioVentaNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;

            try
            {
                txtCantidad.Text = string.Empty;
                txtFlete.Text = string.Empty;
                txtIva.Text = string.Empty;
                txtPrecioVentaNuevo.Text = string.Empty;
                txtGanancia.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Calculo precio promedio ponderado (precio de costo).
        public decimal CalculoPPP(int pCantidad, int pExistenciaActual, decimal pPrecioCostoActual, decimal pPrecioCostoAnterior)
        {
            try
            {
                return oBLLArticulo.CalculoPPP(pCantidad, pExistenciaActual, pPrecioCostoActual, pPrecioCostoAnterior);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }        
        }
        //Metodo calculo ppp para egreso.
        public decimal CalculoPPPEgreso(int pCantidad, int pExistenciaActual, decimal pPrecioCostoActual, decimal pPrecioCostoAnterior)
        {
            try
            {
                return oBLLArticulo.CalculoPPPEgreso(pCantidad, pExistenciaActual, pPrecioCostoActual, pPrecioCostoAnterior);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo para el calculo de precio de venta.
        public decimal CalculoPrecioVenta(decimal pPrecioCostoNuevo, decimal pIva, decimal pFlete, decimal pGanancia)
        {
            try
            {
                return oBLLArticulo.CalculoPrecioVenta(pPrecioCostoNuevo, pIva, pFlete, pGanancia);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }           
        }

        //Metodo para verificar que el articulo en cuestion tenga los stocks calculados.
        private void VerficarStocksCalculados()
        {
            Label lblStockMin = (Label)ListaControles.Find(x => x.Nombre == "lbl_StockMin2").Puntero;
            Label lblStockMax = (Label)ListaControles.Find(x => x.Nombre == "lbl_StockMax2").Puntero;

            try
            {
                //Si no hay stocks calculados.
                if(int.Parse(lblStockMin.Text) == 0 && int.Parse(lblStockMax.Text) == 0)
                {
                    //Desactivo todos los componentes, para evitar que se haga un movimiento.
                    DesactivarComponentes3();
                    //Aviso.
                    MessageBox.Show("Para poder realizar un movimiento, deben estar los stocks definidos!!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes3()
        {
            TextBox txtArticulo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Articulo").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPrecioCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoUnitario").Puntero;
            TextBox txtPrecioCostoNuevo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCostoNuevo").Puntero;
            TextBox txtIva = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IVA").Puntero;
            TextBox txtFlete = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Flete").Puntero;
            TextBox txtGanancia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Ganancia").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            RadioButton rbIngreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Ingreso").Puntero;
            RadioButton rbEgreso = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Egreso").Puntero;
            TextBox txtPrecioVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVentaNuevo").Puntero;
            Button btnCalcularPrecioCosto = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioCosto").Puntero;
            Button btnCalcularPrecioVenta = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularPrecioVenta").Puntero;
            Button btnAceptarMovimiento = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarMovimiento").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero;
            Button btnTerminarMovimiento = (Button)ListaControles.Find(x => x.Nombre == "btn_TerminarMovimiento").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;

            try
            {
                txtArticulo.Enabled = false;
                txtCantidad.Enabled = false;
                txtPrecioCosto.Enabled = false;
                txtPrecioCostoNuevo.Enabled = false;
                txtIva.Enabled = false;
                txtFlete.Enabled = false;
                txtGanancia.Enabled = false;
                cbEmpleado.Enabled = false;
                rbIngreso.Enabled = false;
                rbEgreso.Enabled = false;
                txtPrecioVenta.Enabled = false;
                btnCalcularPrecioCosto.Enabled = false;
                btnCalcularPrecioVenta.Enabled = false;
                btnAceptarMovimiento.Enabled = false;
                btnCancelar.Enabled = false;
                btnTerminarMovimiento.Enabled = false;
                dtFecha.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
