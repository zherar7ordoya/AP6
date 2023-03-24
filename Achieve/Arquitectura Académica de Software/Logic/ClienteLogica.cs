﻿/**
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
        ClienteDatos _clienteDA;
        public ClienteDatos ClienteDA { get => _clienteDA; set => _clienteDA = value; }

        public ClienteLogica() { _clienteDA = new ClienteDatos(); }


        public void Alta(ClienteModelo QueObjeto = null)
        {
            ClienteDA.Alta(QueObjeto);
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
