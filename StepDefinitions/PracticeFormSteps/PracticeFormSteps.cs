using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.PageObject;
using DemoQA_Project_SpecFlow.PageObject.formObject;
using DemoQA_Project_SpecFlow.Pages;
using DemoQA_Project_SpecFlow.resourceUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Linq;
using TechTalk.SpecFlow.Assist;

namespace DemoQA_Project_SpecFlow.StepDefinitions.PracticeFormSteps
{
    [Binding]
    public class PracticeFormSteps : FormsSteps
    {

        public PracticeFormPage PracticeFormPage { get; private set; }


        public PracticeFormSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }


        [When(@"I fill the form")]
        public void WhenIFillTheForm()
        {
            var scenarioTitle = ScenarioContext.ScenarioInfo.Title;
            PracticeFormPage = new PracticeFormPage(DriverInstance.Driver);

            var data = InputObject.GetSpecificObject<PracticeFormObject>();
            PracticeFormPage.CompleteFields(data);
            PracticeFormPage.ValidateEnteredValues(data);

        }

        [When(@"I fill the entire form with the following details")]
        public void WhenIFillTheEntireFormWithTheFollowingDetails(Table table)
        {
            PracticeFormPage = new PracticeFormPage(DriverInstance.Driver);
            var data = table.CreateInstance<PracticeFormObject>();
            PracticeFormPage.CompleteFields(data);
        }

        [When(@"I subbmit form")]
        public void WhenISubbmitForm()
        {
            PracticeFormPage = new PracticeFormPage(DriverInstance.Driver);
            PracticeFormPage.Submit();
            
        }

        [Then(@"I validate all the entered fields from form page")]
        public void ThenIValidateAllTheEnteredFieldsFromFormPage(Table table)
        {
            
            var data = table.CreateInstance<PracticeFormObject>();
            PracticeFormPage.ValidateValues(data);
        }


    }
}

