using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.PageObject.alertsObject;
using DemoQA_Project_SpecFlow.PageObject.webTableObject;
using DemoQA_Project_SpecFlow.Pages.AlertFramePage;
using DemoQA_Project_SpecFlow.Pages.webTablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.StepDefinitions.AlertFrameSteps
{
    [Binding]
    public class AlertFrameSteps : BaseSteps
    {
        public AlertFrameSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }

        public AlertFramePage AlertFramePage { get; private set; }

        [Then(@"I deal with everyAlert")]
        public void ThenIDealWithEveryAlert()
        {
            AlertFramePage = new AlertFramePage(DriverInstance.Driver);
            var data = InputObject.GetSpecificObject<AlertsObject>();
            AlertFramePage.ClickOnEveryAlertJS(data);
        }

    }
}
