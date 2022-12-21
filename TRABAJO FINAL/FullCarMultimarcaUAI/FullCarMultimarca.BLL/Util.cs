using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
	/// <summary>
	/// Clase estática que ofrece métodos para ayudar a la gestión de la BLL
	/// </summary>
    public static class Util
    {		
		
		#region SOPORTE VALIDACIONES DE DATOS

		public static readonly string PatronValidacionDNI = @"^((\d{7}|\d{8}))$"; //Patrón de validación den DNI que debe tener entre 7 y 8 dígitos
		public static readonly string PatronValidacionCUIT = @"^[0-9]{2}-[0-9]{8}-[0-9]$"; //Patrón de validación CUIT				
		public static readonly string PatronValidacionCHASIS = @"^[A-Z0-9]{17}$"; //Valida que un chasis solo acepta numeros o letras exactamente 17 posiciones
		public static readonly string PatronValidacionEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"; //Patrón para validar un correo electrónico


		#endregion

		#region TEXTOS LOG

		public static readonly string Log_Alta = "ALTA";
		public static readonly string Log_Modificacion = "MODIFICACIÓN";
		public static readonly string Log_Baja = "BAJA";
		public static readonly string Log_Anulacion = "ANULACIÓN";

		#endregion

		#region METODOS VARIOS

		public static string RandomString(int length)
		{
			const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var constructor = new StringBuilder();

			for (var i = 0; i < length; i++)
			{
				Thread.Sleep(100);
				var c = pool[new Random().Next(0, pool.Length)];
				constructor.Append(c);
			}

			return constructor.ToString();
		}		

		#endregion

	}
}
