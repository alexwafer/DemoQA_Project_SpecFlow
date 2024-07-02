using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.Pages;
using DemoQA_Project_SpecFlow.Utils;
using NUnit.Framework;

namespace DemoQA_Project_SpecFlow.StepDefinitions
{
    [Binding]
    public class HomeSteps : BaseSteps
    {
        public HomeSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext) 
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }

        public HomePage HomePage { get; private set; }
        public Helpers Helpers { get; private set; }

        [When("I click on (.*) menu")]
        public void GivenIClickOn(string elementName)
        {
            HomePage = new HomePage(DriverInstance.Driver);
            Helpers = new Helpers(DriverInstance.Driver);
            Helpers.ClickWithJS(elementName);
        }

        [Given("Home page was displayed")]
        public void ValidateHomePagePresence()
        {
            Assert.True(DriverInstance.Driver.Url.Equals("https://demoqa.com/"));
        }
    }
}
