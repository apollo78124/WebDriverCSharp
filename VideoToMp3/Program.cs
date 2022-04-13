using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace VideoToMp3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            VideoToMp3V1 downloader1 = new VideoToMp3V1();

            downloader1.downloadWithDriver();


        }
    }
}
