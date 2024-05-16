using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.resourceUtility;

namespace DemoQA_Project_SpecFlow.StepDefinitions
{
    public class BaseSteps
    {
        public ChromeBrowserService DriverInstance { get; private set; }
        public FeatureContext FeatureContext { get; private set; }
        public ScenarioContext ScenarioContext { get; }
        public ResourceUtility Resource { get; set; }
        public static InputObject InputObject { get; set; }


        public BaseSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
        {
            this.DriverInstance = DriverInstance;
            this.ScenarioContext = ScenarioContext;
            this.FeatureContext = FeatureContext;

        }

        public Dictionary<string, string> PrepareTestDataInputValues(Table Table)
        {
            var Dictionary = new Dictionary<string, string>();
            foreach (var row in Table.Rows)
            {
                Dictionary.Add(row[0], row[1]);
            }
            return Dictionary;
        }

        public Dictionary<string, string> PrepareTestDataInputResourceValues(Table table)
        {
            Resource = new ResourceUtility(table.Rows[0]["key"]);
            var Dictionary = Resource.GetAllKeyValue();
            return Dictionary;
        }

        public string GetObjectType(string scenarioName)
        {
            string[] splitBySpace = scenarioName.Split(' ');

            foreach (string part in splitBySpace)
            {
                if (part.Contains("Scenario"))
                {
                    return part;
                }
            }

            return string.Empty;
        }
    }
}
