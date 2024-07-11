using DemoQA_Project_SpecFlow.loggerUtility;
using DemoQA_Project_SpecFlow.PageObject.textBoxObject;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace DemoQA_Project_SpecFlow.Pages.TextBoxPage
{
    public class TextBoxPage : BasePage
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TextBoxPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FullName => Driver.FindElement(By.Id("userName"));
        private IWebElement Email => Driver.FindElement(By.Id("userEmail"));
        private IWebElement CurrentAddress => Driver.FindElement(By.Id("currentAddress"));
        private IWebElement PermanentAddress => Driver.FindElement(By.Id("permanentAddress"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));
        private IReadOnlyList<IWebElement> OutPutText => Driver.FindElements(By.ClassName("mb-1"));

        public void CompleteForm(TextBoxObject textBoxObject)
        {
            FillFullName(textBoxObject);
            LoggerUtility.logger.Info("The user completes the Full Name field");
            FillEmail(textBoxObject);
            logger.Info("The user completes the Email field");
            FillCurrentAddress(textBoxObject);
            logger.Info("The user completes the Current Address field");
            FillPermanentAddress(textBoxObject);
            logger.Info("The user completes the Permanent Address field");
            ValidateForm(textBoxObject);
            logger.Info("The form is validated");
            SubmitForm();
            logger.Info("The form is submited");
        }

        public void FillFullName(TextBoxObject textBoxObject)
        {
            Helpers.FillElement(FullName, textBoxObject.FullName);

        }

        public void FillEmail(TextBoxObject textBoxObject)
        {
            Helpers.FillElement(Email, textBoxObject.Email);

        }

        public void FillCurrentAddress(TextBoxObject textBoxObject)
        {
            Helpers.FillElement(CurrentAddress, textBoxObject.CurrentAddress);

        }

        public void FillPermanentAddress(TextBoxObject textBoxObject)
        {
            Helpers.FillElement(PermanentAddress, textBoxObject.PermanentAddress);

        }

        public void SubmitForm()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0,500)");
            SubmitButton.Click();
        }

        public void ValidateForm(TextBoxObject textBoxObject)
        {
            Assert.IsTrue(Helpers.GetTextWithAttribute(FullName).Contains(textBoxObject.FullName));
            Assert.IsTrue(Helpers.GetTextWithAttribute(Email).Contains(textBoxObject.Email));
            Assert.IsTrue(Helpers.GetTextWithAttribute(CurrentAddress).Contains(textBoxObject.CurrentAddress));
            Assert.IsTrue(Helpers.GetTextWithAttribute(PermanentAddress).Contains(textBoxObject.PermanentAddress));    
        }
    }
}
