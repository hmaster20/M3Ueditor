namespace M3Ueditor
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.toolS = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.ts1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.ts2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTV = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.tvgNameBox = new System.Windows.Forms.TextBox();
            this.tvglogoBox = new System.Windows.Forms.TextBox();
            this.groupTitleBox = new System.Windows.Forms.TextBox();
            this.UDPbox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 556);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1025, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1025, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // toolS
            // 
            this.toolS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.ts1,
            this.tsOpen,
            this.tsSave,
            this.ts2,
            this.tsAdd,
            this.tsRemove});
            this.toolS.Location = new System.Drawing.Point(0, 24);
            this.toolS.Name = "toolS";
            this.toolS.Size = new System.Drawing.Size(1025, 25);
            this.toolS.TabIndex = 2;
            this.toolS.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = global::M3Ueditor.Properties.Resources.FileNew;
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(23, 22);
            this.tsNew.Text = "Новый плейлист";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // ts1
            // 
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpen.Image = global::M3Ueditor.Properties.Resources.FileOpen;
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(23, 22);
            this.tsOpen.Text = "Открыть";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::M3Ueditor.Properties.Resources.FileSave;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Text = "Сохранить";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // ts2
            // 
            this.ts2.Name = "ts2";
            this.ts2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAdd
            // 
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdd.Enabled = false;
            this.tsAdd.Image = global::M3Ueditor.Properties.Resources.Add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(23, 22);
            this.tsAdd.Text = "Добавить";
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Enabled = false;
            this.tsRemove.Image = global::M3Ueditor.Properties.Resources.Remove;
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(23, 22);
            this.tsRemove.Text = "Удалить";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 507);
            this.splitContainer1.SplitterDistance = 720;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvTV
            // 
            this.dgvTV.AllowUserToResizeColumns = false;
            this.dgvTV.AllowUserToResizeRows = false;
            this.dgvTV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTV.Location = new System.Drawing.Point(0, 0);
            this.dgvTV.MultiSelect = false;
            this.dgvTV.Name = "dgvTV";
            this.dgvTV.ReadOnly = true;
            this.dgvTV.RowHeadersVisible = false;
            this.dgvTV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTV.Size = new System.Drawing.Size(720, 507);
            this.dgvTV.TabIndex = 0;
            this.dgvTV.SelectionChanged += new System.EventHandler(this.dgvTV_SelectionChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.NameBox);
            this.panel.Controls.Add(this.UDPbox);
            this.panel.Controls.Add(this.groupTitleBox);
            this.panel.Controls.Add(this.tvglogoBox);
            this.panel.Controls.Add(this.tvgNameBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 507);
            this.panel.TabIndex = 0;
            // 
            // tvgNameBox
            // 
            this.tvgNameBox.Location = new System.Drawing.Point(18, 78);
            this.tvgNameBox.Name = "tvgNameBox";
            this.tvgNameBox.Size = new System.Drawing.Size(271, 20);
            this.tvgNameBox.TabIndex = 0;
            // 
            // tvglogoBox
            // 
            this.tvglogoBox.Location = new System.Drawing.Point(18, 125);
            this.tvglogoBox.Name = "tvglogoBox";
            this.tvglogoBox.Size = new System.Drawing.Size(271, 20);
            this.tvglogoBox.TabIndex = 0;
            // 
            // groupTitleBox
            // 
            this.groupTitleBox.Location = new System.Drawing.Point(18, 170);
            this.groupTitleBox.Name = "groupTitleBox";
            this.groupTitleBox.Size = new System.Drawing.Size(271, 20);
            this.groupTitleBox.TabIndex = 0;
            // 
            // UDPbox
            // 
            this.UDPbox.Location = new System.Drawing.Point(18, 216);
            this.UDPbox.Name = "UDPbox";
            this.UDPbox.Size = new System.Drawing.Size(271, 20);
            this.UDPbox.TabIndex = 0;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(18, 261);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(271, 20);
            this.NameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "tvglogo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "tvgName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "groupTitle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "UDP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Name";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolS);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "M3U editor";
            this.toolS.ResumeLayout(false);
            this.toolS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip toolS;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripSeparator ts1;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTV;
        private System.Windows.Forms.ToolStripSeparator ts2;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox UDPbox;
        private System.Windows.Forms.TextBox groupTitleBox;
        private System.Windows.Forms.TextBox tvglogoBox;
        private System.Windows.Forms.TextBox tvgNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

