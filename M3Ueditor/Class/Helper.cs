using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        public static string getGlobalParams(string fullName)
        {
            try
            {
                StreamReader RAWlist = new StreamReader(fullName);
                string playlist = RAWlist.ReadToEnd();

                string valueFind = @"#EXTM3U";

                string raw = playlist;
                var F1 = raw.IndexOf(valueFind) + valueFind.Length;
                var F2 = raw.IndexOf(@"#EXTINF");
                var RESULT = raw.Substring(F1, F2 - F1);


                string data = playlist;
                var start1 = data.IndexOf(@"#EXTM3U") + 7;
                var finish2 = data.Substring(start1, data.IndexOf(@"#EXTINF") - start1);

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
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return "#EXTM3U";
            }
        }


        /// <summary>Парсит файл и создает список строк каналов</summary>
        public static List<string> getRawChannels(string playlist)
        {
            string data = playlist;
            var start1 = data.IndexOf(@"#EXTM3U") + 7;
            var finish2 = data.Substring(start1, data.IndexOf(@"#EXTINF") - start1);

            string input = playlist;
            //input = input.Replace("\r\n", "");
            //input = Regex.Replace(input, @"\s+", string.Empty);
            input = Regex.Replace(input, @"\t|\n|\r", "");

            Debug.Print(input);

            var start = input.IndexOf(@"#EXTM3U") + @"#EXTM3U".Length;
            var match2 = input.Substring(start, input.IndexOf(@"#EXTINF") - start);

            string allChannels = input.Substring(input.IndexOf(@"#EXTINF"));

            List<string> listChannel = new List<string>();

            string allChannelsParse = allChannels;

            while (allChannelsParse.Length > 0)
            {
                string valueFind = @"#EXTINF:";
                var FistIndex = allChannelsParse.IndexOf(valueFind) + valueFind.Length;
                var SecondIndex = allChannelsParse.IndexOf(valueFind, FistIndex);
                if (SecondIndex > 0)
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

            return listChannel;

            //Debug.Print("allChannels -- start");
            //Debug.Print(allChannels);
            //Debug.Print("allChannels -- end");

            ////var tets = allChannels.Split("#EXTINF".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray().Where(x => !string.IsNullOrEmpty(x)).Distinct();
            //var tets  = allChannels.Split(@"#EXTINF".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            //var tets2 = allChannels.Split(@"#EXTINF".ToCharArray()).ToArray().Distinct();

            //MatchCollection mt = ParseStream(playlist, @"#EXTINF.*\s\S.*");
            //List<string> lst = new List<string>();
            //foreach (var item in mt)
            //{
            //    lst.Add(item.ToString());
            //}            
            //return lst;
        }

        public static SortableBindingList<TVChannel> getChannels(string fullName)
        {
            List<string> RawChannels = getRawChannels(fullName);

            SortableBindingList<TVChannel> channels = new SortableBindingList<TVChannel>();

            for (int i = 0; i < RawChannels.Count; i++)
            {

            }
            return channels;
        }

        public static SortableBindingList<TVChannel> ParseM3U(string fullName)
        {
            StreamReader playlist = new StreamReader(fullName);

            SortableBindingList<TVChannel> ListTV = new SortableBindingList<TVChannel>();

            string line = "";

            string tvgName = "N/A";
            string tvglogo = "N/A";
            string groupTitle = "N/A";
            string Name = "N/A";
            string udp = "N/A";

            while ((line = playlist.ReadLine()) != null)
            {
                if (line.StartsWith("#EXTM3U"))
                {
                    continue;
                }
                if (line.StartsWith("#EXTINF"))
                {
                    tvgName = stringOperations.Between(line, "tvg-name=\"", "\"");
                    tvglogo = stringOperations.Between(line, "tvg-logo=\"", "\"");
                    groupTitle = stringOperations.Between(line, "group-title=\"", "\"");
                    Name = line.Split(',').Last();
                    continue;
                }
                else if (line.Contains("//"))
                {
                    udp = line;
                }
                else
                {
                    continue;
                }

                try
                {
                    ListTV.Add(new TVChannel(
                        _tvgName: tvgName.Trim(),
                        _tvglogo: tvglogo.Trim(),
                        _groupTitle: groupTitle.Trim(),
                        _udp: udp.Trim(),
                        _Name: Name.Trim()
                        ));
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("A channel has been omitted due to its incorrect format");
                    continue;
                }
            }
            playlist.Close();

            if (ListTV.Count == 0)
            {
                MessageBox.Show("Структура файла не распознана!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //fileName = null;
            }
            return ListTV;
        }


        //public void ParseM3Utest(string fullName)
        //{
        //    using (StreamReader playlist = new StreamReader(fullName))
        //    {
        //        string fullTextFile = playlist.ReadToEnd();
        //        textBoxGlobal.Text = Helper.getGlobalParams(fullTextFile);
        //        Helper.getRawChannels(fullTextFile);
        //        // channels = Helper.Options(fullTextFile);
        //        // GetGlobalOption = // string
        //        // GetListChannel = // List<TVChannel>
        //    }
        //}


    }
}
