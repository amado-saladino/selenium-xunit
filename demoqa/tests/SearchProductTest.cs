using System;
using demoqa.pages;
using AventStack.ExtentReports;
using System.Collections.Generic;
using UnitTestProject1.helper;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections;
using System.Threading;
using demoqa.globals;
using Xunit.Abstractions;
using Xunit;
using demoqa.helper;

namespace demoqa.tests
{
    public class SearchProductTest : Test
    {
        public SearchProductTest(TestFixture fixture, ITestOutputHelper testcontext) : base(fixture, testcontext)
        {
        }

        [Theory]
        [Trait("Description", "It should search for product")]
        //[MemberData(nameof(DataFactory.ProductDataJSON), MemberType =typeof(DataFactory))]
        //[ClassData(typeof(ProductClassData))]
        [JsonData("data.json", "products")]
        public void SearchProduct(string keyword, string productName)
        {
            screenshotPath = _testFixture.Utils.GenerateScreenshotFileName(_testFixture.CurrentPath, testName);
            HomePage homePage = new HomePage(_testFixture.Driver);
            testReporter.Log(Status.Info, "Product Name: " + productName.ToUpper());
            ProductPage productPage = homePage.Search(keyword);
            _testFixture.Utils.takeSnapshot(_testFixture.Driver, screenshotPath);
            testReporter.AddScreenCaptureFromPath(screenshotPath);
            result = productPage.isValidPage(productName);
            Assert.True(result);
        }

        [Fact]
        [Trait("Description", "Test 2 method description")]
        public void test2()
        {
            testReporter.Log(Status.Info, "This is only a logging info to Test 2 method");
            _testcontext.WriteLine("This is Test 2");
        }
    }
}
