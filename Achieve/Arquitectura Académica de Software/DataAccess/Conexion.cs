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
		// La clase SqlConnection tiene 2 constructores:
        SqlConnection VobjConexion;


        // 1er constructor => new  SqlConnection()
        public SqlConnection ObjConexion()
        {
            VobjConexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GESTION;Integrated Security=True");
            return VobjConexion;
        }
        

		// 2do constructor => new  SqlConnection(connectionString) 
        public SqlConnection ObjConexion(string QueStringDeConexion)
        {
            VobjConexion = new SqlConnection(QueStringDeConexion);
            return VobjConexion;
        }
        
        // Aunque se termina usando el 2do constructor en ambos casos
    }
}
