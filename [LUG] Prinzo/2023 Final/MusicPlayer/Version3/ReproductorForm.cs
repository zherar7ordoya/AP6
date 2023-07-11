using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using WMPLib;
using AxWMPLib;

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
            VolumenBarra.Value = 50;

            _presenter = new ReproductorPresenter(this);
        }

        // Implementar los métodos de la interfaz IReproductorView
        public event EventHandler AnteriorBotonClick
        {
            add { AnteriorBoton.Click += value; }
            remove { AnteriorBoton.Click -= value; }
        }

        public event EventHandler SiguienteBotonClick
        {
            add { SiguienteBoton.Click += value; }
            remove { SiguienteBoton.Click -= value; }
        }

        public event EventHandler ReproducirBotonClick
        {
            add { ReproducirBoton.Click += value; }
            remove { ReproducirBoton.Click -= value; }
        }

        public event EventHandler PausarBotonClick
        {
            add { PausarBoton.Click += value; }
            remove { PausarBoton.Click -= value; }
        }

        public event EventHandler DetenerBotonClick
        {
            add { DetenerBoton.Click += value; }
            remove { DetenerBoton.Click -= value; }
        }

        public event EventHandler CargarBotonClick
        {
            add { CargarBoton.Click += value; }
            remove { CargarBoton.Click -= value; }
        }

        public event EventHandler PistasListaSelectedIndexChanged
        {
            add { PistasLista.SelectedIndexChanged += value; }
            remove { PistasLista.SelectedIndexChanged -= value; }
        }

        public event EventHandler VolumenBarraScroll
        {
            add { VolumenBarra.Scroll += value; }
            remove { VolumenBarra.Scroll -= value; }
        }

        public event MouseEventHandler PistaProgresoBarraMouseDown
        {
            add { PistaProgresoBarra.MouseDown += value; }
            remove { PistaProgresoBarra.MouseDown -= value; }
        }

        public event EventHandler TemporizadorTick
        {
            add { Temporizador.Tick += value; }
            remove { Temporizador.Tick -= value; }
        }

        public void SeleccionarPistaAnterior()
        {
            if (PistasLista.SelectedIndex > 0)
            {
                PistasLista.SelectedIndex--;
            }
        }

        public void SeleccionarPistaSiguiente()
        {
            if (PistasLista.SelectedIndex < PistasLista.Items.Count - 1)
            {
                PistasLista.SelectedIndex++;
            }
        }

        public void ReproducirPista(string ruta)
        {
            Reproductor.URL = ruta;
            Reproductor.Ctlcontrols.play();
        }

        public void RestablecerProgresoPista()
        {
            PistaProgresoBarra.Value = 0;
        }

        public string[] SeleccionarArchivos()
        {
            OpenFileDialog selector = new OpenFileDialog
            {
                Multiselect = true
            };

            if (selector.ShowDialog() == DialogResult.OK)
            {
                return selector.FileNames;
            }

            return null;
        }

        public int ObtenerIndicePistaSeleccionada()
        {
            return PistasLista.SelectedIndex;
        }

        public void ActualizarListaPistas(string[] nombresPistas)
        {
            PistasLista.Items.Clear();
            PistasLista.Items.AddRange(nombresPistas);
        }

        public void MostrarImagenCubierta(Image imagen)
        {
            CubiertaPic.Image = imagen;
        }

        public int ObtenerVolumen()
        {
            return VolumenBarra.Value;
        }

        public void ActualizarEtiquetaVolumen(int volumen)
        {
            NivelVolumenEtiqueta.Text = string.Format("{0}%", volumen.ToString());
        }

        public int CalcularPosicionPista(int x)
        {
            return (int)(Reproductor.currentMedia.duration * x / PistaProgresoBarra.Width);
        }

        public void ActualizarProgresoPista(int duracionActual, int duracionTotal)
        {
            PistaProgresoBarra.Maximum = duracionTotal;
            PistaProgresoBarra.Value = duracionActual;
        }

        public void ActualizarEtiquetasPista(int posicionActual, string duracionActualString)
        {
            PistaProgresoEtiqueta.Text = duracionActualString;
            PistaDuracionEtiqueta.Text = Reproductor.Ctlcontrols.currentItem.durationString;
        }





        


    }
}
