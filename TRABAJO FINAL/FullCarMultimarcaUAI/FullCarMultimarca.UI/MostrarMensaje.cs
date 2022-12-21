using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI
{
    /// <summary>
    /// Brinda servicio de mensajes a la GUI
    /// </summary>
    public static class MostrarMensaje
    {
        public static void Informacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
        }
        public static DialogResult Pregunta(string mensaje)
        {

            return MessageBox.Show(mensaje, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MostrarError(Exception ex)
        {
            //Si el error es personalizado lo trato como advertencia, dado que es un ERROR lanzado por el desarrollador
            if (ex is NegocioException)
            {                
               Advertencia(ex.Message);
            }
            else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
