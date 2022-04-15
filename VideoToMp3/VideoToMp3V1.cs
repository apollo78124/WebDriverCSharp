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

            foreach (var link in fileList)
            {
                try
                {
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath);
                    service.HideCommandPromptWindow = false;

                    var options = new ChromeOptions();
                    options.AddArgument("--window-position=1,1");
                    options.AddArgument("incognito");
                    options.AddExcludedArgument("headless");

                    ChromeDriver driver = new ChromeDriver(service, options);
                    driver.Url = "https://ytmp3.cc/";
                    driver.Navigate().GoToUrl("https://ytmp3.cc/");
                    Thread.Sleep(3000);

                    /**
                    WebElement url = driver.FindElement(By.id("input"));
                    url.click();
                    url.sendKeys(links[i]);
                    WebElement convertForm = driver.findElement(By.id("submit"));
                    convertForm.submit();
                    Thread.sleep(10000);
                    WebElement download = driver.findElement(By.xpath("/html/body/div[2]/div[1]/div[1]/div[3]/a[1]"));
                    download.click();
                    Thread.sleep(3000);
                    */
                }
                catch (Exception e)
                {
                    Console.WriteLine("Interrupted: " + link + "");
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
