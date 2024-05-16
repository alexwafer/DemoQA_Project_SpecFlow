using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.StepDefinitions.PracticeFormSteps
{
    public class FormsSteps : BaseSteps
    {
        public PracticeFormPage PracticeFormPage { get; set; }

        public FormsSteps(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext)
            : base(DriverInstance, FeatureContext, ScenarioContext)
        { }
    }
}
