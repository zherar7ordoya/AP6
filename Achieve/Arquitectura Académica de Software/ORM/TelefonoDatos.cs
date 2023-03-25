using Abstract;
using DataAccess;
using Structure;
using System;
using System.Collections.Generic;
using System.Data;


namespace ORM
{
    public class TelefonoDatos : IEstandarCRUD<TelefonoModelo>, IEstandarId
    {
        private readonly Comando comando = new Comando();
        private IEstandarId _clienteId;

        public IEstandarId ClienteId
        {
            get => _clienteId;
            set => _clienteId = value;
        }

        public int RetornaId()
        {
            return ((int)comando
                .RetornaTablaCompleta("SELECT MAX(TelefonoId) FROM Telefono")
                .Rows[0]
                .ItemArray[0]) + 1;
        }

        public void Alta(TelefonoModelo telefono = null)
        {
            DataTable tabla = comando.RetornaTablaEstructura("Telefono");

            /**
             * Las modificaciones que se hicieron aquí viene dadas porque, para
             * poder relacionar la tabla Cliente y Telefono, necesito que un
             * teléfono dado de alta contenga el id del cliente al que
             * pertenece.
             */

            DataRow fila = tabla.NewRow();

            fila.ItemArray= new object[]
            {
                RetornaId(),
                _clienteId.RetornaId(),
                telefono.Numero,
                true
            };
            tabla.Rows.Add(fila);
            comando.ActualizaBase("Telefono", tabla);
        }

        
        public void Baja(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public void Modificacion(TelefonoModelo QueObjeto = null)
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
    }
}
