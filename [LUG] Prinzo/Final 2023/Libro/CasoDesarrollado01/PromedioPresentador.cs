using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasoDesarrollado01
{
    /// <summary>
    ///             VISTA (View)            => GUI
    ///             PRESENTADOR(Presenter)  => BLL
    ///             MODELO(Model)           => DAT
    /// </summary>
    public class PromedioPresentador
    {
        readonly IPromedioModelo modelo;
        readonly IPromedioVista vista;
        PromedioVista formulario = new PromedioVista();

        public PromedioPresentador(IPromedioModelo modelo, IPromedioVista vista)
        {
            this.modelo = modelo;

            this.vista = vista;
            this.vista.Calcular += Calcula;
            this.vista.Limpiar += Limpia;
            this.vista.Salir += Sale;
            formulario.Show();
        }

        public void Calcula(object sender, EventArgs e)
        {
            modelo.Promediar(new List<string>
            {
                vista.Nota1,
                vista.Nota2,
                vista.Nota3,
                vista.Nota4
            }
            .ConvertAll(TryParseNumero));

            vista.Promedio = Convert.ToString(modelo.Promedio);
        }

        public void Limpia(object sender, EventArgs e)
        {
            modelo.Limpiar();

            foreach (Control control in formulario.Controls)
            {
                if (control is TextBox)
                {
                    control.ResetText();
                }
            }
        }

        public void Sale(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public decimal TryParseNumero(string input)
        {
            return decimal.TryParse(input, out decimal numero) ? numero : 0;
        }
    }
}
