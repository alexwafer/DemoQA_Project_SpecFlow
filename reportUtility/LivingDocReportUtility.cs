using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoQA_Project_SpecFlow.reportUtility
{
    public class LivingDocReportUtility
    {
        public string ReportDirectory { get; private set; }

        public LivingDocReportUtility()
        {
            InitializeReport();
        }

        private void InitializeReport()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ReportDirectory = $"{GetProjectDirectoryPath(path)}\\reports\\";
        }

        private string GetProjectDirectoryPath(string path)
        {
            return Directory.GetParent(path).Parent.Parent.FullName;
        }

        public void PrepareSpecFlowLivingDoc(IWebDriver Driver, ISpecFlowOutputHelper _specFlowOutputHelper, ScenarioContext ScenarioContext, string StepError)
        {
            var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");
            var screenshotFile = ReportDirectory + filename;

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotFile);
            _specFlowOutputHelper.AddAttachment(screenshotFile);

            var stepTackTrace = ScenarioContext.TestError.StackTrace;
            _specFlowOutputHelper.WriteLine(StepError);
            _specFlowOutputHelper.WriteLine(stepTackTrace);
        }
    }
}
