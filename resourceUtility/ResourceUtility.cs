using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace DemoQA_Project_SpecFlow.resourceUtility
{
    public class ResourceUtility
    {
        public ResourceManager Resource { get; private set; }

        public ResourceUtility(string path)
        {
            Resource = new ResourceManager("DemoQA_Project_Specflow." + path, Assembly.GetExecutingAssembly());
        }

        public string GetValue(string key)
        {
            return Resource.GetString(key);
        }

       

        public Dictionary<string, string> GetAllKeyValue()
        {
            var Dictionary = new Dictionary<string, string>();
            foreach (var resource in Resource.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                var result = (System.Collections.DictionaryEntry)resource;
                Dictionary.Add(result.Key.ToString(), result.Value.ToString());
            }

            return Dictionary;
        }
    }
}
