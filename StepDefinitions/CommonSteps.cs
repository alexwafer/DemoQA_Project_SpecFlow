using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.Pages;

namespace DemoQA_Project_SpecFlow.StepDefinitions
{
    [Binding]
    public class CommonSteps : BaseSteps
    {

        public CommonSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext) 
            : base(DriverInstance, FeatureContext, ScenarioContext) { }

        public CommonPage CommonPage { get; private set; }


        [When("I click on (.*) subMenu")]
        public void GivenIClickOn(string elementName)
        {
            CommonPage = new CommonPage(DriverInstance.Driver);
            CommonPage.ClickOnElement(elementName);
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
