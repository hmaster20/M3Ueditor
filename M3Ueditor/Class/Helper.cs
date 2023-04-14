using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public static List<string> getRawChannels(string playlist)
        {
            string data = playlist;
            var start1 = data.IndexOf(@"#EXTM3U") + 7;
            var finish2 = data.Substring(start1, data.IndexOf(@"#EXTINF") - start1);


            //string input = playlist;
            //var start = input.IndexOf(@"#EXTM3U") + 7;
            //var match2 = input.Substring(start, input.IndexOf(@"#EXTINF") - start);

            //string St = "super exemple of string key : text I want to keep - end of my string";
            //int pFrom = St.IndexOf("key : ") + "key : ".Length;
            //int pTo = St.LastIndexOf(" - ");
            //string result = St.Substring(pFrom, pTo - pFrom);

            string input = playlist;
            //input = input.Replace("\r\n", "\n");
            //input = input.Replace("\r\n", "");
            //input = input.Replace("\n", "");

            //input = Regex.Replace(input, @"\s+", string.Empty);

            input = Regex.Replace(input, @"\t|\n|\r", "");

            Debug.Print(input);


            var start = input.IndexOf(@"#EXTM3U") + @"#EXTM3U".Length;
            var match2 = input.Substring(start, input.IndexOf(@"#EXTINF") - start);

            string allChannels = input.Substring(input.IndexOf(@"#EXTINF"));

            List<string> listChannel = new List<string>();

            string allChannelsParse = allChannels;

            while (allChannelsParse.Length>0)
            {
                string valueFind = @"#EXTINF:";
                var FistIndex = allChannelsParse.IndexOf(valueFind) + valueFind.Length;
                var SecondIndex = allChannelsParse.IndexOf(valueFind, FistIndex);
                if (SecondIndex>0)
                {
                    var FindString = allChannelsParse.Substring(FistIndex, SecondIndex - FistIndex);
                    listChannel.Add(FindString);
                    allChannelsParse = allChannelsParse.Remove(0, SecondIndex);
                }
                else
                {
                    if (allChannelsParse.Length > 0)
                    {
                        var FindString = allChannelsParse.Substring(FistIndex, allChannelsParse.Length - FistIndex);
                        listChannel.Add(FindString);
                    }
                    allChannelsParse = null;
                    break;
                }
            }


            Debug.Print("allChannels -- start");
            Debug.Print(allChannels);
            Debug.Print("allChannels -- end");

            //var tets = allChannels.Split("#EXTINF".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray().Where(x => !string.IsNullOrEmpty(x)).Distinct();
            var tets  = allChannels.Split(@"#EXTINF".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            var tets2 = allChannels.Split(@"#EXTINF".ToCharArray()).ToArray().Distinct();

            Debug.Print(tets.ToString());

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
