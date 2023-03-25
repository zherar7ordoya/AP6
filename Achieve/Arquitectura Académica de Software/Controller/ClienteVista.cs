using Logic;
using static Microsoft.VisualBasic.Interaction;
using Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Controller
{
    /**
     * ¿Por qué le saco la obligación de implementar IEstandarId? Porque, si lo
     * implemento, la vista al llamar a los métodos de esta clase se ve
     * obligada a conocer la capa de estructura, dejando así a un lado las
     * restricciones que la arquitectura me impone.
     */
    public class ClienteVista
    {
        readonly Form _formulario;

        private ClienteModelo _clienteBE = new ClienteModelo();
        private ClienteLogica _clienteBL = new ClienteLogica();

        public ClienteModelo ClienteBE { get => _clienteBE; set => _clienteBE = value; }
        public ClienteLogica ClienteBL { get => _clienteBL; set => _clienteBL = value; }

        // Constructores
        public ClienteVista(Form formulario) { _formulario = formulario; }


        /**
         * No tiene sentido que tenga como parámetro a Cliente. ¿Por qué?
         * Porque el parámetro es el objeto que se va a modificar. Pero en este
         * caso, estoy construyendo un objeto nuevo a partir de lo que obtengo
         * de lavista.
         */
        public void Alta()
        {
            int clienteId = _clienteBL.RetornaClienteId();

            /**
             * Bueno, aquí hay todo un tema. Tiene que ver con cómo se ha
             * diseñado la base de datos. ¿Por qué? Porque el Id del cliente
             * (y del teléfono) está administrado por la base de datos. En un
             * principio lo hice (según la práctica normal) autoincremental.
             * Pero hay un problema con lo autoincremental. Según ciertas
             * situaciones que no vienen al caso, no siempre va a darse que el
             * próximo Id sea el siguiente. Por ejemplo, si borro un registro,
             * o si este proyecto lo llevo a otra computadora (no sé la razón,
             * la verdad) el próximo Id puede no ser el inmediato posterior.
             * Entonces opté por hacer la clave primaria UNIQUE. Por otro lado,
             * por la forma en que trabaja el DataTable, aparentemente no es
             * posible indicarle que una columna sea autoincremental.
             * El control del Id es necesario para relacionar la tabla Telefono
             * y no parece buena idea que el usuario decida la Id (no es
             * práctica normal). Es por eso que no tomo el Id del cliente de lo
             * que haya puesto el usuario en la vista. Lo tomo de la base de
             * datos y, al hacer esa columna UNIQUE, me aseguro que no vaya a
             * tener tampoco el error de que el SGBD me rechace el Id siguiente
             * al máximo que obra en esa columna.
             */
            //ClienteBE.Id = int.Parse(Formulario.Controls.Find("Id", true).FirstOrDefault().Text);

            _clienteBE.Id = clienteId;
            _clienteBE.Nombre = _formulario.Controls.Find("Nombre", true).FirstOrDefault().Text;
            _clienteBE.FechaAlta = DateTime.Parse(_formulario.Controls.Find("FechaAlta", true).FirstOrDefault().Text);
            _clienteBE.Activo = (_formulario.Controls.Find("Activo", true).FirstOrDefault() as CheckBox).Checked;

            /**
             * ¿Por qué un contador?  Necesito un contador porque, en una
             * primera pasada, voy a recuperar el Id del teléfono que
             * corresponde a lo guardado en la base de datos. En una segunda
             * pasada, cuando recupere el Id, voy a obtener el mismo porque aún
             * no guardé el anterior.
             */
            int contador = 0;

            while (MessageBox.Show(
                "¿Desea ingresar un teléfono?",
                "Teléfonos",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int telefonoId = _clienteBL.RetornaTelefonoId() + contador;
                contador++; // Incremento el contador para que en la siguiente
                            // iteración, el Id que recupere sea el siguiente.

                _clienteBE.Telefonos.Add(
                    new TelefonoModelo(
                        telefonoId,
                        clienteId,
                        InputBox("Ingrese el nuevo número de teléfono"),
                        true));
            }
            _clienteBL.Alta(_clienteBE);
        }


        public void Baja() { throw new NotImplementedException(); }
        public void Modificacion() { throw new NotImplementedException(); }
        public List<ClienteModelo> ConsultaObjeto() { throw new NotImplementedException(); }
        public List<ClienteModelo> ConsultaRango() { throw new NotImplementedException(); }
    }
}
