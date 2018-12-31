namespace FollowUp
{
    partial class ExtractTasksReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractTasksReport));
            this.PrintTasks = new System.Windows.Forms.Button();
            this.DueDateFromt = new System.Windows.Forms.TextBox();
            this.DueDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DueDateTot = new System.Windows.Forms.TextBox();
            this.DueDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.DGVOfferSLD = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.DGVOfferSchematics = new System.Windows.Forms.DataGridView();
            this.DGVOrderSLD = new System.Windows.Forms.DataGridView();
            this.DGVOrderSchematics = new System.Windows.Forms.DataGridView();
            this.DGVABOM = new System.Windows.Forms.DataGridView();
            this.DGVBBOM = new System.Windows.Forms.DataGridView();
            this.DGVNSR = new System.Windows.Forms.DataGridView();
            this.DGVPF = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ExtractXML = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBOverDue = new System.Windows.Forms.RadioButton();
            this.RBCompleted = new System.Windows.Forms.RadioButton();
            this.RBNotCompleted = new System.Windows.Forms.RadioButton();
            this.RBAll = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SelectNone = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.DesignersCB = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfferSLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfferSchematics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderSLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderSchematics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVABOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPF)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintTasks
            // 
            this.PrintTasks.Location = new System.Drawing.Point(738, 84);
            this.PrintTasks.Name = "PrintTasks";
            this.PrintTasks.Size = new System.Drawing.Size(134, 23);
            this.PrintTasks.TabIndex = 0;
            this.PrintTasks.Text = "Apply Filters";
            this.PrintTasks.UseVisualStyleBackColor = true;
            this.PrintTasks.Click += new System.EventHandler(this.PrintTasks_Click);
            // 
            // DueDateFromt
            // 
            this.DueDateFromt.Location = new System.Drawing.Point(133, 19);
            this.DueDateFromt.Name = "DueDateFromt";
            this.DueDateFromt.Size = new System.Drawing.Size(201, 20);
            this.DueDateFromt.TabIndex = 70;
            this.DueDateFromt.Tag = "WBS";
            this.DueDateFromt.TextChanged += new System.EventHandler(this.DueDateFromt_TextChanged);
            // 
            // DueDateFrom
            // 
            this.DueDateFrom.CustomFormat = "";
            this.DueDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DueDateFrom.Location = new System.Drawing.Point(133, 19);
            this.DueDateFrom.Name = "DueDateFrom";
            this.DueDateFrom.Size = new System.Drawing.Size(232, 20);
            this.DueDateFrom.TabIndex = 71;
            this.DueDateFrom.TabStop = false;
            this.DueDateFrom.ValueChanged += new System.EventHandler(this.DueDateFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Due Date From";
            // 
            // DueDateTot
            // 
            this.DueDateTot.Location = new System.Drawing.Point(133, 45);
            this.DueDateTot.Name = "DueDateTot";
            this.DueDateTot.Size = new System.Drawing.Size(201, 20);
            this.DueDateTot.TabIndex = 73;
            this.DueDateTot.Tag = "WBS";
            this.DueDateTot.TextChanged += new System.EventHandler(this.DueDateTot_TextChanged);
            // 
            // DueDateTo
            // 
            this.DueDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DueDateTo.Location = new System.Drawing.Point(133, 45);
            this.DueDateTo.Name = "DueDateTo";
            this.DueDateTo.Size = new System.Drawing.Size(232, 20);
            this.DueDateTo.TabIndex = 74;
            this.DueDateTo.TabStop = false;
            this.DueDateTo.ValueChanged += new System.EventHandler(this.DueDateTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Due Date To";
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // DGVOfferSLD
            // 
            this.DGVOfferSLD.AllowUserToAddRows = false;
            this.DGVOfferSLD.AllowUserToDeleteRows = false;
            this.DGVOfferSLD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOfferSLD.Location = new System.Drawing.Point(30, 240);
            this.DGVOfferSLD.Name = "DGVOfferSLD";
            this.DGVOfferSLD.ReadOnly = true;
            this.DGVOfferSLD.Size = new System.Drawing.Size(590, 207);
            this.DGVOfferSLD.TabIndex = 75;
            this.DGVOfferSLD.Tag = "Offer SLD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(738, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 76;
            this.button1.Text = "Print Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGVOfferSchematics
            // 
            this.DGVOfferSchematics.AllowUserToAddRows = false;
            this.DGVOfferSchematics.AllowUserToDeleteRows = false;
            this.DGVOfferSchematics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOfferSchematics.Location = new System.Drawing.Point(30, 482);
            this.DGVOfferSchematics.Name = "DGVOfferSchematics";
            this.DGVOfferSchematics.ReadOnly = true;
            this.DGVOfferSchematics.Size = new System.Drawing.Size(590, 207);
            this.DGVOfferSchematics.TabIndex = 77;
            this.DGVOfferSchematics.Tag = "Offer Schematics";
            // 
            // DGVOrderSLD
            // 
            this.DGVOrderSLD.AllowUserToAddRows = false;
            this.DGVOrderSLD.AllowUserToDeleteRows = false;
            this.DGVOrderSLD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOrderSLD.Location = new System.Drawing.Point(30, 724);
            this.DGVOrderSLD.Name = "DGVOrderSLD";
            this.DGVOrderSLD.ReadOnly = true;
            this.DGVOrderSLD.Size = new System.Drawing.Size(590, 207);
            this.DGVOrderSLD.TabIndex = 78;
            this.DGVOrderSLD.Tag = "Order SLD";
            // 
            // DGVOrderSchematics
            // 
            this.DGVOrderSchematics.AllowUserToAddRows = false;
            this.DGVOrderSchematics.AllowUserToDeleteRows = false;
            this.DGVOrderSchematics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOrderSchematics.Location = new System.Drawing.Point(30, 966);
            this.DGVOrderSchematics.Name = "DGVOrderSchematics";
            this.DGVOrderSchematics.ReadOnly = true;
            this.DGVOrderSchematics.Size = new System.Drawing.Size(590, 207);
            this.DGVOrderSchematics.TabIndex = 79;
            this.DGVOrderSchematics.Tag = "Order Schematics";
            // 
            // DGVABOM
            // 
            this.DGVABOM.AllowUserToAddRows = false;
            this.DGVABOM.AllowUserToDeleteRows = false;
            this.DGVABOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVABOM.Location = new System.Drawing.Point(30, 1208);
            this.DGVABOM.Name = "DGVABOM";
            this.DGVABOM.ReadOnly = true;
            this.DGVABOM.Size = new System.Drawing.Size(590, 207);
            this.DGVABOM.TabIndex = 80;
            this.DGVABOM.Tag = "ABOM";
            // 
            // DGVBBOM
            // 
            this.DGVBBOM.AllowUserToAddRows = false;
            this.DGVBBOM.AllowUserToDeleteRows = false;
            this.DGVBBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBBOM.Location = new System.Drawing.Point(30, 1450);
            this.DGVBBOM.Name = "DGVBBOM";
            this.DGVBBOM.ReadOnly = true;
            this.DGVBBOM.Size = new System.Drawing.Size(590, 207);
            this.DGVBBOM.TabIndex = 81;
            this.DGVBBOM.Tag = "BBOM";
            // 
            // DGVNSR
            // 
            this.DGVNSR.AllowUserToAddRows = false;
            this.DGVNSR.AllowUserToDeleteRows = false;
            this.DGVNSR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNSR.Location = new System.Drawing.Point(30, 1692);
            this.DGVNSR.Name = "DGVNSR";
            this.DGVNSR.ReadOnly = true;
            this.DGVNSR.Size = new System.Drawing.Size(590, 207);
            this.DGVNSR.TabIndex = 82;
            this.DGVNSR.Tag = "NSR";
            // 
            // DGVPF
            // 
            this.DGVPF.AllowUserToAddRows = false;
            this.DGVPF.AllowUserToDeleteRows = false;
            this.DGVPF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPF.Location = new System.Drawing.Point(30, 1934);
            this.DGVPF.Name = "DGVPF";
            this.DGVPF.ReadOnly = true;
            this.DGVPF.Size = new System.Drawing.Size(590, 207);
            this.DGVPF.TabIndex = 83;
            this.DGVPF.Tag = "Production File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Offer SLD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Offer Schematics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 708);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Order SLD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 950);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Order Schematics";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 1192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Order ABOM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 1434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Order BBOM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 1676);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Order NSR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 1918);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 91;
            this.label10.Text = "Order Production File";
            // 
            // ExtractXML
            // 
            this.ExtractXML.Location = new System.Drawing.Point(738, 164);
            this.ExtractXML.Name = "ExtractXML";
            this.ExtractXML.Size = new System.Drawing.Size(134, 23);
            this.ExtractXML.TabIndex = 92;
            this.ExtractXML.Text = "Extract XML";
            this.ExtractXML.UseVisualStyleBackColor = true;
            this.ExtractXML.Click += new System.EventHandler(this.ExtractXML_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DueDateFromt);
            this.groupBox1.Controls.Add(this.DueDateFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DueDateTot);
            this.groupBox1.Controls.Add(this.DueDateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 84);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By Due Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBOverDue);
            this.groupBox2.Controls.Add(this.RBCompleted);
            this.groupBox2.Controls.Add(this.RBNotCompleted);
            this.groupBox2.Controls.Add(this.RBAll);
            this.groupBox2.Location = new System.Drawing.Point(429, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 84);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tasks Status";
            // 
            // RBOverDue
            // 
            this.RBOverDue.AutoSize = true;
            this.RBOverDue.Location = new System.Drawing.Point(149, 48);
            this.RBOverDue.Name = "RBOverDue";
            this.RBOverDue.Size = new System.Drawing.Size(97, 17);
            this.RBOverDue.TabIndex = 3;
            this.RBOverDue.TabStop = true;
            this.RBOverDue.Text = "Over Due Date";
            this.RBOverDue.UseVisualStyleBackColor = true;
            this.RBOverDue.CheckedChanged += new System.EventHandler(this.RBOverDue_CheckedChanged);
            // 
            // RBCompleted
            // 
            this.RBCompleted.AutoSize = true;
            this.RBCompleted.Location = new System.Drawing.Point(149, 25);
            this.RBCompleted.Name = "RBCompleted";
            this.RBCompleted.Size = new System.Drawing.Size(76, 17);
            this.RBCompleted.TabIndex = 2;
            this.RBCompleted.TabStop = true;
            this.RBCompleted.Text = "Completed";
            this.RBCompleted.UseVisualStyleBackColor = true;
            this.RBCompleted.CheckedChanged += new System.EventHandler(this.RBCompleted_CheckedChanged);
            // 
            // RBNotCompleted
            // 
            this.RBNotCompleted.AutoSize = true;
            this.RBNotCompleted.Location = new System.Drawing.Point(24, 49);
            this.RBNotCompleted.Name = "RBNotCompleted";
            this.RBNotCompleted.Size = new System.Drawing.Size(96, 17);
            this.RBNotCompleted.TabIndex = 1;
            this.RBNotCompleted.TabStop = true;
            this.RBNotCompleted.Text = "Not Completed";
            this.RBNotCompleted.UseVisualStyleBackColor = true;
            this.RBNotCompleted.CheckedChanged += new System.EventHandler(this.RBNotCompleted_CheckedChanged);
            // 
            // RBAll
            // 
            this.RBAll.AutoSize = true;
            this.RBAll.Checked = true;
            this.RBAll.Location = new System.Drawing.Point(24, 23);
            this.RBAll.Name = "RBAll";
            this.RBAll.Size = new System.Drawing.Size(36, 17);
            this.RBAll.TabIndex = 0;
            this.RBAll.TabStop = true;
            this.RBAll.Text = "All";
            this.RBAll.UseVisualStyleBackColor = true;
            this.RBAll.CheckedChanged += new System.EventHandler(this.RBAll_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SelectNone);
            this.groupBox3.Controls.Add(this.SelectAll);
            this.groupBox3.Controls.Add(this.DesignersCB);
            this.groupBox3.Location = new System.Drawing.Point(30, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 95);
            this.groupBox3.TabIndex = 95;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter By Designer";
            // 
            // SelectNone
            // 
            this.SelectNone.Location = new System.Drawing.Point(634, 55);
            this.SelectNone.Name = "SelectNone";
            this.SelectNone.Size = new System.Drawing.Size(59, 23);
            this.SelectNone.TabIndex = 2;
            this.SelectNone.Text = "None";
            this.SelectNone.UseVisualStyleBackColor = true;
            this.SelectNone.Click += new System.EventHandler(this.SelectNone_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(634, 26);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(59, 23);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "ALL";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DesignersCB
            // 
            this.DesignersCB.CheckOnClick = true;
            this.DesignersCB.FormattingEnabled = true;
            this.DesignersCB.HorizontalScrollbar = true;
            this.DesignersCB.Location = new System.Drawing.Point(6, 19);
            this.DesignersCB.MultiColumn = true;
            this.DesignersCB.Name = "DesignersCB";
            this.DesignersCB.Size = new System.Drawing.Size(622, 64);
            this.DesignersCB.TabIndex = 0;
            // 
            // ExtractTasksReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(928, 733);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExtractXML);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVPF);
            this.Controls.Add(this.DGVNSR);
            this.Controls.Add(this.DGVBBOM);
            this.Controls.Add(this.DGVABOM);
            this.Controls.Add(this.DGVOrderSchematics);
            this.Controls.Add(this.DGVOrderSLD);
            this.Controls.Add(this.DGVOfferSchematics);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGVOfferSLD);
            this.Controls.Add(this.PrintTasks);
            this.Name = "ExtractTasksReport";
            this.Text = "ExtractTasksReport";
            this.Load += new System.EventHandler(this.ExtractTasksReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfferSLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfferSchematics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderSLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderSchematics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVABOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPF)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintTasks;
        private System.Windows.Forms.TextBox DueDateFromt;
        private System.Windows.Forms.DateTimePicker DueDateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DueDateTot;
        private System.Windows.Forms.DateTimePicker DueDateTo;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridView DGVOfferSLD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGVOfferSchematics;
        private System.Windows.Forms.DataGridView DGVOrderSLD;
        private System.Windows.Forms.DataGridView DGVOrderSchematics;
        private System.Windows.Forms.DataGridView DGVABOM;
        private System.Windows.Forms.DataGridView DGVBBOM;
        private System.Windows.Forms.DataGridView DGVNSR;
        private System.Windows.Forms.DataGridView DGVPF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ExtractXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBOverDue;
        private System.Windows.Forms.RadioButton RBCompleted;
        private System.Windows.Forms.RadioButton RBNotCompleted;
        private System.Windows.Forms.RadioButton RBAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox DesignersCB;
        private System.Windows.Forms.Button SelectNone;
        private System.Windows.Forms.Button SelectAll;
    }
}