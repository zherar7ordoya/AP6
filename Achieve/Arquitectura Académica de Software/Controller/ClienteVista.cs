using Abstract;

using Logic;

using static Microsoft.VisualBasic.Interaction;

using Structure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class ClienteVista : IABMC<ClienteModelo>
    {
        ClienteModelo _clienteBE;
        ClienteLogica _clienteBL;

        public ClienteModelo ClienteBE { get => _clienteBE; set => _clienteBE = value; }
        public ClienteLogica ClienteBL { get => _clienteBL; set => _clienteBL = value; }

        readonly Form Formulario;

        public ClienteVista(Form formulario)
        {
            Formulario = formulario;
            ClienteBE = new ClienteModelo();
            ClienteBL = new ClienteLogica();
        }


        // No tiene sentido que tenga como parámetro a Cliente. ¿Por qué? Porque
        // el parámetro es el objeto que se va a modificar. En este caso, el
        // objeto que se va a modificar es el que está en la vista. Por eso
        // no tiene sentido que tenga parámetro.
        /* public void Alta(Cliente QueObjeto = null) */
        public void Alta(ClienteModelo cliente = null)
        {
            ClienteBE.Id = int.Parse(Formulario.Controls.Find("Id", true).FirstOrDefault().Text);
            ClienteBE.Nombre = Formulario.Controls.Find("Nombre", true).FirstOrDefault().Text;
            ClienteBE.FechaAlta = DateTime.Parse(Formulario.Controls.Find("FechaAlta", true).FirstOrDefault().Text);
            ClienteBE.Activo = (Formulario.Controls.Find("Activo", true).FirstOrDefault() as CheckBox).Checked;

            while (MessageBox.Show(
                "¿Desea ingresar un teléfono?",
                "Teléfonos",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClienteBE.Telefonos.Add(new TelefonoModelo(ClienteBE.Id, InputBox("Ingrese el nuevo número de teléfono")));
            }

            ClienteBL.Alta(ClienteBE);
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
