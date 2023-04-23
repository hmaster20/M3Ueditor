using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Linq;

namespace M3Ueditor
{
    /// <summary>
    /// Simple channel scanner.
    /// It scans provided multicast ip range.
    /// Settings form is updated via delegates.
    /// </summary>
    class Scanner
    {
        // delegates for GUI updates
        public delegate void UpdateTextCallback(string text);
        public delegate void UpdateButtonsCallback();
        public delegate void ProgressbarCallback(int percent);
        public delegate void RefreshDatatableViewCallback(TVChannel tvc);

        Socket sock { get; set; }
        Thread ThreadReceiver { get; set; }

        IPEndPoint multiep;
        IPAddress curip, IPstart, IPstop;
        int Port;
        int Timeout;
        int lastchan;
        int found = 0;
        int newchan = 0;

        string localhost { get; set; }
        Button start_bt { get; set; }
        Button stop_bt { get; set; }
        ProgressBar progress_Bar { get; set; }
        Label CurrentIP_label { get; set; }
        Label FoundIP_label { get; set; }
        SortableBindingList<TVChannel> FindCH { get; set; }

        public Scanner(Button startBtn, Button stopBtn, ProgressBar prBar, Label CurrentIP, Label FoundIP, SortableBindingList<TVChannel> FindChannels)
        {
            start_bt = startBtn;
            stop_bt = stopBtn;
            progress_Bar = prBar;
            CurrentIP_label = CurrentIP;
            FoundIP_label = FoundIP;
            FindCH = FindChannels;
            localhost = Ethernet.getLocalIP();
        }


        /// <summary>Start scanning</summary>
        public void StartScann(IPAddress startIP, IPAddress endIP, int prt, int tmo)
        {
            IPstart = startIP;
            IPstop = endIP;
            curip = IPstart;
            Port = prt;
            Timeout = tmo;
            CurrentIP_label.Text = "Scanning...";

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
            bool searchforward = Ethernet.searchForward(IPstart, IPstop);
            uint progressfull = Ethernet.calculateNumOfIpAddr(IPstart, IPstop);
            bool stopcondition = false;
            byte[] oct = IPstart.GetAddressBytes();
            multiep = new IPEndPoint(new IPAddress(oct), Port);
            EndPoint ep = (EndPoint)multiep;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(localhost), Port);

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
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Timeout);
                sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, IPAddress.Parse(localhost).GetAddressBytes());

                try
                {
                    // Must be valid multicast address, else exception 10049                    
                    sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(new IPAddress(oct), IPAddress.Parse(localhost)));
                }
                catch (SocketException) { break; }

                CurrentIP_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
                FoundIP_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());

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

                string tvgName = "Chan " + lastchan;
                string tvglogo = "New Logo";
                string groupTitle = "New Group";
                string Name = lastchan.ToString();
                string address = "udp://@" + curip.ToString() + ":" + Port;
                string addon = "";

                TVChannel tvc =
                new TVChannel(
                            _tvgName: tvgName.Trim(),
                            _tvglogo: tvglogo.Trim(),
                            _groupTitle: groupTitle.Trim(),
                            _address: address.Trim(),
                            _Name: Name.Trim(),
                            _Addon: addon
                            );

                bool isTVC = false;

                for (int count = 0; count < FindCH.Count; count++)
                {
                    if (FindCH[count].Equals(tvc))
                    {
                        isTVC = true;
                        break;
                    }
                }

                //Check if entry allready exists
                if (foundchannel && !isTVC)
                {
                    CurrentIP_label.Invoke(new RefreshDatatableViewCallback(TableAdd), tvc);
                    newchan++;
                    lastchan++;
                    CurrentIP_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
                    FoundIP_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());
                }

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

                if (curip.Equals(IPstop))
                    stopcondition = true;
                sock.Close();
            }

            sock.Close();

            CurrentIP_label.Invoke(new UpdateTextCallback(UpdateipLabel), curip.ToString());
            FoundIP_label.Invoke(new UpdateTextCallback(UpdatefoundLabel), found.ToString());
            start_bt.Invoke(new UpdateButtonsCallback(UpdatestartButton));
            stop_bt.Invoke(new UpdateButtonsCallback(UpdatestopButton));
            progress_Bar.Invoke(new ProgressbarCallback(UpdateprogressBar), 100);

            //Abort thread
            ThreadReceiver.Abort();
        }
        
        public void TableAdd(TVChannel tvc)
        {
            FindCH.Add(tvc);
        }

        /// <summary>Отмена сканирования</summary>
        public void stopScann()
        {
            progress_Bar.Value = 100;
            ThreadReceiver.Abort();
            sock.Close();
        }


        #region Обновление данных в процессе сканирования

        /// <summary>Update ip label during the scann</summary>
        private void UpdateipLabel(string text)
        {
            CurrentIP_label.Text = text;
        }

        /// <summary>Update found label during the scan</summary>
        private void UpdatefoundLabel(string found)
        {
            FoundIP_label.Text = "Найдено: " + found + " (" + newchan + " новых)";
        }

        /// <summary>
        /// Enable start button
        /// </summary>
        private void UpdatestartButton()
        {
            start_bt.Enabled = true;
        }

        /// <summary>
        /// Disable start button
        /// </summary>
        private void UpdatestopButton()
        {
            stop_bt.Enabled = false;
        }

        /// <summary>Progress bar 100 (before thread exits)</summary>
        private void UpdateprogressBar(int percent)
        {
            progress_Bar.Value = Math.Min(100, percent);
        }

        #endregion

    }
}
