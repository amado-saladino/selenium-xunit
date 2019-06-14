using AventStack.ExtentReports;
using demoqa.globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.helper;
using Xunit;
using Xunit.Abstractions;

namespace demoqa.tests
{
    [Collection("Global collection")]
    [Trait("Description","Description for Test class")]
    public class Test
    {
        protected TestFixture _testFixture;
        protected string testName;
        protected readonly ITestOutputHelper _testcontext;
        protected ExtentTest testReporter;
        protected ExtentTest parentTest;

        public Test(TestFixture fixture, ITestOutputHelper testcontext)
        {
            _testFixture = fixture;
            _testcontext = testcontext;
            ExtractTestContextData();
        }

        private void ExtractTestContextData()
        {
            Type type = _testcontext.GetType();
            FieldInfo method = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            ITest test = (ITest)method.GetValue(_testcontext);
            TestMethodName = test.DisplayName;
            TestClassName = TypeDescriptor.GetClassName(this);          
            parentTest = ExtentTestManager.CreateTest(TestClassName, test.TestCase.Traits["Description"].First());
            testReporter = ExtentTestManager.CreateMethod(TestMethodName);
        }

        protected string TestMethodName { get; set; }
        protected string TestClassName { get; set; }

        protected string screenshotPath;
        protected bool result;
    }
}
