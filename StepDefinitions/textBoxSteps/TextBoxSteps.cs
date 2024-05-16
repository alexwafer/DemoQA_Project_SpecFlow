using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject.webTableObject;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.Pages.webTablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA_Project_SpecFlow.Pages.TextBoxPage;
using DemoQA_Project_SpecFlow.PageObject.textBoxObject;

namespace DemoQA_Project_SpecFlow.StepDefinitions.TextBoxSteps
{
    [Binding]
    public class TextBoxSteps : BaseSteps
    {
        public TextBoxPage TextBoxPage { get; private set; }
        public TextBoxSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }

        [Then(@"I fill TextBox Form")]
        public void ThenIFillTextBoxForm()
        {
            TextBoxPage = new TextBoxPage(DriverInstance.Driver);
            var data = InputObject.GetSpecificObject<TextBoxObject>();
            TextBoxPage.CompleteForm(data);
        }

    }
}
