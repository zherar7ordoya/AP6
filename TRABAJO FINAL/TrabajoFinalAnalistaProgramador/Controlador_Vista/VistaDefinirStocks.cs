using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Controlador_Vista
{
    public class VistaDefinirStocks
    {
        System.Windows.Forms.Form frmDefinirStocks;
        BLL_Articulo oBLLArticulo;
        E_Articulo oArticulo;
        List<Control> ListaControles;

        public VistaDefinirStocks(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privadala referencia al formulario que llega al parámetro del constructor
                frmDefinirStocks = pForm;
                //Recorro el frmDefinirStocks.
                foreach (System.Windows.Forms.Control c in frmDefinirStocks.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_CalcularStockMin").Puntero).Click += btn_CalcularStockMin_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CalcularStockMax").Puntero).Click += btn_CalcularStockMax_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero).Click += btn_CancelarStocks_Click;
                frmDefinirStocks.Load += frmDefinirStocks_Load;

                oBLLArticulo = new BLL_Articulo();
                oArticulo = new E_Articulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmDefinirStocks_Load(object sender, EventArgs e)
        {
            try
            {
                DesactivarComponentes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //Boton Calcular stock minimo.
        private void btn_CalcularStockMin_Click(object sender, EventArgs e)
        {
            TextBox txtStockMin2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin2").Puntero;
            TextBox txtStockMin1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin1").Puntero;
            TextBox txtEntregaProv1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv1").Puntero;
            TextBox txtConsumoProm1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm1").Puntero;
            TextBox txtConsumoProm2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm2").Puntero;

            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de tiempo de entrega del proveedor.
                if (string.IsNullOrWhiteSpace(txtEntregaProv1.Text))
                {
                    MessageBox.Show("Debe ingresar el tiempo de entrega del articulo por parte del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv1.Focus();
                    return;
                }
                //Valido que el numero ingresado sea entero.
                Regex exp = new Regex("^[0-9]+$");

                if (!exp.IsMatch(txtEntregaProv1.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de entrega de proveedor. Debe ser un numero entero y mayor a 0", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de consumo promedio.
                if (string.IsNullOrWhiteSpace(txtConsumoProm1.Text))
                {
                    MessageBox.Show("Debe ingresar el consumo promedio del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtConsumoProm1.Focus();
                    return;
                }
                //Valido que no se escriban letras en el consumo promedio.
                Regex exp2 = new Regex("^([a-zA-Z])");
                if (exp2.IsMatch(txtConsumoProm1.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de consumo promedio. No debe contener letras.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que el tiempo de entrega no sea menor a 0.
                if (int.Parse(txtEntregaProv1.Text) <= 0)
                {
                    MessageBox.Show("El tiempo de entrega del proveedor debe ser mayor a 0!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv1.Focus();
                    return;
                }
                #endregion

                //Paso a una variable, el resultado que me trae el metodo.
                double resultado = CalcularStockMin(int.Parse(txtEntregaProv1.Text), double.Parse(txtConsumoProm1.Text));
                //Redondeo el valor del resultado, ya que los stocks se tratan con numeros enteros.
                Math.Round(resultado, 0);
                //Asigno al txt, el valor del calculo del stock minimo.
                txtStockMin1.Text = Convert.ToInt32(resultado).ToString();
                //Paso el stock minimo al otro txt.
                txtStockMin2.Text = txtStockMin1.Text;
                //Paso el consumo promedio al otro txt.
                txtConsumoProm2.Text = txtConsumoProm1.Text;
                //Asigno al objeto articulo el stock minimo calculado.
                oArticulo.stockMin = Convert.ToInt32(resultado); 
                //Activo componentes para calcular stock maximo.
                ActivarComponentes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }
        //Boton Calcular stock maximo.
        private void btn_CalcularStockMax_Click(object sender, EventArgs e)
        {
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMax").Puntero;
            TextBox txtEntregaProv2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv2").Puntero;
            TextBox txtConsumoProm2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm2").Puntero;
            TextBox txtStockMin2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin2").Puntero;
            TextBox txtStockMin1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin1").Puntero;
            TextBox txtEntregaProv1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv1").Puntero;
            TextBox txtConsumoProm1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm1").Puntero;

            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de tiempo de entrega del proveedor.
                if (string.IsNullOrWhiteSpace(txtEntregaProv2.Text))
                {
                    MessageBox.Show("Debe ingresar el tiempo de entrega del articulo por parte del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que el numero ingresado sea entero.
                Regex exp = new Regex("^[0-9]+$");

                if (!exp.IsMatch(txtEntregaProv2.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de entrega de proveedor. Debe ser un numero entero y mayor a 0", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de tiempo de entrega del proveedor.
                if (string.IsNullOrWhiteSpace(txtConsumoProm2.Text))
                {
                    MessageBox.Show("Debe ingresar el consumo promedio del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que no se escriban letras en el consumo promedio.
                Regex exp2 = new Regex("^([a-zA-Z])");
                if (exp2.IsMatch(txtConsumoProm2.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de consumo promedio. No debe contener letras.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de tiempo de entrega del proveedor.
                if (string.IsNullOrWhiteSpace(txtStockMin2.Text))
                {
                    MessageBox.Show("Debe ingresar el stock minimo del articulo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que no tenga letras el stock minimo.
                if (exp2.IsMatch(txtStockMin2.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de stock mínimo. No debe contener letras.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que lo valores ingresados sean mayores a 0.
                if (int.Parse(txtEntregaProv2.Text) <= 0)
                {
                    MessageBox.Show("El tiempo de entrega del proveedor debe ser mayor a 0!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que el tiempo de entrega de proveedor sea igual al del calculo del stock minimo.
                if (int.Parse(txtEntregaProv2.Text) != int.Parse(txtEntregaProv1.Text))
                {
                    MessageBox.Show("El tiempo de entrega del proveedor es distinto al utilizado en el calculo del stock mínimo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que el consumo promedio sea igual al del calculo del stock minimo.
                if (double.Parse(txtConsumoProm2.Text) != double.Parse(txtConsumoProm1.Text))
                {
                    MessageBox.Show("El consumo promedio diario del articulo es distinto al utilizado en el calculo del stock mínimo!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                //Valido que el stock minimo sea el mismo.
                if (int.Parse(txtStockMin2.Text) != int.Parse(txtStockMin1.Text))
                {
                    MessageBox.Show("El stock mínimo no coincide con el calculado recientemente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtEntregaProv2.Focus();
                    return;
                }
                #endregion

                //Asigno a una variable el calculo del stock maximo.
                double resultado = CalcularStockMax(int.Parse(txtEntregaProv2.Text), double.Parse(txtConsumoProm2.Text), int.Parse(txtStockMin2.Text));
                //Redondeo el valor del calculo.
                Math.Round(resultado, 0);
                //Asigno al txt el valor calculado.
                txtStockMax.Text = Convert.ToInt32(resultado).ToString();
                //Asigno al objeto, el valor del stock maximo.
                oArticulo.stockMax = Convert.ToInt32(resultado);
                ActivarComponentes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        //Boton Cancelar.
        private void btn_CancelarStocks_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        //Metodos.
        public double CalcularStockMin(int pTiempoEntrega, double pConsumoProm)
        {
            try
            {
                return oBLLArticulo.CalcularStockMin(pTiempoEntrega, pConsumoProm);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public double CalcularStockMax(int pTiempoEntrega, double pConsumoProm, int pStockMin)
        {
            try
            {
                return oBLLArticulo.CalcularStockMax(pTiempoEntrega, pConsumoProm, pStockMin);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            
        }

        private void Limpiar()
        {
            TextBox txtEntregaProv1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv1").Puntero;
            TextBox txtEntregaProv2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv2").Puntero;
            TextBox txtConsumoProm1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm1").Puntero;
            TextBox txtConsumoProm2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm2").Puntero;
            TextBox txtStockMin2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin2").Puntero;
            TextBox txtStockMin1 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin1").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMax").Puntero;

            try
            {
                txtConsumoProm1.Text = string.Empty;
                txtConsumoProm2.Text = string.Empty;
                txtEntregaProv1.Text = string.Empty;
                txtEntregaProv2.Text = string.Empty;
                txtStockMax.Text = string.Empty;
                txtStockMin1.Text = string.Empty;
                txtStockMin2.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
           
        }

        private void DesactivarComponentes()
        {
            TextBox txtEntregaProv2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv2").Puntero;
            TextBox txtConsumoProm2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm2").Puntero;
            TextBox txtStockMin2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin2").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMax").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_Guardar").Puntero;
            Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularStockMax").Puntero;

            try
            {
                txtEntregaProv2.Enabled = false;
                txtConsumoProm2.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                txtStockMin2.Enabled = false;
                btnCalcular.Enabled = false;
                txtStockMax.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            TextBox txtEntregaProv2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EntregaProv2").Puntero;
            TextBox txtConsumoProm2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ConsumoProm2").Puntero;
            TextBox txtStockMin2 = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMin2").Puntero;
            TextBox txtStockMax = (TextBox)ListaControles.Find(x => x.Nombre == "txt_StockMax").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_Guardar").Puntero;
            Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularStockMax").Puntero;

            try
            {
                txtEntregaProv2.Enabled = true;
                txtConsumoProm2.Enabled = true;
                btnCancelar.Enabled = true;
                btnGuardar.Enabled = true;
                txtStockMin2.Enabled = true;
                btnCalcular.Enabled = true;
                txtStockMax.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
