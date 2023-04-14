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
        private static void ParseM3Utest(StreamReader playlist)
        {
            List<TVChannel> channel = new List<TVChannel>();

            string test = playlist.ReadToEnd();

            Regex rm3 = new Regex(@"#EXTM3U.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesM = rm3.Matches(test);
            Regex rin = new Regex(@"#EXTINF.*\s\S.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesI = rin.Matches(test);
        }


        private static MatchCollection getGlobalOptions(StreamReader playlist)
        {
            Regex pattern = new Regex(@"#EXTM3U.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist.ReadToEnd());
            return matchesOptions;
        }

        private static MatchCollection getOptions(StreamReader playlist)
        {
            Regex pattern = new Regex(@"#EXTINF.*\s\S.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist.ReadToEnd());
            return matchesOptions;
        }


        private static MatchCollection ParseStream(string playlist, string textPattern)
        {
            Regex pattern = new Regex(@textPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matchesOptions = pattern.Matches(playlist);
            return matchesOptions;
        }


        /// <summary>Получает файл и извлекает строку EXTM3U с общими параметрами</summary>
        /// <returns>Возвращает EXTM3U... (string)</returns>
        public static string getGlobalParams(string playlist)
        {
            try
            {
                // https://stackoverflow.com/questions/17252615/get-string-between-two-strings-in-a-string

                string global = playlist.Split(new string[] { @"#EXTM3U" }, 
                    StringSplitOptions.None)[1]
                    .Split(@"#EXTINF".ToCharArray())[0]
                    .Trim();

                global = "#EXTM3U " + global;
                return global;

                // Старая версия
                //MatchCollection mt = ParseStream(playlist, @"#EXTM3U((.*\r\n.*)||(.*))#EXTINF");
                //var options = mt[0].Value;
                //return options;
            }
            catch (Exception)
            {
                return "";
            }
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
