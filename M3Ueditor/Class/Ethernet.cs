using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace M3Ueditor
{
    class Ethernet
    {
        /// <summary>Получает первый IP-адрес на активной сетевой карте</summary>
        /// <returns>Возвращает IP-адрес в виде строки (string)</returns>
        public static string getLocalIP()
        {
            string ipstring = "";
            if (NetworkInterface.GetIsNetworkA‌​vailable())
            {
                NetworkInterface[] alladapter =
                    NetworkInterface.GetAllNetworkInterfaces().Where(x => x.NetworkInterfaceType == NetworkInterfaceType.Ethernet).ToArray();

                NetworkInterface ActiveAdapter = alladapter.First(x => x.OperationalStatus == OperationalStatus.Up);
                PhysicalAddress address = ActiveAdapter.GetPhysicalAddress();
                UnicastIPAddressInformationCollection ip = ActiveAdapter.GetIPProperties().UnicastAddresses;
                ipstring = ip[0].Address.ToString();
            }
            return ipstring;
        }


        /// <summary>Возвращает количество адресов для сканирования</summary>
        /// <param name="start">Начальный IP-адрес</param>
        /// <param name="stop">Конечный IP-адрес</param>
        /// <returns>Число в формате uint</returns>
        public static uint calculateNumOfIpAddr(IPAddress start, IPAddress stop)
        {
            byte[] str = start.GetAddressBytes();
            byte[] stp = stop.GetAddressBytes();

            uint sta = (uint)255 * 255 * 255 * str[0] + (uint)255 * 255 * str[1] + (uint)255 * str[2] + (uint)str[3];
            uint stb = (uint)255 * 255 * 255 * stp[0] + (uint)255 * 255 * stp[1] + (uint)255 * stp[2] + (uint)stp[3];

            if (sta > stb)
                return (sta - stb) + 1;
            else
                return (stb - sta) + 1;
        }


        /// <summary>Направление поиска (прямое или обратное)</summary>
        /// <param name="start">Начальный IP-адрес</param>
        /// <param name="stop">Конечный IP-адрес</param>
        /// <returns>True или False</returns>
        public static bool searchForward(IPAddress start, IPAddress stop)
        {
            byte[] str = start.GetAddressBytes();
            byte[] stp = stop.GetAddressBytes();

            uint sta = (uint)255 * 255 * 255 * str[0] + (uint)255 * 255 * str[1] + (uint)255 * str[2] + (uint)str[3];
            uint stb = (uint)255 * 255 * 255 * stp[0] + (uint)255 * 255 * stp[1] + (uint)255 * stp[2] + (uint)stp[3];

            if (sta > stb)
                return false;
            else
                return true;
        }
    }
}
