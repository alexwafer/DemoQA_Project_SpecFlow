using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoQA_Project_SpecFlow.Utils
{
    public class AlertHelper
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait WaitExplicit { get; private set; }

        public AlertHelper(IWebDriver Driver)
        {
            this.Driver = Driver;
            WaitExplicit = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public void AlertOk()
        {
            Driver.SwitchTo().Alert().Accept();
            Driver.SwitchTo().DefaultContent();
        }
        public void AlertWithDelay()
        {
            //o alta modalitate de a utiliza wait fara a fii nevoie sa instalez din nuget SeleniumExtras.WaitHelpers;
            var alert = WaitExplicit.Until(x => Driver.SwitchTo().Alert());
            Driver.SwitchTo().Alert().Accept();
        }

        public void AlertWithConfirmOrCancel(string option)
        {
           
            if (option.Equals("Accept"))
            {
                Driver.SwitchTo().Alert().Accept();
            }
            else if (option.Equals("Cancel"))
            {
                Driver.SwitchTo().Alert().Dismiss();
            }
        }

        public void AlertWithPrompt(string text)
        {
            WaitExplicit.Until(ExpectedConditions.AlertIsPresent());
            var alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();

        }
    }
}
