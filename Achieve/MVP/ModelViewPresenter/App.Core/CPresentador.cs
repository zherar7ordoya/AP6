namespace App.Core
{
    public class CPresentador
    {

        private readonly IVista _Vista;

        private decimal _Buffer             = 0;
        private char _OperacionActual       = ' ';
        private bool _OperacionCompletada   = false;

        public CPresentador(IVista vista) { this._Vista = vista; }

        public void PresionaBotonNumero(string valor)
        {
            if (_Vista.TextoPantalla == "0." || _OperacionCompletada)
            {
                _Vista.TextoPantalla = valor;
                _OperacionCompletada = false;
            }
            else
            { _Vista.TextoPantalla += valor; }
        }

        public void PresionaBotonOperacion(string operador)
        {
            if (_OperacionActual == ' ')
            {
                _OperacionActual = operador.Contains("+") ? '+' : operador[0];
                _Buffer = decimal.Parse(_Vista.TextoPantalla);
                _Vista.TextoPantalla = "0.";
            }
            else
            {
                decimal valor = decimal.Parse(_Vista.TextoPantalla);

                _Buffer = _OperacionActual switch
                {
                    '+' => (_Buffer + valor),
                    '-' => (_Buffer - valor),
                    'x' => (_Buffer * valor),
                    '/' => (_Buffer / valor),
                    _ => 0m
                };

                _Vista.TextoPantalla = _Buffer.ToString();
                _OperacionCompletada = true;
            }
        }

        public void PresionaBotonClear() {
            _Vista.TextoPantalla = "0.";
            _OperacionActual = ' ';
        }
    }
}
