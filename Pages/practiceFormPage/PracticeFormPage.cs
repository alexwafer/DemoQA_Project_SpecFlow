using DemoQA_Project_SpecFlow.loggerUtility;
using DemoQA_Project_SpecFlow.PageObject.formObject;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DemoQA_Project_SpecFlow.Pages
{
    public class PracticeFormPage : BasePage
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstNameElement => Driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameElement => Driver.FindElement(By.Id("lastName"));
        private IWebElement UserEmailElement => Driver.FindElement(By.Id("userEmail"));
        private IWebElement UserNumberElement => Driver.FindElement(By.Id("userNumber"));
        private IWebElement SubmitForm => Driver.FindElement(By.Id("submit"));
        private IWebElement CurrentAddressElement => Driver.FindElement(By.Id("currentAddress"));
        private IWebElement MaleGennderElement => Driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        private IWebElement FemaleGennderElement => Driver.FindElement(By.CssSelector("label[for='gender-radio-2']"));
        private IWebElement OtherGennderElement => Driver.FindElement(By.CssSelector("label[for='gender-radio-3']"));
        private IWebElement SubjectsElement => Driver.FindElement(By.Id("subjectsInput"));
        private IWebElement SportsElement => Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
        private IWebElement ReadingElement => Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']"));
        private IWebElement MusicElement => Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']"));
        private IWebElement StateElement => Driver.FindElement(By.XPath("//div[@id='state']//input"));
        private IWebElement CityElement => Driver.FindElement(By.XPath("//div[@id='city']//input"));

        private IWebElement MonthSelector => Driver.FindElement(By.ClassName("react-datepicker__month-select"));
        private IWebElement DateOfBirthSelector => Driver.FindElement(By.Id("dateOfBirthInput"));
        private IWebElement userForm => Driver.FindElement(By.ClassName("menu-list"));
        private IWebElement YearSelector => Driver.FindElement(By.ClassName("react-datepicker__year-select"));
        private IWebElement DaysSelector => Driver.FindElement(By.XPath("//div[@class='react-datepicker__month']/div/div"));

        public IWebElement ThankYouMessageSelector => Driver.FindElement(By.Id("example-modal-sizes-title-lg"));
        public IWebElement ResultsTableSelector => Driver.FindElement(By.XPath("//div[@class='table-responsive']/table//tr/td[2]"));


        public void CompleteFields(PracticeFormObject practiceFormObject)
        {
            FillFirstName(practiceFormObject.FirstName);
            logger.Info("The user completes Firt Name field");
            FillLastName(practiceFormObject.LastName);
            logger.Info("The user completes Last Name field");
            FillEmail(practiceFormObject.UserEmail);
            logger.Info("The user completes Email field");
            ClickOnGender(practiceFormObject);
            logger.Info("The user clicks on Gender");
            FillPhoneNumber(practiceFormObject.UserNumber);
            logger.Info("The user completes the Phone Number field");
            FillDateOfBirth(practiceFormObject.Month, practiceFormObject.Year, practiceFormObject.Day);
            logger.Info("The user completes the Date of Birth field");
            FillSubjects(practiceFormObject.Subjects);
            logger.Info("The user completes Subjects field");
            FillHobies(practiceFormObject);
            logger.Info("The user clicks on desiered Hobbies");
            FillAddress(practiceFormObject.CurrentAddress);
            logger.Info("The user completes the Current Address field");
            FillState(practiceFormObject.State);
            logger.Info("The user selects the State");
            FillCity(practiceFormObject.City);
            logger.Info("The user selects the City");
            Submit();
           
        }

        public void FillFirstName(string FirstName)
        {
            Helpers.ClearAndFillElement(FirstNameElement, FirstName);
        }

        public void FillLastName(string LastName)
        {
            Helpers.ClearAndFillElement(LastNameElement, LastName);
        }

        public void FillEmail(string Email)
        {
            Helpers.ClearAndFillElement(UserEmailElement, Email);
        }

        public void ClickOnGender(PracticeFormObject practiceFormObject)
        {
            if (practiceFormObject.Gender.Equals("Male")) Helpers.ClickWithJS(MaleGennderElement);
            else if (practiceFormObject.Gender.Equals("Female")) Helpers.ClickWithJS(FemaleGennderElement);
            else if (practiceFormObject.Gender.Equals("Other")) Helpers.ClickWithJS(OtherGennderElement);
        }
        public void FillPhoneNumber(string PhoneNumber)
        {
            Helpers.ClearAndFillElement(UserNumberElement, PhoneNumber);
        }

        public void FillSubjects(IList<string> Subjects)
        {
            Subjects.ToList().ForEach(Subject =>
            {
                Helpers.FillElement(SubjectsElement, Subject);
                Helpers.FillElement(SubjectsElement, Keys.Enter);
            });
        }

        public void FillHobies(PracticeFormObject practiceFormObject)
        {
            Helpers.ScrollBy(700);
            IList<string> hobbies = practiceFormObject.Hobbies;

            foreach (string hobbie in hobbies)
            {
                if (hobbie.Contains("Sports")) Helpers.ClickOnElement(SportsElement);
                else if (hobbie.Contains("Reading")) Helpers.ClickOnElement(ReadingElement);
                else if (hobbie.Contains("Music")) Helpers.ClickOnElement(MusicElement);
            }
        }

        public PracticeFormPage FillDateOfBirth(string month, string year, string day)
        {          
            Helpers.ClickWithJS(DateOfBirthSelector);
            if(!String.IsNullOrEmpty(month)) Helpers.SelectByText(MonthSelector, month);
            if(!String.IsNullOrEmpty(year)) Helpers.SelectByText(YearSelector, year);
            if(!String.IsNullOrEmpty(day)) Driver.FindElements(By.XPath("//div[@class='react-datepicker__month']/div/div"))
                .Where(element => element.GetAttribute("aria-label").Contains(month + " " + day))
                .ToList()
                .ForEach(result =>
                {
                    Helpers.HoverElement(result);
                    Helpers.ClickWithJS(result);
                });
            DateOfBirthSelector.SendKeys(Keys.Escape);
            return this;
        }

        public void FillAddress(string address)
        {
            Helpers.FillElement(CurrentAddressElement, address);
        }

        public void FillState(string state)
        {
            Helpers.ScrollBy(500);
            Helpers.FillElement(StateElement, state);
            Helpers.FillElement(StateElement, Keys.Enter);


        }

        public void FillCity(string city)
        {
            Helpers.FillElement(CityElement, city);
            Helpers.FillElement(CityElement, Keys.Enter);
        }

        public void Submit()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0,500)");
            Helpers.ClickWithJS(SubmitForm);
        }

        public PracticeFormPage ValidateEnteredValues(PracticeFormObject practiceFormObject)
        {
            Helpers.ElementIsPresent(ThankYouMessageSelector);
            LoggerUtility.Info($"The user waits for presence of ThankYouMessageSelector field");
            int countValidations = -1;
            IList<IWebElement> TableValues = Driver.FindElements(By.XPath("//table//tr/td[2]"));
            practiceFormObject.ActualPracticeFormValues.ToList()
                .ForEach(itemValue => TableValues
                .Where(actualResult => actualResult.Text.Contains(itemValue) && actualResult.Text.Length > 0)
                .ToList()
                .ForEach(result =>
                {
                    Assert.IsTrue(result.Text.Contains(itemValue));
                    countValidations += 1;
                }));
            Assert.IsTrue(practiceFormObject.ActualPracticeFormValues.Count == countValidations, "Not all values were displayed into validation form table..");
            return this;
        }

        public void ValidateValues(PracticeFormObject practiceFormObject)
        {
            IWebElement tableValues = Driver.FindElement(By.ClassName("modal-body"));

            string fullName = practiceFormObject.FirstName + " " + practiceFormObject.LastName;
            string stateAndCity = practiceFormObject.State + " " + practiceFormObject.City;


            string rowContent = tableValues.Text;

            Assert.True(rowContent.Contains(fullName));
            Assert.True(rowContent.Contains(practiceFormObject.UserEmail));
            Assert.True(rowContent.Contains(practiceFormObject.Gender));
            Assert.True(rowContent.Contains(practiceFormObject.UserNumber));
            Assert.True(rowContent.Contains(practiceFormObject.Day));
            Assert.True(rowContent.Contains(practiceFormObject.Year));
            Assert.True(rowContent.Contains(practiceFormObject.Month));
            
            foreach(var item in practiceFormObject.Subjects)
            {
                Assert.True(rowContent.Contains(item));
            }
            foreach (var item in practiceFormObject.Hobbies)
            {
                Assert.True(rowContent.Contains(item));
            }
            Assert.True(rowContent.Contains(practiceFormObject.CurrentAddress));
            Assert.True(rowContent.Contains(stateAndCity));    
        }
    }
}
