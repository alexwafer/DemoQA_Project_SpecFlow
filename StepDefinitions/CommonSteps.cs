using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.Pages;
using log4net;
using System.Reflection;

namespace DemoQA_Project_SpecFlow.StepDefinitions
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CommonSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext) 
            : base(DriverInstance, FeatureContext, ScenarioContext) { }

        public CommonPage CommonPage { get; private set; }


        [When("I click on (.*) subMenu")]
        public void GivenIClickOn(string elementName)
        {
            CommonPage = new CommonPage(DriverInstance.Driver);
            CommonPage.ClickOnElement(elementName);
            logger.Info("The user clicks on " + elementName + " submenu");
        }

        [Given(@"Test data was successfully loaded")]
        public void GivenTestDataWasSuccessfullyLoaded(Table Table)
        {
            var scenarioTitle = ScenarioContext.ScenarioInfo.Title;
            var Dictionary = PrepareTestDataInputResourceValues(Table);

            InputObject = InputObject.PrepareObject(GetObjectType(scenarioTitle), Dictionary);
             
        }

    }
}
