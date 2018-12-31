namespace FollowUp
{
    partial class otherTask
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
            this.TaskName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Hours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_current = new System.Windows.Forms.TextBox();
            this.Next = new System.Windows.Forms.Button();
            this.Prev = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.LBL_Access = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Employe_name = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.RequestDatet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RequestDate = new System.Windows.Forms.DateTimePicker();
            this.DueDatet = new System.Windows.Forms.TextBox();
            this.DueDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskName
            // 
            this.TaskName.Location = new System.Drawing.Point(120, 53);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(345, 20);
            this.TaskName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Task name";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(120, 79);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(345, 60);
            this.Description.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Task description";
            // 
            // Comment
            // 
            this.Comment.Location = new System.Drawing.Point(120, 270);
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(345, 62);
            this.Comment.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Comment";
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(120, 234);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(100, 20);
            this.Hours.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Estimated work hours";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.tb_current);
            this.panel1.Controls.Add(this.Next);
            this.panel1.Controls.Add(this.Prev);
            this.panel1.Location = new System.Drawing.Point(501, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 100);
            this.panel1.TabIndex = 70;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Current Entry";
            // 
            // tb_current
            // 
            this.tb_current.Location = new System.Drawing.Point(146, 16);
            this.tb_current.Name = "tb_current";
            this.tb_current.Size = new System.Drawing.Size(99, 20);
            this.tb_current.TabIndex = 29;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(146, 65);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 9;
            this.Next.Text = "Next.";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Prev
            // 
            this.Prev.Location = new System.Drawing.Point(35, 65);
            this.Prev.Name = "Prev";
            this.Prev.Size = new System.Drawing.Size(75, 23);
            this.Prev.TabIndex = 27;
            this.Prev.Text = "Prev.";
            this.Prev.UseVisualStyleBackColor = true;
            this.Prev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(598, 309);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(105, 23);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save&&Close";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(613, 270);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 72;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(526, 270);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(75, 23);
            this.Apply.TabIndex = 7;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // LBL_Access
            // 
            this.LBL_Access.AutoSize = true;
            this.LBL_Access.Location = new System.Drawing.Point(557, 20);
            this.LBL_Access.Name = "LBL_Access";
            this.LBL_Access.Size = new System.Drawing.Size(0, 13);
            this.LBL_Access.TabIndex = 78;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(421, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 77;
            this.label21.Text = "Database connection:";
            // 
            // Employe_name
            // 
            this.Employe_name.AutoSize = true;
            this.Employe_name.Location = new System.Drawing.Point(73, 20);
            this.Employe_name.Name = "Employe_name";
            this.Employe_name.Size = new System.Drawing.Size(0, 13);
            this.Employe_name.TabIndex = 76;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(33, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 75;
            this.label22.Text = "Hello:";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(226, 20);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 13);
            this.lbl_status.TabIndex = 74;
            // 
            // RequestDatet
            // 
            this.RequestDatet.Location = new System.Drawing.Point(120, 162);
            this.RequestDatet.Name = "RequestDatet";
            this.RequestDatet.Size = new System.Drawing.Size(180, 20);
            this.RequestDatet.TabIndex = 3;
            this.RequestDatet.TextChanged += new System.EventHandler(this.RequestDatet_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Request Date";
            // 
            // RequestDate
            // 
            this.RequestDate.Location = new System.Drawing.Point(120, 162);
            this.RequestDate.Name = "RequestDate";
            this.RequestDate.Size = new System.Drawing.Size(213, 20);
            this.RequestDate.TabIndex = 81;
            this.RequestDate.TabStop = false;
            this.RequestDate.CloseUp += new System.EventHandler(this.RequestDate_ValueChanged);
            // 
            // DueDatet
            // 
            this.DueDatet.Location = new System.Drawing.Point(120, 200);
            this.DueDatet.Name = "DueDatet";
            this.DueDatet.Size = new System.Drawing.Size(180, 20);
            this.DueDatet.TabIndex = 4;
            this.DueDatet.TextChanged += new System.EventHandler(this.DueDatet_TextChanged);
            // 
            // DueDate
            // 
            this.DueDate.Location = new System.Drawing.Point(120, 200);
            this.DueDate.Name = "DueDate";
            this.DueDate.Size = new System.Drawing.Size(213, 20);
            this.DueDate.TabIndex = 84;
            this.DueDate.TabStop = false;
            this.DueDate.CloseUp += new System.EventHandler(this.DueDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "Due Date";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(700, 270);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 85;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // otherTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 348);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.DueDatet);
            this.Controls.Add(this.DueDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.RequestDatet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RequestDate);
            this.Controls.Add(this.LBL_Access);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Employe_name);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TaskName);
            this.Controls.Add(this.label7);
            this.Name = "otherTask";
            this.Text = "otherTask";
            this.Load += new System.EventHandler(this.otherTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TaskName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Hours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_current;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Prev;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Label LBL_Access;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label Employe_name;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.TextBox RequestDatet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker RequestDate;
        private System.Windows.Forms.TextBox DueDatet;
        private System.Windows.Forms.DateTimePicker DueDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Delete;
    }
}