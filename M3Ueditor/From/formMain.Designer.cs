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
            this.status = new System.Windows.Forms.StatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMerge = new System.Windows.Forms.ToolStripMenuItem();
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmScan = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.menu.SuspendLayout();
            this.toolS.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabel2});
            this.status.Location = new System.Drawing.Point(0, 556);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1025, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // tssLabel1
            // 
            this.tssLabel1.Name = "tssLabel1";
            this.tssLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tssLabel2
            // 
            this.tssLabel2.Name = "tssLabel2";
            this.tssLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1025, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
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
            this.tsmFile.Size = new System.Drawing.Size(48, 20);
            this.tsmFile.Text = "Файл";
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.Size = new System.Drawing.Size(162, 22);
            this.tsmNew.Text = "Новый";
            this.tsmNew.Click += new System.EventHandler(this.tsmNew_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Image = global::M3Ueditor.Properties.Resources.file_open;
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(162, 22);
            this.tsmOpen.Text = "Открыть";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmMerge
            // 
            this.tsmMerge.Enabled = false;
            this.tsmMerge.Image = global::M3Ueditor.Properties.Resources.merge;
            this.tsmMerge.Name = "tsmMerge";
            this.tsmMerge.Size = new System.Drawing.Size(162, 22);
            this.tsmMerge.Text = "Объединить...";
            this.tsmMerge.Click += new System.EventHandler(this.tsmMerge_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmSave
            // 
            this.tsmSave.Enabled = false;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(162, 22);
            this.tsmSave.Text = "Сохранить";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Enabled = false;
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(162, 22);
            this.tsmSaveAs.Text = "Сохранить как...";
            this.tsmSaveAs.Click += new System.EventHandler(this.tsmSaveAs_Click);
            // 
            // tss3
            // 
            this.tss3.Name = "tss3";
            this.tss3.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(162, 22);
            this.tsmExit.Text = "Выход";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHistory,
            this.tss4,
            this.tsmAbout});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(65, 20);
            this.tsmHelp.Text = "Справка";
            // 
            // tsmHistory
            // 
            this.tsmHistory.Name = "tsmHistory";
            this.tsmHistory.Size = new System.Drawing.Size(185, 22);
            this.tsmHistory.Text = "История изменений";
            this.tsmHistory.Click += new System.EventHandler(this.tsmHistory_Click);
            // 
            // tss4
            // 
            this.tss4.Name = "tss4";
            this.tss4.Size = new System.Drawing.Size(182, 6);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(185, 22);
            this.tsmAbout.Text = "О программе";
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
            this.ts4});
            this.toolS.Location = new System.Drawing.Point(0, 24);
            this.toolS.Name = "toolS";
            this.toolS.Size = new System.Drawing.Size(1025, 25);
            this.toolS.TabIndex = 2;
            this.toolS.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = global::M3Ueditor.Properties.Resources.file_new;
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
            this.tsOpen.Image = global::M3Ueditor.Properties.Resources.file_open;
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(23, 22);
            this.tsOpen.Text = "Открыть";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::M3Ueditor.Properties.Resources.file_save;
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
            this.tsAdd.Image = global::M3Ueditor.Properties.Resources.add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(23, 22);
            this.tsAdd.Text = "Добавить";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::M3Ueditor.Properties.Resources.remove;
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
            this.tsUp.Image = global::M3Ueditor.Properties.Resources.arrow_up;
            this.tsUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUp.Name = "tsUp";
            this.tsUp.Size = new System.Drawing.Size(23, 22);
            this.tsUp.Text = "Сдвинуть строку выше";
            this.tsUp.Click += new System.EventHandler(this.tsUp_Click);
            // 
            // tsDown
            // 
            this.tsDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDown.Image = global::M3Ueditor.Properties.Resources.arrow_down;
            this.tsDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDown.Name = "tsDown";
            this.tsDown.Size = new System.Drawing.Size(23, 22);
            this.tsDown.Text = "Сдвинуть строку ниже";
            this.tsDown.Click += new System.EventHandler(this.tsDown_Click);
            // 
            // ts4
            // 
            this.ts4.Name = "ts4";
            this.ts4.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelEdit);
            this.splitContainer.Size = new System.Drawing.Size(1025, 507);
            this.splitContainer.SplitterDistance = 720;
            this.splitContainer.TabIndex = 3;
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
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(301, 507);
            this.panelEdit.TabIndex = 0;
            // 
            // btnChangeCancel
            // 
            this.btnChangeCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChangeCancel.Location = new System.Drawing.Point(205, 274);
            this.btnChangeCancel.Name = "btnChangeCancel";
            this.btnChangeCancel.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCancel.TabIndex = 3;
            this.btnChangeCancel.Text = "Отмена";
            this.btnChangeCancel.UseVisualStyleBackColor = true;
            this.btnChangeCancel.Visible = false;
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
            this.btnChangeApprove.Visible = false;
            this.btnChangeApprove.Click += new System.EventHandler(this.btnChangeApprove_Click);
            // 
            // groupTitleComboBox
            // 
            this.groupTitleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTitleComboBox.FormattingEnabled = true;
            this.groupTitleComboBox.Location = new System.Drawing.Point(18, 170);
            this.groupTitleComboBox.Name = "groupTitleComboBox";
            this.groupTitleComboBox.Size = new System.Drawing.Size(262, 21);
            this.groupTitleComboBox.TabIndex = 2;
            this.groupTitleComboBox.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            this.groupTitleComboBox.TextUpdate += new System.EventHandler(this.UserModifiedChanged);
            this.groupTitleComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.groupTitleComboBox_Validating);
            // 
            // ltvgName
            // 
            this.ltvgName.AutoSize = true;
            this.ltvgName.Location = new System.Drawing.Point(15, 62);
            this.ltvgName.Name = "ltvgName";
            this.ltvgName.Size = new System.Drawing.Size(50, 13);
            this.ltvgName.TabIndex = 1;
            this.ltvgName.Text = "tvgName";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(15, 15);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(133, 13);
            this.lName.TabIndex = 1;
            this.lName.Text = "Name (Название канала)";
            // 
            // lUDPbox
            // 
            this.lUDPbox.AutoSize = true;
            this.lUDPbox.Location = new System.Drawing.Point(15, 200);
            this.lUDPbox.Name = "lUDPbox";
            this.lUDPbox.Size = new System.Drawing.Size(45, 13);
            this.lUDPbox.TabIndex = 1;
            this.lUDPbox.Text = "UDP/IP";
            // 
            // lgroupTitle
            // 
            this.lgroupTitle.AutoSize = true;
            this.lgroupTitle.Location = new System.Drawing.Point(15, 154);
            this.lgroupTitle.Name = "lgroupTitle";
            this.lgroupTitle.Size = new System.Drawing.Size(54, 13);
            this.lgroupTitle.TabIndex = 1;
            this.lgroupTitle.Text = "groupTitle";
            // 
            // ltvglogo
            // 
            this.ltvglogo.AutoSize = true;
            this.ltvglogo.Location = new System.Drawing.Point(15, 109);
            this.ltvglogo.Name = "ltvglogo";
            this.ltvglogo.Size = new System.Drawing.Size(42, 13);
            this.ltvglogo.TabIndex = 1;
            this.ltvglogo.Text = "tvglogo";
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(18, 31);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(262, 20);
            this.NameBox.TabIndex = 0;
            this.NameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.NameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBox_Validating);
            // 
            // UDPbox
            // 
            this.UDPbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UDPbox.Location = new System.Drawing.Point(18, 216);
            this.UDPbox.Name = "UDPbox";
            this.UDPbox.Size = new System.Drawing.Size(262, 20);
            this.UDPbox.TabIndex = 0;
            this.UDPbox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.UDPbox.Validating += new System.ComponentModel.CancelEventHandler(this.UDPbox_Validating);
            // 
            // tvglogoBox
            // 
            this.tvglogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvglogoBox.Location = new System.Drawing.Point(18, 125);
            this.tvglogoBox.Name = "tvglogoBox";
            this.tvglogoBox.Size = new System.Drawing.Size(262, 20);
            this.tvglogoBox.TabIndex = 0;
            this.tvglogoBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tvglogoBox.Validating += new System.ComponentModel.CancelEventHandler(this.tvglogoBox_Validating);
            // 
            // tvgNameBox
            // 
            this.tvgNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvgNameBox.Location = new System.Drawing.Point(18, 78);
            this.tvgNameBox.Name = "tvgNameBox";
            this.tvgNameBox.Size = new System.Drawing.Size(262, 20);
            this.tvgNameBox.TabIndex = 0;
            this.tvgNameBox.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tvgNameBox.Validating += new System.ComponentModel.CancelEventHandler(this.tvgNameBox_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmScan
            // 
            this.tsmScan.Image = global::M3Ueditor.Properties.Resources.scan;
            this.tsmScan.Name = "tsmScan";
            this.tsmScan.Size = new System.Drawing.Size(162, 22);
            this.tsmScan.Text = "Сканер IPTV";
            this.tsmScan.Click += new System.EventHandler(this.tsmScan_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 578);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolS);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "M3U editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolS.ResumeLayout(false);
            this.toolS.PerformLayout();
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
    }
}

