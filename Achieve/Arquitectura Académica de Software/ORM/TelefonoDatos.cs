using Abstract;

using DataAccess;

using Structure;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class TelefonoDatos : IABMC<TelefonoModelo>
    {
        IID VobjetoSolicitante;

        public IID ObjetoSolicitante
        {
            get => VobjetoSolicitante;
            set => VobjetoSolicitante = value;
        }


        public void Alta(TelefonoModelo QueObjeto = null)
        {
            DataTable dt1 = new DataTable();
            Comando comando = new Comando();

            dt1 = comando.ObjStructureTable("telefono");

            // *****************************************************************
            // Tener en cuenta que Id debería ser autonumérico, que la tabla 
            // Teléfono tiene su propio Id y debe almacenar conjuntamente el Id
            // del cliente.
            // *****************************************************************
            
            int contador = ((int)comando.ObjDataTable("SELECT MAX(TelefonoId) FROM Telefono").Rows[0].ItemArray[0]) + 1;
            DataRow dr1 = dt1.NewRow();
            dr1.ItemArray= new object[] { contador, QueObjeto.Numero, VobjetoSolicitante.RetornaId() };
            dt1.Rows.Add(dr1);
            contador++;
            comando.ActualizaBase("Telefono", dt1);
        }

        public void Baja(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<TelefonoModelo> ConsultaObjeto(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<TelefonoModelo> ConsultaRango(TelefonoModelo QueObjeto1 = null, TelefonoModelo QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
    }
}
