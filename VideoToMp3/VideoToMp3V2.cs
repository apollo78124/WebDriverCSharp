using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace VideoToMp3
{
    //https://ytmp3hub.com/
    //
    class VideoToMp3V2
    {
        public List<String> fileList;
        public String projectPath;

        public VideoToMp3V2()
        {
            projectPath = AppDomain.CurrentDomain.BaseDirectory;
            readDownloadLink();
        }

        public void readDownloadLink()
        {
            fileList = System.IO.File.ReadAllLines(Path.GetFullPath("../../../Files/downloadLink.txt")).ToList();
        }

        public void downloadWithDriver()
        {
            string driverPath = Path.GetFullPath("../../../Files");
            string InterruptedListPath = Path.GetFullPath("../../../Files/interruptedLinks.txt");

            foreach (var link in fileList)
            {
                try
                {
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath);
                    service.HideCommandPromptWindow = false;

                    var options = new ChromeOptions();
                    options.AddArgument("--window");
                    options.AddExtensions("D:/adblock/5.8.1_0.crx");

                    ChromeDriver driver = new ChromeDriver(service, options);
                    driver.Url = "https://ytmp3hub.com/";
                    Thread.Sleep(3000);

                    var url = driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div[1]/div/div[2]/div/div/div/div/input"));
                    url.Click();
                    url.SendKeys(link);
                    var convertForm = driver.FindElement(By.CssSelector("body > div > main > div > div:nth-child(1) > div.bg-gradient-to-r.from-green-400.to-blue-500 > div > div.py-12 > div > div > div > div > button"));
                    Thread.Sleep(3000);
                    convertForm.Click();
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\nInterrupted: " + link + "\n\n");
                    Console.WriteLine(e.ToString());
                    System.IO.File.AppendAllText(InterruptedListPath, link + "\n");
                }
            }
        }
    }
}
