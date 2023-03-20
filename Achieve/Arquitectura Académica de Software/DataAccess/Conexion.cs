using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Conexion
    {
        SqlConnection VobjConexion;

        public SqlConnection ObjConexion()
        {
            VobjConexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GESTION;Integrated Security=True");
            return VobjConexion;
        }


        public SqlConnection ObjConexion(string QueStringDeConexion)
        {
            VobjConexion = new SqlConnection(QueStringDeConexion);
            return VobjConexion;
        }

    }
}
