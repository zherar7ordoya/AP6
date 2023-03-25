using Abstract;
using DataAccess;
using Structure;
using System;
using System.Collections.Generic;
using System.Data;


namespace ORM
{
    public class ClienteDatos : IEstandarCRUD<ClienteModelo>, IEstandarId
    {
        private Comando _comando = new Comando();
        private readonly TelefonoDatos _telefonoDA = new TelefonoDatos();


        public int RetornaId()
        {
            return ((int)_comando
                .RetornaTablaCompleta("SELECT MAX(ClienteId) FROM Cliente")
                .Rows[0]
                .ItemArray[0]) + 1;
        }


        public void Alta(ClienteModelo cliente = null)
        {
            try
            {
                DataTable tabla = _comando.RetornaTablaEstructura("Cliente");
                DataRow fila = tabla.NewRow();

                /**
                 * ¿Por qué le tengo que pasar el Id del cliente si, por
                 * ejemplo, es autoincremental en la base de datos?: I don't
                 * think that it's possible to trigger the AutoIncrement
                 * functionality when the rows are already in the table.
                 * https://stackoverflow.com/a/16179861/14009797
                 */
                int id = RetornaId();

                fila.ItemArray = new object[]
                {
                    id,
                    cliente.Nombre,
                    cliente.FechaAlta,
                    cliente.Activo
                };

                tabla.Rows.Add(fila);
                _comando.ActualizaBase("Cliente", tabla);

                if (cliente.Telefonos.Count > 0)
                {
                    _telefonoDA.ClienteId = cliente;

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
