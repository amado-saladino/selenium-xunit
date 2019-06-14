using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using System.ComponentModel;
using demoqa.globals;
using UnitTestProject1.helper;
using AventStack.ExtentReports;

namespace demoqa
{
    public class Class1 : IClassFixture<ClassFixture>
    {
        private readonly ITestOutputHelper _output;
        ExtentTest testReporter;

        public Class1(ClassFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            Type type = output.GetType();
            FieldInfo method = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            ITest test = (ITest)method.GetValue(output);
            output.WriteLine($"Test Name is {test.DisplayName}");
            output.WriteLine($"Class name is {TypeDescriptor.GetClassName(this)}");
            testReporter = ExtentTestManager.CreateMethod(test.DisplayName);            
        }

        [Fact]
        void test1()
        {
            testReporter.Log(Status.Info, "test1 log");
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            string baseURL = config["BaseURL"];
            _output.WriteLine($"Base URL: {baseURL}");
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.LinkText("Dismiss")).Click();
            driver.FindElement(By.LinkText("Checkout")).Click();
            driver.Quit();
        }

        [Fact]
        void test2()
        {
            testReporter.Log(Status.Info, "test2 log");
            _output.WriteLine($"Inside test2");
        }

    }
}
