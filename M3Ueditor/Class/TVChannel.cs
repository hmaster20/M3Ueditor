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
            TvgName = _tvgName;
            Tvglogo = _tvglogo;
            GroupTitle = _groupTitle;
            UDP = _udp;
            Name = _Name;
        }

        private string tvgName;
        public string TvgName
        {
            get { return tvgName; }
            set { tvgName = (value != "") ? value : "N/A"; }
        }

        private string tvglogo;
        public string Tvglogo
        {
            get { return tvglogo; }
            set { tvglogo = (value != "") ? value : "N/A"; }
        }

        private string groupTitle;
        public string GroupTitle
        {
            get { return groupTitle; }
            set { groupTitle = (value != "") ? value : "N/A"; }
        }

        private string uDP;
        public string UDP
        {
            get { return uDP; }
            set { uDP = (value != "") ? value : "N/A"; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = (value != "") ? value : "N/A"; }
        }

        public bool Equals(TVChannel tvc)
        {
            if (tvc is TVChannel && tvc != null)
            {
                if (tvc.UDP == this.UDP)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
