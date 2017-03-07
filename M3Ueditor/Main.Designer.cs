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
            this.ts3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUp = new System.Windows.Forms.ToolStripButton();
            this.tsDown = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.dgvTV = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.btnChangeCancel = new System.Windows.Forms.Button();
            this.btnChangeApprove = new System.Windows.Forms.Button();
            this.groupTitleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.UDPbox = new System.Windows.Forms.TextBox();
            this.tvglogoBox = new System.Windows.Forms.TextBox();
            this.tvgNameBox = new System.Windows.Forms.TextBox();
            this.toolS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.tsRemove,
            this.ts3,
            this.tsUp,
            this.tsDown});
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
            this.tsAdd.Image = global::M3Ueditor.Properties.Resources.Add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(23, 22);
            this.tsAdd.Text = "Добавить";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::M3Ueditor.Properties.Resources.Remove;
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(23, 22);
            this.tsRemove.Text = "Удалить";
            this.tsRemove.Click += new System.EventHandler(this.tsRemove_Click);
            // 
            // ts3
            // 
            this.ts3.Name = "ts3";
            this.ts3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsUp
            // 
            this.tsUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUp.Image = global::M3Ueditor.Properties.Resources.arrow_Up;
            this.tsUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUp.Name = "tsUp";
            this.tsUp.Size = new System.Drawing.Size(23, 22);
            this.tsUp.Text = "toolStripButton1";
            this.tsUp.Click += new System.EventHandler(this.tsUp_Click);
            // 
            // tsDown
            // 
            this.tsDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDown.Image = global::M3Ueditor.Properties.Resources.arrow_Down;
            this.tsDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDown.Name = "tsDown";
            this.tsDown.Size = new System.Drawing.Size(23, 22);
            this.tsDown.Text = "toolStripButton2";
            this.tsDown.Click += new System.EventHandler(this.tsDown_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 507);
            this.splitContainer1.SplitterDistance = 720;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvTV);
            this.splitContainer2.Size = new System.Drawing.Size(720, 507);
            this.splitContainer2.SplitterDistance = 232;
            this.splitContainer2.TabIndex = 1;
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(232, 507);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.tree_DragEnter);
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
            this.dgvTV.Size = new System.Drawing.Size(484, 507);
            this.dgvTV.TabIndex = 0;
            this.dgvTV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTV_CellMouseClick);
            this.dgvTV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTV_CellMouseDown);
            this.dgvTV.SelectionChanged += new System.EventHandler(this.dgvTV_SelectionChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnChangeCancel);
            this.panel.Controls.Add(this.btnChangeApprove);
            this.panel.Controls.Add(this.groupTitleComboBox);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.NameBox);
            this.panel.Controls.Add(this.UDPbox);
            this.panel.Controls.Add(this.tvglogoBox);
            this.panel.Controls.Add(this.tvgNameBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 507);
            this.panel.TabIndex = 0;
            // 
            // btnChangeCancel
            // 
            this.btnChangeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChangeCancel.Location = new System.Drawing.Point(214, 274);
            this.btnChangeCancel.Name = "btnChangeCancel";
            this.btnChangeCancel.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCancel.TabIndex = 3;
            this.btnChangeCancel.Text = "Отмена";
            this.btnChangeCancel.UseVisualStyleBackColor = true;
            this.btnChangeCancel.Click += new System.EventHandler(this.btnChangeCancel_Click);
            // 
            // btnChangeApprove
            // 
            this.btnChangeApprove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangeApprove.Location = new System.Drawing.Point(18, 274);
            this.btnChangeApprove.Name = "btnChangeApprove";
            this.btnChangeApprove.Size = new System.Drawing.Size(75, 23);
            this.btnChangeApprove.TabIndex = 3;
            this.btnChangeApprove.Text = "Применить";
            this.btnChangeApprove.UseVisualStyleBackColor = true;
            this.btnChangeApprove.Click += new System.EventHandler(this.btnChangeApprove_Click);
            // 
            // groupTitleComboBox
            // 
            this.groupTitleComboBox.FormattingEnabled = true;
            this.groupTitleComboBox.Location = new System.Drawing.Point(18, 170);
            this.groupTitleComboBox.Name = "groupTitleComboBox";
            this.groupTitleComboBox.Size = new System.Drawing.Size(271, 21);
            this.groupTitleComboBox.TabIndex = 2;
            this.groupTitleComboBox.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Name (Название канала)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "UDP/IP";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "tvglogo";
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(18, 31);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(271, 20);
            this.NameBox.TabIndex = 0;
            this.NameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // UDPbox
            // 
            this.UDPbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UDPbox.Location = new System.Drawing.Point(18, 216);
            this.UDPbox.Name = "UDPbox";
            this.UDPbox.Size = new System.Drawing.Size(271, 20);
            this.UDPbox.TabIndex = 0;
            this.UDPbox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // tvglogoBox
            // 
            this.tvglogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvglogoBox.Location = new System.Drawing.Point(18, 125);
            this.tvglogoBox.Name = "tvglogoBox";
            this.tvglogoBox.Size = new System.Drawing.Size(271, 20);
            this.tvglogoBox.TabIndex = 0;
            this.tvglogoBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // tvgNameBox
            // 
            this.tvgNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvgNameBox.Location = new System.Drawing.Point(18, 78);
            this.tvgNameBox.Name = "tvgNameBox";
            this.tvgNameBox.Size = new System.Drawing.Size(271, 20);
            this.tvgNameBox.TabIndex = 0;
            this.tvgNameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.toolS.ResumeLayout(false);
            this.toolS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tvglogoBox;
        private System.Windows.Forms.TextBox tvgNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ComboBox groupTitleComboBox;
        private System.Windows.Forms.Button btnChangeCancel;
        private System.Windows.Forms.Button btnChangeApprove;
        private System.Windows.Forms.ToolStripSeparator ts3;
        private System.Windows.Forms.ToolStripButton tsUp;
        private System.Windows.Forms.ToolStripButton tsDown;
    }
}

