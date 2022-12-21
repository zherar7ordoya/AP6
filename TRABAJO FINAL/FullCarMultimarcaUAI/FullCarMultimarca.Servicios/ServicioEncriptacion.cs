using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
	/// <summary>
	/// Provee metodos de encriptación
	/// </summary>
    public class ServicioEncriptacion : IServicioEncriptacion
    {
		private readonly string _SemillaEncriptacion = "MReina_SecretoClave";

		private string EncriptarSHA(byte[] bytes, string clave)
		{
			string lClave = _SemillaEncriptacion + clave;
			byte[] miClave = System.Text.Encoding.UTF8.GetBytes(lClave);

			HMACSHA1 miHMAC = new HMACSHA1(miClave);
			CryptoStream cs = new CryptoStream(Stream.Null, miHMAC, CryptoStreamMode.Write);
			cs.Write(bytes, 0, bytes.Length);
			cs.Close();

			return Convert.ToBase64String(miHMAC.Hash);
		}		
		private string EncriptarSHA(string texto, string clave)
		{
			byte[] Datos = System.Text.Encoding.UTF8.GetBytes(texto);
			return EncriptarSHA(Datos, clave);
		}
		public string EncriptarSHA(string texto)
		{
			return EncriptarSHA(texto, String.Empty);
		}

		public string Encriptar3DES(string texto)
		{
			try
			{
				byte[] keyArray;
				byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

				//Se utilizan las clases de encriptación MD5
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_SemillaEncriptacion));
				hashmd5.Clear();

				//Algoritmo TripleDES
				TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
				tdes.Key = keyArray;
				tdes.Mode = CipherMode.ECB;
				tdes.Padding = PaddingMode.PKCS7;
				ICryptoTransform cTransform = tdes.CreateEncryptor();
				byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
				tdes.Clear();

				//se regresa el resultado en forma de una cadena
				texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
			}
			catch (Exception)
			{

			}
			return texto;
		}
		public string Desencriptar3DES(string textoEncriptado)
		{
			try
			{
				byte[] keyArray;
				byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

				//algoritmo MD5
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_SemillaEncriptacion));

				hashmd5.Clear();

				TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

				tdes.Key = keyArray;
				tdes.Mode = CipherMode.ECB;
				tdes.Padding = PaddingMode.PKCS7;

				ICryptoTransform cTransform = tdes.CreateDecryptor();
				byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
				tdes.Clear();
				textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

			}
			catch (Exception)
			{

			}
			return textoEncriptado;
		}
	}
}
