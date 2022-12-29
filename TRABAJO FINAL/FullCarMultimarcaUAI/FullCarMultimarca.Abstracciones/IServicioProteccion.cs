using System.Data;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción para la inversión de dependencia en el servicio que ofrece métodos para llevar a cabo la protección
    /// </summary>
    public interface IServicioProteccion
    {
        object[] DataRowToArray(DataRow fila, string[] columnasAExcluir);
        object[] DataTableToArray(DataTable tabla, string columnaAGenerar);
        string ByteArrayToString(byte[] arrInput);
        string ObtenerCodigoHash(object[] array);
    }
}
