using DemoQA_Project_SpecFlow.PageObject.alertsObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages.AlertFramePage
{
    public class AlertFramePage : BasePage
    {
        public AlertFramePage(IWebDriver driver) : base(driver)
        { }
/*       
        private IWebElement AlertButton => Driver.FindElement(By.Id("alertButton"));
        private IWebElement TimerAlertButton => Driver.FindElement(By.Id("timerAlertButton"));
        private IWebElement ConfirmAlertButtonButton => Driver.FindElement(By.Id("confirmButton"));
        private IWebElement PromptAlertButton => Driver.FindElement(By.Id("promtButton"));

       *//* public void ClickOnEveryAlert(AlertsObject alertFrameObject)
        {
            clickOnAlertOk();
            alertWithDelay();
            alertWithConfirm(alertFrameObject);
            alertWithText(alertFrameObject);
        }

        public void clickOnAlertOk()
        {
            Helpers.ClickOnElement(AlertButton);
            AlertHelper.AlertOk();
        }

        public void alertWithDelay()
        {
            Helpers.ClickOnElement(TimerAlertButton);
            AlertHelper.AlertWithDelay();
        }

        public void alertWithConfirm(AlertsObject alertFrameObject)
        {
            Helpers.ClickOnElement(ConfirmAlertButtonButton);
            AlertHelper.AlertWithConfirmOrCancel(alertFrameObject.AlertOption);
        }

        public void alertWithText(AlertsObject alertFrameObject)
        {
            Helpers.ClickOnElement(PromptAlertButton);
            AlertHelper.AlertWithPrompt(alertFrameObject.AlertInput);

        }*/


        public void ClickOnEveryAlertJS(AlertsObject alertFrameObject)
        {
            clickOnAlertOkJS();
            alertWithDelayJS();
            alertWithConfirmJS(alertFrameObject);
            alertWithTextJS(alertFrameObject);
        }

        public void clickOnAlertOkJS()
        {
            Helpers.ClickWithJS("alertButton");
            AlertHelper.AlertOk();
        }

        public void alertWithDelayJS()
        {
            Helpers.ClickWithJS("timerAlertButton");
            AlertHelper.AlertWithDelay();
        }

        public void alertWithConfirmJS(AlertsObject alertFrameObject)
        {
            Helpers.ClickWithJS("confirmButton");
            AlertHelper.AlertWithConfirmOrCancel(alertFrameObject.AlertOption);
        }

        public void alertWithTextJS(AlertsObject alertFrameObject)
        {
            Helpers.ClickWithJS("promtButton");
            AlertHelper.AlertWithPrompt(alertFrameObject.AlertInput);

        }


    }
}
