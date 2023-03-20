using Abstract;

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
