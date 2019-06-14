using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.helper;
using Xunit.Sdk;

namespace demoqa.helper
{
    public class JsonDataAttribute : DataAttribute
    {
        private string _fileName, _arrayName;

        public JsonDataAttribute(string jsonFileName, string dataArrayName)
        {
            _fileName = jsonFileName;
            _arrayName = dataArrayName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            foreach (JToken item in DataFactory.GetData(_fileName, _arrayName))
            {
                yield return item.Values().ToArray();
            } 
        }
    }
}
