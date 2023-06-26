using MVC.Controlador;
using MVC.Modelo;
using MVC.Vista;

Auto auto = new("March", 2019, 250000);
IVistaAuto vista = new VistaAuto();
ControladorAuto controlador = new(vista, auto);

while(controlador.Opcion != 3)
{
    controlador.DespliegaVista();
    controlador.Solicita();
}