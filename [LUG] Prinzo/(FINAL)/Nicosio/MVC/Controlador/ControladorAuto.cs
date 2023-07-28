using MVC.Modelo;
using MVC.Vista;
using static System.Console;

namespace MVC.Controlador
{
    public class ControladorAuto
    {
        private IVistaAuto vista;
        private Auto modelo;
        private int opcion;

        public ControladorAuto(IVistaAuto vista, Auto modelo)
        {
            this.vista = vista;
            this.modelo = modelo;
        }

        public int Opcion { get => opcion; set => opcion = value; }

        public void DespliegaVista()
        {
            vista.DespliegaAuto(modelo);
        }

        public void Solicita()
        {
            opcion = vista.SolicitaEntrada();

            if (opcion == 1)
            {
                ActualizaCosto(modelo.Costo * 1.15);
            }
            if (opcion == 2)
            {
                ActualizaModelo();
            }
        }

        public void ActualizaCosto(double costo)
        {
            modelo.Costo = costo;
        }

        public void ActualizaModelo()
        {
            WriteLine("¿Modelo?:");
            modelo.Modelo = Convert.ToInt32(ReadLine());
        }
    }
}
