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

            TableRefresh();
        }


        #region Кнопки

        private void btnSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void btnUnSelectAll_Click(object sender, EventArgs e) => UnSelectAll();
        private void cBoxSelectDubl_CheckedChanged(object sender, EventArgs e) => SelectDublicate();
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
        }
        private void UnSelectAll()
        {
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                dgvMerge.Rows[i].Cells[5].Value = false;
            }
        }
        
        private void SelectDublicate()
        {
            int count = 0;

            dgvMerge.Sort(dgvMerge.Columns[3], ListSortDirection.Ascending);

            for (int ThisRow = 0; ThisRow < dgvMerge.Rows.Count - 1; ThisRow++)
            {
                DataGridViewRow CompareRow = dgvMerge.Rows[ThisRow];

                for (int NextRow = ThisRow + 1; NextRow < dgvMerge.Rows.Count; NextRow++)
                {
                    DataGridViewRow currentRow = dgvMerge.Rows[NextRow];
                    bool DuplicateRow = true;

                    if ((CompareRow.Cells[3].Value.ToString()) == (currentRow.Cells[3].Value.ToString()))
                    {
                        RowCompareColor(CompareRow);
                        RowDublicateColor(currentRow);
                        count++;
                    }
                    else if (DuplicateRow)
                    {
                        DuplicateRow = false;
                    }
                }
            }
            infolabel.Text = "Количество дубликатов: " + count;
        }

        private static void RowCompareColor(DataGridViewRow CompareRow)
        {
            CompareRow.Cells[5].Value = false;
            CompareRow.DefaultCellStyle = new DataGridViewCellStyle();  // сброс на параметры по умолчанию

            //CompareRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;   // основная строка
            //CompareRow.Cells[5].Value = false;

            //DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
            ////dgvMerge.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvMerge.Font, FontStyle.Underline);
            ////dgvMerge.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            //dgvMerge.Rows[e.RowIndex].DefaultCellStyle = currencyCellStyle; // сброс на параметры по умолчанию
        }
        private void RowDublicateColor(DataGridViewRow currentRow)  // дубликат
        {
            currentRow.DefaultCellStyle.ForeColor = Color.Silver;
            currentRow.DefaultCellStyle.Font = new Font(dgvMerge.Font, FontStyle.Strikeout);
            currentRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            currentRow.Cells[5].Value = true;
        }


        private void Delete()
        {
            for (int i = 0; i < dgvMerge.RowCount; i++)
            {
                dgvMerge.Rows.RemoveAt(i);


                //TVChannelMerge tvc = null;
                //if (dgvMerge.SelectedRows[0].DataBoundItem is TVChannelMerge) tvc = dgvMerge.SelectedRows[0].DataBoundItem as TVChannelMerge;
                //if (tvc != null)
                //{
                //    dgvMerge.Rows.RemoveAt(i);
                //    NewChannels.Remove(tvc);
                //} 


                //if (Convert.ToBoolean(dgvMerge.Rows[i].Cells[5].Value))
                //{                 
                //        dgvMerge.Rows[i].Selected = true;
                //}

                //foreach (DataGridViewRow dr in dgvMerge.SelectedRows)
                //{
                //    dgvMerge.Rows.Remove(dr);
                //    if (!dr.IsNewRow)
                //    { dgvMerge.Rows.Remove(dr); }
                //}
                //dgvMerge.Rows.RemoveAt(i);



            }
            //TableRefresh();
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
        void TableRefresh()
        {
            dgvMerge.DataSource = NewChannels;
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
                    RowDublicateColor(currentRow);
                }
                else
                {
                    RowCompareColor(currentRow);
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
        }
        private void dgvCellContentClick()
        {
            dgvMerge.RefreshEdit();
        }


        #endregion

    }
}









//private TVChannel GetSelected()
//{
//    DataGridView dgv = dgvMerge;
//    if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
//    {
//        TVChannelMerge tvc = null;
//        if (dgv.SelectedRows[0].DataBoundItem is TVChannelMerge) tvc = dgv.SelectedRows[0].DataBoundItem as TVChannelMerge;
//        if (tvc != null) return tvc;
//    }
//    return null;
//}







// - CellMouseDown: True  - кнопка нажата но не отпущена
// - CellClick: True
// - CellValueChanged: 5False



//private void dgvMerge_CellContentClick(object sender, DataGridViewCellEventArgs e)
//{
//    DataGridViewRow _row = dgvMerge.Rows[e.RowIndex];
//    if (_row.DefaultCellStyle.BackColor == Color.Silver)
//    {
//        _row.DefaultCellStyle.BackColor = Color.LightYellow;
//    }
//    else
//    {
//        _row.DefaultCellStyle.BackColor = Color.Silver;
//    }

//    return;

//    // DataGridViewRow _row = dgvMerge.Rows[e.RowIndex];



//    string message = string.Empty;
//    foreach (DataGridViewRow row in dgvMerge.Rows)
//    {
//        //bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
//        bool isSelected = Convert.ToBoolean(row.Cells[5].Value);
//        if (isSelected)
//        {
//            if (row.Cells[4] != null)
//            {
//                //message += Environment.NewLine;
//                message += row.Cells[4].Value.ToString();
//            }

//        }
//    }

//    MessageBox.Show("Selected Values" + message);

//    return;

//    if (e.ColumnIndex == 5)
//    {
//        DataGridView dgv = (DataGridView)sender;
//        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[5];
//        if (chk.Value == chk.FalseValue || chk.Value == null)
//        {
//            chk.Value = chk.TrueValue;
//        }
//        else
//        {
//            chk.Value = chk.FalseValue;
//        }

//        //if (chk.Value == chk.FalseValue || chk.Value == null)
//        //{
//        //    chk.Value = chk.TrueValue;
//        //}
//        //else
//        //{
//        //    chk.Value = chk.FalseValue;
//        //}
//    }


//    //if (row.Cells[5].Value == true)
//    //{

//    //}
//}

//private void dgvMerge_CellValueChanged(object sender, DataGridViewCellEventArgs e)
//{
//    if (e.ColumnIndex == 5 && e.RowIndex > -1)
//    {
//        if (dgvMerge.Rows[e.RowIndex].Cells[5].Value.ToString() == "true")
//        {
//            MessageBox.Show("true");
//        }
//        else
//        {
//            MessageBox.Show("Test");
//        }
//        //if (dgvMerge.Rows[e.RowIndex].Cells[5].Value.ToString() == "true" || dgvMerge.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
//        //    dgvMerge[1, e.RowIndex].Selected = true;
//        //else
//        //    dgvMerge[1, e.RowIndex].Selected = false;
//    }
//}



//private void button6_Click(object sender, EventArgs e)
//{

//    dgvMerge.ColumnCount = 3;
//    dgvMerge.Columns[0].Name = "Product ID";
//    dgvMerge.Columns[1].Name = "Product Name";
//    dgvMerge.Columns[2].Name = "Product Price";

//    string[] row = new string[] { "1", "Product 1", "1000" };
//    dgvMerge.Rows.Add(row);
//    row = new string[] { "2", "Product 2", "2000" };
//    dgvMerge.Rows.Add(row);
//    row = new string[] { "3", "Product 3", "3000" };
//    dgvMerge.Rows.Add(row);
//    row = new string[] { "4", "Product 4", "4000" };
//    dgvMerge.Rows.Add(row);

//    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
//    dgvMerge.Columns.Add(chk);
//    chk.HeaderText = "Check Data";
//    chk.Name = "chk";
//    dgvMerge.Rows[2].Cells[3].Value = true;
//}