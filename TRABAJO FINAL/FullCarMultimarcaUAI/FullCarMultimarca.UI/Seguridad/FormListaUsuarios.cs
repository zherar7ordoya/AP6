
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios.Extensiones;
using FullCarMultimarca.Vistas;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormListaUsuarios : FormListaBase
    {
        private FormListaUsuarios()
        {
            InitializeComponent();
        }
        private static FormListaUsuarios _instancia;
        public static FormListaUsuarios ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaUsuarios();
            if (_instancia.IsDisposed)
                _instancia = new FormListaUsuarios();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                new ConsultaCriterio(nameof(Usuario.Logon).ObtenerFullNameMasPropiedad<Usuario>(), "Logon"),
                new ConsultaCriterio(nameof(Usuario.Nombre).ObtenerFullNameMasPropiedad<Usuario>(),"Nombre"),
                new ConsultaCriterio(nameof(Usuario.Apellido).ObtenerFullNameMasPropiedad<Usuario>(), "Apellido") }) ;

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLUsuario.ObtenerInstancia().Buscar((string)cmbCampoBusqueda.SelectedValue,txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaUsuario));
            ActualizarOrdenamiento<VistaUsuario>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormAltaUsuario();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaUsuario>();
            if (elem != default)
            {
                var fModf = new FormModificarUsuario(BLLUsuario.ObtenerInstancia().Leer(new Usuario { Logon = elem.Logon }));
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaUsuario>();
            if (elem != default)
            {
                var usr = BLLUsuario.ObtenerInstancia().Leer(new Usuario { Logon = elem.Logon });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar al usuario {usr}?") == DialogResult.Yes)
                {
                    BLLUsuario.ObtenerInstancia().Eliminar(usr);
                    RefrescarGrilla();
                }
            }
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaUsuario>();
        }       

        private void btnRestablecerClave_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaUsuario>();
                if(elem != null)
                {
                    var usr = BLLUsuario.ObtenerInstancia().Leer(new Usuario { Logon = elem.Logon });

                    if (MostrarMensaje.Pregunta($"¿Desea restablecer la clave del usuario {usr}?\n" +
                        $"No se exige seguridad de clave (salvo la minima cantidad de caracteres establecida) ya que el usuario deberá modificarla la proxima vez que ingrese.") == DialogResult.Yes)
                    {                                           
                        string nuevaClave = BLLUsuario.ObtenerInstancia().GenerarClaveRandom(usr);
                        MostrarMensaje.Informacion($"Nueva clave: {nuevaClave}");
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaUsuario>();
                if (elem != null)
                {
                    var usr = BLLUsuario.ObtenerInstancia().Leer(new Usuario { Logon = elem.Logon });

                    if (!usr.Bloqueado)
                        throw new NegocioException("El usuario no está bloqueado.");

                    if (MostrarMensaje.Pregunta($"¿Desea desbloquear al usuario {usr}?") == DialogResult.Yes)
                    {                        
                        BLLUsuario.ObtenerInstancia().DesbloquearUsuario(usr);
                        RefrescarGrilla();
                        MostrarMensaje.Informacion("Usuario desbloqueado.");
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }

    }
}
