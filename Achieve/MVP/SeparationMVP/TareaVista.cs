using System;
using System.Windows.Forms;

namespace SeparationMVP
{
    /**
     * The view, meaning our form, does very little. It has properties that
     * reflect the data that will be stored in the data-layer, and fires some
     * specific events.
     * La vista, es decir, nuestro formulario, hace muy poco. Tiene propiedades
     * que reflejan los datos que se almacenarán en la capa de datos y activa
     * algunos eventos específicos.
     */

    public partial class TareaVista : Form, ITarea
    {
        /* ***************************** SETUP ***************************** */

        //private TareaPresentador _presentador;
        public bool IsDirty { get; set; }
        public event EventHandler<EventArgs> SaveTask;
        public event EventHandler<EventArgs> NewTask;
        public event EventHandler<EventArgs> PrevTask;
        public event EventHandler<EventArgs> NextTask;

        public TareaVista()
        {
            InitializeComponent();
        }

        private void TareaVista_Load(object sender, EventArgs e)
        {
            _ = new TareaPresentador(this);
            IsDirty = false;
        }



        public string Nombre
        {
            get { return txtTask.Text; }
            set { txtTask.Text = value; }
        }


        public string Prioridad
        {
            get { return cboPriority.Text; }
            set { cboPriority.Text = value; }
        }


        public DateTime? FechaInicio
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtStartDate.Text)) return null;
                else { return DateTime.Parse(txtStartDate.Text); }
            }
            set
            {
                if (value == null) txtStartDate.Text = string.Empty;
                else { txtStartDate.Text = value.Value.ToShortDateString(); }
            }
        }


        public DateTime? FechaVencimiento
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtDueDate.Text)) return null;
                else { return DateTime.Parse(txtDueDate.Text); }
            }
            set
            {
                if (value == null) txtDueDate.Text = String.Empty;
                else { txtDueDate.Text = value.Value.ToShortDateString(); }
            }
        }


        public bool Completado
        {
            get { return ckbCompleted.Checked; }
            set { ckbCompleted.Checked = value; }
        }


        public DateTime? FechaCompletado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtCompletionDate.Text)) return null;
                else { return DateTime.Parse(txtCompletionDate.Text); }
            }
            set
            {
                if (value == null) txtCompletionDate.Text = String.Empty;
                else { txtCompletionDate.Text = value.Value.ToShortDateString(); }
            }
        }


        public string StatusChange
        {
            set { lblStatus.Text = value; }
        }










        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text))
            {
                MessageBox.Show(
                    "Enter the task name/description.",
                    "Task Detail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtTask.Focus();
                return;
            }
            SaveTask?.Invoke(this, EventArgs.Empty);
        }


        private void New_Click(object sender, EventArgs e)
        {
            if (IsDirty)
            {
                if (AbandonEdit() == DialogResult.Yes) IsDirty = false;
                else { return; }
            }
            NewTask?.Invoke(this, EventArgs.Empty);
        }


        private void Previous_Click(object sender, EventArgs e)
        {
            if (IsDirty)
            {
                if (AbandonEdit() == DialogResult.Yes) IsDirty = false;
                else { return; }
            }
            PrevTask?.Invoke(this, EventArgs.Empty);
        }


        private void Next_Click(object sender, EventArgs e)
        {
            if (IsDirty)
            {
                if (AbandonEdit() == DialogResult.Yes) IsDirty = false;
                else { return; }
            }
            NextTask?.Invoke(this, EventArgs.Empty);
        }


        private DialogResult AbandonEdit()
        {
            return MessageBox.Show(
                "Abandon current editing?",
                "Abandon",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }


        private void txtTask_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }


        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }


        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }


        private void txtDueDate_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }


        private void ckbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }


        private void txtCompletionDate_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}
