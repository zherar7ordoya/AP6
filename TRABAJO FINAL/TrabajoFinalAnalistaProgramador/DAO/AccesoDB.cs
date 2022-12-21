using System;
using System.Data;

namespace DAO
{
    public class AccesoDB
    {
        //Creo el Dataset.
        public DataSet ds = new DataSet("Trabajo_Final");
        //Creo los Datatables.
        public DataTable dtUsuario = new DataTable("Usuario");
        public DataTable dtEmpleado = new DataTable("Empleado");
        public DataTable dtGerente = new DataTable("Gerente");
        public DataTable dtProveedor = new DataTable("Proveedor");
        public DataTable dtPermiso = new DataTable("Permiso");
        public DataTable dtPermisoComp_Permiso = new DataTable("PermisoCompuesto_Permiso");
        public DataTable dtBackUp = new DataTable("BackUp");
        public DataTable dtSueldoNeto = new DataTable("SueldoNeto");
        public DataTable dtMarca = new DataTable("Marca");
        public DataTable dtArticulo = new DataTable("Articulo");
        public DataTable dtMovimiento = new DataTable("Movimiento");
        public DataTable dtLogin = new DataTable("LogIn");
        public DataTable dtEntrega = new DataTable("Entrega");

        public AccesoDB()
        {
            try
            {
                //Columnas de la tabla Usuario.
                DataColumn dcId = new DataColumn("Usuario_Id", Type.GetType("System.Int32"));
                DataColumn dcFechaAlta = new DataColumn("Usuario_FechaAlta", Type.GetType("System.DateTime"));
                DataColumn dcNombreUsuario = new DataColumn("Usuario_Nombre", Type.GetType("System.String"));
                DataColumn dcContraseña = new DataColumn("Usuario_Contraseña", Type.GetType("System.String"));
                DataColumn dcBloqueado = new DataColumn("Usuario_Bloqueado", Type.GetType("System.Boolean"));
                DataColumn dcPermiso = new DataColumn("Usuario_Permiso", Type.GetType("System.String"));

                
                //Agrego las columnas al datatable.
                dtUsuario.Columns.AddRange(new DataColumn[] { dcId, dcFechaAlta, dcNombreUsuario, dcContraseña, dcBloqueado, dcPermiso });
                dtUsuario.PrimaryKey = new DataColumn[] { dcId };
                //Agrego al dataset el datatable.
                ds.Tables.Add(dtUsuario);

                //Columnas del datatable Empleado.
                DataColumn dcDni = new DataColumn("Empleado_Dni", Type.GetType("System.Int32"));
                DataColumn dcNombre = new DataColumn("Empleado_Nombre", Type.GetType("System.String"));
                DataColumn dcApellido = new DataColumn("Empleado_Apellido", Type.GetType("System.String"));
                DataColumn dcDireccion = new DataColumn("Empleado_Direccion", Type.GetType("System.String"));
                DataColumn dcCelular = new DataColumn("Empleado_Celular", Type.GetType("System.Int64"));
                DataColumn dcTelefono = new DataColumn("Empleado_Telefono", Type.GetType("System.Int64"));
                DataColumn dcFechaNac = new DataColumn("Empleado_FechaNacimiento", Type.GetType("System.DateTime"));
                DataColumn dcEstadoCivil = new DataColumn("Empleado_EstadoCivil", Type.GetType("System.String"));
                DataColumn dcSueldoBruto = new DataColumn("Empleado_SueldoBruto", Type.GetType("System.Decimal"));
                DataColumn dcIdUsuario = new DataColumn("Empleado_Usuario_Id", Type.GetType("System.Int32"));
                DataColumn dcMailPersonal = new DataColumn("Empleado_MailPersonal", Type.GetType("System.String"));

                //Agrego las columnas al datatable.
                dtEmpleado.Columns.AddRange(new DataColumn[] { dcDni, dcNombre, dcApellido, dcDireccion, dcCelular, dcTelefono, dcFechaNac, dcEstadoCivil,
                dcSueldoBruto, dcIdUsuario, dcMailPersonal });
                dtEmpleado.PrimaryKey = new DataColumn[] { dcDni };
                //Agrego al dataset el datatable.
                ds.Tables.Add(dtEmpleado);

                //Relacion Usuario_Empleado.
                ds.Relations.Add("Usuario_Id_Empleado_Usuario_Id", ds.Tables["Usuario"].Columns["Usuario_Id"], ds.Tables["Empleado"].Columns["Empleado_Usuario_Id"]);

                //Columnas del datatable Gerente.
                DataColumn dcDniGerente = new DataColumn("Gerente_Dni", Type.GetType("System.Int32"));
                DataColumn dcNombreGerente = new DataColumn("Gerente_Nombre", Type.GetType("System.String"));
                DataColumn dcApellidoGerente = new DataColumn("Gerente_Apellido", Type.GetType("System.String"));
                DataColumn dcDireccionGerente = new DataColumn("Gerente_Direccion", Type.GetType("System.String"));
                DataColumn dcCelularGerente = new DataColumn("Gerente_Celular", Type.GetType("System.Int64"));
                DataColumn dcTelefonoGerente = new DataColumn("Gerente_Telefono", Type.GetType("System.Int64"));
                DataColumn dcFechaNacGerente = new DataColumn("Gerente_FechaNacimiento", Type.GetType("System.DateTime"));
                DataColumn dcEstadoCivilGerente = new DataColumn("Gerente_EstadoCivil", Type.GetType("System.String"));
                DataColumn dcSueldoBrutoGerente = new DataColumn("Gerente_SueldoBruto", Type.GetType("System.Decimal"));
                DataColumn dcIdUsuarioGerente = new DataColumn("Gerente_Usuario_Id", Type.GetType("System.Int32"));
                DataColumn dcMailPersonalGerente = new DataColumn("Gerente_MailPersonal", Type.GetType("System.String"));
                DataColumn dcMailEmpresarial = new DataColumn("Gerente_MailEmpresarial", Type.GetType("System.String"));

                //Agrego las columnas al datatable.
                dtGerente.Columns.AddRange(new DataColumn[] { dcDniGerente, dcNombreGerente, dcApellidoGerente, dcDireccionGerente, dcCelularGerente, dcTelefonoGerente, dcFechaNacGerente, dcEstadoCivilGerente,
                dcSueldoBrutoGerente, dcIdUsuarioGerente, dcMailPersonalGerente, dcMailEmpresarial });
                dtGerente.PrimaryKey = new DataColumn[] { dcDniGerente };
                //Agrego al dataset el datatable.
                ds.Tables.Add(dtGerente);

                //Relacion Usuario_Gerente.
                ds.Relations.Add("Usuario_Id_Gerente_Usuario_Id", ds.Tables["Usuario"].Columns["Usuario_Id"], ds.Tables["Gerente"].Columns["Gerente_Usuario_Id"]);

                //Columnas del datatable Proveedor.
                DataColumn dcIdProv = new DataColumn("Proveedor_Id", Type.GetType("System.Int32"));
                DataColumn dcNombreProv = new DataColumn("Proveedor_Nombre", Type.GetType("System.String"));
                DataColumn dcDireccionProv = new DataColumn("Proveedor_Direccion", Type.GetType("System.String"));
                DataColumn dcLocalidadProv = new DataColumn("Proveedor_Localidad", Type.GetType("System.String"));
                DataColumn dcProvinciaProv = new DataColumn("Proveedor_Provincia", Type.GetType("System.String"));
                DataColumn dcTelefonoProv = new DataColumn("Proveedor_Telefono", Type.GetType("System.Int64"));
                DataColumn dcMailProv = new DataColumn("Proveedor_Mail", Type.GetType("System.String"));
                DataColumn dcActivoProv = new DataColumn("Proveedor_Activo", Type.GetType("System.Boolean"));
                DataColumn dcGerente = new DataColumn("Proveedor_Gerente_Dni", Type.GetType("System.Int32"));

                dtProveedor.Columns.AddRange(new DataColumn[] { dcIdProv, dcNombreProv, dcDireccionProv,
                dcLocalidadProv, dcProvinciaProv, dcTelefonoProv, dcMailProv, dcActivoProv, dcGerente});
                dtProveedor.PrimaryKey = new DataColumn[] { dcIdProv };
                dcIdProv.AutoIncrement = true;
                ds.Tables.Add(dtProveedor);

                //Relacion Gerente_Proveedor.
                ds.Relations.Add("Gerente_Dni_Proveedor_Gerente_Dni", ds.Tables["Gerente"].Columns["Gerente_Dni"], ds.Tables["Proveedor"].Columns["Proveedor_Gerente_Dni"]);

                //Columnas del datatable Permiso.
                DataColumn dcIdPermiso = new DataColumn("Permiso_Id", Type.GetType("System.String"));
                DataColumn dcNombrePermiso = new DataColumn("Permiso_Nombre", Type.GetType("System.String"));
                DataColumn dcTipoPermiso = new DataColumn("Permiso_Tipo", Type.GetType("System.String"));

                dcIdPermiso.AllowDBNull = true;

                dtPermiso.Columns.AddRange(new DataColumn[] { dcIdPermiso, dcNombrePermiso, dcTipoPermiso });
                dtPermiso.PrimaryKey = new DataColumn[] { dcIdPermiso };
                ds.Tables.Add(dtPermiso);

                //Columnas del datatable PermisoCompuesto_Permiso.
                DataColumn dcIdPermisoCompuesto = new DataColumn("PermisoCompuesto_Id", Type.GetType("System.String"));
                DataColumn dcIdPermisoP = new DataColumn("Permiso_Id", Type.GetType("System.String"));
                DataColumn dcNombrePermisoP = new DataColumn("Permiso_Nombre", Type.GetType("System.String"));

                dtPermisoComp_Permiso.Columns.AddRange(new DataColumn[] { dcIdPermisoCompuesto, dcIdPermisoP, dcNombrePermisoP });
                dtPermisoComp_Permiso.PrimaryKey = new DataColumn[] { dcIdPermisoCompuesto, dcIdPermisoP };
                ds.Tables.Add(dtPermisoComp_Permiso);

                //Columnas del datatable BackUp.
                DataColumn dcCodigoBackUp = new DataColumn("BackUp_Codigo", Type.GetType("System.Int32"));
                DataColumn dcUsuarioBackUp = new DataColumn("BackUp_Usuario_Id", Type.GetType("System.Int32"));
                DataColumn dcFechaBackUp = new DataColumn("BackUp_Fecha", Type.GetType("System.DateTime"));

                dtBackUp.Columns.AddRange(new DataColumn[] { dcCodigoBackUp, dcUsuarioBackUp,  dcFechaBackUp });
                dtBackUp.PrimaryKey = new DataColumn[] { dcCodigoBackUp };
                dcCodigoBackUp.AutoIncrement = true;
                ds.Tables.Add(dtBackUp);

                //Relacion Usuario_BackUp
                ds.Relations.Add("Usuario_Id_BackUp_Usuario_Id", ds.Tables["Usuario"].Columns["Usuario_Id"], ds.Tables["BackUp"].Columns["BackUp_Usuario_Id"]);

                //Columnas del datatable SueldoNeto.
                DataColumn dcIdSueldo = new DataColumn("SueldoNeto_Id", Type.GetType("System.Int32"));
                DataColumn dcFechaSueldo = new DataColumn("SueldoNeto_Fecha", Type.GetType("System.DateTime"));
                DataColumn dcEmpleado = new DataColumn("SueldoNeto_Empleado_Dni", Type.GetType("System.Int32"));
                DataColumn dcSueldoBruto2 = new DataColumn("SueldoNeto_SueldoBruto", Type.GetType("System.Decimal"));
                DataColumn dcCantInasistencia = new DataColumn("SueldoNeto_CantidadInasistencia", Type.GetType("System.Int32"));
                DataColumn dcPuntualidad = new DataColumn("SueldoNeto_Puntualidad", Type.GetType("System.String"));
                DataColumn dcHorasExtra = new DataColumn("SueldoNeto_HorasExtra", Type.GetType("System.Int32"));
                DataColumn dcGerente2 = new DataColumn("SueldoNeto_Gerente_Dni", Type.GetType("System.Int32"));
                DataColumn dcImporte = new DataColumn("SueldoNeto_Importe", Type.GetType("System.Decimal"));

                dtSueldoNeto.Columns.AddRange(new DataColumn[] { dcIdSueldo, dcFechaSueldo, dcEmpleado, dcSueldoBruto2,
                dcCantInasistencia, dcPuntualidad, dcHorasExtra, dcGerente2, dcImporte });
                dtSueldoNeto.PrimaryKey = new DataColumn[] { dcIdSueldo };
                dcIdSueldo.AutoIncrement = true;
                ds.Tables.Add(dtSueldoNeto);

                //Relacion Empleado_SueldoNeto.
                ds.Relations.Add("Empleado_Dni_SueldoNeto_Empleado_Dni", ds.Tables["Empleado"].Columns["Empleado_Dni"], ds.Tables["SueldoNeto"].Columns["SueldoNeto_Empleado_Dni"]);
                //Relacion Gerente_SueldoNeto
                ds.Relations.Add("Gerente_Dni_SueldoNeto_Gerente_Dni", ds.Tables["Gerente"].Columns["Gerente_Dni"], ds.Tables["SueldoNeto"].Columns["SueldoNeto_Gerente_Dni"]);

                //Columnas del datatable Marca.
                DataColumn dcCodigoMarca = new DataColumn("Marca_Codigo", Type.GetType("System.Int32"));
                DataColumn dcNombreMarca = new DataColumn("Marca_Nombre", Type.GetType("System.String"));
                DataColumn dcGerente3 = new DataColumn("Marca_Gerente_Dni", Type.GetType("System.Int32"));

                dtMarca.Columns.AddRange(new DataColumn[] { dcCodigoMarca, dcNombreMarca, dcGerente3 });
                dtMarca.PrimaryKey = new DataColumn[] { dcCodigoMarca };
                dcCodigoMarca.AutoIncrement = true;
                ds.Tables.Add(dtMarca);

                //Relacion Gerente_Marca
                ds.Relations.Add("Gerente_Dni_Marca_Gerente_Dni", ds.Tables["Gerente"].Columns["Gerente_Dni"], ds.Tables["Marca"].Columns["Marca_Gerente_Dni"]);

                //Columnas del datatable Articulo.
                DataColumn dcCodigoArt = new DataColumn("Articulo_Codigo", Type.GetType("System.String"));
                DataColumn dcDescripArt = new DataColumn("Articulo_Descripcion", Type.GetType("System.String"));
                DataColumn dcCodigoMarca2 = new DataColumn("Articulo_Marca_Codigo", Type.GetType("System.Int32"));
                DataColumn dcTalleArt = new DataColumn("Articulo_Talle", Type.GetType("System.String"));
                DataColumn dcExistenciaArt = new DataColumn("Articulo_Existencia", Type.GetType("System.Int32"));
                DataColumn dcStockMin = new DataColumn("Articulo_StockMin", Type.GetType("System.Int32"));
                DataColumn dcStockMax = new DataColumn("Articulo_StockMax", Type.GetType("System.Int32"));
                DataColumn dcPrecioCosto = new DataColumn("Articulo_PrecioCosto", Type.GetType("System.Decimal"));
                DataColumn dcPrecioVenta = new DataColumn("Articulo_PrecioVenta", Type.GetType("System.Decimal"));
                DataColumn dcPrecioPromo = new DataColumn("Articulo_PrecioPromocion", Type.GetType("System.Decimal"));
                DataColumn dcProveedor = new DataColumn("Articulo_Proveedor_Id", Type.GetType("System.Int32"));
                DataColumn dcObservacionArt = new DataColumn("Articulo_Observacion", Type.GetType("System.String"));
                DataColumn dcEmpleado2 = new DataColumn("Articulo_Empleado_Dni", Type.GetType("System.Int32"));
                DataColumn dcActivoArt = new DataColumn("Articulo_Activo", Type.GetType("System.Boolean"));

                dcExistenciaArt.AllowDBNull = true;
                dcStockMin.AllowDBNull = true;
                dcStockMax.AllowDBNull = true;
                dcPrecioCosto.AllowDBNull = true;
                dcPrecioVenta.AllowDBNull = true;
                dcPrecioPromo.AllowDBNull = true;
                dcObservacionArt.AllowDBNull = true;

                dtArticulo.Columns.AddRange(new DataColumn[] { dcCodigoArt, dcDescripArt, dcCodigoMarca2, dcTalleArt, dcExistenciaArt, dcStockMin, dcStockMax,
                dcPrecioCosto, dcPrecioVenta, dcPrecioPromo, dcProveedor, dcObservacionArt, dcEmpleado2, dcActivoArt });
                dtArticulo.PrimaryKey = new DataColumn[] { dcCodigoArt };
                
                ds.Tables.Add(dtArticulo);

                //Relacion Articulo_Marca.
                ds.Relations.Add("Marca_Codigo_Articulo_Marca_Codigo", ds.Tables["Marca"].Columns["Marca_Codigo"], ds.Tables["Articulo"].Columns["Articulo_Marca_Codigo"]);
                //Relacion Articulo_Proveedor.
                ds.Relations.Add("Proveedor_Id_Articulo_Proveedor_Id", ds.Tables["Proveedor"].Columns["Proveedor_Id"], ds.Tables["Articulo"].Columns["Articulo_Proveedor_Id"]);
                //Relacion Articulo_Empleado.
                ds.Relations.Add("Empleado_Dni_Articulo_Empleado_Dni", ds.Tables["Empleado"].Columns["Empleado_Dni"], ds.Tables["Articulo"].Columns["Articulo_Empleado_Dni"]);

                //Columnas del datatable Movimiento.
                DataColumn dcNumero = new DataColumn("Movimiento_Numero", Type.GetType("System.Int32"));
                DataColumn dcCodArt = new DataColumn("Movimiento_Articulo_Codigo", Type.GetType("System.String"));
                DataColumn dcFecha = new DataColumn("Movimiento_Fecha", Type.GetType("System.DateTime"));
                DataColumn dcAccion = new DataColumn("Movimiento_Accion", Type.GetType("System.String"));
                DataColumn dcCantidadMov = new DataColumn("Movimiento_CantidadMov", Type.GetType("System.Int32"));
                DataColumn dcPCostoCal = new DataColumn("Movimiento_PrecioCostoCalculado", Type.GetType("System.Decimal"));
                DataColumn dcPVentaCal = new DataColumn("Movimiento_PrecioVentaCalculado", Type.GetType("System.Decimal"));
                DataColumn dcEmp = new DataColumn("Movimiento_Empleado_Dni", Type.GetType("System.Int32"));

                dtMovimiento.Columns.AddRange(new DataColumn[] { dcNumero, dcCodArt, dcFecha, dcAccion, dcCantidadMov, dcPCostoCal,
                dcPVentaCal, dcEmp });
                dtMovimiento.PrimaryKey = new DataColumn[] { dcNumero };
                dcNumero.AutoIncrement = true;
                dcPVentaCal.AllowDBNull = true;
                ds.Tables.Add(dtMovimiento);

                //Relacion Moviento_Articulo
                ds.Relations.Add("Articulo_Codigo_Movimiento_Articulo_Codigo", ds.Tables["Articulo"].Columns["Articulo_Codigo"], ds.Tables["Movimiento"].Columns["Movimiento_Articulo_Codigo"]);
                //Relacion Movimiento_Empleado
                ds.Relations.Add("Empleado_Dni_Movimiento_Empleado_Dni", ds.Tables["Empleado"].Columns["Empleado_Dni"], ds.Tables["Movimiento"].Columns["Movimiento_Empleado_Dni"]);

                //Columnas del datatable Login.
                DataColumn dcNumero2 = new DataColumn("LogIn_Numero", Type.GetType("System.Int32"));
                DataColumn dcFechaLogIn = new DataColumn("LogIn_Fecha", Type.GetType("System.DateTime"));
                DataColumn dcUsuarioLogIn = new DataColumn("LogIn_Usuario_Id", Type.GetType("System.Int32"));

                dtLogin.Columns.AddRange(new DataColumn[] { dcNumero2, dcFechaLogIn, dcUsuarioLogIn });
                dtLogin.PrimaryKey = new DataColumn[] { dcNumero2 };
                dcNumero2.AutoIncrement = true;
                ds.Tables.Add(dtLogin);

                //Relacion LogIn_Usuario.
                ds.Relations.Add("Usuario_Id_LogIn_Usuario_Id", ds.Tables["Usuario"].Columns["Usuario_Id"], ds.Tables["LogIn"].Columns["LogIn_Usuario_Id"]);

                //Columnas del datatable Entrega.
                DataColumn dcIdEntrega = new DataColumn("Entrega_Id", Type.GetType("System.Int32"));
                DataColumn dcFechaEntrega = new DataColumn("Entrega_Fecha", Type.GetType("System.DateTime"));
                DataColumn dcHoraEntrega = new DataColumn("Entrega_Hora", Type.GetType("System.String"));
                DataColumn dcProveedorEnt = new DataColumn("Entrega_Proveedor_Id", Type.GetType("System.Int32"));
                DataColumn dcGerenteEnt = new DataColumn("Entrega_Gerente_Dni", Type.GetType("System.Int32"));
               
                dcIdEntrega.AutoIncrement = true;
                dcIdEntrega.AutoIncrementSeed = 1;
                dcIdEntrega.AutoIncrementStep = 1;
                dcIdEntrega.AllowDBNull = false;
                dcIdEntrega.Unique = true;

                dtEntrega.Columns.AddRange(new DataColumn[] { dcIdEntrega, dcFechaEntrega, dcHoraEntrega, dcProveedorEnt, dcGerenteEnt });
                dtEntrega.PrimaryKey = new DataColumn[] { dcIdEntrega };
                ds.Tables.Add(dtEntrega);

                //Relacion Entrega_Proveedor.
                ds.Relations.Add("Proveedor_Id_Entrega_Proveedor_Id", ds.Tables["Proveedor"].Columns["Proveedor_Id"], ds.Tables["Entrega"].Columns["Entrega_Proveedor_Id"]);
                //Relacion Entrega_Gerente
                ds.Relations.Add("Persona_Dni_Entrega_Gerente_Dni", ds.Tables["Gerente"].Columns["Gerente_Dni"], ds.Tables["Entrega"].Columns["Entrega_Gerente_Dni"]);

                LeerDatos();
                //GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Leer datos.
        public void LeerDatos()
        {
            try
            {
                ds.ReadXml("Datos.xml");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Grabar datos.
        public void GrabarDatos()
        {
            try
            {
                ds.WriteXml("Datos.xml");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Realizar backup.
        public void RealizarBackUp(string ruta)
        {
            try
            {
                //Hago una copia del dataset, en la ruta especificada.
                ds.Copy().WriteXml(ruta);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}