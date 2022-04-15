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
            //VideoToMp3V1 downloader1 = new VideoToMp3V1();

            //downloader1.downloadWithDriver();


            string driverPath = Path.GetFullPath("../../../Files");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath);
            service.HideCommandPromptWindow = false;

            var options = new ChromeOptions();
            options.AddArgument("--window-position=1,1");
            options.AddArgument("incognito");

            ChromeDriver driver = new ChromeDriver(service, options);
            driver.Url = "https://ytmp3.cc/";
            driver.Navigate().GoToUrl("https://ytmp3.cc/");
            Thread.Sleep(3000);
        }
    }
}
