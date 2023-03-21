using Abstract;

using ORM;

using Structure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClienteD : IABMC<Cliente>
    {
        private ClienteDatos VclienteDatos;

        public ClienteDatos ClienteDatos { get => VclienteDatos; set => VclienteDatos = value; }

        public ClienteD()
        {
            VclienteDatos = new ClienteDatos();
        }


        public void Alta(Cliente QueObjeto = null)
        {
            ClienteDatos.Alta(QueObjeto);
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
