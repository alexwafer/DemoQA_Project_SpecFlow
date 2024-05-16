using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.PageObject.autoCompleteObject;
using DemoQA_Project_SpecFlow.Pages.autoCompletePage;

namespace DemoQA_Project_SpecFlow.StepDefinitions.autoCompleteSteps
{
    [Binding]
    public class AutoCompleteSteps : BaseSteps
    {
        public AutoCompletePage AutoCompletePage { get; private set; }

        public AutoCompleteSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }

        [Then(@"I complete both color fields")]
        public void ThenICompleteBothColorFields()
        {
            AutoCompletePage = new AutoCompletePage(DriverInstance.Driver);
            var data = InputObject.GetSpecificObject<AutoCompleteObject>();
            AutoCompletePage.CompleteFields(data);
        }

    }
}
