namespace M3Ueditor
{
    partial class formPortScan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPortScan));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblEndIP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ipEnd = new iptb.IPTextBox();
            this.lblStartIP = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ipStart = new iptb.IPTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeOutNumber = new System.Windows.Forms.NumericUpDown();
            this.PortNumber = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.FoundIP = new System.Windows.Forms.Label();
            this.CurrentIP = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTV = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOutNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblEndIP);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.ipEnd);
            this.groupBox4.Controls.Add(this.lblStartIP);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.ipStart);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.TimeOutNumber);
            this.groupBox4.Controls.Add(this.PortNumber);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // lblEndIP
            // 
            resources.ApplyResources(this.lblEndIP, "lblEndIP");
            this.lblEndIP.Name = "lblEndIP";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ipEnd
            // 
            resources.ApplyResources(this.ipEnd, "ipEnd");
            this.ipEnd.Name = "ipEnd";
            this.ipEnd.ToolTipText = "";
            // 
            // lblStartIP
            // 
            resources.ApplyResources(this.lblStartIP, "lblStartIP");
            this.lblStartIP.Name = "lblStartIP";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // ipStart
            // 
            resources.ApplyResources(this.ipStart, "ipStart");
            this.ipStart.Name = "ipStart";
            this.ipStart.ToolTipText = "";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TimeOutNumber
            // 
            this.TimeOutNumber.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.TimeOutNumber, "TimeOutNumber");
            this.TimeOutNumber.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.TimeOutNumber.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeOutNumber.Name = "TimeOutNumber";
            this.TimeOutNumber.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // PortNumber
            // 
            resources.ApplyResources(this.PortNumber, "PortNumber");
            this.PortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // FoundIP
            // 
            resources.ApplyResources(this.FoundIP, "FoundIP");
            this.FoundIP.Name = "FoundIP";
            // 
            // CurrentIP
            // 
            resources.ApplyResources(this.CurrentIP, "CurrentIP");
            this.CurrentIP.Name = "CurrentIP";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentIP);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.FoundIP);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnStop);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dgvTV
            // 
            this.dgvTV.AllowUserToResizeColumns = false;
            this.dgvTV.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvTV, "dgvTV");
            this.dgvTV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTV.MultiSelect = false;
            this.dgvTV.Name = "dgvTV";
            this.dgvTV.ReadOnly = true;
            this.dgvTV.RowHeadersVisible = false;
            this.dgvTV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // formPortScan
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox4);
            this.Name = "formPortScan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formPortScan_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOutNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TimeOutNumber;
        private System.Windows.Forms.NumericUpDown PortNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        internal iptb.IPTextBox ipStart;
        internal System.Windows.Forms.Label lblEndIP;
        internal iptb.IPTextBox ipEnd;
        internal System.Windows.Forms.Label lblStartIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label FoundIP;
        private System.Windows.Forms.Label CurrentIP;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTV;
    }
}