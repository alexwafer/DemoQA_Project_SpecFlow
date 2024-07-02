using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA_Project_SpecFlow.Drivers
{
    public class ChromeBrowserService
    {
        public IWebDriver Driver { get; private set; }

        public void SetUpDriver()
        {
            //dotnet test ..dll --testparam=ciCd=true
            var ciCd = Environment.GetEnvironmentVariable("ciCd");
            if (ciCd != null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--headless");
                //aici sa faca instanta cu headless
                Driver = new ChromeDriver(options);
            }
            else
            {
                //rulez fara headless
                Driver = new ChromeDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://demoqa.com/";
        }

        public void ClearDriver()
        {
            if (Driver != null)
            {
                Driver.Dispose();
                Driver.Quit();
            }
        }
    }
}
