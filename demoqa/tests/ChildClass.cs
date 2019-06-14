using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoqa.globals;
using Xunit.Abstractions;
using Xunit;

namespace demoqa.tests
{
    public class ChildClass : Test
    {
        public ChildClass(TestFixture fixture, ITestOutputHelper testcontext) : base(fixture, testcontext)
        {
        }

        [Fact]
        public void test01()
        {
            _testcontext.WriteLine("ChildClass.test01");
        }

    }
}
