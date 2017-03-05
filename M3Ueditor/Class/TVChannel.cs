using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Ueditor
{
    public class TVChannel
    {
        public TVChannel(string _tvgName, string _tvglogo, string _groupTitle, string _udp, string _Name)
        {
            tvgName = _tvgName;
            tvglogo = _tvglogo;
            groupTitle = _groupTitle;
            UDP = _udp;
            Name = _Name;
        }

        public string tvgName { get; set; }
        public string tvglogo { get; set; }
        public string groupTitle { get; set; }
        public string UDP { get; set; }
        public string Name { get; set; }
    }
}
