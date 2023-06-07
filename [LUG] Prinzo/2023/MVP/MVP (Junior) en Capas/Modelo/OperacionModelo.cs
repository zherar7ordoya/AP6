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

namespace Modelo
{
    public class OperacionModelo
    {
        public double Suma(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
