﻿namespace M3Ueditor
{
    partial class FormMerge
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
            this.cBoxSelectDubl = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntDelete = new System.Windows.Forms.Button();
            this.dgvMerge = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.infolabel = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerge)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxSelectDubl
            // 
            this.cBoxSelectDubl.AutoSize = true;
            this.cBoxSelectDubl.Location = new System.Drawing.Point(76, 6);
            this.cBoxSelectDubl.Name = "cBoxSelectDubl";
            this.cBoxSelectDubl.Size = new System.Drawing.Size(148, 17);
            this.cBoxSelectDubl.TabIndex = 1;
            this.cBoxSelectDubl.Text = "Выбрать все дубликаты";
            this.cBoxSelectDubl.UseVisualStyleBackColor = true;
            this.cBoxSelectDubl.CheckedChanged += new System.EventHandler(this.cBoxSelectDubl_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(495, 349);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(576, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // bntDelete
            // 
            this.bntDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntDelete.Location = new System.Drawing.Point(526, 4);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(125, 23);
            this.bntDelete.TabIndex = 2;
            this.bntDelete.Text = "Удалить выбранные";
            this.bntDelete.UseVisualStyleBackColor = true;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // dgvMerge
            // 
            this.dgvMerge.AllowUserToAddRows = false;
            this.dgvMerge.AllowUserToResizeColumns = false;
            this.dgvMerge.AllowUserToResizeRows = false;
            this.dgvMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMerge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column3});
            this.dgvMerge.Location = new System.Drawing.Point(12, 31);
            this.dgvMerge.MultiSelect = false;
            this.dgvMerge.Name = "dgvMerge";
            this.dgvMerge.RowHeadersVisible = false;
            this.dgvMerge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMerge.Size = new System.Drawing.Size(639, 312);
            this.dgvMerge.TabIndex = 3;
            this.dgvMerge.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerge_CellClick);
            this.dgvMerge.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerge_CellContentClick);
            this.dgvMerge.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerge_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TvgName";
            this.Column1.HeaderText = "TvgName";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Tvglogo";
            this.Column4.HeaderText = "Tvglogo";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "GroupTitle";
            this.Column2.HeaderText = "GroupTitle";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "UDP";
            this.Column5.HeaderText = "UDP";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "Name";
            this.Column6.HeaderText = "Name";
            this.Column6.Name = "Column6";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "check";
            this.Column3.HeaderText = "Дубль";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // infolabel
            // 
            this.infolabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infolabel.Location = new System.Drawing.Point(12, 354);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(212, 23);
            this.infolabel.TabIndex = 4;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = global::M3Ueditor.Properties.Resources.SelectAll;
            this.btnSelectAll.Location = new System.Drawing.Point(12, 2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(23, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnSelectAll.Image = global::M3Ueditor.Properties.Resources.unSelectAll;
            this.btnUnSelectAll.Location = new System.Drawing.Point(41, 2);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(23, 23);
            this.btnUnSelectAll.TabIndex = 5;
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // FormMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 379);
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.infolabel);
            this.Controls.Add(this.dgvMerge);
            this.Controls.Add(this.bntDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cBoxSelectDubl);
            this.Name = "FormMerge";
            this.Text = "Слияние плейлистов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cBoxSelectDubl;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.DataGridView dgvMerge;
        private System.Windows.Forms.Label infolabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnSelectAll;
    }
}