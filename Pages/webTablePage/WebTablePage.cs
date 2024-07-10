using DemoQA_Project_SpecFlow.PageObject.webTableObject;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;

namespace DemoQA_Project_SpecFlow.Pages.webTablePage
{
    public class WebTablePage : BasePage
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public WebTablePage(IWebDriver driver) : base(driver)
        {
        }

        private string NewRecordButton = "addNewRecordButton";
        //private IWebElement AddButton => Driver.FindElement(By.Id("addNewRecordButton"));
        private IWebElement FirstNameElement => Driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameElement => Driver.FindElement(By.Id("lastName"));
        private IWebElement EmailElement => Driver.FindElement(By.Id("userEmail"));
        private IWebElement AgeElement => Driver.FindElement(By.Id("age"));
        private IWebElement SalaryElement => Driver.FindElement(By.Id("salary"));
        private IWebElement DepartamentElement => Driver.FindElement(By.Id("department"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));
        private string tableRowsxPath = "//div[@class='rt-tr-group']/div[@class='rt-tr -odd' or @class='rt-tr -even']";

        public void completeForm(WebTableObject webTableObject)
        {
            int actualRowsCount = Driver.FindElements(By.XPath(tableRowsxPath)).Count;
            addEntry(webTableObject);
            validateTable(actualRowsCount, webTableObject);
        }

        public void addEntry(WebTableObject webTableObject)
        {
            Helpers.ClickWithJS(NewRecordButton);
            logger.Info("The user clicks on Add Entry button");
            Helpers.ClearAndFillElement(FirstNameElement, webTableObject.FirstName);
            logger.Info("The user completes the First Name field");
            Helpers.ClearAndFillElement(LastNameElement, webTableObject.LastName);
            logger.Info("The user completes the Last Name field");
            Helpers.ClearAndFillElement(EmailElement, webTableObject.Email);
            logger.Info("The user completes the Email field");
            Helpers.ClearAndFillElement(AgeElement, webTableObject.Age);
            logger.Info("The user completes the Age field");
            Helpers.ClearAndFillElement(SalaryElement, webTableObject.Salary);
            logger.Info("The user completes the Salary field");
            Helpers.ClearAndFillElement(DepartamentElement, webTableObject.Departament);
            logger.Info("The user completes the Departament field");
            Helpers.ClickOnElement(SubmitButton);
            logger.Info("The user Submits the form");

        }

        public void validateTable(int actualRowsCount, WebTableObject webTableObject)
        {
            Assert.IsTrue(Driver.FindElements(By.XPath(tableRowsxPath)).Count == actualRowsCount + 1, "The new row is not present");

            IList<IWebElement> LastTableRowValues = Driver.FindElements(By.XPath(tableRowsxPath))[Driver.FindElements(By.XPath(tableRowsxPath)).Count - 1].FindElements(By.TagName("div"));
            Assert.Multiple(() =>
            {
                Assert.IsTrue(LastTableRowValues[0].Text.Equals(webTableObject.FirstName), "FirstName not correct");
                Assert.IsTrue(LastTableRowValues[1].Text.Equals(webTableObject.LastName), "LastName not correct");
                Assert.IsTrue(LastTableRowValues[2].Text.Equals(webTableObject.Age), "Age not correct");
                Assert.IsTrue(LastTableRowValues[3].Text.Equals(webTableObject.Email), "Email not correct");
                Assert.IsTrue(LastTableRowValues[4].Text.Equals(webTableObject.Salary), "Salary not correct");
                Assert.IsTrue(LastTableRowValues[5].Text.Equals(webTableObject.Departament), "Departament not correct");
            });
        }
    }


}
