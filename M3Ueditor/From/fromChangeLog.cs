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
    public partial class fromChangeLog : Form
    {
        public fromChangeLog()
        {
            InitializeComponent();

            tbLog.Text = Properties.Resources.ChangeLog;
        }
    }
}
