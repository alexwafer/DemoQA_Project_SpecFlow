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
