using Dynamitey.DynamicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.PageObject.autoCompleteObject
{
    public class AutoCompleteObject : InputObject
    {
        public IList<string> Color1List { get; private set; }
        public string Color1 {  get; private set; }
        public string Color2 { get; private set; }

        public AutoCompleteObject(Dictionary<string, string> Hash)
        {
            PopulateObject(Hash);
            SplitPropertiesIntoSeparateLists();
            
        }

        public void SplitPropertiesIntoSeparateLists()
        {
            string[] splitColorValues = Color1.Split(',');
            Color1List = splitColorValues.Select(x => x).ToList();
            
        }

    }
}
