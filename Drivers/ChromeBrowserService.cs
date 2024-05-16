using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA_Project_SpecFlow.Drivers
{
    public class ChromeBrowserService
    {
        public IWebDriver Driver { get; private set; }

        public void SetUpDriver()
        {
            Driver = new ChromeDriver();
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
