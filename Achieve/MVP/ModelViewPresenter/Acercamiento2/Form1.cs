﻿using System;
using System.Windows.Forms;
using Presentador;

/// <summary>
/// https://nicolocodev.wordpress.com/2011/08/31/patronmvpnet/
/// </summary>

namespace Acercamiento2
{
    public partial class Form1 : Form, IVistaOperaciones
    {
        private readonly PresentadorOperaciones _operaciones;
        public Form1()
        {
            InitializeComponent();
            _operaciones = new PresentadorOperaciones(this);
        }

        #region Implementation of IVistaOperaciones
        public double Num1
        {
            get { return !string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDouble(textBox1.Text) : 0; }
            set { textBox1.Text = value.ToString(); }
        }
        public double Num2
        {
            get { return !string.IsNullOrEmpty(textBox2.Text) ? Convert.ToDouble(textBox2.Text) : 0; }
            set { textBox2.Text = value.ToString(); }
        }
        public double Resultado
        {
            set { label1.Text = value.ToString(); }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            _operaciones.IniciarVista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _operaciones.ActualizarVista();
        }
    }
}
