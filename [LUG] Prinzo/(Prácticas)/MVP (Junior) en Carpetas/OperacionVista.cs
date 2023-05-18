/*
==========================================================================
Autor:          Gerardo Tordoya
Creación:       2023-05-18
Actualización:  XXXX-XX-XX
Descripción:    [C#] Implementando el patron MVP en .NET
URL:            https://nicolocodev.wordpress.com/2011/08/31/patronmvpnet/
==========================================================================
*/


#region ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| PIZARRA
/*
       Actualiza       ┌────────┐
       ┌──────────────►│ IVista │
       │               └────────┘
       │                   △
       │                   │
       │               ┌───┴────┐
       │               │ Vista  │◄────── Interacción del Usuario
       │               └───┬────┘
┌──────┴──────┐ Llamadas   │
│             │◄───────────┘
│ Presentador │
│             │◄───────────┐
└──────┬──────┘ Eventos    │
       │               ┌───┴────┐
       └──────────────►│ Modelo │
        Maneja         └────────┘


Entendemos entonces que:
      *=> El Modelo es el MODELO DE NEGOCIO como tal
      *=> La Vista será nuestra tecnología de INTERFAZ DE USUARIO
      *=> El Presentador será el encargado de desacoplar la comunicación
          entre el Modelo y la Vista
*/
#endregion


using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Aplicativo
{

    public partial class OperacionVista : Form, IOperacionVista
    {
        private readonly OperacionPresentador _presentador;

        public OperacionVista()
        {
            InitializeComponent();
            _presentador = new OperacionPresentador(this);
        }

        private void OperacionVista_Load(object sender, EventArgs e)
        {
            _presentador.IniciaVista();
        }

        private void Resultado_Click(object sender, EventArgs e)
        {
            _presentador.ActualizaVista();
        }

        #region ||||||||||||||||||||||||||| IMPLEMENTACIÓN DE «IOperacionVista»
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid integer Number")]
        public double Num1
        {
            // get { return !string.IsNullOrEmpty(Num1TextBox.Text) ? Convert.ToDouble(Num1TextBox.Text) : 0; }
            get { return Convert.ToDouble(Num1TextBox.Text); }
            set { Num1TextBox.Text = value.ToString(); }
        }

        public double Num2
        {
            get { return !string.IsNullOrEmpty(Num2TextBox.Text) ? Convert.ToDouble(Num2TextBox.Text) : 0; }
            set { Num2TextBox.Text = value.ToString(); }
        }

        public double Resultado
        {
            set { ResultadoLabel.Text = value.ToString(); }
        }
        #endregion
    }

}
