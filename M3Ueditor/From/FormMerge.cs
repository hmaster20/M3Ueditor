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

            // CheckedListBox clb = new CheckedListBox();
            //  clb.MultiColumn = true;

            dataGridView1.AutoGenerateColumns = false;


            foreach (var item in tvcCurrent)
            {
                // checkedListBox.Items.Add(item);
                //clb.Items.Add(item);

                NewChannels.Add(
                    new TVChannelMerge(
                                _tvgName: item.TvgName,
                                _tvglogo: item.Tvglogo,
                                _groupTitle: item.GroupTitle,
                                _udp: item.UDP,
                                _Name: item.Name,
                                _check: false)
                                    );
            }

            foreach (var item in tvcMerge)
            {
                //checkedListBox.Items.Add(item);
                //clb.Items.Add(item);
                //NewChannels.Add((TVChannelMerge)item);
            }

            // checkedListBox.MultiColumn = true;
            // checkedListBox.Items.AddRange(clb.Items);


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
    }
}
