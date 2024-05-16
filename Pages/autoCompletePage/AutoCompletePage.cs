using DemoQA_Project_SpecFlow.PageObject.autoCompleteObject;
using DemoQA_Project_SpecFlow.PageObject.textBoxObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages.autoCompletePage
{
    public class AutoCompletePage : BasePage
    {
        public AutoCompletePage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement Color1Field => Driver.FindElement(By.Id("autoCompleteMultipleInput"));
        private IWebElement Color2Field => Driver.FindElement(By.Id("autoCompleteSingleInput"));
        private IReadOnlyList<IWebElement> Color1Text => Driver.FindElements(By.XPath("//*[@class='css-12jo7m5 auto-complete__multi-value__label']"));
        private IWebElement Color2Text => Driver.FindElement(By.XPath("//*[@class='auto-complete__single-value css-1uccc91-singleValue']"));

        public void CompleteFields(AutoCompleteObject autoCompleteObject)
        {
            CompleteColor1(autoCompleteObject);
            CompleteColor2(autoCompleteObject);
            validateFields(autoCompleteObject);
        }

        public void CompleteColor1(AutoCompleteObject autoCompleteObject)
        {
            for (int index = 0; index < autoCompleteObject.Color1List.Count; index++)
            {
                Helpers.CompleteWithFirstValue(Color1Field, autoCompleteObject.Color1List[index]);
            }
        }

        public void CompleteColor2(AutoCompleteObject autoCompleteObject)
        {
            Helpers.CompleteWithFirstValue(Color2Field, autoCompleteObject.Color2);
        }

        public void validateFields(AutoCompleteObject autoCompleteObject)
        {
            for (int i = 0; i < Color1Text.Count; i++)
            {
                Assert.IsTrue(Color1Text[i].Text.Contains(autoCompleteObject.Color1List[i]));
            }
            Assert.IsTrue(Color2Text.Text.Contains(autoCompleteObject.Color2));
        }
    }
}
