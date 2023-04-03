using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TelefonoModelo : ITelefonoModelo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public bool Activo { get; set; }


        #region CONSTRUCTORES

        public TelefonoModelo() { }

        /// <summary>
        /// Constructor para las operaciones de Read y Delete
        /// </summary>
        /// <param name="id">Id del teléfono</param>
        public TelefonoModelo(int id) { Id = id; }

        /// <summary>
        /// Constructor para las operaciones de Create y Update
        /// </summary>
        /// <param name="id">Id del teléfono</param>
        /// <param name="clienteId">Id del cliente</param>
        /// <param name="numero">Número de teléfono</param>
        /// <param name="activo">Borrado lógico</param>
        public TelefonoModelo(
            int id,
            int clienteId,
            string numero,
            bool activo)
        {
            Id = id;
            ClienteId = clienteId;
            Numero = numero;
            Activo = activo;
        }

        #endregion


        #region IMPLEMENTACIONES DE INTERFACES

        public object Clone() { return MemberwiseClone(); }

        #endregion
    }
}
