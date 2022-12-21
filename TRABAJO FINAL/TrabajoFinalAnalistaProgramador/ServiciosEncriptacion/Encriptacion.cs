using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServiciosEncriptacion
{
    public class Encriptacion
    {
        public Encriptacion() { }

        //Metodo Encriptar simple. El ref significa que se pasa la variable por referencia.
        public ref string EncriptarSimple(ref string cadena)
        {
            //Creo variable.
            string resultado = string.Empty;
            //Paso la cadena codificada a la coleccion de bytes.
            byte[] encriptacion = System.Text.Encoding.Unicode.GetBytes(cadena);
            //Asigno a la variable la conversion de encriptacion en base 64.
            resultado = Convert.ToBase64String(encriptacion);
            //Paso el valor de resultado a la cadena de entrada.
            cadena = resultado;
            //Retorno.
            return ref cadena;
        }
        //Metodo Desencriptar simple.
        public ref string DesencriptarSimple(ref string cadenaEncriptada)
        {
            //Creo variable.
            string resultado = string.Empty;
            //Paso a la coleccion de bytes la cadena encriptada.
            byte[] cadena = Convert.FromBase64String(cadenaEncriptada);
            //Asigno a la variable, la cadena desencriptada.
            resultado = System.Text.Encoding.Unicode.GetString(cadena);
            //Paso el valor de resultado a la cadena de entrada.
            cadenaEncriptada = resultado;
            //Retorno.
            return ref cadenaEncriptada;
        }
    }
}
