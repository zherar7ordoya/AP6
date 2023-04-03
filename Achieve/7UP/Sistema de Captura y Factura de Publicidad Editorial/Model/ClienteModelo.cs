using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClienteModelo : IClienteModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        public List<ITelefonoModelo> Telefonos { get; set; }
        

        #region CONSTRUCTORES
        public ClienteModelo() { }

        /// <summary>
        /// Constructor para las operaciones de Read y Delete
        /// </summary>
        /// <param name="id">Id del cliente</param>
        public ClienteModelo(int id) { Id = id; }

        // Originalmente, el constructor de alta no necesitaba id. Ver notas.

        /// <summary>
        /// Constructor para las operaciones de Create y Update        
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

        #endregion


        #region IMPLEMENTACIONES DE INTERFACES

        public object Clone()
        {
            ClienteModelo cliente = (ClienteModelo)MemberwiseClone();
            Telefonos = new List<ITelefonoModelo>();

            if (Telefonos != null)
            {
                foreach (TelefonoModelo T in Telefonos.Cast<TelefonoModelo>())
                {
                    cliente.Telefonos.Add((TelefonoModelo)T.Clone());
                }
            }
            return cliente;
        }

        #endregion
    }
}
