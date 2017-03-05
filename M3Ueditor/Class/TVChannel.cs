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

        //private string _tvgName, _Group, _ip, _tvid, _logo;
        //public event PropertyChangedEventHandler PropertyChanged;

        //public TVChannel(string Name, string ip, string Group = "", string logo = "", string tvid = "", string lol = "")
        //{
        //    _tvgName = Name;
        //    _Group = Group;
        //    _ip = ip;
        //    _tvid = tvid;
        //    _logo = logo;
        //}


        //#EXTINF:-1 tvg-name="Карусель" tvg-logo="@Карусель" group-title="Детям",Карусель
        public TVChannel(string _tvgName,  string _tvglogo, string _groupTitle, string _udp, string _Name)
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

        //public string tvgName
        //{
        //    get { return _tvgName; }
        //    set { _tvgName = value; }
        //}

        //public string tvglogo
        //{
        //    get { return _logo; }
        //    set { _logo = value; }
        //}

        //public string Group
        //{
        //    get { return _Group; }
        //    set { _Group = value; }
        //}

        //public string IP
        //{
        //    get { return _ip; }
        //    set { _ip = value; }
        //}






        //private void NotifyPropertyChanged(string value)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(value));
        //}
    }
}
