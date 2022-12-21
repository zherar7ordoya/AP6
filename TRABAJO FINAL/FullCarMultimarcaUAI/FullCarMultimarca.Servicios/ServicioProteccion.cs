using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
    /// <summary>
    /// Provee los metodos necesarios para brindar protección vertical y horizonal sobre aquellos elementos que lo requieran
    /// </summary>
    public class ServicioProteccion : IServicioProteccion
    {

        public object[] DataRowToArray(DataRow fila, string[] columnasAExcluir)
        {
            if (columnasAExcluir.Length == 0)
                return fila.ItemArray;
            else
            {
                object[] array = new object[fila.Table.Columns.Count - columnasAExcluir.Length];
                int indiceDestino = 0;
                for (int i = 0; i < fila.Table.Columns.Count; i++)
                {
                    if (!columnasAExcluir.Contains(fila.Table.Columns[i].ColumnName))
                    {
                        array[indiceDestino] = fila.ItemArray[i];
                        indiceDestino++;
                    }
                }
                return array;
            }

        }
        public object[] DataTableToArray(DataTable tabla, string columnaAGenerar)
        {
            int registros = tabla.Rows.Count;
            object[] array = new object[registros];
            for (int i = 0; i < registros; i++)
                array[i] = tabla.Rows[i][columnaAGenerar];
            return array;
        }
        public string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        public string ObtenerCodigoHash(object[] array)
        {
            var fuenteStr = string.Join(", ", array);
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(fuenteStr);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }                
                
    }
}
