using DemoQA_Project_SpecFlow.Drivers;
using DemoQA_Project_SpecFlow.loggerUtility;
using DemoQA_Project_SpecFlow.reportUtility;
using log4net.Config;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoQA_Project_SpecFlow.StepDefinitions
{
    [Binding]
    public class Hooks : BaseSteps
    {
        private readonly ISpecFlowOutputHelper _outputHelper;
        private static bool checkLogsPresence = false;

        public Hooks(ChromeBrowserService DriverInstance, FeatureContext FeatureContext, ScenarioContext ScenarioContext, ISpecFlowOutputHelper outputHelper) 
            : base(DriverInstance, FeatureContext, ScenarioContext) 
        {
            _outputHelper = outputHelper;
        }

        [BeforeFeature]
        public static void PrepareFeature(FeatureContext context, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            if (!checkLogsPresence)
            {
                //LoggerUtility.ClearFolderLogs();
                BasicConfigurator.Configure(new CustomLogAppender(specFlowOutputHelper));
                checkLogsPresence = true;
                
            }
            LoggerUtility.StartFeature(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            DriverInstance.SetUpDriver();
            LoggerUtility.StartScenario(ScenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverInstance.ClearDriver();
            LoggerUtility.StopScenario(ScenarioContext.ScenarioInfo.Title);
        }

        [AfterFeature]
        public static void ClearFeature(FeatureContext context)
        {
            LoggerUtility.StopFeature(context.FeatureInfo.Title);
        }

        [BeforeStep]
        public void PrepareStep()
        {
            LoggerUtility.StartStep(ScenarioContext.StepContext.StepInfo.Text);
        }

        [AfterStep]
        public void ClearStep()
        {
            LivingDocReportUtility livingDocReport = new LivingDocReportUtility();

            if (ScenarioContext.TestError != null)
            {
                var stepError = ScenarioContext.TestError.Message;
                livingDocReport.PrepareSpecFlowLivingDoc(DriverInstance.Driver, _outputHelper, ScenarioContext, stepError);
                LoggerUtility.Error(stepError);
            }
            LoggerUtility.StopStep(ScenarioContext.StepContext.StepInfo.Text);
        }
    }
}
