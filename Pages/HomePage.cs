using DemoQA_Project_SpecFlow.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ConsentElement => Driver.FindElement(By.XPath("//*[text()='Consent']"));


        public CommonPage Click(string elementText)
        {
            //consentElement.Click();
            Helpers.ClickOnElementByText(elementText);
            return new CommonPage(Driver);
        }

    }
}
