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
using System.Windows.Forms;

namespace Aplicativo
{
    // ---------------------------------------------
    // Vista es la tecnología de INTERFAZ DE USUARIO
    // ---------------------------------------------
    public partial class OperacionVista : Form, IOperacionVista
    {
        private readonly OperacionPresentador _presentador;

        // Evento: Momento 1 => Declaración
        // (se hace en clase propietaria del evento)
        public event EventHandler Actualizar;

        public OperacionVista()
        {
            InitializeComponent();
            _presentador = Fabrica.CreaOperacionPresentador(this);
        }

        private void OperacionVista_Load(object sender, EventArgs e)
        {
            _presentador.IniciaVista();

            // Evento: Momento 2 => Desencadenamiento
            // (se produce en clase propietaria del evento)
            // ResultadoButton.Click += delegate { Actualizar?.Invoke(this, EventArgs.Empty); };
            ResultadoButton.Click += Actualizar; 
        }


        #region ||||||||||||||||||||||||||| IMPLEMENTACIÓN DE «IOperacionVista»
        public double Num1
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Num1TextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Num1 tiene que ser un número válido.");
                }
                return 0;
            }
            set { Num1TextBox.Text = value.ToString(); }
        }

        public double Num2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Num2TextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Num2 tiene que ser un número válido.");
                }
                return 0;

            }
            set { Num2TextBox.Text = value.ToString(); }
        }

        public double Resultado
        {
            set { ResultadoLabel.Text = value.ToString(); }
        }
        #endregion
    }

}
