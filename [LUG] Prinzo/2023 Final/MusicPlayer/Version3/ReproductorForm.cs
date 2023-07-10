using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/**
 * Developer/s: Gerardo Tordoya
 * Description: MUSIC PLAYER (REPRODUCTOR DE MÚSICA)
 *              Con esta reestructuración (la presente actualización fue para
 *              refactorizar), el código del formulario "ReproductorForm" se
 *              ha reducido considerablemente, y la lógica se ha trasladado
 *              al presentador "ReproductorPresenter" y al modelo
 *              "ReproductorMusica".
 *              Ahora hay una mejor separación de responsabilidades y el
 *              código sigue los principios SOLID (como la separación de
 *              intereses y la responsabilidad única). Además, el patrón MVP
 *              se ha aplicado para tener una arquitectura más modular y
 *              mantenible.
 *              => Ver README.md por notas en cuanto a MVP.
 * Create Date: 2023-07-08
 * Update Date: 2023-07-10
 * Forked From: https://youtu.be/QJkFfKDhz5o
 */


namespace MusicPlayer
{
    /// <summary>
    /// El formulario "ReproductorForm" implementa la interfaz
    /// "IReproductorView" y delega la lógica al presentador
    /// "ReproductorPresenter".
    /// </summary>
    public partial class ReproductorForm : Form, IReproductorView
    {
        private ReproductorPresenter _presenter;

        public ReproductorForm()
        {
            InitializeComponent();
            _presenter = new ReproductorPresenter(this);
            VolumenBarra.Value = 50;
        }

        public void ActualizarPistas(List<string> nombresPistas)
        {
            PistasLista.Items.Clear();
            foreach (var nombrePista in nombresPistas)
            {
                PistasLista.Items.Add(nombrePista);
            }
        }

        public void ActualizarImagenCubierta(Image imagen)
        {
            CubiertaPic.Image = imagen;
        }

        public void ActualizarProgresoPista(int duracion, int posicion)
        {
            PistaProgresoBarra.Maximum = duracion;
            PistaProgresoBarra.Value = posicion;
        }

        private void AnteriorBoton_Click(object sender, EventArgs e)
        {
            if (PistasLista.SelectedIndex > 0)
            {
                PistasLista.SelectedIndex--;
            }
        }

        private void SiguienteBoton_Click(object sender, EventArgs e)
        {
            if (PistasLista.SelectedIndex < PistasLista.Items.Count - 1)
            {
                PistasLista.SelectedIndex++;
            }
        }

        private void ReproducirBoton_Click(object sender, EventArgs e)
        {
            _presenter.Reproducir();
        }

        private void PausarBoton_Click(object sender, EventArgs e)
        {
            _presenter.Pausar();
        }

        private void DetenerBoton_Click(object sender, EventArgs e)
        {
            _presenter.Detener();
        }

        private void CargarBoton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selector = new OpenFileDialog
            {
                Multiselect = true
            };

            if (selector.ShowDialog() == DialogResult.OK)
            {
                string[] rutas = selector.FileNames;
                _presenter.CargarPistas(rutas);
            }
        }

        private void PistasLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.SeleccionarPista(PistasLista.SelectedIndex);
        }

        private void VolumenBarra_Scroll(object sender, EventArgs e)
        {
            _presenter.CambiarVolumen(VolumenBarra.Value);
            NivelVolumenEtiqueta.Text = string.Format("{0}%", VolumenBarra.Value.ToString());
        }

        private void PistaProgresoBarra_MouseDown(object sender, MouseEventArgs e)
        {
            _presenter.CambiarPosicionPista(e.X * 100 / PistaProgresoBarra.Width);
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                PistaProgresoBarra.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
                PistaProgresoBarra.Value = (int)Reproductor.Ctlcontrols.currentPosition;

                try
                {
                    PistaProgresoEtiqueta.Text = Reproductor.Ctlcontrols.currentPositionString;
                    PistaDuracionEtiqueta.Text = Reproductor.Ctlcontrols.currentItem.durationString;
                }
                catch { }
            }
        }
    }
}
