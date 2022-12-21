using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
    /// <summary>
    /// Clase que brinda servicio de armar el DataSet y actualizaciones
    /// </summary>
    public class ServicioMigracion : IServicioMigracion
    {
        public ServicioMigracion()
        {

        }


        /// <summary>
        /// Cada ver que se genere una actualización de la base de datos se sube la versión
        /// </summary>
        private int versionVigente = 28;

        #region BASE DE DATOS DE BACKUPS

        public DataSet CrearBaseDatosBackup(string nombrePrimerBackup, DateTime fechaYHora)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(CrearTablaCatalogBackup());

            DataTable tabla = dataSet.Tables["Catalogo"];
            DataRow dr = tabla.NewRow();
            dr["FechaYHora"] = fechaYHora;
            dr["Creador"] = "admin";
            dr["NombreArchivo"] = nombrePrimerBackup;
            dr["Descripcion"] = "Backup inicial";
            tabla.Rows.Add(dr);

            return dataSet;
        }
        private DataTable CrearTablaCatalogBackup()
        {
            var tabla = new DataTable("Catalogo");
            DataColumn columna;          

            columna = new DataColumn();
            columna.ColumnName = "FechaYHora";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Creador";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "NombreArchivo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["FechaYHora"] };

            return tabla;
        }

        #endregion

        #region BASE DE DATOS DE LOGS

        public DataSet CrearBaseDatosLogs()
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(CrearTablaLog());

            return dataSet;
        }
        private DataTable CrearTablaLog()
        {
            var tabla = new DataTable("Log");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "CodigoTransaccion";
            columna.DataType = typeof(Guid);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Fecha";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Usuario";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Operacion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["CodigoTransaccion"] };

            return tabla;
        }


        #endregion

        #region BASE DE DATOS PRINCIPAL

        public DataSet CrearBaseDatosFullCar()
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(CrearTablaVersionBD());
            dataSet.Tables.Add(CrearTablaFlagsSeguridad());
            dataSet.Tables.Add(CrearTablaUsuario());            
            dataSet.Tables.Add(CrearTablaPermiso());
            dataSet.Tables.Add(CrearTablaPermisoPermiso());
            dataSet.Tables.Add(CrearTablaProteccionDatos());
       

            //Relación Permiso-Permiso
            DataRelation rel = new DataRelation("DR_Permiso_Permiso_1", dataSet.Tables["Permiso"].Columns["Codigo"], dataSet.Tables["PermisoPermiso"].Columns["CodigoPermiso1"]);
            dataSet.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            rel = new DataRelation("DR_Permiso_Permiso_2", dataSet.Tables["Permiso"].Columns["Codigo"], dataSet.Tables["PermisoPermiso"].Columns["CodigoPermiso2"]);
            dataSet.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;
                                  
            //Relacion Usuario-Permiso
            rel = new DataRelation("DR_Usuario_Permiso", dataSet.Tables["Permiso"].Columns["Codigo"], dataSet.Tables["Usuario"].Columns["CodigoPermiso"]);
            dataSet.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;

            //Precarga de datos
            PrecargarDatos(dataSet);

            return dataSet;
        }
        public void ActualizarVersionFullCar(DataSet ds)
        {
            int versionBD = Convert.ToInt32(ds.Tables["VersionBD"].Rows[0]["Version"]);
            while(versionBD < versionVigente)
            {
                versionBD++;
                string metodo = $"AplicarCambiosVersion{versionBD}";
                MethodInfo methodInfo = this.GetType()
                    .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
                methodInfo.Invoke(this, new object[] { ds });
            }
            ds.Tables["VersionBD"].Rows[0]["Version"] = versionBD;
        }

        private DataTable CrearTablaVersionBD()
        {
            var tabla = new DataTable("VersionBD");
            DataColumn columna;
            columna = new DataColumn();
            columna.ColumnName = "Version";
            columna.DataType = typeof(Int32);
            tabla.Columns.Add(columna);          

            return tabla;
        }
        private DataTable CrearTablaFlagsSeguridad()
        {
            var tabla = new DataTable("FlagsSeguridad");
            DataColumn columna;
                        
            columna = new DataColumn();
            columna.ColumnName = "MinimoCaracteresPassword";
            columna.DataType = typeof(Int32);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "IntentosBloqueoPassword";
            columna.DataType = typeof(Int32);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DiasVigenciaPassword";
            columna.DataType = typeof(Int32);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DebeContenerMayuscula";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DebeContenerCaracterEspecial";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DebeContenerNumero";
            columna.DataType = typeof(bool);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DebeContenerMinuscula";
            columna.DataType = typeof(bool);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);          

            return tabla;
        }
        private DataTable CrearTablaUsuario()
        {
            var tabla = new DataTable("Usuario");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Legajo";
            columna.DataType = typeof(Int32);            
            tabla.Columns.Add(columna);            

            columna = new DataColumn();
            columna.ColumnName = "Logon";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Nombre";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Apellido";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Bloqueado";
            columna.DataType = typeof(bool);
            columna.DefaultValue = false;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activo";
            columna.DataType = typeof(bool);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Password";
            columna.DataType = typeof(string);            
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "FechaUltimoCambioPassword";
            columna.DataType = typeof(DateTime);            
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PalabraClave";
            columna.DataType = typeof(string);
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "RespuestaClave";
            columna.DataType = typeof(string);
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoPermiso";
            columna.DataType = typeof(string);
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoHash";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Legajo"] };           
         

            return tabla;
        }      
        private DataTable CrearTablaPermiso()
        {
            var tabla = new DataTable("Permiso");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Codigo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Tipo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);         

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Codigo"] };            

            return tabla;

        }
        private DataTable CrearTablaPermisoPermiso()
        {
            var tabla = new DataTable("PermisoPermiso");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "CodigoPermiso1";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoPermiso2";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Otorgado";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["CodigoPermiso1"] , tabla.Columns["CodigoPermiso2"] }; 

            return tabla;
        }
        private DataTable CrearTablaProteccionDatos()
        {
            var tabla = new DataTable("ProteccionDatos");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Tabla";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoHash";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Tabla"] };

            return tabla;
        }     

        private void PrecargarDatos(DataSet ds)
        {
            //Version de BD 0
            var tabla = ds.Tables["VersionBD"];
            tabla.Rows.Add(0);

            //Flags Seguridad
            tabla = ds.Tables["FlagsSeguridad"];
            tabla.Rows.Add(6, 3, 30, true, true, true, true);

            //Permisos
            tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1001";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Usuarios";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS1002";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Parametros de Seguridad";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS1003";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver Logs del Sistema";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS1004";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Permisos";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS1005";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Backups";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PCADMIN";
            dr["Tipo"] = "PermisoCompuesto";
            dr["Descripcion"] = "Administrador";
            tabla.Rows.Add(dr);

            //Permiso-Permiso
            tabla = ds.Tables["PermisoPermiso"];
            dr = tabla.NewRow();
            dr["CodigoPermiso1"] = "PCADMIN";
            dr["CodigoPermiso2"] = "PS1001";
            dr["Otorgado"] = true;
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["CodigoPermiso1"] = "PCADMIN";
            dr["CodigoPermiso2"] = "PS1002";
            dr["Otorgado"] = true;
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["CodigoPermiso1"] = "PCADMIN";
            dr["CodigoPermiso2"] = "PS1003";
            dr["Otorgado"] = false;
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["CodigoPermiso1"] = "PCADMIN";
            dr["CodigoPermiso2"] = "PS1004";
            dr["Otorgado"] = true;
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["CodigoPermiso1"] = "PCADMIN";
            dr["CodigoPermiso2"] = "PS1005";
            dr["Otorgado"] = true;
            tabla.Rows.Add(dr);

            //Usuario
            tabla = ds.Tables["Usuario"];
            dr = tabla.NewRow();
            dr["Legajo"] =999;
            dr["Logon"] = "admin";
            dr["Nombre"] = "Martin";
            dr["Apellido"] = "Reina";
            dr["Password"] = "SnlSNMHqhpO63pgHJPFghXKtS2U="; //1234;         
            dr["CodigoPermiso"] = "PCADMIN";
            tabla.Rows.Add(dr);

            //Proteccion Datos
            tabla = ds.Tables["ProteccionDatos"];
            dr = tabla.NewRow();
            dr["Tabla"] = "Usuario";            
            tabla.Rows.Add(dr);
        }


        //v1 - TABLA MARCA
        private void AplicarCambiosVersion1(DataSet ds)
        {
            ds.Tables.Add(CrearTablaMarca());

            //Agregar permiso            
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1006";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Marcas";
            tabla.Rows.Add(dr);
        }
        private DataTable CrearTablaMarca()
        {
            var tabla = new DataTable("Marca");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "MarcaID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activa";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["MarcaID"] };

            return tabla;

        }


        //v2 - TABLA MODELO
        private void AplicarCambiosVersion2(DataSet ds)
        {
            ds.Tables.Add(CrearTablaModelo());

            //Agregar referencia a Marca
            //Relación Marca-Modelo
            DataRelation rel = new DataRelation("DR_Marca_Modelo", ds.Tables["Marca"].Columns["MarcaID"], ds.Tables["Modelo"].Columns["MarcaID"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;


            //Agregar permiso            
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1007";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Modelos";
            tabla.Rows.Add(dr);
        }
        private DataTable CrearTablaModelo()
        {
            var tabla = new DataTable("Modelo");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Codigo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Tipo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "MarcaID";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activo";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PrecioPublico";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);        

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Codigo"] };

            return tabla;

        }

        //v3 - TABLA COLOR UNIDAD
        private void AplicarCambiosVersion3(DataSet ds)
        {
            ds.Tables.Add(CrearTablaColorUnidad());

            //Agregar permiso            
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1008";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Colores";
            tabla.Rows.Add(dr);
        }
        private DataTable CrearTablaColorUnidad()
        {
            var tabla = new DataTable("ColorUnidad");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "ColorID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activo";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["ColorID"] };

            return tabla;

        }

        //v4 - PARAMETROS EMPRESA y FORMAS DE PAGO
        private void AplicarCambiosVersion4(DataSet ds)
        {
            //Crear tablas
            ds.Tables.Add(CrearTablaFormaPago());
            ds.Tables.Add(CrearTablaFlagsEmpresa());

            //Relación FormaPago-FlagsEmpresa
            DataRelation rel = new DataRelation("DR_FormaPago_Parametro", ds.Tables["FormaPago"].Columns["FormaPagoID"], ds.Tables["FlagsEmpresa"].Columns["FormaPagoContadoDefault"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1009";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Formas de Pago";
            tabla.Rows.Add(dr);
            
            dr = tabla.NewRow();
            dr["Codigo"] = "PS1010";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Parámetros Ventas";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS1011";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Parámetros Comisiones";
            tabla.Rows.Add(dr);

            //Precargar Forma de pago default
            //Usuario
            tabla = ds.Tables["FormaPago"];
            dr = tabla.NewRow();            
            dr["Descripcion"] = "Contado";
            dr["Tipo"] = "FormaPagoContado";
            dr["Activa"] = true;
            tabla.Rows.Add(dr);

            //Precargar datos flags
            tabla = ds.Tables["FlagsEmpresa"];
            tabla.Rows.Add(7,10, 1,3,0.8M,5,1,10,1.2M,15000);

        }
        private DataTable CrearTablaFormaPago()
        {
            var tabla = new DataTable("FormaPago");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "FormaPagoID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Tipo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "ArancelGasto";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activa";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["FormaPagoID"] };

            return tabla;

        }
        private DataTable CrearTablaFlagsEmpresa()
        {
            var tabla = new DataTable("FlagsEmpresa");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeCoberturaARecuperar";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeGastoPatentamiento";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "FormaPagoContadoDefault";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "DiasRetroactivoDeterminacionPauta";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeComisionN1";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CantidadMinimaN2";
            columna.DataType = typeof(int);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeComisionN2";
            columna.DataType = typeof(decimal);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CantidadMinimaN3";
            columna.DataType = typeof(int);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeComisionN3";
            columna.DataType = typeof(decimal);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "ImportePremioVolumen";
            columna.DataType = typeof(decimal);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            return tabla;

        }

        //v5 - TABLA PROVINCIAS, CLIENTES Y CONTACTOS
        private void AplicarCambiosVersion5(DataSet ds)
        {
            //Crear tablas
            ds.Tables.Add(CrearTablaProvincia());
            ds.Tables.Add(CrearTablaTipoContacto());
            ds.Tables.Add(CrearTablaCliente());
            ds.Tables.Add(CrearTablaContacto());

            //Agregar referencia de Cliente
            //Relación Operacion-Unidad
            DataRelation rel = new DataRelation("DR_Contacto_TipoContacto", ds.Tables["TipoContacto"].Columns["TipoContactoID"], ds.Tables["Contacto"].Columns["Tipo"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;            

            //Relación Cliente-Provincia
            rel = new DataRelation("DR_Cliente_Provincia", ds.Tables["Provincia"].Columns["Nombre"], ds.Tables["Cliente"].Columns["Provincia"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;

            //Relacion Cliente-Telefono
            rel = new DataRelation("DR_Cliente_Contacto", ds.Tables["Cliente"].Columns["ClienteID"], ds.Tables["Contacto"].Columns["ClienteID"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1014";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Tipos de Contactos";
            tabla.Rows.Add(dr);

            //Precargar las provincias            
            tabla = ds.Tables["Provincia"];
            dr = tabla.NewRow();
            dr["Nombre"] = "Buenos Aires";            
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "CABA";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Entre Ríos";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Corrientes";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Misiones";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Santa Fe";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Chaco";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Formosa";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Cordoba";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Santiago del Estero";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "San Luis";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "La Pampa";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Rio Negro";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Chubut";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Santa Cruz";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Tierra del Fuego";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Neuquen";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Mendoza";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "San Juan";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "La Rioja";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Catamarca";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Tucuman";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Salta";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Nombre"] = "Jujuy";
            tabla.Rows.Add(dr);

        }
        private DataTable CrearTablaProvincia()
        {
            var tabla = new DataTable("Provincia");
            DataColumn columna;         

            columna = new DataColumn();
            columna.ColumnName = "Nombre";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);            

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Nombre"] };

            return tabla;

        }
        private DataTable CrearTablaTipoContacto()
        {
            var tabla = new DataTable("TipoContacto");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "TipoContactoID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Descripcion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "ExpresionValidacion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "TextoAyuda";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Activo";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["TipoContactoID"] };

            return tabla;

        }
        private DataTable CrearTablaCliente()
        {
            var tabla = new DataTable("Cliente");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "ClienteID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CUIT";
            columna.DataType = typeof(string);            
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Nombre";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Apellido";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Direccion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Localidad";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Provincia";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);



            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["ClienteID"] };

            return tabla;

        }
        private DataTable CrearTablaContacto()
        {
            var tabla = new DataTable("Contacto");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "ClienteID";
            columna.DataType = typeof(Int32);         
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Tipo";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Valor";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["ClienteID"], tabla.Columns["Valor"], tabla.Columns["Tipo"] };

            return tabla;

        }      

        //v6 - PERMISO PARA GESTIONAR CLIENTES
        private void AplicarCambiosVersion6(DataSet ds)
        {
            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS1012";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Clientes";
            tabla.Rows.Add(dr);   

        }

        //v7 - TABLA UNIDAD
        private void AplicarCambiosVersion7(DataSet ds)
        {

            ds.Tables.Add(CrearTablaUnidad());

            //Proteccion Datos
            DataTable tabla = ds.Tables["ProteccionDatos"];
            DataRow dr = tabla.NewRow();
            dr["Tabla"] = "Unidad";
            tabla.Rows.Add(dr);

            //Agregar referencia de Cliente
            //Relación Unidad-Modeo
            DataRelation rel = new DataRelation("DR_Unidad_Modelo", ds.Tables["Modelo"].Columns["Codigo"], ds.Tables["Unidad"].Columns["CodigoModelo"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;
            //Relacion Unidad-Color
            rel = new DataRelation("DR_Unidad_Color", ds.Tables["ColorUnidad"].Columns["ColorID"], ds.Tables["Unidad"].Columns["ColorID"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;
          
            //Agregar permisos         
            tabla = ds.Tables["Permiso"];
            dr = tabla.NewRow();
            dr["Codigo"] = "PS1013";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Gestionar Unidades";
            tabla.Rows.Add(dr);

        }
        private DataTable CrearTablaUnidad()
        {
            var tabla = new DataTable("Unidad");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "UnidadID";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Chasis";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoModelo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "ColorID";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Disponible";
            columna.DataType = typeof(bool);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "FechaCompra";
            columna.DataType = typeof(DateTime);            
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "ImporteCompra";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Oferta";
            columna.DataType = typeof(decimal);
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "VencimientoOferta";
            columna.DataType = typeof(DateTime);
            columna.AllowDBNull = true;
            columna.DefaultValue = DBNull.Value;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoHash";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);



            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["UnidadID"] };

            return tabla;

        }

        //v8 - PERMISO VER STOCK Y ESTABLECER OFERTA
        private void AplicarCambiosVersion8(DataSet ds)
        {            
            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS2001";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver Stock";
            tabla.Rows.Add(dr);
            
            dr = tabla.NewRow();
            dr["Codigo"] = "PS2002";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Poner Unidad en Oferta";
            tabla.Rows.Add(dr);

        }

        //v9 - TABLA OPERACION, OPERACIONFORMAPAGO. PROTECCION Y PERMISOS RELACIONADOS
        private void AplicarCambiosVersion9(DataSet ds)
        {
            //Crear tablas
            ds.Tables.Add(CrearTablaOperacion());
            ds.Tables.Add(CrearTablaOperacionFormaPago());

            //Proteccion Datos
            DataTable tabla = ds.Tables["ProteccionDatos"];
            DataRow dr = tabla.NewRow();
            dr["Tabla"] = "Operacion";
            tabla.Rows.Add(dr);

            //Relación Operacion-Unidad
            DataRelation rel = new DataRelation("DR_Operacion_Unidad", ds.Tables["Unidad"].Columns["UnidadID"], ds.Tables["Operacion"].Columns["Unidad"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;
            //Relacion Operacion-Cliente
            rel = new DataRelation("DR_Operacion_Cliente", ds.Tables["Cliente"].Columns["ClienteID"], ds.Tables["Operacion"].Columns["Cliente"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;
            //Relacion Operacion-Vendedor
            rel = new DataRelation("DR_Operacion_Vendedor", ds.Tables["Usuario"].Columns["Legajo"], ds.Tables["Operacion"].Columns["UsuarioVendedor"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;

            //Relación OperacionFormaPago-Operacion
            rel = new DataRelation("DR_OperacionFormaPago_Operacion", ds.Tables["Operacion"].Columns["Numero"], 
                ds.Tables["OperacionFormaPago"].Columns["NumeroOperacion"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            //Relación OperacionFormaPago-FormaPago
            rel = new DataRelation("DR_OperacionFormaPago_FormaPago", ds.Tables["FormaPago"].Columns["FormaPagoID"],
                ds.Tables["OperacionFormaPago"].Columns["FormaPagoID"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;

            //Agregar permisos
            tabla = ds.Tables["Permiso"];
            dr = tabla.NewRow();
            dr["Codigo"] = "PS2003";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver Operaciones";
            tabla.Rows.Add(dr);

            tabla = ds.Tables["Permiso"];
            dr = tabla.NewRow();
            dr["Codigo"] = "PS2004";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Cargar Operacion Venta";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS2005";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver MIS Operaciones";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS2006";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver TODAS las Operaciones";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS2007";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Autorizar Operaciones";
            tabla.Rows.Add(dr);

        }
        private DataTable CrearTablaOperacion()
        {
            var tabla = new DataTable("Operacion");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Numero";
            columna.DataType = typeof(Int32);
            columna.AutoIncrement = true;
            columna.AutoIncrementSeed = 1;
            columna.AutoIncrementStep = 1;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Fecha";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Unidad";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Cliente";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "UsuarioVendedor";
            columna.DataType = typeof(int);
            columna.DefaultValue = true;
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PrecioPublico";
            columna.DataType = typeof(decimal);                
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Pauta";
            columna.DataType = typeof(decimal);                        
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PatentaEmpresa";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PrecioUnidad";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);
          

            columna = new DataColumn();
            columna.ColumnName = "CodigoHash";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Numero"] };

            return tabla;

        }
        private DataTable CrearTablaOperacionFormaPago()
        {
            var tabla = new DataTable("OperacionFormaPago");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "NumeroOperacion";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "FormaPagoID";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["NumeroOperacion"], tabla.Columns["FormaPagoID"] };

            return tabla;

        }

        //v10 - ESTADO EN TABLA OPERACION
        private void AplicarCambiosVersion10(DataSet ds)
        {
            DataTable tabla = ds.Tables["Operacion"];            
            DataColumn columna = new DataColumn();
            columna.ColumnName = "Estado";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


        }

        //v11 - AGREGAR IMPORTE EN OPERACIONFORMAPAGO
        private void AplicarCambiosVersion11(DataSet ds)
        {
            DataTable tabla = ds.Tables["OperacionFormaPago"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "Importe";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);
        }

        //v12 - ESOFERTA EN TABLA OPERACION
        private void AplicarCambiosVersion12(DataSet ds)
        {
            DataTable tabla = ds.Tables["Operacion"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "EsOferta";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);


        }

        //v13 - PORCENTAJEGASTOGESTORIA EN TABLA OPERACION
        private void AplicarCambiosVersion13(DataSet ds)
        {
            DataTable tabla = ds.Tables["Operacion"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "PorcentajeGastoGestoria";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);


        }

        //v14 - MODIFICABLE EN TABLA OPERACIONFORMAPAGO
        private void AplicarCambiosVersion14(DataSet ds)
        {
            DataTable tabla = ds.Tables["OperacionFormaPago"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "Modificable";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

        }

        //v15 - ANULADA Y NOTARECHAZO EN TABLA OPERACION
        private void AplicarCambiosVersion15(DataSet ds)
        {
            DataTable tabla = ds.Tables["Operacion"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "Anulada";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "NotaRechazo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


        }

        //v16 - PERMISO MODIFICAR Y ANULAR VENTA
        private void AplicarCambiosVersion16(DataSet ds)
        {
            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS2008";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Modificar Operación de Venta";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS2009";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Anular Operación de Venta";
            tabla.Rows.Add(dr);

        }

        //v17 - TABLA TIPO CONTACTO, PERMISO Y DATA RELATION (VERSION EN DESUSO)
        private void AplicarCambiosVersion17(DataSet ds)
        {

            //ds.Tables.Add(CrearTablaTipoContacto());

            ////Relación Operacion-Unidad
            //DataRelation rel = new DataRelation("DR_Contacto_TipoContacto", ds.Tables["TipoContacto"].Columns["TipoContactoID"], ds.Tables["Contacto"].Columns["Tipo"]);
            //ds.Relations.Add(rel);
            //rel.ChildKeyConstraint.DeleteRule = Rule.None;

            ////Agregar permisos         
            //DataTable tabla = ds.Tables["Permiso"];
            //DataRow dr = tabla.NewRow();
            //dr["Codigo"] = "PS1014";
            //dr["Tipo"] = "PermisoSimple";
            //dr["Descripcion"] = "Gestionar Tipos de Contactos";
            //tabla.Rows.Add(dr);          

        }     

        //v18 - CODIGO POSTAL EN CLIENTE
        private void AplicarCambiosVersion18(DataSet ds)
        {
            DataTable tabla = ds.Tables["Cliente"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "CodigoPostal";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


        }

        //v19 - ARANCEL GASTO EN OPERACIONFORMAPAGO
        private void AplicarCambiosVersion19(DataSet ds)
        {
            DataTable tabla = ds.Tables["OperacionFormaPago"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "ArancelGasto";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);
        }

        //v20 - TABLA LIQUIDACION, LIQUIDACIONVENDEDOR Y CODIGO EN OPERACION, PERMISOS
        private void AplicarCambiosVersion20(DataSet ds)
        {

            ds.Tables.Add(CrearTablaLiquidacion());
            ds.Tables.Add(CrearTablaLiquidacionVendedor());

            DataTable tabla = ds.Tables["Operacion"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "CodigoLiquidacion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            //Proteccion Datos
            tabla = ds.Tables["ProteccionDatos"];
            DataRow dr = tabla.NewRow();
            dr["Tabla"] = "LiquidacionVendedor";
            tabla.Rows.Add(dr);


            DataRelation rel = new DataRelation("DR_LiquidacionVendedor_Liquidacion", ds.Tables["Liquidacion"].Columns["Codigo"], ds.Tables["LiquidacionVendedor"].Columns["CodigoLiquidacion"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            rel = new DataRelation("DR_LiquidacionVendedor_Vendedor", ds.Tables["Usuario"].Columns["Legajo"], ds.Tables["LiquidacionVendedor"].Columns["UsuarioVendedor"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;

            rel = new DataRelation("DR_LiquidacionVendedor_Operacion", 
                new DataColumn[] { ds.Tables["LiquidacionVendedor"].Columns["CodigoLiquidacion"], ds.Tables["LiquidacionVendedor"].Columns["UsuarioVendedor"]},
                new DataColumn[] { ds.Tables["Operacion"].Columns["CodigoLiquidacion"], ds.Tables["Operacion"].Columns["UsuarioVendedor"] }, false);
            ds.Relations.Add(rel);
            //rel.ChildKeyConstraint.DeleteRule = Rule.None;

            //Agregar permisos         
            tabla = ds.Tables["Permiso"];
            dr = tabla.NewRow();
            dr["Codigo"] = "PS3001";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Ver Liquidaciones";
            tabla.Rows.Add(dr);

            dr = tabla.NewRow();
            dr["Codigo"] = "PS3002";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Crear Liquidación";
            tabla.Rows.Add(dr);

        }
        private DataTable CrearTablaLiquidacion()
        {
            var tabla = new DataTable("Liquidacion");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "Codigo";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "FechaLiquidacion";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Comentarios";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);          

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["Codigo"] };

            return tabla;
        }
        private DataTable CrearTablaLiquidacionVendedor()
        {
            var tabla = new DataTable("LiquidacionVendedor");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "CodigoLiquidacion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "UsuarioVendedor";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PorcentajeComision";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "PremioVolumen";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "CodigoHash";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["CodigoLiquidacion"], tabla.Columns["UsuarioVendedor"] };

            return tabla;
        }

        //v21 - PERMISO ANULAR LIQUIDACION
        private void AplicarCambiosVersion21(DataSet ds)
        {
            //Agregar permisos         
            DataTable tabla = ds.Tables["Permiso"];
            DataRow dr = tabla.NewRow();
            dr["Codigo"] = "PS3003";
            dr["Tipo"] = "PermisoSimple";
            dr["Descripcion"] = "Eliminar Liquidación";
            tabla.Rows.Add(dr);
          

        }

        //v22 - FLAGS EMPRESA - MAIL NOTIF. VENCIMIENTO OFERTAS
        private void AplicarCambiosVersion22(DataSet ds)
        {
            DataTable tabla = ds.Tables["FlagsEmpresa"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "DestinatariosNotificacionVencimientoOfertas";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


        }

        //v23 - USUARIO - SE AGREGA EMAIL
        private void AplicarCambiosVersion23(DataSet ds)
        {
            DataTable tabla = ds.Tables["Usuario"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "Email";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);


        }

        //v24 - TIPOS DE CONTACTO - SE AGREGA FLAG PARA ESPECIFICAR QUE EL TIPO ADMITE NOTIFICACIONES (EMAIL)
        private void AplicarCambiosVersion24(DataSet ds)
        {
            DataTable tabla = ds.Tables["TipoContacto"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "PermiteNotificaciones";
            columna.DataType = typeof(bool);
            tabla.Columns.Add(columna);
        }

        //v25 - OPERACION - SE AGREGA FECHA Y USUARIO AUTORIZANTE (PARA CUANDO SE AUTORIZA), Y MAILS NOTIFICACION CUANDO SE AUTORIZA UNA OPERACION A PERDIDA (EMAIL)
        private void AplicarCambiosVersion25(DataSet ds)
        {            
            DataTable tabla = ds.Tables["FlagsEmpresa"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "DestinatariosNotificacionAutorizacionAPerdida";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla = ds.Tables["Operacion"];
            columna = new DataColumn();
            columna.ColumnName = "AutorizadaEl";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "AutorizadaPor";
            columna.DataType = typeof(int);
            tabla.Columns.Add(columna);

        }

        //v26 - OPERACION - RELACION CON TABLA USUARIO PARA EL AUTORIZANTE
        private void AplicarCambiosVersion26(DataSet ds)
        {          

            DataRelation rel = new DataRelation("DR_Operacion_UsuarioAutorizacion", ds.Tables["Usuario"].Columns["Legajo"], ds.Tables["Operacion"].Columns["AutorizadaPor"]);
            ds.Relations.Add(rel);
            rel.ChildKeyConstraint.DeleteRule = Rule.None;
        }

        //v27 - AGREGAR COLUMNA NETOACOMISIONAR EN LIQUIDACIONVENDEDOR
        private void AplicarCambiosVersion27(DataSet ds)
        {
            DataTable tabla = ds.Tables["LiquidacionVendedor"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "NetoAComisionar";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);
        }

        //v28 - FLAGS EMPRESA - TASAS IVA
        private void AplicarCambiosVersion28(DataSet ds)
        {
            DataTable tabla = ds.Tables["FlagsEmpresa"];
            DataColumn columna = new DataColumn();
            columna.ColumnName = "TasaIVAModelosPickUp";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "TasaIVAModelosResto";
            columna.DataType = typeof(decimal);
            tabla.Columns.Add(columna);


        }
       
        #endregion      

    }
}
