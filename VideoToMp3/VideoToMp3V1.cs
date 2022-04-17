using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace VideoToMp3
{
    class VideoToMp3V1
    {
        public List<String> fileList;
        public String projectPath;

        public VideoToMp3V1()
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

                    ChromeDriver driver = new ChromeDriver(service, options);
                    driver.Url = "https://ytmp3.cc/";
                    driver.Navigate().GoToUrl("https://ytmp3.cc/");
                    Thread.Sleep(3000);

                    var url = driver.FindElement(By.Id("input"));
                    url.Click();
                    url.SendKeys(link);
                    var convertForm = driver.FindElement(By.Id("submit"));
                    convertForm.Submit();
                    Thread.Sleep(10000);
                    var download = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[1]/div[3]/a[1]"));
                    download.Click();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Interrupted: " + link + "");
                    System.IO.File.AppendAllText(InterruptedListPath, link + "\n");
                }
            }
        }
    }
}
