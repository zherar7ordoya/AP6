using System.Data.SqlClient;
using System.Data;


namespace DataAccess
{
    public class Comando
    {
        SqlCommand _comando;


        private SqlCommand RetornaComando(string sentencia, SqlConnection conexion)
        {
            _comando = new SqlCommand
            {
                CommandText = sentencia,
                CommandType = CommandType.Text,
                Connection = conexion
            };
            return _comando;
        }


        public DataTable RetornaTablaCompleta(string sentencia)
        {
            Conexion conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando(sentencia, conexion.RetornaConexion()));
            
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }


        public DataTable RetornaTablaEstructura(string nombre)
        {
            Conexion conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando($"SELECT * FROM {nombre}", conexion.RetornaConexion()));

            DataTable tabla = new DataTable();
            adaptador.FillSchema(tabla, SchemaType.Mapped);
            return tabla;
        }


        public void ActualizaBase(string nombre, DataTable tabla)
        {
            Conexion conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando($"SELECT * FROM {nombre}", conexion.RetornaConexion()));
            
            SqlCommandBuilder builder = new SqlCommandBuilder(adaptador);
            adaptador.InsertCommand = builder.GetInsertCommand();
            adaptador.DeleteCommand = builder.GetDeleteCommand();
            adaptador.UpdateCommand = builder.GetUpdateCommand();

            adaptador.Update(tabla);
        }
    }
}
