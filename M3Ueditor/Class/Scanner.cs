using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace M3Ueditor
{
    /// <summary>DataTable with channel informations (group, audio language...)</summary>
    static class ChannelTable
    {
        private static DataSet dataset = new DataSet("TransparentMenu");
        public static DataSet menu
        {
            get { return dataset; }
            set { dataset = value; }
        }
    }



    /// <summary>
    /// Simple channel scanner.
    /// It scans provided multicast ip range.
    /// Received data is not inspected and is persumed to be a mpeg-ts.
    /// Settings form is updated via delegates.
    /// TODO: Get rid of hardcoded translations.
    /// TODO: Variable names.
    /// </summary>
    class Scanner
    {
        // lets create delegates for GUI updates
        public delegate void UpdateTextCallback(string text);
        public delegate void UpdateButtonsCallback();
        public delegate void ProgressbarCallback(int percent);
        public delegate void RefreshDatatableViewCallback(DataRow Row);

        Socket sock;
        Thread ThreadReceiver;
        IPEndPoint multiep;
        IPAddress curip;
        IPAddress start;
        IPAddress stop;
        int port;
        int timeout;
        int lastchan;
        int found = 0;
        int newchan = 0;

        string localhost { get; set; } = "172.16.3.35"; // = "192.168.1.102";

        Button start_bt = new Button();
        Button stop_bt { get; set; } = new Button();
        ProgressBar progress_Bar = new ProgressBar();
        Label ip_label = new Label();
        Label found_label = new Label();
        DataGridView dgv = new DataGridView();


        /// <summary>Constructor</summary>
        /// <param name="l">Settings form info label1</param>
        /// <param name="l2">Settings form info label2</param>
        public Scanner(Button startButton, Button stopButton, ProgressBar progressBar, Label l, Label l2, DataGridView datagridview)
        {
            start_bt = startButton;
            stop_bt = stopButton;
            progress_Bar = progressBar;
            ip_label = l;
            found_label = l2;
            dgv = datagridview;
        }

        /// <summary>Start scanning</summary>
        /// <param name="str">Start ip address</param>
        /// <param name="stp">End ip address</param>
        /// <param name="prt">Port</param>
        /// <param name="tmo">Timeout</param>
        public void StartScann(IPAddress str, IPAddress stp, int prt, int tmo)
        {
            start = str;
            stop = stp;
            curip = start;
            port = prt;
            timeout = tmo;
            ip_label.Text = "Scanning...";


            progress_Bar.Visible = true;
            progress_Bar.Invoke(new ProgressbarCallback(UpdateprogressBar), 0);

            ThreadReceiver = new Thread(new ThreadStart(packetReceive));
            ThreadReceiver.IsBackground = true;
            ThreadReceiver.Start();
        }

        void packetReceive()
        {
            byte[] data = new byte[65535]; // max udp size datagram
            int recv = 0;
            bool foundchannel = false;
            bool timedout = false;
            bool searchforward = searchForward(start, stop);
            uint progressfull = calculateNumOfIpAddr(start, stop);

            //Sort chan dataview by channels and get last channel number
            DataView chan = new DataView(ChannelTable.menu.Tables["Menu"], "", ChannelTable.menu.Tables["Menu"].Columns[1].ColumnName, DataViewRowState.CurrentRows);
            try
            {
                lastchan = (int)chan[chan.Count - 1][1] + 1;
            }
            catch { lastchan = 1; }

            bool stopcondition = false;
            byte[] oct = start.GetAddressBytes();
            multiep = new IPEndPoint(new IPAddress(oct), port);
            EndPoint ep = (EndPoint)multiep;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(localhost), port);
            //IPEndPoint iep = new IPEndPoint(IPAddress.Parse(Globals.interfaceip), port);

            int i = 0;
            int dir, tst;
            byte str;
            if (searchforward)
            {
                dir = 1;
                tst = 256;
                str = (byte)0;
            }
            else
            {
                dir = -1;
                tst = -1;
                str = (byte)255;
            }

            while (true)
            {
                i++;
                Thread.Sleep(300); // 300 ms between requests
                foundchannel = false;
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                try
                {
                    sock.Bind(iep);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                    {
                        break;
                    }
                }
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeout);
                sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, IPAddress.Parse(localhost).GetAddressBytes());
                //sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, IPAddress.Parse(Globals.interfaceip).GetAddressBytes());

                try
                {
                    // Must be valid multicast address, else exception 10049                    
                    sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(new IPAddress(oct), IPAddress.Parse(localhost)));
                    //sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(new IPAddress(oct), IPAddress.Parse(Globals.interfaceip)));
                }
                catch (SocketException ex)
                {
                    break;
                }

                ip_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
                found_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());


                try
                {
                    recv = sock.ReceiveFrom(data, ref ep);
                }
                catch (SocketException ex1)
                {
                    if (ex1.SocketErrorCode == SocketError.TimedOut)
                    {
                        timedout = true;
                        recv = 0;
                        foundchannel = false;
                    }
                }

                if (recv > 0)
                {
                    foundchannel = true;
                    found++;
                }//We found a channel

                if (!timedout)
                    Thread.Sleep(300); // we are receiving for 300 ms

                DataRow Row = ChannelTable.menu.Tables["Menu"].NewRow();
                Row[2] = "Chan " + lastchan;
                Row[0] = curip.ToString() + ":" + port;
                Row[3] = "";
                Row[1] = lastchan;
                Row[4] = "";
                Row[6] = false;

                //Check if entry allready exists
                DataRow foundrow = ChannelTable.menu.Tables["Menu"].Rows.Find(Row[0].ToString());

                if (foundchannel && foundrow == null)
                {
                    dgv.Invoke(new RefreshDatatableViewCallback(tableRefresh), Row);
                    newchan++;
                    lastchan++;
                    ip_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
                    found_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());
                }

                //sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(new IPAddress(oct), IPAddress.Parse(Globals.interfaceip)));
                sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(new IPAddress(oct), IPAddress.Parse(localhost)));

                if (stopcondition)
                    break;

                int test1 = oct[3] + dir;
                if (test1 == tst)
                {
                    oct[3] = str;
                    int test2 = oct[2] + dir;
                    if (test2 == tst)
                    {
                        oct[2] = str;
                        int test3 = oct[1] + dir;
                        if (test3 == tst)
                        {
                            oct[1] = str;
                            int test4 = oct[0] + dir;
                            if (test4 == tst)
                            {
                                oct[0] = str;
                            }
                        }
                        else
                            oct[1] = (byte)(oct[1] + dir);
                    }
                    else
                        oct[2] = (byte)(oct[2] + dir);
                }
                else
                    oct[3] = (byte)(oct[3] + dir);

                curip = new IPAddress(oct);
                progress_Bar.Invoke(new ProgressbarCallback(UpdateprogressBar), (int)Math.Round(100 * (float)i / (float)progressfull));

                if (curip.Equals(stop))
                    stopcondition = true;
                sock.Close();
            }

            sock.Close();

            ip_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
            found_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());
            start_bt.Invoke(new UpdateButtonsCallback(UpdatestartButton));
            stop_bt.Invoke(new UpdateButtonsCallback(UpdatestopButton));
            progress_Bar.Invoke(new ProgressbarCallback(UpdateprogressBar), 100);

            //Abort thread
            ThreadReceiver.Abort();
        }

        private uint calculateNumOfIpAddr(IPAddress start, IPAddress stop)
        {
            byte[] str = start.GetAddressBytes();
            byte[] stp = stop.GetAddressBytes();

            uint sta = (uint)255 * 255 * 255 * str[0] + (uint)255 * 255 * str[1] + (uint)255 * str[2] + (uint)str[3];
            uint stb = (uint)255 * 255 * 255 * stp[0] + (uint)255 * 255 * stp[1] + (uint)255 * stp[2] + (uint)stp[3];

            if (sta > stb)
                return (sta - stb) + 1;
            else
                return (stb - sta) + 1;
        }


        /// <summary>Направление поиска (прямое или обратное)</summary>
        /// <param name="start">Начальный IP-адрес</param>
        /// <param name="stop">Конечный IP-адрес</param>
        /// <returns>True или False</returns>
        private bool searchForward(IPAddress start, IPAddress stop)
        {
            byte[] str = start.GetAddressBytes();
            byte[] stp = stop.GetAddressBytes();

            uint sta = (uint)255 * 255 * 255 * str[0] + (uint)255 * 255 * str[1] + (uint)255 * str[2] + (uint)str[3];
            uint stb = (uint)255 * 255 * 255 * stp[0] + (uint)255 * 255 * stp[1] + (uint)255 * stp[2] + (uint)stp[3];

            if (sta > stb)
                return false;
            else
                return true;
        }

        public void tableRefresh(DataRow Row)
        {
            ChannelTable.menu.Tables["Menu"].Rows.Add(Row);
        }

        /// <summary>Отмена сканирования</summary>
        public void stopScann()
        {
            progress_Bar.Value = 100;
            ThreadReceiver.Abort();
            sock.Close();
            dgv.Focus();
        }


        #region Обновление данных в процессе сканирования

        /// <summary>Update ip label during the scann</summary>
        private void UpdateipLabel(string text)
        {
            ip_label.Text = text;
        }

        /// <summary>Update found label during the scan</summary>
        private void UpdatefoundLabel(string found)
        {
            found_label.Text = "Found: " + found + " (" + newchan + " new)";
        }

        private void UpdatestartButton() => StartButtonMode(true);
        private void UpdatestopButton() => StartButtonMode(false);

        void StartButtonMode(bool state)
        {
            stop_bt.Enabled = state;
        }

        /// <summary>Progress bar 100 (before thread exits)</summary>
        private void UpdateprogressBar(int percent)
        {
            progress_Bar.Value = Math.Min(100, percent);
        }

        #endregion

    }
}
