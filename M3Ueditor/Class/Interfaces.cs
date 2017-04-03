using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace M3Ueditor
{

    /// <summary>
    /// Get informations about installed network interfaces. 
    /// </summary>

    class Interfaces
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        public List<string> getNames()
        {
            List<string> ips = new List<string>();

            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection ipv4 = properties.UnicastAddresses;
                foreach (UnicastIPAddressInformation uip in ipv4)
                {
                    if (uip.Address.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                    {
                        if (!ips.Contains(adapter.Name))
                            ips.Add(adapter.Name);
                    }
                }
               
            }
            return ips;
        }

        public string getIpFromName(string name)
        {
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Name.Equals(name))
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    UnicastIPAddressInformationCollection ipv4 = properties.UnicastAddresses;
                    // TODO: What if interface doesn't have an ip address?
                    foreach (UnicastIPAddressInformation uip in ipv4)
                        if (uip.Address.AddressFamily.ToString()==ProtocolFamily.InterNetwork.ToString())
                    return uip.Address.ToString();
                }
            }
            return "";

        }

        public int getIndexFromName(string name)
        {
            if (name.Length == 0)
                 { return 0; }
            
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Name.Equals(name))
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    try
                        {
                            int index = properties.GetIPv4Properties().Index;
                            return index;
                        }
                        // 0 is normally for localhost
                        catch { return -1; }
                }
            }
            return 0;
        }

        public NetworkInterface getAdapter(int index)
        {
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPv4InterfaceProperties iv4 = properties.GetIPv4Properties();
                if (iv4 != null &&  iv4.Index == index)
                    return adapter;
            }
            return null;
        }

        public bool supportsMulticast(int index)
        {
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPv4InterfaceProperties iv4 = properties.GetIPv4Properties();
                if (iv4 != null && iv4.Index == index)
                    return adapter.SupportsMulticast;
            }
            return false;
        }

        public string networkInterfaceSummary()
        {
            int ethernet = 0;
            int ppp = 0;
            int p4 = 0;

            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    ethernet++;
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ppp)
                    ppp++;

                IPInterfaceProperties properties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection ipv4 = properties.UnicastAddresses;
                foreach (UnicastIPAddressInformation uip in ipv4)
               if (uip.Address.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                    {
                       if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback) 
                           p4++;
                    }
            }
            return "ethernet interfaces: "+ethernet.ToString()+ ", " + "ppp: "+ppp.ToString() + ", " +"ipv4 addresses: " + p4.ToString() ;
        }
    }
}
