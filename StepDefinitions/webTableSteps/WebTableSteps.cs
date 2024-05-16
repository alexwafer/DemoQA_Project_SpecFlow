using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject.formObject;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.Pages;
using DemoQA_Project_SpecFlow.Pages.webTablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA_Project_SpecFlow.PageObject.webTableObject;

namespace DemoQA_Project_SpecFlow.StepDefinitions.webTableSteps
{
    [Binding]

    public class WebTableSteps : BaseSteps
    {
        public WebTablePage WebTablePage { get; private set; }
        public WebTableSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }

        [Then(@"I add a new entry into table")]
        public void ThenIAddANewEntryIntoTable()
        {
            WebTablePage = new WebTablePage(DriverInstance.Driver);
            var data = InputObject.GetSpecificObject<WebTableObject>();
            WebTablePage.addEntry(data);

        }



    }
}
