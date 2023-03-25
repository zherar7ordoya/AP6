using Abstract;
using System;
using System.Collections.Generic;


namespace Structure
{
    public class ClienteModelo : IEstandarId, ICloneable
    {
        public List<TelefonoModelo> Telefonos = new List<TelefonoModelo>();
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }


        // Constructores
        public ClienteModelo() { }

        /// <summary>
        /// Este constructor es el que se usa en las operaciones de baja
        /// </summary>
        /// <param name="id">Id del cliente</param>
        public ClienteModelo(int id) { Id = id; }

        // Originalmente, el constructor de alta no necesitaba id. Ver notas.

        /// <summary>
        /// Este constructor es el que se usa en las operaciones de alta y de
        /// modificación
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="fechaAlta">Fecha de alta del cliente</param>
        /// <param name="activo">Borrado lógico</param>
        public ClienteModelo(
            int id,
            string nombre,
            DateTime fechaAlta,
            bool activo)
        {
            Id = id;
            Nombre = nombre;
            FechaAlta = fechaAlta;
            Activo = activo;
        }


        // Implementaciones (Interfaces)
        public int RetornaId() { return Id; }

        public object Clone()
        {
            ClienteModelo RetornoCliente = (ClienteModelo)MemberwiseClone();

            if (Telefonos != null) // *--------------------> Clonación Profunda
            {
                foreach (TelefonoModelo T in Telefonos)
                {
                    RetornoCliente.Telefonos.Add((TelefonoModelo)T.Clone());
                }
            }
            return RetornoCliente;
        }
    }
}
