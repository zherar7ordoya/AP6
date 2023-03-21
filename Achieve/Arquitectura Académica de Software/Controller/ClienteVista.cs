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
    public class ClienteVista : IABMC<Cliente>
    {
        Cliente _vcliente;
        ClienteD _vclienteD;
        readonly Form Vgui;

        public Cliente Vcliente { get => _vcliente; set => _vcliente = value; }
        public ClienteD VclienteD { get => _vclienteD; set => _vclienteD = value; }


        public ClienteVista(Form formulario)
        {
            Vgui = formulario;
            _vcliente = new Cliente();
            _vclienteD = new ClienteD();
        }


        public void Alta(Cliente QueObjeto = null)
        {
            Vcliente.Id = int.Parse(Vgui.Controls.Find("Id", true).FirstOrDefault().Text);
            Vcliente.Nombre = Vgui.Controls.Find("Nombre", true).FirstOrDefault().Text;
            Vcliente.FechaAlta = DateTime.Parse(Vgui.Controls.Find("FechaAlta", true).FirstOrDefault().Text);
            //Vcliente.Activo = bool.Parse(Vgui.Controls.Find("Activo", true).FirstOrDefault().Text);
            Vcliente.Activo = (Vgui.Controls.Find("Activo", true).FirstOrDefault() as CheckBox).Checked;

            DialogResult resultado = MessageBox.Show(
                "¿Desea ingresar un teléfono?",
                "Teléfonos",
                MessageBoxButtons.YesNo);

            
            while (resultado == DialogResult.Yes)
            {

                Vcliente.Telefonos.Add(new Telefono(Vcliente.Id, InputBox("Ingrese el nuevo número de teléfono")));

                resultado = MessageBox.Show(
                    "¿Desea ingresar un teléfono?",
                    "Teléfonos",
                    MessageBoxButtons.YesNo);
            }

            VclienteD.Alta(Vcliente);
        }

        public void Baja(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Consulta(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ConsultaRango(Cliente QueObjeto1 = null, Cliente QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Cliente QueObjeto = null)
        {
            throw new NotImplementedException();
        }
    }
}
