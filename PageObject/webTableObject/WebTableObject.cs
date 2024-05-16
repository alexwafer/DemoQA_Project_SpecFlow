using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.PageObject.webTableObject
{
    public class WebTableObject : InputObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Age { get; private set; }
        public string Salary { get; set; }
        public string Departament { get; private set; }

        public WebTableObject(Dictionary<string, string> Hash)
        {
            PopulateObject(Hash);
        }
    }
}
