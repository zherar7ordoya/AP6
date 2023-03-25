using Abstract;
using ORM;
using Structure;
using System;
using System.Collections.Generic;


namespace Logic
{
    public class ClienteLogica : IEstandarCRUD<ClienteModelo>
    {
        readonly ClienteDatos _clienteDA = new ClienteDatos();
        readonly TelefonoDatos _telefonoDA = new TelefonoDatos();


        public int RetornaClienteId() { return _clienteDA.RetornaId(); }
        public int RetornaTelefonoId() { return _telefonoDA.RetornaId(); }


        public void Alta(ClienteModelo cliente = null)
        {
            _clienteDA.Alta(cliente);
        }


        public void Baja(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public void Modificacion(ClienteModelo QueObjeto = null)
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
    }
}
