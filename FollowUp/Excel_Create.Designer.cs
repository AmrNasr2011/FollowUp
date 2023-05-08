namespace FollowUp
{
    partial class Excel_Create
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.select_file_Order = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_url_Order = new System.Windows.Forms.TextBox();
            this.upload_Order = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.select_file_offer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_url_Offer = new System.Windows.Forms.TextBox();
            this.upload_Offer = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.select_file_Order);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_url_Order);
            this.groupBox1.Controls.Add(this.upload_Order);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Location = new System.Drawing.Point(69, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1101, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Select source:";
            // 
            // select_file_Order
            // 
            this.select_file_Order.Location = new System.Drawing.Point(901, 97);
            this.select_file_Order.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.select_file_Order.Name = "select_file_Order";
            this.select_file_Order.Size = new System.Drawing.Size(140, 35);
            this.select_file_Order.TabIndex = 15;
            this.select_file_Order.Text = "Select Excel File";
            this.select_file_Order.UseVisualStyleBackColor = true;
            this.select_file_Order.Click += new System.EventHandler(this.Select_file_Order_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Please select source of items:";
            // 
            // tb_url_Order
            // 
            this.tb_url_Order.Location = new System.Drawing.Point(231, 100);
            this.tb_url_Order.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_url_Order.Name = "tb_url_Order";
            this.tb_url_Order.Size = new System.Drawing.Size(643, 26);
            this.tb_url_Order.TabIndex = 13;
            // 
            // upload_Order
            // 
            this.upload_Order.Location = new System.Drawing.Point(736, 140);
            this.upload_Order.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upload_Order.Name = "upload_Order";
            this.upload_Order.Size = new System.Drawing.Size(140, 35);
            this.upload_Order.TabIndex = 12;
            this.upload_Order.Text = "Upload Excel";
            this.upload_Order.UseVisualStyleBackColor = true;
            this.upload_Order.Click += new System.EventHandler(this.Upload_Order_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(824, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Export Orders";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.select_file_offer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_url_Offer);
            this.groupBox2.Controls.Add(this.upload_Offer);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Location = new System.Drawing.Point(69, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1101, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Offer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Select source:";
            // 
            // select_file_offer
            // 
            this.select_file_offer.Location = new System.Drawing.Point(901, 94);
            this.select_file_offer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.select_file_offer.Name = "select_file_offer";
            this.select_file_offer.Size = new System.Drawing.Size(140, 35);
            this.select_file_offer.TabIndex = 15;
            this.select_file_offer.Text = "Select Excel File";
            this.select_file_offer.UseVisualStyleBackColor = true;
            this.select_file_offer.Click += new System.EventHandler(this.Select_file_offer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Please select source of items:";
            // 
            // tb_url_Offer
            // 
            this.tb_url_Offer.Location = new System.Drawing.Point(231, 97);
            this.tb_url_Offer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_url_Offer.Name = "tb_url_Offer";
            this.tb_url_Offer.Size = new System.Drawing.Size(643, 26);
            this.tb_url_Offer.TabIndex = 13;
            // 
            // upload_Offer
            // 
            this.upload_Offer.Location = new System.Drawing.Point(736, 137);
            this.upload_Offer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upload_Offer.Name = "upload_Offer";
            this.upload_Offer.Size = new System.Drawing.Size(140, 35);
            this.upload_Offer.TabIndex = 12;
            this.upload_Offer.Text = "Upload Excel";
            this.upload_Offer.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(824, 22);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(103, 20);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Export Offers";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 486);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1204, 242);
            this.dataGridView1.TabIndex = 2;
            // 
            // Excel_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 740);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Excel_Create";
            this.Text = "Excel_Create";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button select_file_Order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_url_Order;
        private System.Windows.Forms.Button upload_Order;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button select_file_offer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_url_Offer;
        private System.Windows.Forms.Button upload_Offer;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}