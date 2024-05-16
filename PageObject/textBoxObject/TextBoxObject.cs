using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.PageObject.textBoxObject
{
    public class TextBoxObject : InputObject
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string CurrentAddress { get; private set; }
        public string PermanentAddress { get; private set; }

        public TextBoxObject(Dictionary<string, string> Hash)
        {
            PopulateObject(Hash);
        }
    }
}
