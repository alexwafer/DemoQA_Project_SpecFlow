using DemoQA_Project_SpecFlow.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages
{
    public class CommonPage : BasePage
    {
        public CommonPage(IWebDriver driver) : base(driver)
        {
        }

        public PracticeFormPage ClickOnElement(string elementText)
        {
            Helpers.ClickOnElementByText(elementText);
            return new PracticeFormPage(Driver);
        }
    }
}
