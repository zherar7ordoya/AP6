using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Conexion
    {
        SqlConnection _conexion;

        readonly string CadenaConexion =
            ConfigurationManager
            .ConnectionStrings["CadenaConexion"].ConnectionString;


        public SqlConnection RetornaConexion()
        {
            _conexion = new SqlConnection(CadenaConexion);
            return _conexion;
        }


        [Obsolete("Este método aún no se ha usado")]
        public SqlConnection RetornaConexion(string cadenaConexion)
        {
            _conexion = new SqlConnection(cadenaConexion);
            return _conexion;
        }
    }
}
