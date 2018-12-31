namespace FollowUp
{
    partial class DB_Location
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
            this.URL_Note = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.URL_Test = new System.Windows.Forms.Button();
            this.URL_Save = new System.Windows.Forms.Button();
            this.URL_Cancel = new System.Windows.Forms.Button();
            this.URL_Link = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // URL_Note
            // 
            this.URL_Note.AutoSize = true;
            this.URL_Note.Location = new System.Drawing.Point(119, 63);
            this.URL_Note.Name = "URL_Note";
            this.URL_Note.Size = new System.Drawing.Size(0, 13);
            this.URL_Note.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Notes:";
            // 
            // URL_Test
            // 
            this.URL_Test.Location = new System.Drawing.Point(755, 17);
            this.URL_Test.Name = "URL_Test";
            this.URL_Test.Size = new System.Drawing.Size(75, 23);
            this.URL_Test.TabIndex = 18;
            this.URL_Test.Text = "Test link";
            this.URL_Test.UseVisualStyleBackColor = true;
            this.URL_Test.Click += new System.EventHandler(this.URL_Test_Click);
            // 
            // URL_Save
            // 
            this.URL_Save.Location = new System.Drawing.Point(322, 129);
            this.URL_Save.Name = "URL_Save";
            this.URL_Save.Size = new System.Drawing.Size(75, 23);
            this.URL_Save.TabIndex = 17;
            this.URL_Save.Text = "Save";
            this.URL_Save.UseVisualStyleBackColor = true;
            this.URL_Save.Click += new System.EventHandler(this.URL_Save_Click);
            // 
            // URL_Cancel
            // 
            this.URL_Cancel.Location = new System.Drawing.Point(424, 129);
            this.URL_Cancel.Name = "URL_Cancel";
            this.URL_Cancel.Size = new System.Drawing.Size(75, 23);
            this.URL_Cancel.TabIndex = 16;
            this.URL_Cancel.Text = "Cancel";
            this.URL_Cancel.UseVisualStyleBackColor = true;
            this.URL_Cancel.Click += new System.EventHandler(this.URL_Cancel_Click);
            // 
            // URL_Link
            // 
            this.URL_Link.Location = new System.Drawing.Point(122, 19);
            this.URL_Link.Name = "URL_Link";
            this.URL_Link.Size = new System.Drawing.Size(617, 20);
            this.URL_Link.TabIndex = 15;
            this.URL_Link.TextChanged += new System.EventHandler(this.URL_Link_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "URL for Database";
            // 
            // DB_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 169);
            this.Controls.Add(this.URL_Note);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.URL_Test);
            this.Controls.Add(this.URL_Save);
            this.Controls.Add(this.URL_Cancel);
            this.Controls.Add(this.URL_Link);
            this.Controls.Add(this.label1);
            this.Name = "DB_Location";
            this.Text = "DB_Location";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DB_Location_FormClosing);
            this.Load += new System.EventHandler(this.DB_Location_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label URL_Note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button URL_Test;
        private System.Windows.Forms.Button URL_Save;
        private System.Windows.Forms.Button URL_Cancel;
        private System.Windows.Forms.TextBox URL_Link;
        private System.Windows.Forms.Label label1;
    }
}