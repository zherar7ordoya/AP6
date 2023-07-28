using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SingletonForm
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : Form
    {
		private Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new Point(64, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Form 2";
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(208, 141);
			this.Controls.Add(this.label1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
