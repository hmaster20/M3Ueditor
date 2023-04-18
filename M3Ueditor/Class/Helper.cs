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
    /// <summary>Класс обработки данных, полученных из файла</summary>
    public class Helper
    {
        public static string Between(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

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
                using (StreamReader RAWlist = new StreamReader(fullName))
                {
                    string playlist = RAWlist.ReadToEnd();

                    // Старая версия
                    //MatchCollection mt = ParseStream(playlist, @"#EXTM3U((.*\r\n.*)||(.*))#EXTINF");
                    //var options = mt[0].Value;
                    //return options;

                    //string valueFind = @"#EXTM3U";
                    //string raw = playlist;
                    //var F1 = raw.IndexOf(valueFind) + valueFind.Length;
                    //var F2 = raw.IndexOf(@"#EXTINF");
                    //var RESULT = raw.Substring(F1, F2 - F1);


                    //string data = playlist;
                    //var start1 = data.IndexOf(@"#EXTM3U") + 7;
                    //var finish2 = data.Substring(start1, data.IndexOf(@"#EXTINF") - start1);

                    // https://stackoverflow.com/questions/17252615/get-string-between-two-strings-in-a-string

                    string global = playlist.Split(new string[] { @"#EXTM3U" },
                        StringSplitOptions.None)[1]
                        .Split(@"#EXTINF".ToCharArray())[0]
                        .Trim();

                    global = "#EXTM3U " + global;
                    return global;
                }              
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return "#EXTM3U";
            }
        }

        /// <summary>Разбивает содержимое файла на список каналов</summary>
        private static List<string> getRawChannels(string playlist)
        {
            //string input = playlist;
            ////input = input.Replace("\r\n", "");
            ////input = Regex.Replace(input, @"\s+", string.Empty);
            //input = Regex.Replace(input, @"\t|\n|\r", "");

            //var start = input.IndexOf(@"#EXTM3U") + @"#EXTM3U".Length;
            //var match2 = input.Substring(start, input.IndexOf(@"#EXTINF") - start);

            //string allChannels = input.Substring(input.IndexOf(@"#EXTINF"));

            List<string> listChannel = new List<string>();

            int indexator = playlist.IndexOf(@"#EXTINF");

            if (indexator > 0)
            {
                string allChannels = playlist.Substring(indexator);

                while (allChannels.Length > 0)
                {
                    string valueFind = @"#EXTINF:";
                    var FistIndex = allChannels.IndexOf(valueFind) + valueFind.Length;
                    var SecondIndex = allChannels.IndexOf(valueFind, FistIndex);
                    if (SecondIndex > 0)
                    {
                        var FindString = allChannels.Substring(FistIndex, SecondIndex - FistIndex);
                        listChannel.Add(FindString);
                        allChannels = allChannels.Remove(0, SecondIndex);
                    }
                    else
                    {
                        if (allChannels.Length > 0)
                        {
                            var FindString = allChannels.Substring(FistIndex, allChannels.Length - FistIndex);
                            listChannel.Add(FindString);
                        }
                        allChannels = null;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Структура файла не распознана!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listChannel;
        }

        /// <summary>Раcпознает каналы и выдет готовый реестр</summary>
        public static SortableBindingList<TVChannel> getChannels(string fullName)
        {
            SortableBindingList<TVChannel> channels = new SortableBindingList<TVChannel>();

            using (StreamReader playlist = new StreamReader(fullName))
            {
                string fullTextFile = playlist.ReadToEnd();

                List<string> RawChannels = getRawChannels(fullTextFile);

                for (int i = 0; i < RawChannels.Count; i++)
                {
                    string tvgName = "N/A";
                    string tvglogo = "N/A";
                    string groupTitle = "N/A";
                    string Name = "N/A";
                    string udp = "N/A";

                    string ch = RawChannels[i];

                    // "-1 tvg-name=\"tvgFirst\" tvg-logo=\"New Logo\" group-title=\"New Group\",First\r\nudp://@224.1.1.1:6000\r\n"
                    // "1740 tvg-name=\"5 канал (Россия) (+4)\" tvg-logo=\"http://web.web/1740.png?w=250&h=250\" group-title=\"Эфирные\",5 канал +4 http://web.web/web.php?channel=1740 "


                    tvgName = Between(ch, "tvg-name=\"", "\"");
                    tvglogo = Between(ch, "tvg-logo=\"", "\"");
                    groupTitle = Between(ch, "group-title=\"", "\"");

                    Name = ch.Split(',').Last();

                    int indexatorFIND = 0;

                    int indexatorUDP = Name.IndexOf(@"udp://");
                    int indexatorHTTP = Name.IndexOf(@"http://");

                    if (indexatorUDP > 0)
                    {
                        indexatorFIND = indexatorUDP;
                    }
                    else if (indexatorHTTP > 0)
                    {
                        indexatorFIND = indexatorHTTP;
                    }

                    if (indexatorFIND > 0)
                    {
                        udp = Name.Substring(indexatorFIND);
                        Name = Name.Remove(indexatorFIND);
                    }

                    try
                    {
                        channels.Add(new TVChannel(
                            _tvgName: tvgName.Trim(),
                            _tvglogo: tvglogo.Trim(),
                            _groupTitle: groupTitle.Trim(),
                            _address: udp.Trim(),
                            _Name: Name.Trim()
                            ));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        //MessageBox.Show("A channel has been omitted due to its incorrect format");                        
                        MessageBox.Show("Канал был пропущен из-за его неправильного формата");
                    }
                }
            }

            if (channels.Count == 0)
            {
                MessageBox.Show("Структура файла не распознана!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return channels;
        }
    }
}
