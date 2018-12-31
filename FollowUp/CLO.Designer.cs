namespace FollowUp
{
    partial class CLO
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
            this.StartDatet = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfCells = new System.Windows.Forms.TextBox();
            this.Complexity = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.Family = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.SLDCLODate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CLOSLDButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDatet
            // 
            this.StartDatet.Location = new System.Drawing.Point(106, 28);
            this.StartDatet.Name = "StartDatet";
            this.StartDatet.Size = new System.Drawing.Size(201, 20);
            this.StartDatet.TabIndex = 62;
            this.StartDatet.Tag = "WBS";
            this.StartDatet.TextChanged += new System.EventHandler(this.StartDatet_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 61;
            this.label14.Text = "Start Date";
            // 
            // StartDate
            // 
            this.StartDate.CustomFormat = "dd/MM/yyyy";
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(106, 28);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(236, 20);
            this.StartDate.TabIndex = 63;
            this.StartDate.TabStop = false;
            this.StartDate.ValueChanged += new System.EventHandler(this.StartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "No. Of Cells";
            // 
            // NumberOfCells
            // 
            this.NumberOfCells.Location = new System.Drawing.Point(106, 68);
            this.NumberOfCells.Name = "NumberOfCells";
            this.NumberOfCells.Size = new System.Drawing.Size(236, 20);
            this.NumberOfCells.TabIndex = 64;
            // 
            // Complexity
            // 
            this.Complexity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Complexity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Complexity.FormattingEnabled = true;
            this.Complexity.Location = new System.Drawing.Point(106, 112);
            this.Complexity.Name = "Complexity";
            this.Complexity.Size = new System.Drawing.Size(233, 21);
            this.Complexity.TabIndex = 71;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(21, 115);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(60, 13);
            this.label35.TabIndex = 70;
            this.label35.Text = "Complexity";
            // 
            // Family
            // 
            this.Family.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Family.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Family.FormattingEnabled = true;
            this.Family.Location = new System.Drawing.Point(106, 154);
            this.Family.Name = "Family";
            this.Family.Size = new System.Drawing.Size(234, 21);
            this.Family.TabIndex = 73;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(19, 157);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(37, 13);
            this.label37.TabIndex = 72;
            this.label37.Text = "Family";
            // 
            // SLDCLODate
            // 
            this.SLDCLODate.Location = new System.Drawing.Point(106, 199);
            this.SLDCLODate.Name = "SLDCLODate";
            this.SLDCLODate.ReadOnly = true;
            this.SLDCLODate.Size = new System.Drawing.Size(231, 20);
            this.SLDCLODate.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "CLO Date";
            // 
            // CLOSLDButton
            // 
            this.CLOSLDButton.Location = new System.Drawing.Point(395, 71);
            this.CLOSLDButton.Name = "CLOSLDButton";
            this.CLOSLDButton.Size = new System.Drawing.Size(234, 57);
            this.CLOSLDButton.TabIndex = 91;
            this.CLOSLDButton.Text = "Calculate CLO";
            this.CLOSLDButton.UseVisualStyleBackColor = true;
            this.CLOSLDButton.Click += new System.EventHandler(this.CLOSLDButton_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(395, 162);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(234, 57);
            this.Save.TabIndex = 92;
            this.Save.Text = "Save && Close";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CLO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 311);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.CLOSLDButton);
            this.Controls.Add(this.SLDCLODate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Family);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.Complexity);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberOfCells);
            this.Controls.Add(this.StartDatet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.StartDate);
            this.Name = "CLO";
            this.Text = "CLO";
            this.Load += new System.EventHandler(this.CLO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StartDatet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumberOfCells;
        private System.Windows.Forms.ComboBox Complexity;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox Family;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox SLDCLODate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CLOSLDButton;
        private System.Windows.Forms.Button Save;
    }
}