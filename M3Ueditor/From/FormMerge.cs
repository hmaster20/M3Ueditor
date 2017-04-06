using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class FormMerge : Form
    {
        public SortableBindingList<TVChannelMerge> NewChannels { get; set; }    // Новый список каналов с селектором
        public SortableBindingList<TVChannel> ModChannels { get; set; }         // Новый стандартный список каналов

        public FormMerge()
        {
            InitializeComponent();
        }

        public FormMerge(SortableBindingList<TVChannel> tvcCurrent, SortableBindingList<TVChannel> tvcMerge)
        {
            InitializeComponent();

            this.Icon = M3Ueditor.Properties.Resources.m3u_icon;

            NewChannels = new SortableBindingList<TVChannelMerge>();
            ModChannels = new SortableBindingList<TVChannel>();

            dgvMerge.AutoGenerateColumns = false;

            foreach (TVChannel tvc in tvcCurrent)
                CreateTVChannelMerge(tvc);

            foreach (TVChannel tvc in tvcMerge)
                CreateTVChannelMerge(tvc);

            dgvMerge.DataSource = NewChannels;
        }


        #region Кнопки

        private void btnSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void btnUnSelectAll_Click(object sender, EventArgs e) => UnSelectAll();
        private void cBoxSelectDubl_CheckedChanged(object sender, EventArgs e) => FindAndSelectAllDublicates();
        private void bntDelete_Click(object sender, EventArgs e) => Delete();
        private void btnApply_Click(object sender, EventArgs e) => Apply();

        #endregion


        #region Методы

        private void CreateTVChannelMerge(TVChannel item)
        {
            NewChannels.Add(new TVChannelMerge(
                            _tvgName: item.TvgName,
                            _tvglogo: item.Tvglogo,
                            _groupTitle: item.GroupTitle,
                            _udp: item.UDP,
                            _Name: item.Name,
                            _check: false));
        }

        private void SelectAll()
        {
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                dgvMerge.Rows[i].Cells[5].Value = true;
            }
            DublicateLabel(dgvMerge.RowCount);
        }
        private void UnSelectAll()
        {
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                dgvMerge.Rows[i].Cells[5].Value = false;
            }
            DublicateLabel(0);
        }


        private void FindAndSelectAllDublicates()
        {
            int count = 0;

            dgvMerge.Sort(dgvMerge.Columns[3], ListSortDirection.Ascending);

            DataGridViewRow CompareRow = null;

            for (int ThisRow = 0; ThisRow < dgvMerge.Rows.Count - 1; ThisRow++)
            {
                if (CompareRow == null)
                {
                    CompareRow = dgvMerge.Rows[ThisRow];
                }
                else
                {
                    if (CompareRow.Cells[3].Value.ToString() == dgvMerge.Rows[ThisRow].Cells[3].Value.ToString())
                    {
                        continue;
                    }
                    else
                    {
                        CompareRow = dgvMerge.Rows[ThisRow];
                    }
                }

                // DataGridViewRow CompareRow = dgvMerge.Rows[ThisRow];

                for (int NextRow = ThisRow + 1; NextRow < dgvMerge.Rows.Count; NextRow++)
                {
                    DataGridViewRow currentRow = dgvMerge.Rows[NextRow];
                    bool DuplicateRow = true;

                    if ((CompareRow.Cells[3].Value.ToString()) == (currentRow.Cells[3].Value.ToString()))
                    {
                        RowChangeStyleForCompare(CompareRow);
                        RowChangeStyleForDublicate(currentRow);
                        count++;
                    }
                    else if (DuplicateRow)
                    {
                        DuplicateRow = false;
                    }
                }
            }
            DublicateLabel(count);
        }

        private void DublicateLabel(int count)
        {
            infolabel.Text = "Количество дубликатов: " + count;
            //if (count != null)
            //{
            //    infolabel.Text = "Количество дубликатов: " + count;
            //}
            //else
            //{
            //    infolabel.Text = "";
            //}
        }

        private void DublicateCalculate()
        {
            int count = 0;
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvMerge.Rows[i].Cells[5].Value))
                {
                    count++;
                }
            }
            DublicateLabel(count);
        }

        private static void RowChangeStyleForCompare(DataGridViewRow CompareRow)
        {
            CompareRow.Cells[5].Value = false;
            CompareRow.DefaultCellStyle = new DataGridViewCellStyle();
        }

        private void RowChangeStyleForDublicate(DataGridViewRow currentRow)
        {
            currentRow.DefaultCellStyle.ForeColor = Color.Silver;
            currentRow.DefaultCellStyle.Font = new Font(dgvMerge.Font, FontStyle.Strikeout);
            currentRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            currentRow.Cells[5].Value = true;
        }


        private void Delete()
        {
            dgvMerge.MultiSelect = true;

            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvMerge.Rows[i].Cells[5].Value))
                    dgvMerge.Rows[i].Selected = true;
            }

            foreach (DataGridViewRow row in dgvMerge.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvMerge.Rows.Remove(row);
            }

            DublicateCalculate();
        }
        private void Apply()
        {
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                TVChannel tvc = null;
                if (dgvMerge.Rows[i].DataBoundItem is TVChannel) tvc = dgvMerge.Rows[i].DataBoundItem as TVChannel;
                if (tvc != null)
                {
                    ModChannels.Add(tvc);
                }
            }
        }

        #endregion


        #region DGV клик
        private void dgvMerge_CellValueChanged(object sender, DataGridViewCellEventArgs e) => dgvValueChanged(e);
        private void dgvMerge_CellClick(object sender, DataGridViewCellEventArgs e) => dgvCellClick(e);
        private void dgvMerge_CellContentClick(object sender, DataGridViewCellEventArgs e) => dgvCellContentClick();

        #endregion


        #region DGV Методы

        private void dgvValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow currentRow = dgvMerge.Rows[e.RowIndex];

                if (Convert.ToBoolean(dgvMerge.Rows[e.RowIndex].Cells[5].Value))
                {
                    RowChangeStyleForDublicate(currentRow);
                }
                else
                {
                    RowChangeStyleForCompare(currentRow);
                }
            }
        }

        private void dgvCellClick(DataGridViewCellEventArgs e)  //Обработка изменения Checkbox в таблице
        {
            DataGridViewCheckBoxCell cell = this.dgvMerge.CurrentCell as DataGridViewCheckBoxCell;

            if (cell != null && !cell.ReadOnly)
            {
                cell.Value = cell.Value == null || !((bool)cell.Value);
                this.dgvMerge.RefreshEdit();
                this.dgvMerge.NotifyCurrentCellDirty(true);
            }

            DublicateCalculate();
        }

        private void dgvCellContentClick()
        {
            dgvMerge.RefreshEdit();
        }

        #endregion

    }
}