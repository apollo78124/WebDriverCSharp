using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace VideoToMp3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            VideoToMp3V2 downloader2 = new VideoToMp3V2();

            downloader2.downloadWithDriver();

        }
    }
}
