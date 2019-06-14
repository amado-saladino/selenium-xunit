using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.IO;
using UnitTestProject1.helper;

namespace demoqa.globals
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            Driver = WebDriverFactory.Driver;
            Utils = new Utilities();
            Driver.Navigate().GoToUrl(Utils.Url);
            Driver.Manage().Window.Maximize();
            CurrentPath = Directory.GetCurrentDirectory();
            Extent = ExtentTestManager.ExtentReportInstance();
        }

        public IWebDriver Driver { get; set; }
        public Utilities Utils { get; set; }
        public ExtentReports Extent { get; set; }
        public string CurrentPath { get; set; }

        public void Dispose()
        {
            Extent.Flush();
            WebDriverFactory.CloseBrowser();
        }
    }
}
