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
    public class TelefonoDatos : IABMC<Telefono>
    {
        IID VobjetoSolicitante;

        public IID ObjetoSolicitante
        {
            get => VobjetoSolicitante;
            set => VobjetoSolicitante = value;
        }


        public void Alta(Telefono QueObjeto = null)
        {
            DataTable dt1 = new DataTable();
            Comando comando = new Comando();
            int contador;

            dt1 = comando.ObjStructureTable("telefono");
            contador = comando.ObjDataTable("SELECT MAX(TelefonoId) FROM Telefono").Rows(0).
                //.Rows(0).Item(0) + 1;
                
                }

        public void Baja(Telefono QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<Telefono> Consulta(Telefono QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<Telefono> ConsultaRango(Telefono QueObjeto1 = null, Telefono QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Telefono QueObjeto = null)
        {
            throw new NotImplementedException();
        }
    }
}
