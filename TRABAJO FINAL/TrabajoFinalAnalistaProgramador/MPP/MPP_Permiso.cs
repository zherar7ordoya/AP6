using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using System.Data;
using DAO;
using Entidad;
using PermisoComposite;

namespace MPP
{
    public class MPP_Permiso : Iabmc<PermisoComposite.Permiso>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtPermiso;
        DataTable dtPermisoComp_Permiso;

        public MPP_Permiso()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtPermiso = oAcceso.dtPermiso;
                dtPermisoComp_Permiso = oAcceso.dtPermisoComp_Permiso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };      
        }
        //Metodo Alta.
        public void Alta(Permiso oPermiso)
        {
            if (oPermiso is PermisoSimple)
            {
                DataRow dr = dtPermiso.NewRow();

                dtPermiso.Rows.Add(new object[]{
                   oPermiso.Id,
                   oPermiso.Nombre,
                   oPermiso.Tipo,
              });
 
            }
            //Si se trata de un compuesto.
            else if (oPermiso is PermisoCompuesto)
            {
                DataRow dr = dtPermiso.NewRow();

                dtPermiso.Rows.Add(new object[]{
                   oPermiso.Id,
                   oPermiso.Nombre,
                   oPermiso.Tipo
                });
            }

            oAcceso.GrabarDatos();
        }
        //Metodo Baja.
        public void Baja(Permiso oPermiso)
        {
            try
            {
                //Creo una lista para las filas.
                List<int> filas = new List<int>();

                //Consulto si el permiso a eliminar es simple.
                if (oPermiso is PermisoSimple)
                {
                    //Elimino el permiso .
                    dtPermiso.Rows.Remove(dtPermiso.Rows.Find(oPermiso.Id));

                    //Veo si el permiso esta en el datatable de permisocompuesto_permiso.
                    if (dtPermisoComp_Permiso.Rows.Count > 0)
                    {
                        //Recorro.
                        for (int i = dtPermisoComp_Permiso.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtPermisoComp_Permiso.Rows[i];
                            //Si coincide.
                            if (dr["Permiso_Id"].ToString() == oPermiso.Id)
                            {
                                //Lo elimino del datatable de permisocompuesto_permiso.
                                dr.Delete();
                            }
                        }
                    }
                    oAcceso.GrabarDatos();
                }
                //Si es compuesto tengo que ver si no tiene permisos asignados.
                else
                {
                    //Elimino el permiso.
                    dtPermiso.Rows.Remove(dtPermiso.Rows.Find(oPermiso.Id));

                    //Veo si el permiso esta en el datatable de permisocompuesto_permiso.
                    if (dtPermisoComp_Permiso.Rows.Count > 0)
                    {
                        //Recorro.
                        for (int i = dtPermisoComp_Permiso.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtPermisoComp_Permiso.Rows[i];
                            //Si coinciden.
                            if (dr["PermisoCompuesto_Id"].ToString() == oPermiso.Id)
                            {
                                //Lo elimino del datatable de permisocompuesto_permiso.
                                 dr.Delete();
                            }
                        }
                    }
                    oAcceso.GrabarDatos();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }
        //Metodo Listar.
        public List<Permiso> Listar()
        {
            List<Permiso> listaPermiso;

            try
            {
                listaPermiso = new List<Permiso>();

                    foreach (DataRow r in ds.Tables["Permiso"].Rows)
                    {
                        //Me fijo si es simple
                        if (r.Field<string>(2) == "Simple")
                        {
                            E_Permiso oPermiso = new E_Permiso();
                            oPermiso.Id = r.Field<string>(0);
                            oPermiso.Nombre = r.Field<string>(1);
                            oPermiso.Tipo = r.Field<string>(2);
                            listaPermiso.Add(new PermisoSimple(oPermiso));
                        }
                        else
                        {
                            E_Permiso oPermiso = new E_Permiso();
                            oPermiso.Id = r.Field<string>(0);
                            oPermiso.Nombre = r.Field<string>(1);
                            oPermiso.Tipo = r.Field<string>(2);
                            listaPermiso.Add(new PermisoCompuesto(oPermiso));
                        }

                    }

                return listaPermiso;
            }
            catch (Exception ex) { throw new Exception(ex.Message); };
        }
        //Metodo Modificar.
        public void Modificar(Permiso oPermiso)
        {
            if (oPermiso is PermisoSimple)
            {
                dtPermiso.Rows.Find(oPermiso.Id).ItemArray = new object[] { oPermiso.Id, oPermiso.Nombre, oPermiso.Tipo };
            }
            //Si se trata de un compuesto
            else if (oPermiso is PermisoCompuesto) 
            {
                dtPermiso.Rows.Find(oPermiso.Id).ItemArray = new object[] { oPermiso.Id, oPermiso.Nombre, oPermiso.Tipo };
            }

            oAcceso.GrabarDatos();
        }
        //Metodo Asignar permisos.
        public void AsignarPermisos(Permiso oPermiso)
        {
            try
            { 
                //Agregado el permiso a la tabla consulto si tiene permisos cargados
                if (((PermisoCompuesto)oPermiso).ListaPermisos != null)
                {
                    foreach (var permiso in ((PermisoCompuesto)oPermiso).ListaPermisos)
                    {
                        DataRow dr = dtPermisoComp_Permiso.NewRow();
                        //Añado el permiso al datatable permisocompuesto_permiso.
                        dtPermisoComp_Permiso.Rows.Add(new object[]{
                        oPermiso.Id,
                        permiso.Id,
                        });
                    }
                }
                oAcceso.GrabarDatos();
                //Limpio la lista, para que no se me acumulen permisos repetidos.
                ((PermisoCompuesto)oPermiso).ListaPermisos.Clear();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no asigne permisos repetidos.
        public bool ValidarPermisos(Permiso oPermiso, string idPermiso)
        {
            //Creo una variable bool.
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtPermisoComp_Permiso.Rows)
                {
                    //Si el permiso compuesto coincide con el id del parametro y lo mismo con el otro el permiso.
                    if(row["PermisoCompuesto_Id"].ToString() == idPermiso && row["Permiso_Id"].ToString() == oPermiso.Id)
                    {
                        //Asigno la variable en false, y luego doy aviso que ya existe ese permiso asignado.
                        resultado = false;
                        break;
                    }
                    //Sino, no esta asignado.
                    else
                    {
                        resultado = true;
                    }
                }

                return resultado;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no cree permiso iguales.
        public bool ValidarPermisosCreacion(Permiso oPermiso)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtPermiso.Rows)
                {
                    //Si el nombre y el tipo son similares a los valores del objeto recibido.
                    if (row["Permiso_Nombre"].ToString() == oPermiso.Nombre && row["Permiso_Tipo"].ToString() == oPermiso.Tipo)
                    {
                        //Coloco la variable en false, y luego aviso en la vista que se esta creando un mismo permiso.
                        resultado = false;
                        break;
                    }
                    else
                    {
                        resultado = true;
                    }
                }

                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no ingrese ids repetidos.
        public bool ValidarId(Permiso oPermiso)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtPermiso.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (row["Permiso_Id"].ToString() == oPermiso.Id)
                    {
                        //Coloco la variable en false, y luego doy aviso en la vista que se trata de un id repetido.
                        resultado = false;
                        break;
                    }
                    else
                    {
                        resultado = true;
                    }
                }

                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        //Metodo Cargar permisos, para obtener el permiso por el codigo.
        public List<Permiso> CargarPermisos(string id)
        {
            //Creo dos listas.
            List<Permiso> listaPermisos;
            List<Permiso> listaAux;

            try
            {
                //Obtengo todos los permisos, es decir, asigno a la lista de permisos lo que tenga el metodo listar.
                listaPermisos = this.Listar();

                if (listaPermisos != null)
                {
                    //Encuentro el permiso por el tipo.
                    PermisoCompuesto pc = ((PermisoCompuesto)listaPermisos.Find(x => x.Id == id && x.Tipo == "Compuesto"));

                    //Si lo encontro busco los que tiene asociados.
                    if (pc != null)
                    {
                        foreach (var item in this.ListarPermisosCompuestos(pc.Id))
                        {
                            //Si el permiso que busco en la lista de permisos compuestos es simple lo añado directamente.
                            if (item is PermisoSimple)
                            {
                                pc.Añadir(item);
                            }
                            //Si el permiso es compuesto entonces tengo que buscar los que tiene asociados.
                            else
                            {
                                //Busco por id y tipo.
                                PermisoCompuesto pc2 = ((PermisoCompuesto)listaPermisos.Find(x => x.Id == item.Id && x.Tipo == "Compuesto"));
                                //Recorro.
                                foreach (var item2 in this.ListarPermisosCompuestos(pc2.Id))
                                {
                                    pc2.Añadir(item2);
                                }
                                //Añado al permiso compuesto, el otro permiso compuesto encontrado.
                                pc.Añadir(pc2);
                            }

                        }

                        listaAux = new List<Permiso>();
                        //Asigno a la lista auxiliar, lo que me trae el retorna permiso del permiso compuesto.
                        listaAux = pc.RetornaPermiso();
                    }
                    else
                    {
                        listaAux = null;
                    }
                }
                else
                {
                    listaAux = null; 
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };

            return listaAux;
        }
        //Metodo Listar permisos compuestos.
        public List<Permiso> ListarPermisosCompuestos(string id)
        {
            List<Permiso> lista;

            try
            {
                lista = new List<Permiso>();
                Permiso permisoAux;

                //Consulto si tiene datos.
                if (ds.Tables["PermisoCompuesto_Permiso"].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables["PermisoCompuesto_Permiso"].Rows)
                    {
                        //Si el id coincide.
                        if (r.Field<string>(0) == id)
                        {
                            permisoAux = this.Listar().Find(x => x.Id == r.Field<string>(1));
                            //Añado a la lista el permiso auxiliar.
                            lista.Add(permisoAux);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex) { throw new Exception(ex.Message); };
        }
        //Metodo Quitar permiso.
        public void QuitarPermiso(Permiso oPermiso, string idPermiso)
        {
            try
            {
                if (dtPermisoComp_Permiso.Rows.Count > 0)
                {
                    //Recorro el datable de permisocompuesto_permiso.
                    for (int i = dtPermisoComp_Permiso.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtPermisoComp_Permiso.Rows[i];
                        //Si coinciden los id de cada permiso, lo borro.
                        if (dr["PermisoCompuesto_Id"].ToString() == idPermiso && dr["Permiso_Id"].ToString() == oPermiso.Id)
                        {
                            dr.Delete();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                oAcceso.GrabarDatos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }
        //Metodo Quitar permiso compuesto.
        public void QuitarPermisoCompuesto(Permiso oPermiso, string idPermiso)
        {
            try
            {
                //Controlo que el datatable tenga los datos, busco el permiso y si existe lo elimina.
                if (dtPermisoComp_Permiso.Rows.Count > 0)
                {
                    for (int i = dtPermisoComp_Permiso.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtPermisoComp_Permiso.Rows[i];

                        if (dr["PermisoCompuesto_Id"].ToString() == idPermiso && dr["Permiso_Id"].ToString() == oPermiso.Id)
                        {
                            dr.Delete();
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                oAcceso.GrabarDatos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }

        //Metodo Consultar.
        public List<Permiso> Consultar(string pNombre)
        {
            List<Permiso> listaPermiso;

            try
            {
                listaPermiso = new List<Permiso>();

                foreach (DataRow r in ds.Tables["Permiso"].Rows)
                {
                    if (r["Permiso_Nombre"].ToString().StartsWith(pNombre))
                    {
                        //Me fijo si es simple
                        if (r.Field<string>(2) == "Simple")
                        {
                            E_Permiso oPermiso = new E_Permiso();
                            oPermiso.Id = r.Field<string>(0);
                            oPermiso.Nombre = r.Field<string>(1);
                            oPermiso.Tipo = r.Field<string>(2);
                            listaPermiso.Add(new PermisoSimple(oPermiso));
                            break;
                        }
                        else
                        {
                            E_Permiso oPermiso = new E_Permiso();
                            oPermiso.Id = r.Field<string>(0);
                            oPermiso.Nombre = r.Field<string>(1);
                            oPermiso.Tipo = r.Field<string>(2);
                            listaPermiso.Add(new PermisoCompuesto(oPermiso));
                            break;
                        }

                    }

                }

                return listaPermiso;
            }
            catch (Exception ex) { throw new Exception(ex.Message); };
        }

    }
}
