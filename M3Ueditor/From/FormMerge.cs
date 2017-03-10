using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class FormMerge : Form
    {
        public SortableBindingList<TVChannelMerge> NewChannels { get; set; } // Новый список каналов
        public SortableBindingList<TVChannel> ModChannels { get; set; } // Новый список каналов

        public FormMerge()
        {
            InitializeComponent();
        }

        public FormMerge(SortableBindingList<TVChannel> tvcCurrent, SortableBindingList<TVChannel> tvcMerge)
        {
            InitializeComponent();

            NewChannels = new SortableBindingList<TVChannelMerge>();
            ModChannels = new SortableBindingList<TVChannel>();

            dataGridView1.AutoGenerateColumns = false;

            foreach (var item in tvcCurrent)
            {
                NewChannels.Add(new TVChannelMerge(
                                _tvgName: item.TvgName,
                                _tvglogo: item.Tvglogo,
                                _groupTitle: item.GroupTitle,
                                _udp: item.UDP,
                                _Name: item.Name,
                                _check: false));
            }

            foreach (var item in tvcMerge)
            {
                NewChannels.Add(new TVChannelMerge(
                _tvgName: item.TvgName,
                _tvglogo: item.Tvglogo,
                _groupTitle: item.GroupTitle,
                _udp: item.UDP,
                _Name: item.Name,
                _check: false));
            }
            dataGridView1.DataSource = NewChannels;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";

            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView1.Rows.Add(row);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Check Data";
            chk.Name = "chk";
            dataGridView1.Rows[2].Cells[3].Value = true;
        }

        private void cBoxSelectDubl_CheckedChanged(object sender, EventArgs e)
        {
            //if (NewChannels.Count > 0)
            //{
            //    NewChannels.Where(x => x.)
            //}

            for (int ThisRow = 0; ThisRow < dataGridView1.Rows.Count - 1; ThisRow++)
            {
               DataGridViewRow CompareRow = dataGridView1.Rows[ThisRow];
                for (int NextRow = ThisRow + 1; NextRow < dataGridView1.Rows.Count; NextRow++)
                {
                    DataGridViewRow row = dataGridView1.Rows[NextRow];
                    bool DuplicateRow = true;

                    string aa = CompareRow.Cells[1].Value.ToString();

                    //if ((CompareRow.Cells[3]) == (row.Cells[3]))
                    if ((CompareRow.Cells[3].Value.ToString()) == (row.Cells[3].Value.ToString()))
                    {
                        //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                        //row.DefaultCellStyle.ForeColor = Color.Silver;
                        //row.DefaultCellStyle.Font = new Font(TableRec.Font, FontStyle.Strikeout);
                        // dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red; 

                        row.DefaultCellStyle.ForeColor = Color.Silver;
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        //row.BackColor = System.Drawing.Color.Red;
                        //CompareRow.BackColor = System.Drawing.Color.Red;
                        CompareRow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                    else if (DuplicateRow)
                    {
                        DuplicateRow = false;
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }
    }
}
