using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1.helper
{
    public class DataFactory
    {
        public static JToken GetData(string filename, string token)
        {
            string jsonpath = Directory.GetCurrentDirectory() + @"\Data\" + filename;
            string filecontent = File.ReadAllText(jsonpath);
            JObject jsoncontent = JObject.Parse(filecontent);
            return jsoncontent[token];
        }

        public static IEnumerable<object[]> ProductData()
        {
            List<object[]> data = new List<object[]>();
            data.Add(new object[] { "pink drop", "pink drop shoulder oversized t shirt" });
            data.Add(new object[] { "black lux", "black lux graphic t-shirt" });
            return data;
        }

        public static IEnumerable<object[]> ProductDataJSON()
        {
            foreach (var product in GetData("data.json", "products"))
            {
                yield return new object[] { product["keyword"].ToString(), product["name"].ToString() };
            }
        }
    }
}
