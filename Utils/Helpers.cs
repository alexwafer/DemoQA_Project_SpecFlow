using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Project_SpecFlow.Utils
{
    public class Helpers
    {

        private IWebDriver Driver;
        public WebDriverWait WaitExplicit { get; private set; }
        public IJavaScriptExecutor JsExecutor { get; private set; }
        public IAlert alert { get; private set; }
        public Helpers(IWebDriver driver)
        {
            this.Driver = driver;
            WaitExplicit = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            JsExecutor = (IJavaScriptExecutor)Driver;
        }
        public void ClickOnElementByText(string ElementText)
        {
            Driver.FindElement(By.XPath($"//*[text()='{ElementText}']")).Click();
        }
        public void ClickOnElement(IWebElement Element)
        {
            ElementIsPresent(Element);
            Element.Click();
        }
        public void HoverElement(IWebElement Element)
        {
            ElementIsPresent(Element);
            Actions ActionsObject = new Actions(Driver);
            ActionsObject.MoveToElement(Element).Build().Perform();
        }

        public void FillElement(IWebElement Element, string Value)
        {
            ElementIsPresent(Element);
            Element.SendKeys(Value);
        }

        public void ClearAndFillElement(IWebElement Element, string Value)
        {
            ElementIsPresent(Element);
            Element.Clear();
            Element.SendKeys(Value);
        }

        public void ScrollBy(int ScrollBy)
        {
            JsExecutor.ExecuteScript($"window.scrollBy(0, {ScrollBy});");
        }

        public void ElementIsPresent(IWebElement Element)
        {
            WaitExplicit.Until(Driver => Element.Displayed);
        }

        public void ClickWithJS(string elementName)
        {
            IWebElement Element = Driver.FindElement(By.XPath($"//*[text()='{elementName}' or @id='{elementName}']"));
            JsExecutor.ExecuteScript("arguments[0].click();", Element);

        }

        public void ClickWithJS(IWebElement Element)
        {
            ElementIsPresent(Element);
            JsExecutor.ExecuteScript("arguments[0].click();", Element);
        }
        public void SelectByText(IWebElement Identificator, string Value)
        {
            ElementIsPresent(Identificator);

            SelectElement selectElement = new SelectElement(Identificator);
            selectElement.SelectByText(Value);
        }


        public void FillWithActions(IWebElement Element, string text)
        {

            Actions action = new Actions(Driver);
            action.Click(Element).Perform();
            action.SendKeys(text).Perform();
            WaitExplicit.Until(Driver => Element.Displayed);
            action.SendKeys(Keys.Enter).Perform();
        }

        public string GetTextWithAttribute(IWebElement Element)
        {
            return Element.GetAttribute("value");
        }

        public void CompleteWithFirstValue(IWebElement Element, string text)
        {
            Element.SendKeys(text);
            WaitExplicit.Until(Driver => Element.Displayed);
            Element.SendKeys(Keys.Tab);
        }
       
    }
}
