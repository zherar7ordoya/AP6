using System;
using System.Windows.Forms;

namespace Version2
{
    public partial class TareaVista : Form, ITareaVista
    {
        public string Estado { set { StatusLabel.Text = value; } }
        public bool Cambiado { get; set; }

        
        public TareaVista()
        {
            InitializeComponent();
        }

        private void TareaForm_Load(object sender, EventArgs e)
        {
            _ = new TareaPresentador(this);
            Cambiado = false;
        }


        public event EventHandler<EventArgs> NuevaTarea;
        public event EventHandler<EventArgs> GuardarTarea;
        public event EventHandler<EventArgs> TareaAnterior;
        public event EventHandler<EventArgs> TareaSiguiente;

        private DialogResult AbandonaEdicion()
        {
            return MessageBox.Show(
                "¿Abandonar edición?",
                "Abandonar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }


        private void GuardarBtn_Click(object sender, EventArgs e)
        {
            GuardarTarea?.Invoke(this, EventArgs.Empty);
        }

        private void NuevaBtn_Click(object sender, EventArgs e)
        {
            if (Cambiado)
            {
                if (AbandonaEdicion() == DialogResult.Yes) Cambiado = false;
                else { return; }
            }
            NuevaTarea?.Invoke(this, EventArgs.Empty);
        }

        private void AnteriorBtn_Click(object sender, EventArgs e)
        {
            if (Cambiado)
            {
                if (AbandonaEdicion() == DialogResult.Yes) Cambiado = false;
                else { return; }
            }
            TareaAnterior?.Invoke(this, EventArgs.Empty);
        }

        private void SiguienteBtn_Click(object sender, EventArgs e)
        {
            if (Cambiado)
            {
                if (AbandonaEdicion() == DialogResult.Yes) Cambiado = false;
                else { return; }
            }
            TareaSiguiente?.Invoke(this, EventArgs.Empty);
        }


        public int Id { get; set; }

        public string Nombre
        {
            get { return NombreCtrl.Text; }
            set => NombreCtrl.Text = value;
        }

        public string Prioridad
        {
            get { return PrioridadCtrl.Text; }
            set => PrioridadCtrl.Text = value;
        }

        public DateTime? FechaComienzo
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FechaComienzoCtrl.Text)) return null;
                else { return DateTime.Parse(FechaComienzoCtrl.Text); }
            }
            set
            {
                if (value == null) FechaComienzoCtrl.Text = string.Empty;
                else { FechaComienzoCtrl.Text = value.ToString(); }
            }
        }

        public DateTime? FechaVencimiento
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FechaVencimientoCtrl.Text)) return null;
                else { return DateTime.Parse(FechaVencimientoCtrl.Text); }
            }
            set
            {
                if (value == null) FechaVencimientoCtrl.Text = string.Empty;
                else { FechaVencimientoCtrl.Text = value.ToString(); }
            }
        }

        public bool Completada
        {
            get { return CompletadaCtrl.Checked; }
            set => CompletadaCtrl.Checked = value;
        }

        public DateTime? FechaTerminacion
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FechaTerminacionCtrl.Text)) return null;
                else { return DateTime.Parse(FechaTerminacionCtrl.Text); }
            }
            set
            {
                if (value == null) FechaTerminacionCtrl.Text = string.Empty;
                else { FechaTerminacionCtrl.Text = value.ToString(); }
            }
        }


        private void NombreCtrl_TextChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }

        private void PrioridadCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }

        private void FechaComienzoCtrl_TextChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }

        private void FechaVencimientoCtrl_TextChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }

        private void FechaTerminacionCtrl_TextChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }

        private void CompletadaCtrl_CheckedChanged(object sender, EventArgs e)
        {
            Cambiado = true;
        }
    }
}
