namespace M3Ueditor
{
    partial class formAbout
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
            this.btnOk = new System.Windows.Forms.Button();
            this.pBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.labelHome = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lCopyright = new System.Windows.Forms.Label();
            this.btnLicense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(257, 278);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // pBoxLogo
            // 
            this.pBoxLogo.Image = global::M3Ueditor.Properties.Resources.m3u;
            this.pBoxLogo.Location = new System.Drawing.Point(12, 9);
            this.pBoxLogo.Name = "pBoxLogo";
            this.pBoxLogo.Size = new System.Drawing.Size(107, 105);
            this.pBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLogo.TabIndex = 1;
            this.pBoxLogo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о программе";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(9, 19);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(305, 110);
            this.textBoxDescription.TabIndex = 24;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Описание";
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.AutoSize = true;
            this.linkLabelHome.Location = new System.Drawing.Point(237, 98);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(98, 13);
            this.linkLabelHome.TabIndex = 24;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "http://it-enginer.ru/";
            this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Location = new System.Drawing.Point(124, 98);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(115, 13);
            this.labelHome.TabIndex = 25;
            this.labelHome.Text = "Домашняя страница:";
            // 
            // lVersion
            // 
            this.lVersion.Location = new System.Drawing.Point(125, 37);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(200, 13);
            this.lVersion.TabIndex = 26;
            this.lVersion.Text = "Версия";
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(124, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(200, 13);
            this.lName.TabIndex = 26;
            this.lName.Text = "Название";
            // 
            // lCopyright
            // 
            this.lCopyright.Location = new System.Drawing.Point(126, 67);
            this.lCopyright.Name = "lCopyright";
            this.lCopyright.Size = new System.Drawing.Size(215, 13);
            this.lCopyright.TabIndex = 26;
            this.lCopyright.Text = "Автор";
            // 
            // btnLicense
            // 
            this.btnLicense.Location = new System.Drawing.Point(12, 278);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(75, 23);
            this.btnLicense.TabIndex = 1;
            this.btnLicense.Text = "Лицензия";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // formAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 313);
            this.ControlBox = false;
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lCopyright);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.labelHome);
            this.Controls.Add(this.linkLabelHome);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pBoxLogo);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pBoxLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lCopyright;
        private System.Windows.Forms.Button btnLicense;
    }
}