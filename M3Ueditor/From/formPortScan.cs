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
        SortableBindingList<TVChannel> CurrentChannels { get; set; }
        SortableBindingList<TVChannel> ScanFindChannels { get; set; }

        Scanner scanner { get; set; }

        public formPortScan()
        {
            InitializeComponent();
        }

        public formPortScan(SortableBindingList<TVChannel> tvcCurrent)
        {
            InitializeComponent();

            SetDefaultValue();
            CurrentChannels = tvcCurrent;
           // dgvTV.DataSource = ScanFindChannels;
        }

        void SetDefaultValue()
        {
            ipStart.Text = "224.1.1.1";
            ipEnd.Text = "224.1.2.250";

           // ScanFindChannels = new SortableBindingList<TVChannel>();
        }

        private void formPortScan_Load(object sender, EventArgs e)
        {
            //bindingSource1.DataSource = ChannelTable.menu.Tables["Menu"];
            //dataGridView1.DataSource = bindingSource1;

            //// show all channels
            //if (bindingSource1.Filter != "")
            //    bindingSource1.Filter = "";
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            // IPAddress ipstop = new IPAddress(ipAddressControl2.GetAddressBytes());

            IPAddress ipstart = IPAddress.Parse(ipStart.Text);
            IPAddress ipstop = IPAddress.Parse(ipEnd.Text);

            if (ipstart.ToString() == "0.0.0.0" || ipstop.ToString() == "0.0.0.0")
                return;

            // parent.Invoke(new delegateParentThread(parent.vlcStop));

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            scanner = new Scanner(btnStart, btnStop, progressBar1, CurrentAddress, FoundAddress, dataGridView1, CurrentChannels, ScanFindChannels);

            int timeout = (int)TimeOutNumber.Value;
            int port = (int)PortNumber.Value;

            scanner.StartScann(ipstart, ipstop, port, timeout);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            scanner.stopScann();
        }
    }
}
