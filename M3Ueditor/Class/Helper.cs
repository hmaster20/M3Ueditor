using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace M3Ueditor
{
    public class Helper
    {
        public static void ParseM3Utest(StreamReader playlist)
        {
            List<TVChannel> channel = new List<TVChannel>();

            string test = playlist.ReadToEnd();

            Regex rm3 = new Regex(@"#EXTM3U.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesM = rm3.Matches(test);
            Regex rin = new Regex(@"#EXTINF.*\s\S.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesI = rin.Matches(test);
        }


        public static MatchCollection getGlobalOptions(StreamReader playlist)
        {
            Regex pattern = new Regex(@"#EXTM3U.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist.ReadToEnd());
            return matchesOptions;
        }

        public static MatchCollection getOptions(StreamReader playlist)
        {
            Regex pattern = new Regex(@"#EXTINF.*\s\S.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist.ReadToEnd());
            return matchesOptions;
        }


        public static MatchCollection ParseStream(string playlist, string textPattern)
        {
            Regex pattern = new Regex(@textPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist);
            return matchesOptions;
        }

        public static string GlobalOptions(string playlist)
        {
            MatchCollection mt = ParseStream(playlist, @"#EXTM3U.*");
            return mt[0].Value;
        }

        public static List<string> Options(string playlist)
        {   
            MatchCollection mt = ParseStream(playlist, @"#EXTINF.*\s\S.*");
            List<string> lst = new List<string>();
            foreach (var item in mt)
            {
                lst.Add(item.ToString());
            }            
            return lst;
        }


    }
}
