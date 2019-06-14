using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.helper;
using Xunit.Abstractions;

namespace demoqa.globals
{
    public class ClassFixture : IDisposable
    {
        ExtentTest parentTest;
        ExtentReports Extent;

        public ClassFixture()
        {
            Extent = ExtentTestManager.ExtentReportInstance();
            parentTest = ExtentTestManager.CreateTest("TestClass Name", "Test Class Description");
        }

        public void Dispose()
        {
            Extent.Flush();
        }
    }
}
