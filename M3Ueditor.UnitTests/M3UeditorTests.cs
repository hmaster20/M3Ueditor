using System;
using NUnit.Framework;

namespace M3Ueditor.UnitTests
{
    [TestFixture]
    public class M3UeditorTests
    {
        [TestCase("-")]
        [TestCase("-g")]
        [TestCase("+dsgf")]
        [TestCase("=dsgf")]
        [TestCase("()fghfg")]
        [TestCase("_fghfg")]
        public void TestValidatorTextfalse(string txt)
        {
            bool result = Main.ValidatorText(txt);
            Assert.False(result);
        }

        [TestCase("n-")]
        [TestCase("Name+")]
        [TestCase("Name=")]
        [TestCase("Name()")]
        [TestCase("Name_")]
        [TestCase("@Disney")]
        public void TestValidatorTextTrue(string txt)
        {
            bool result = Main.ValidatorText(txt);
            Assert.True(result);
        }

        [TestCase("udp://@224.1.1.1:6")]
        [TestCase("udp://@224.1.1.1:23")]
        [TestCase("udp://@224.1.1.1:250")]
        [TestCase("udp://@224.1.1.1:1024")]
        [TestCase("udp://@224.1.1.1:6000")]
        [TestCase("udp://@224.1.1.1:16000")]
        [TestCase("udp://@224.1.1.1:65535")]
        [TestCase("http://@192.168.1.1:1024")]
        public void TestValidatorUDPtrue(string srv)
        {
            bool result = Main.ValidatorUDP(srv);
            Assert.True(result);
        }

        [TestCase("udp://@224.1.1.1:600000")]
        [TestCase("udp://@224.1.1.1:65536")]
        [TestCase("udp://@224.1.11:6000")]
        [TestCase("udp://@224.1.1.1:")]
        [TestCase("udp://224.1.1.1:33")]
        public void TestValidatorUDP(string srv)
        {
            bool result = Main.ValidatorUDP(srv);
            Assert.False(result);
        }




    }
}