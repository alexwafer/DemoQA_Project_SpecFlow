using DemoQA_Project_SpecFlow.PageObject.formObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages
{
    public class PracticeFormPage : BasePage
    {
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
        private IWebElement StateElement => Driver.FindElement(By.Id("react-select-3-input"));
        private IWebElement CityElement => Driver.FindElement(By.Id("city"));

        private IWebElement MonthSelector => Driver.FindElement(By.ClassName("react-datepicker__month-select"));
        private IWebElement DateOfBirthSelector => Driver.FindElement(By.Id("dateOfBirthInput"));
        private IWebElement YearSelector => Driver.FindElement(By.ClassName("react-datepicker__year-select"));
        private IWebElement DaysSelector => Driver.FindElement(By.XPath("//div[@class='react-datepicker__month']/div/div"));

        public IWebElement ThankYouMessageSelector => Driver.FindElement(By.Id("example-modal-sizes-title-lg"));
        public IWebElement ResultsTableSelector => Driver.FindElement(By.XPath("//div[@class='table-responsive']/table//tr/td[2]"));


        public void CompleteFields(PracticeFormObject practiceFormObject)
        {
            FillFirstName(practiceFormObject.FirstName);
            FillLastName(practiceFormObject.LastName);
            FillEmail(practiceFormObject.UserEmail);
            ClickOnGender(practiceFormObject);
            FillPhoneNumber(practiceFormObject.UserNumber);
            FillDateOfBirth(practiceFormObject.Month, practiceFormObject.Year, practiceFormObject.Day);
            FillSubjects(practiceFormObject.Subjects);
            FillHobies(practiceFormObject);
            FillAddress(practiceFormObject.CurrentAddress);
            FillState(practiceFormObject.State);
            FillCity(practiceFormObject.City);
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
            if (practiceFormObject.Gender.Equals("Male")) MaleGennderElement.Click();
            else if (practiceFormObject.Gender.Equals("Female")) FemaleGennderElement.Click();
            else if (practiceFormObject.Gender.Equals("Other")) OtherGennderElement.Click();
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
            Helpers.ClickOnElement(DateOfBirthSelector);
            Helpers.SelectByText(MonthSelector, month);
            Helpers.SelectByText(YearSelector, year);
            Driver.FindElements(By.XPath("//div[@class='react-datepicker__month']/div/div"))
                .Where(element => element.GetAttribute("aria-label").Contains(month + " " + day))
                .ToList()
                .ForEach(result =>
                {
                    Helpers.HoverElement(result);
                    Helpers.ClickOnElement(result);
                });
            return this;
        }

        public void FillAddress(string address)
        {
            Helpers.FillElement(CurrentAddressElement, address);
        }

        public void FillState(string state)
        {
            Helpers.ScrollBy(500);
            Helpers.fillWithActions(StateElement, state);
 
        }

        public void FillCity(string city)
        {
            Helpers.fillWithActions(CityElement, city);
        }

        public void Submit()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0,500)");
            SubmitForm.Submit();
        }

        public PracticeFormPage ValidateEnteredValues(PracticeFormObject practiceFormObject)
        {
            Helpers.ElementIsPresent(ThankYouMessageSelector);
            int countValidations = -1;
            IList<IWebElement> TableValues = Driver.FindElements(By.XPath("//div[@class='table-responsive']//table//tr/td[2]"));
            practiceFormObject.ActualPracticeFormValues.ToList()
                .ForEach(itemValue => TableValues
                .Where(actualResult => actualResult.Text.Contains(itemValue) && !string.IsNullOrEmpty(actualResult.Text))
                .ToList()
                .ForEach(result =>
                {
                    Assert.IsTrue(result.Text.Contains(itemValue));
                    countValidations ++;
                }));
            Assert.IsTrue(practiceFormObject.ActualPracticeFormValues.Count == countValidations, "Not all values were displayed into validation form table..");
            return this;
        }
    }
}
