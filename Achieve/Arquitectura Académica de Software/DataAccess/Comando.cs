using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Comando
    {
        SqlCommand Vcomando;


        private SqlCommand ObjComando(string SelectCommand, SqlConnection Conexion)
        {
            Vcomando = new SqlCommand
            {
                CommandText = SelectCommand,
                CommandType = CommandType.Text,
                Connection = Conexion
            };
            return Vcomando;
        }


        public DataTable ObjDataTable(string SelectCommand)
        {
            Conexion conexion = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter(ObjComando(SelectCommand, conexion.ObjConexion()));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void ActualizaBase(string TableName, DataTable dt)
        {
            Conexion conexion = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter(ObjComando("SELECT * FROM " + TableName, conexion.ObjConexion()));
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.Update(dt);
        }


        public DataTable ObjStructureTable(string TableName)
        {
            Conexion conexion = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter(ObjComando("SELECT * FROM " + TableName, conexion.ObjConexion()));
            DataTable dt = new DataTable();
            da.FillSchema(dt, SchemaType.Mapped);
            return dt;
        }
    }
}
