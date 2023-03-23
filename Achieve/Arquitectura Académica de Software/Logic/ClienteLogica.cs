/**
 * La capa denominada "lógica" contiene los comportamientos correspondientes a
 * las entidades del negocio (reglas de negocio), incluyendo los definidos por
 * las operaciones básicas del CRUD.
 * 
 *              => OPERACIONES PROPIAS + OPERACIONES CRUD
 */

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
    public class ClienteLogica : IABMC<ClienteModelo>
    {
        private ClienteDatos VclienteDatos;

        public ClienteDatos ClienteDatos { get => VclienteDatos; set => VclienteDatos = value; }

        public ClienteLogica()
        {
            VclienteDatos = new ClienteDatos();
        }


        public void Alta(ClienteModelo QueObjeto = null)
        {
            ClienteDatos.Alta(QueObjeto);
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
