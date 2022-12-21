using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
    /// <summary>
    /// Servicio que ofrece validaciones varias
    /// </summary>
    public class ServicioValidacion : IServicioValidacion
    {

        public bool ValidarPatronString(string valor, string patronValidacion)
        {
            return Regex.IsMatch(valor, patronValidacion);
        }
        public bool ValidarPatronInt(int valor, string patronValidacion)
		{
            return ValidarPatronString(valor.ToString(), patronValidacion);
		}		
		public bool ValidarCuit(string cuit)
		{
			if (String.IsNullOrEmpty(cuit)) { return false; }
			string cuit_limpio = cuit.Replace("-", "");
			if (cuit_limpio.Length != 11) { return false; }
			long numero = Convert.ToInt64(cuit_limpio.Substring(0, 10));
			char digito = Convert.ToChar(cuit_limpio.Substring(10, 1));
			//calcular digito correcto
			char digitoCorrecto = DigitoVerificadorCuit(numero);
			//comparar y devolver resultado
			return (digitoCorrecto == digito);
		}
        public bool ValidarCBU(string cbu)
        {
            if (String.IsNullOrEmpty(cbu)) //Si está vacío lo damos por bueno ya que no es obligatorio
                return true;
            if (cbu.Length != 22)
                return false;

            int[] numeros = new int[22];
            int i = 0;
            foreach (char c in cbu)
            {
                numeros[i] = Convert.ToInt32(c.ToString());
                i++;
            }
            int suma = numeros[0] * 7 + numeros[1] + numeros[2] * 3 + numeros[3] * 9 + numeros[4] * 7 + numeros[5] + numeros[6] * 3;
            int ultdig = (10 - (suma % 10)) % 10; //Me quedo con el último digito de la resta (para los casos con digito verificador es cero).
            if (ultdig != numeros[7])
            {
                return false;
            }
            suma = numeros[8] * 3 + numeros[9] * 9 + numeros[10] * 7 + numeros[11] + numeros[12] * 3 + numeros[13] * 9 + numeros[14] * 7 + numeros[15] + numeros[16] * 3 + numeros[17] * 9 + numeros[18] * 7 + numeros[19] + numeros[20] * 3;
            ultdig = (10 - (suma % 10)) % 10;
            if (ultdig != numeros[21])
            {
                return false;
            }
            return true;
        }


        private char DigitoVerificadorCuit(long rut)
        {
            long contador = 0, sumaTotal = 0, ultimoDigito;
            do
            {
                rut = rut - (ultimoDigito = rut % 10);
                sumaTotal += ultimoDigito * (2 + contador++ % 6);
            } while ((rut /= 10) > 0);
            return (sumaTotal = 11 - (sumaTotal % 11)) == 10 ? 'K' : (sumaTotal == 11 ? '0' : (char)(sumaTotal + (int)'0'));
        }

    }
}
