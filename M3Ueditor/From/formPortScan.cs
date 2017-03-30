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
            Scanner scanner = new Scanner(btnStart, btnStop, progressBar1, label9, label18, dataGridView1);
            int timeout = (int)numericUpDown2.Value;
            int port = (int)numericUpDown3.Value;
            scanner.StartScann(ipstart, ipstop, port, timeout);
        }
    }
}
