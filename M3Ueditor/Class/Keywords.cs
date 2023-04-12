using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M3Ueditor
{
    public class Keywords
    {
        // https://borpas.info/iptvplayer-docs#6

        string[] keys = {
            "url-tvg",
            "cache" ,
            "deinterlace ",
            "aspect-ratio",
            "croppadd",
            "num"  };
       


   
    }
}

//(#EXTM3U)(.*)(#EXTINF)(.*)(#EXTINF)
//(#EXTINF).*\s\S.*
//(#EXTINF)(.*\s\S.*)
//http://cc.davelozinski.com/c-sharp/the-fastest-way-to-read-and-process-text-files