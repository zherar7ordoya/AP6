using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SingletonForm
{
	/// <summary>
	/// Summary description for MDI.
	/// </summary>
	public class MDI : Form
    {
		private MainMenu mainMenu1;
		private MenuItem menuItem1;
		private MenuItem menuItem2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public MDI()
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
			this.mainMenu1 = new MainMenu();
			this.menuItem1 = new MenuItem();
			this.menuItem2 = new MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "From1";
			this.menuItem1.Click += new EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Form 2";
			this.menuItem2.Click += new EventHandler(this.menuItem2_Click);
			// 
			// MDI
			// 
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(292, 273);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MDI";
			this.Text = "MDI";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			MDI mdi = new MDI();
			mdi.ShowDialog();
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			Form f = Form1.Instance();
			f.MdiParent = this;
			f.Show();
			f.Activate();
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			Form f = new Form2();
			f.MdiParent = this;
			f.Show();
		}
	}
}
