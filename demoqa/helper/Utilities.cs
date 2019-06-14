using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.helper
{
    public class Utilities
    {
        private string url;
        IConfigurationRoot config;

        public Utilities()
        {
            config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            Url = config["BaseURL"];
        }

        public void takeSnapshot(IWebDriver driver, string filename)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filename);
        }

        public string GenerateScreenshotFileName(string path, string screenshotName)
        {
            return path + @"\Report\images\" + screenshotName + generateLocalTimeFingerprint() + ".png";
        }

        private string generateLocalTimeFingerprint()
        {
            return DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '_');
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }       
    }
}
