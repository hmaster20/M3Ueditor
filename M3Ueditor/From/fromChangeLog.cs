using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class fromChangeLog : Form
    {
        public fromChangeLog(string lng)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lng);

            InitializeComponent();

            tbLog.Text = Properties.Resources.ChangeLog;
        }
    }
}
