/**
 * Presentador se encarga de desacoplar la comunicación entre Modelo y Vista.
 */


namespace Aplicativo
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
