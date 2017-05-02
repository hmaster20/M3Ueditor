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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.dgvTV = new System.Windows.Forms.DataGridView();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.btnChangeCancel = new System.Windows.Forms.Button();
            this.btnChangeApprove = new System.Windows.Forms.Button();
            this.groupTitleComboBox = new System.Windows.Forms.ComboBox();
            this.ltvgName = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lUDPbox = new System.Windows.Forms.Label();
            this.lgroupTitle = new System.Windows.Forms.Label();
            this.ltvglogo = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.UDPbox = new System.Windows.Forms.TextBox();
            this.tvglogoBox = new System.Windows.Forms.TextBox();
            this.tvgNameBox = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmScan = new System.Windows.Forms.ToolStripMenuItem();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ts4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSelectLang = new System.Windows.Forms.ToolStripComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.status.SuspendLayout();
            this.menu.SuspendLayout();
            this.toolS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelEdit);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvTV);
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            resources.ApplyResources(this.tree, "tree");
            this.tree.Name = "tree";
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
            resources.ApplyResources(this.dgvTV, "dgvTV");
            this.dgvTV.MultiSelect = false;
            this.dgvTV.Name = "dgvTV";
            this.dgvTV.ReadOnly = true;
            this.dgvTV.RowHeadersVisible = false;
            this.dgvTV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTV_CellEndEdit);
            this.dgvTV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTV_CellMouseClick);
            this.dgvTV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTV_CellMouseDown);
            this.dgvTV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTV_CellValidating);
            this.dgvTV.SelectionChanged += new System.EventHandler(this.dgvTV_SelectionChanged);
            this.dgvTV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTV_KeyDown);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.btnChangeCancel);
            this.panelEdit.Controls.Add(this.btnChangeApprove);
            this.panelEdit.Controls.Add(this.groupTitleComboBox);
            this.panelEdit.Controls.Add(this.ltvgName);
            this.panelEdit.Controls.Add(this.lName);
            this.panelEdit.Controls.Add(this.lUDPbox);
            this.panelEdit.Controls.Add(this.lgroupTitle);
            this.panelEdit.Controls.Add(this.ltvglogo);
            this.panelEdit.Controls.Add(this.NameBox);
            this.panelEdit.Controls.Add(this.UDPbox);
            this.panelEdit.Controls.Add(this.tvglogoBox);
            this.panelEdit.Controls.Add(this.tvgNameBox);
            resources.ApplyResources(this.panelEdit, "panelEdit");
            this.panelEdit.Name = "panelEdit";
            // 
            // btnChangeCancel
            // 
            resources.ApplyResources(this.btnChangeCancel, "btnChangeCancel");
            this.btnChangeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChangeCancel.Name = "btnChangeCancel";
            this.btnChangeCancel.UseVisualStyleBackColor = true;
            this.btnChangeCancel.Click += new System.EventHandler(this.btnChangeCancel_Click);
            // 
            // btnChangeApprove
            // 
            this.btnChangeApprove.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnChangeApprove, "btnChangeApprove");
            this.btnChangeApprove.Name = "btnChangeApprove";
            this.btnChangeApprove.UseVisualStyleBackColor = true;
            this.btnChangeApprove.Click += new System.EventHandler(this.btnChangeApprove_Click);
            // 
            // groupTitleComboBox
            // 
            resources.ApplyResources(this.groupTitleComboBox, "groupTitleComboBox");
            this.groupTitleComboBox.FormattingEnabled = true;
            this.groupTitleComboBox.Name = "groupTitleComboBox";
            this.groupTitleComboBox.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            this.groupTitleComboBox.TextUpdate += new System.EventHandler(this.UserModifiedChanged);
            this.groupTitleComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.groupTitleComboBox_Validating);
            // 
            // ltvgName
            // 
            resources.ApplyResources(this.ltvgName, "ltvgName");
            this.ltvgName.Name = "ltvgName";
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.Name = "lName";
            // 
            // lUDPbox
            // 
            resources.ApplyResources(this.lUDPbox, "lUDPbox");
            this.lUDPbox.Name = "lUDPbox";
            // 
            // lgroupTitle
            // 
            resources.ApplyResources(this.lgroupTitle, "lgroupTitle");
            this.lgroupTitle.Name = "lgroupTitle";
            // 
            // ltvglogo
            // 
            resources.ApplyResources(this.ltvglogo, "ltvglogo");
            this.ltvglogo.Name = "ltvglogo";
            // 
            // NameBox
            // 
            resources.ApplyResources(this.NameBox, "NameBox");
            this.NameBox.Name = "NameBox";
            this.NameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.NameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBox_Validating);
            // 
            // UDPbox
            // 
            resources.ApplyResources(this.UDPbox, "UDPbox");
            this.UDPbox.Name = "UDPbox";
            this.UDPbox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.UDPbox.Validating += new System.ComponentModel.CancelEventHandler(this.UDPbox_Validating);
            // 
            // tvglogoBox
            // 
            resources.ApplyResources(this.tvglogoBox, "tvglogoBox");
            this.tvglogoBox.Name = "tvglogoBox";
            this.tvglogoBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tvglogoBox.Validating += new System.ComponentModel.CancelEventHandler(this.tvglogoBox_Validating);
            // 
            // tvgNameBox
            // 
            resources.ApplyResources(this.tvgNameBox, "tvgNameBox");
            this.tvgNameBox.Name = "tvgNameBox";
            this.tvgNameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tvgNameBox.Validating += new System.ComponentModel.CancelEventHandler(this.tvgNameBox_Validating);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabel2});
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            // 
            // tssLabel1
            // 
            this.tssLabel1.Name = "tssLabel1";
            resources.ApplyResources(this.tssLabel1, "tssLabel1");
            // 
            // tssLabel2
            // 
            this.tssLabel2.Name = "tssLabel2";
            resources.ApplyResources(this.tssLabel2, "tssLabel2");
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmHelp});
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNew,
            this.tss1,
            this.tsmOpen,
            this.tsmMerge,
            this.toolStripSeparator1,
            this.tsmScan,
            this.tss2,
            this.tsmSave,
            this.tsmSaveAs,
            this.tss3,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            resources.ApplyResources(this.tsmFile, "tsmFile");
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            resources.ApplyResources(this.tsmNew, "tsmNew");
            this.tsmNew.Click += new System.EventHandler(this.tsmNew_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            resources.ApplyResources(this.tss1, "tss1");
            // 
            // tsmOpen
            // 
            this.tsmOpen.Image = global::M3Ueditor.Properties.Resources.file_open;
            this.tsmOpen.Name = "tsmOpen";
            resources.ApplyResources(this.tsmOpen, "tsmOpen");
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmMerge
            // 
            resources.ApplyResources(this.tsmMerge, "tsmMerge");
            this.tsmMerge.Image = global::M3Ueditor.Properties.Resources.merge;
            this.tsmMerge.Name = "tsmMerge";
            this.tsmMerge.Click += new System.EventHandler(this.tsmMerge_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsmScan
            // 
            this.tsmScan.Image = global::M3Ueditor.Properties.Resources.scan;
            this.tsmScan.Name = "tsmScan";
            resources.ApplyResources(this.tsmScan, "tsmScan");
            this.tsmScan.Click += new System.EventHandler(this.tsmScan_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            resources.ApplyResources(this.tss2, "tss2");
            // 
            // tsmSave
            // 
            resources.ApplyResources(this.tsmSave, "tsmSave");
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmSaveAs
            // 
            resources.ApplyResources(this.tsmSaveAs, "tsmSaveAs");
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Click += new System.EventHandler(this.tsmSaveAs_Click);
            // 
            // tss3
            // 
            this.tss3.Name = "tss3";
            resources.ApplyResources(this.tss3, "tss3");
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            resources.ApplyResources(this.tsmExit, "tsmExit");
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHistory,
            this.tss4,
            this.tsmAbout});
            this.tsmHelp.Name = "tsmHelp";
            resources.ApplyResources(this.tsmHelp, "tsmHelp");
            // 
            // tsmHistory
            // 
            this.tsmHistory.Name = "tsmHistory";
            resources.ApplyResources(this.tsmHistory, "tsmHistory");
            this.tsmHistory.Click += new System.EventHandler(this.tsmHistory_Click);
            // 
            // tss4
            // 
            this.tss4.Name = "tss4";
            resources.ApplyResources(this.tss4, "tss4");
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            resources.ApplyResources(this.tsmAbout, "tsmAbout");
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
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
            this.tsDown,
            this.ts4,
            this.tsSelectLang});
            resources.ApplyResources(this.toolS, "toolS");
            this.toolS.Name = "toolS";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = global::M3Ueditor.Properties.Resources.file_new;
            resources.ApplyResources(this.tsNew, "tsNew");
            this.tsNew.Name = "tsNew";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // ts1
            // 
            this.ts1.Name = "ts1";
            resources.ApplyResources(this.ts1, "ts1");
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpen.Image = global::M3Ueditor.Properties.Resources.file_open;
            resources.ApplyResources(this.tsOpen, "tsOpen");
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::M3Ueditor.Properties.Resources.file_save;
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // ts2
            // 
            this.ts2.Name = "ts2";
            resources.ApplyResources(this.ts2, "ts2");
            // 
            // tsAdd
            // 
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdd.Image = global::M3Ueditor.Properties.Resources.add;
            resources.ApplyResources(this.tsAdd, "tsAdd");
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::M3Ueditor.Properties.Resources.remove;
            resources.ApplyResources(this.tsRemove, "tsRemove");
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Click += new System.EventHandler(this.tsRemove_Click);
            // 
            // ts3
            // 
            this.ts3.Name = "ts3";
            resources.ApplyResources(this.ts3, "ts3");
            // 
            // tsUp
            // 
            this.tsUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUp.Image = global::M3Ueditor.Properties.Resources.arrow_up;
            resources.ApplyResources(this.tsUp, "tsUp");
            this.tsUp.Name = "tsUp";
            this.tsUp.Click += new System.EventHandler(this.tsUp_Click);
            // 
            // tsDown
            // 
            this.tsDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDown.Image = global::M3Ueditor.Properties.Resources.arrow_down;
            resources.ApplyResources(this.tsDown, "tsDown");
            this.tsDown.Name = "tsDown";
            this.tsDown.Click += new System.EventHandler(this.tsDown_Click);
            // 
            // ts4
            // 
            this.ts4.Name = "ts4";
            resources.ApplyResources(this.ts4, "ts4");
            // 
            // tsSelectLang
            // 
            this.tsSelectLang.BackColor = System.Drawing.SystemColors.Control;
            this.tsSelectLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsSelectLang.Name = "tsSelectLang";
            resources.ApplyResources(this.tsSelectLang, "tsSelectLang");
            this.tsSelectLang.SelectedIndexChanged += new System.EventHandler(this.tsSelectLang_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolS);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTV)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolS.ResumeLayout(false);
            this.toolS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvTV;
        private System.Windows.Forms.ToolStripSeparator ts2;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label ltvglogo;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox UDPbox;
        private System.Windows.Forms.TextBox tvglogoBox;
        private System.Windows.Forms.TextBox tvgNameBox;
        private System.Windows.Forms.Label ltvgName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lUDPbox;
        private System.Windows.Forms.Label lgroupTitle;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ComboBox groupTitleComboBox;
        private System.Windows.Forms.Button btnChangeCancel;
        private System.Windows.Forms.Button btnChangeApprove;
        private System.Windows.Forms.ToolStripSeparator ts3;
        private System.Windows.Forms.ToolStripButton tsUp;
        private System.Windows.Forms.ToolStripButton tsDown;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmNew;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmHistory;
        private System.Windows.Forms.ToolStripSeparator tss4;
        private System.Windows.Forms.ToolStripMenuItem tsmMerge;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripSeparator ts4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmScan;
        private System.Windows.Forms.ToolStripComboBox tsSelectLang;
    }
}

