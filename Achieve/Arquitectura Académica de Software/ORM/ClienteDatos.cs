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
    public class ClienteDatos : IABMC<Cliente>
    {
        private TelefonoDatos VtelefonoDatos = new TelefonoDatos();

        public void Alta(Cliente QueObjeto = null)
        {
            try
            {
                Comando comando = new Comando();
                DataTable dt = comando.ObjStructureTable("cliente");
                DataRow dr = dt.NewRow();

                dr.ItemArray = new object[]
                {
                    QueObjeto.Id,
                    QueObjeto.Nombre,
                    QueObjeto.FechaAlta,
                    QueObjeto.Activo
                };

                dt.Rows.Add(dr);
                comando.ActualizaBase("cliente", dt);

                if (QueObjeto.Telefonos.Count > 0)
                {
                    VtelefonoDatos.ObjetoSolicitante = QueObjeto;

                    foreach (Telefono Tr in QueObjeto.Telefonos)
                        VtelefonoDatos.Alta(Tr);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Baja(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }


        public List<Cliente> Consulta(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }


        public List<Cliente> ConsultaRango(Cliente QueObjeto1 = null, Cliente QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }


        public void Modificacion(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }
    }
}
