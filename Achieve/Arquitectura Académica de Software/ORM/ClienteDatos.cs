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
    public class ClienteDatos : IABMC<ClienteModelo>
    {
        private readonly TelefonoDatos _telefonoDA = new TelefonoDatos();

        public void Alta(ClienteModelo cliente = null)
        {
            try
            {
                Comando comando = new Comando();
                DataTable tabla = comando.ObjStructureTable("Cliente");
                DataRow fila = tabla.NewRow();

                fila.ItemArray = new object[]
                {
                    cliente.Id,
                    cliente.Nombre,
                    cliente.FechaAlta,
                    cliente.Activo
                };

                tabla.Rows.Add(fila);
                comando.ActualizaBase("Cliente", tabla);

                if (cliente.Telefonos.Count > 0)
                {
                    _telefonoDA.ObjetoSolicitante = cliente;

                    foreach (TelefonoModelo telefono in cliente.Telefonos)
                    {
                        _telefonoDA.Alta(telefono);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void Baja(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }


        public List<ClienteModelo> ConsultaObjeto(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }


        public List<ClienteModelo> ConsultaRango(ClienteModelo QueObjeto1 = null, ClienteModelo QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }


        public void Modificacion(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
    }
}
