using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.PageObject.alertsObject
{
    public class AlertsObject : InputObject
    {
        public string AlertInput { get; private set; }
        public string AlertOption { get; private set; }

        public AlertsObject(Dictionary<string, string> Hash)
        {
            PopulateObject(Hash);
        }
    }
}
