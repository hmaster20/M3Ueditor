using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace M3Ueditor
{
    public partial class formPortScan : Form
    {
        public SortableBindingList<TVChannel> FindChannels { get; set; } = new SortableBindingList<TVChannel>();
        private Scanner scanner { get; set; }

        public formPortScan()
        {
            InitializeComponent();

            this.Icon = M3Ueditor.Properties.Resources.m3u_icon;

            SetDefaultValue();
        }

        void SetDefaultValue()
        {
            ipStart.Text = "224.1.1.1";
            ipEnd.Text = "224.1.2.250";
            dgvTV.DataSource = FindChannels;
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

            scanner = new Scanner(btnStart, btnStop, progressBar1, CurrentIP, FoundIP, FindChannels);

            int timeout = (int)TimeOutNumber.Value;
            int port = (int)PortNumber.Value;

            scanner.StartScann(ipstart, ipstop, port, timeout);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            scanner.stopScann();
        }
    }
}
