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
using System.Globalization;

namespace M3Ueditor
{
    public partial class formPortScan : FormGlobal
    {
        public SortableBindingList<TVChannel> FindChannels { get; set; } = new SortableBindingList<TVChannel>();
        private Scanner scanner { get; set; }

        public formPortScan()
        {
            InitializeComponent();
        }

        public formPortScan(string lng)
        {
            InitializeComponent();

            this.resManager = new ComponentResourceManager(this.GetType());
            this.Culture = CultureInfo.GetCultureInfo(lng);

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);

            this.Icon = M3Ueditor.Properties.Resources.m3u_icon;
            ipStart.Text = "224.1.1.1";
            ipEnd.Text = "224.1.2.250";
            dgvTV.DataSource = FindChannels;
            CurrentIP.Text = "";
            FoundIP.Text = "";
        }

        private void btnScan_Click(object sender, EventArgs e) => ScanStart();
        private void btnStop_Click(object sender, EventArgs e) => ScanStop();
        private void formPortScan_FormClosing(object sender, FormClosingEventArgs e) => CheckScanRunning();


        private void ScanStart()
        {
            IPAddress ipstart = IPAddress.Parse(ipStart.Text);
            IPAddress ipstop = IPAddress.Parse(ipEnd.Text);

            if (ipstart.ToString() == "0.0.0.0" || ipstop.ToString() == "0.0.0.0")
                return;

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            scanner = new Scanner(btnStart, btnStop, progressBar1, CurrentIP, FoundIP, FindChannels);

            int timeout = (int)TimeOutNumber.Value;
            int port = (int)PortNumber.Value;

            scanner.StartScann(ipstart, ipstop, port, timeout);
        }

        private void ScanStop()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            scanner.stopScann();
        }

        private void CheckScanRunning()
        {
            if (btnStop.Enabled)
            {
                ScanStop();
            }
        }
    }
}
