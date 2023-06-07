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

using Modelo;

namespace Presentador
{
    public class OperacionPresentador
    {
        private readonly IOperacionVista _vista;
        private readonly OperacionModelo _modelo;

        public OperacionPresentador(IOperacionVista vista)
        {
            _vista = vista;
            _modelo = new OperacionModelo();
        }

        public void IniciaVista()
        {
            _vista.Num1 = 0;
            _vista.Num2 = 0;
            _vista.Resultado = 0;
        }

        public void ActualizaVista()
        {
            _vista.Resultado = _modelo.Suma(_vista.Num1, _vista.Num2);
        }
    }
}
