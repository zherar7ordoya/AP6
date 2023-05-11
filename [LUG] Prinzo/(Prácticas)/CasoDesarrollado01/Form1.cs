using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasoDesarrollado01
{
    public partial class Form1 : Form
    {
        public event EventHandler Calcular;
        public event EventHandler Limpiar;
        public event EventHandler Salir;

        public Form1()
        {
            InitializeComponent();
            CalcularButton.Click += delegate { Calcular?.Invoke(this, EventArgs.Empty); };
            LimpiarButton.Click += delegate { Limpiar?.Invoke(this, EventArgs.Empty); };
            SalirButton.Click += delegate { Salir?.Invoke(this, EventArgs.Empty); };
        }

        public string Alumno
        {
            get => AlumnoTextBox.Text;
            set => AlumnoTextBox.Text = value;
        }

        public string Promedio
        {
            get => PromedioTextBox.Text;
            set => PromedioTextBox.Text = value;
        }

        public string Baja
        {
            get => BajaTextBox.Text;
            set => BajaTextBox.Text = value;
        }

        public string Condicion
        {
            get => CondicionTextBox.Text;
            set => CondicionTextBox.Text = value;
        }

        public string Nota1
        {
            get => Nota1TextBox.Text;
            set => Nota1TextBox.Text = value;
        }

        public string Nota2
        {
            get => Nota2TextBox.Text;
            set => Nota2TextBox.Text = value;
        }

        public string Nota3
        {
            get => Nota3TextBox.Text;
            set => Nota3TextBox.Text = value;
        }

        public string Nota4
        {
            get => Nota4TextBox.Text;
            set => Nota4TextBox.Text = value;
        }
    }
}
