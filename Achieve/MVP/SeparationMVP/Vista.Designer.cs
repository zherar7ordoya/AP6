namespace SeparationMVP
{
    partial class Vista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.ckbCompleted = new System.Windows.Forms.CheckBox();
            this.lblCompletionDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtCompletionDate = new System.Windows.Forms.TextBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(15, 170);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(286, 198);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(205, 198);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboPriority
            // 
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cboPriority.Location = new System.Drawing.Point(15, 82);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(121, 21);
            this.cboPriority.TabIndex = 4;
            this.cboPriority.SelectedIndexChanged += new System.EventHandler(this.cboPriority_SelectedIndexChanged);
            // 
            // ckbCompleted
            // 
            this.ckbCompleted.AutoSize = true;
            this.ckbCompleted.Location = new System.Drawing.Point(204, 160);
            this.ckbCompleted.Name = "ckbCompleted";
            this.ckbCompleted.Size = new System.Drawing.Size(76, 17);
            this.ckbCompleted.TabIndex = 5;
            this.ckbCompleted.Text = "Completed";
            this.ckbCompleted.UseVisualStyleBackColor = true;
            this.ckbCompleted.CheckedChanged += new System.EventHandler(this.ckbCompleted_CheckedChanged);
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.AutoSize = true;
            this.lblCompletionDate.Location = new System.Drawing.Point(283, 141);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(85, 13);
            this.lblCompletionDate.TabIndex = 6;
            this.lblCompletionDate.Text = "Completion Date";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(283, 66);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(53, 13);
            this.lblDueDate.TabIndex = 7;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 66);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "Priority";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(283, 9);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 9;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(12, 236);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(30, 15);
            this.lblStatus.TabIndex = 10;
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.Location = new System.Drawing.Point(286, 157);
            this.txtCompletionDate.Name = "txtCompletionDate";
            this.txtCompletionDate.Size = new System.Drawing.Size(100, 20);
            this.txtCompletionDate.TabIndex = 11;
            this.txtCompletionDate.TextChanged += new System.EventHandler(this.txtCompletionDate_TextChanged);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(286, 83);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(100, 20);
            this.txtDueDate.TabIndex = 12;
            this.txtDueDate.TextChanged += new System.EventHandler(this.txtDueDate_TextChanged);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(286, 25);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 20);
            this.txtStartDate.TabIndex = 13;
            this.txtStartDate.TextChanged += new System.EventHandler(this.txtStartDate_TextChanged);
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(12, 9);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 14;
            this.lblTask.Text = "Task";
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(15, 25);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(100, 20);
            this.txtTask.TabIndex = 15;
            this.txtTask.TextChanged += new System.EventHandler(this.txtTask_TextChanged);
            // 
            // Vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 300);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.txtCompletionDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblCompletionDate);
            this.Controls.Add(this.ckbCompleted);
            this.Controls.Add(this.cboPriority);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnNew);
            this.Name = "Vista";
            this.Text = "frmTasks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.CheckBox ckbCompleted;
        private System.Windows.Forms.Label lblCompletionDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtCompletionDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.TextBox txtTask;
    }
}

