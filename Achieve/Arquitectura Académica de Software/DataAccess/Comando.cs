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
        /** La clase SqlCommand tiene 3 constructores: 
         *		=> SqlCommand()
         * 		=> SqlCommand(commandText)
         * 		=> SqlCommand(commandText,  connection)
         *   Aquí se está usando el 3ro                 */
        SqlCommand Vcomando;


        private SqlCommand ObjComando(string SelectCommand, SqlConnection Conexion)
        {
            Vcomando = new SqlCommand
            {
                CommandText = SelectCommand,	// A  SQL  statement  or  the  name  of  a  stored  procedure
                CommandType = CommandType.Text,	// Cómo CommandText debe ser interpretado
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

        /** Un DataAdapter contiene 4 objetos que debemos conocer:
         *  =>  SelectCommand es el objeto encargado de realizar los trabajos
         *      de selección de datos con una fuente de datos dada. En sí, es
         *      el que se encarga de devolver y rellenar los datos de un origen
         *      de datos a un DataSet.
         *  =>  DeleteCommand es el objeto encargado de realizar las acciones
         *      de borrado de datos.
         *  =>  InsertCommand es el objeto encargado de realizar las acciones
         *      inserción de datos.
         *  =>  UpdateCommand es el objeto encargado de realizar las acciones
         *      de actualización de datos.                                   */
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
