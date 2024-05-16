using DemoQA_Project_SpecFlow.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get;  set; }

        public Helpers Helpers { get; private set; }
        public AlertHelper AlertHelper { get; private set; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            Helpers = new Helpers(driver);
            AlertHelper = new AlertHelper(driver);

        }
    }
}
