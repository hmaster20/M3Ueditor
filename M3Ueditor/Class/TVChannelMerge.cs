using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M3Ueditor
{
    public class TVChannelMerge : TVChannel
    {
        public TVChannelMerge(
            string _tvgName, string _tvglogo, string _groupTitle, string _address, string _Name, string _Addon, bool _check
            ) : base(_tvgName, _tvglogo, _groupTitle, _address, _Name, _Addon)
        {
            check = _check;
        }
        public bool check { get; set; }
    }
}
