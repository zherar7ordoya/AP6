using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SingletonForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 


	public class Form1 : System.Windows.Forms.Form
			{
				private System.Windows.Forms.Label label1;
				/// <summary>
				/// Required designer variable.
				/// </summary>
				private System.ComponentModel.Container components = null;

				private static Form1 aForm = null;
				public static Form1  Instance()
				{
					if(aForm==null)
					{
						aForm = new Form1();
					}
					return aForm;
				}

				private Form1()
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
					aForm = null;
				}

				#region Windows Form Designer generated code
				/// <summary>
				/// Required method for Designer support - do not modify
				/// the contents of this method with the code editor.
				/// </summary>
				private void InitializeComponent()
				{
					this.label1 = new System.Windows.Forms.Label();
					this.SuspendLayout();
					// 
					// label1
					// 
					this.label1.Location = new System.Drawing.Point(64, 40);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(48, 23);
					this.label1.TabIndex = 0;
					this.label1.Text = "From 1";
					// 
					// Form1
					// 
					this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
					this.ClientSize = new System.Drawing.Size(184, 125);
					this.Controls.Add(this.label1);
					this.Name = "Form1";
					this.Text = "Form1";
					this.ResumeLayout(false);

				}
				#endregion
			}
}
