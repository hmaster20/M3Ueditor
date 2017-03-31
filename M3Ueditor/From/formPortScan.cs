using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class formPortScan : Form
    {
        public formPortScan()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            IPAddress ipstart = IPAddress.Parse(ipStart.Text);
            // IPAddress ipstart = new IPAddress(ipStart.Text);
            // IPAddress ipstop = new IPAddress(ipAddressControl2.GetAddressBytes());
            IPAddress ipstop = IPAddress.Parse(ipEnd.Text);

            if (ipstart.ToString() == "0.0.0.0" || ipstop.ToString() == "0.0.0.0")
                return;

            // parent.Invoke(new delegateParentThread(parent.vlcStop));

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            Scanner scanner = new Scanner(btnStart, btnStop, progressBar1, CurrentAddress, FoundAddress, dataGridView1);
            int timeout = (int)numericUpDown2.Value;
            int port = (int)numericUpDown3.Value;
            scanner.StartScann(ipstart, ipstop, port, timeout);
        }

        private void formPortScan_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].DataPropertyName = "Ip";
            dataGridView1.Columns[1].DataPropertyName = "Chanel";
            dataGridView1.Columns[2].DataPropertyName = "Name";
            dataGridView1.Columns[3].DataPropertyName = "Group";
            dataGridView1.Columns[4].DataPropertyName = "Audio";
            dataGridView1.Columns[5].DataPropertyName = "Fav";
            dataGridView1.Columns[6].DataPropertyName = "Skip";
            dataGridView1.Columns[7].DataPropertyName = "Logo";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].DataPropertyName = "Locked";

            bindingSource1.DataSource = ChannelTable.menu.Tables["Menu"];
            dataGridView1.DataSource = bindingSource1;

            // show all channels
            if (bindingSource1.Filter != "")
                bindingSource1.Filter = "";
        }
    }
}
