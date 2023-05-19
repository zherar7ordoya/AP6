using System;


namespace Aplicativo
{
    // -------------------------------------------------------------------------
    // Presentador se encarga de desacoplar la comunicación entre Modelo y Vista
    // -------------------------------------------------------------------------
    public class OperacionPresentador
    {
        private readonly IOperacionVista _vista;
        private readonly OperacionModelo _modelo;

        public OperacionPresentador(IOperacionVista vista)
        {
            _vista = vista;
            _modelo = Fabrica.CreaOperacionModelo();

            // Evento: Momento 3 => Suscripción
            // (se hace en la clase que posee la referencia al objeto dueño del evento)

            // 2 OPCIONES:                         <| Depende de la complejidad

            // ...suscribir a un método nombrado
            // _vista.Actualizar += ActualizaVista;

            // ...o suscribir a un método anónimo.
            _vista.Actualizar += delegate (object sender, EventArgs e)
            {
                _vista.Resultado = _modelo.Suma(_vista.Num1, _vista.Num2);
            };
        }

        // Evento: Momento 4 => Ejecución
        // (el método pertenece a la clase que posee la referencia)
        public void ActualizaVista(object sender, EventArgs e)
        {
            _vista.Resultado = _modelo.Suma(_vista.Num1, _vista.Num2);
        }

        public void IniciaVista()
        {
            _vista.Num1 = 0;
            _vista.Num2 = 0;
            _vista.Resultado = 0;
        }
    }
}
