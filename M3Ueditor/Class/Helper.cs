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

        /// <summary>Получает файл и извлекает строку EXTM3U с общими параметрами</summary>
        /// <returns>Возвращает EXTM3U... (string)</returns>
        public static string getGlobalParams(string fullName)
        {
            string tagHeader = "#EXTM3U";
            string tagChannel = "#EXTINF";

            try
            {
                using (StreamReader RAWlist = new StreamReader(fullName))
                {
                    string raw = RAWlist.ReadToEnd();

                    // V1 - 100% рабочий вариант (но трудно читаемый)
                    //string global = raw.Split(new string[] { @tagHeader },
                    //    StringSplitOptions.None)[1]
                    //    .Split(@tagChannel.ToCharArray())[0]
                    //    .Trim();

                    // V2 - По идее код более понятный, хотя его больше
                    var F1 = raw.IndexOf(@tagHeader) + tagHeader.Length;
                    var F2 = raw.IndexOf(@tagChannel);
                    string global = "";
                    global = raw.Substring(F1, F2 - F1);
                    global = Regex.Replace(global, @"\t|\n|\r", "");
                    global = global.Trim();
                    if (global.Length > 0)
                    {
                        global = tagHeader + " " + global;
                    }
                    else
                    {
                        global = tagHeader;
                    }

                    return global;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return tagHeader;
            }
        }

        /// <summary>Разбивает содержимое файла на список каналов</summary>
        /// <returns>Возвращает построчный список будущих каналов... </returns>
        private static List<string> getRawChannels(string playlist)
        {
            // Старая версия
            //MatchCollection mt = ParseStream(playlist, @"#EXTM3U((.*\r\n.*)||(.*))#EXTINF");
            //var options = mt[0].Value;

            //string valueFind = @"#EXTM3U";
            //string raw = playlist;
            //var F1 = raw.IndexOf(valueFind) + valueFind.Length;
            //var F2 = raw.IndexOf(@"#EXTINF");
            //var RESULT = raw.Substring(F1, F2 - F1);

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

        /// <summary>Раcпознает построчный список как объекты каналов</summary>
        /// <returns>Возвращает готовый реестр каналов (обектовы типа TVChannel)... </returns>
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
                    string protocol = "N/A";
                    string addon = "";

                    string ch = RawChannels[i];

                    // "-1 tvg-name=\"tvgFirst\" tvg-logo=\"New Logo\" group-title=\"New Group\",First\r\nudp://@224.1.1.1:6000\r\n"
                    // "1740 tvg-name=\"5 канал (Россия) (+4)\" tvg-logo=\"http://web.web/1740.png?w=250&h=250\" group-title=\"Эфирные\",5 канал +4 http://web.web/web.php?channel=1740 "
                    //   245 tvg-name="ZeeTV Россия" tvg-logo="http://web.web/245.png?w=250&h=250" aspect-ratio=16:9 group-title="Фильмы и Сериалы",ZeeTV http://web.web/web.php?channel=245

                    // Нужно парсить -1 и 1740 
                    // Нужно парсить типа aspect-ratio и ...

                    // "3450 tvg-name=\"Еврокино\" tvg-logo=\"http://web.web/3450.png?w=250&h=250\" aspect-ratio=4:3 croppadd=0x131 group-title=\"Фильмы и Сериалы\",Еврокино HD http:/web.web/web.php?channel=3450 "

                    // Подготовка к парсингу на основе списка тэгов
                    List<string> tags = Keywords.getTags().Keys.ToList();
                    tags.Remove("tvg-logo");
                    tags.Remove("tvg-name");
                    tags.Remove("group-title");

                    for (int t = 0; t < tags.Count; t++)
                    {
                        string valueTags = tags[t];
                        string valueNewTags = Between(ch, valueTags + "=", " ");
                        if (valueNewTags.Length > 0)
                        {
                            addon = addon + " " + valueTags + "=" + valueNewTags.Trim();
                            Debug.Print(valueTags);
                        }
                    }

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
                        protocol = Name.Substring(indexatorFIND);
                        Name = Name.Remove(indexatorFIND);
                    }

                    try
                    {
                        channels.Add(new TVChannel(
                            _tvgName: tvgName.Trim(),
                            _tvglogo: tvglogo.Trim(),
                            _groupTitle: groupTitle.Trim(),
                            _address: protocol.Trim(),
                            _Name: Name.Trim(),
                            _Addon: addon.Trim()
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



        #region Методы проверки

        public static bool ValidatorUDP(string UDPserver)
        {
            //udp://@224.1.1.1:6000 - шаблон для парсинга
            string re_protocl = "(udp(?!.*udp)|http(?!.*http))";
            string re_at = "(:\\/\\/@)";
            string re_IPv4 = "((?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))(?![\\d])";
            string re7 = "(:)";
            string re_port = "(6553[0-5]|655[0-2][0-9]|65[0-4][0-9][0-9]|6[0-4][0-9][0-9][0-9]|[0-5]?[0-9][0-9][0-9][0-9]|[0-9][0-9][0-9]|[0-9][0-9]?)(?![\\d])";//string re_port = "(\\d+)";//65535

            Regex r = new Regex(re_protocl + re_at + re_IPv4 + re7 + re_port, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(UDPserver);
            if (m.Success)
            {
                String protocol = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String ipaddress1 = m.Groups[3].ToString();
                String c5 = m.Groups[4].ToString();
                String port = m.Groups[5].ToString();

                Debug.Print("(" + protocol.ToString() + ")"
                    + "(" + c1.ToString() + ")"
                    + "(" + ipaddress1.ToString() + ")"
                    + "(" + c5.ToString() + ")"
                    + "(" + port.ToString() + ")" + "\n");

                return true;
            }
            else
            {
                Debug.Print("UDP сервер не распознан!");
            }
            return false;
        }

        public static bool ValidatorText(string txt)
        {
            string pattern = "(^[а-яА-Яa-zA-Z0-9@])";

            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String TextAfterParsing = m.Groups[1].ToString();
                Debug.Print("(" + TextAfterParsing.ToString() + ")" + "\n");
                return true;
            }
            return false;
        }

        #endregion


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

    }
}
