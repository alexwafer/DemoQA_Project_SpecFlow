using DemoQA_Project_SpecFlow.loggerUtility;
using DemoQA_Project_SpecFlow.PageObject.alertsObject;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.Pages.AlertFramePage
{
    public class AlertFramePage : BasePage
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AlertFramePage(IWebDriver driver) : base(driver)
        { }

        public void ClickOnEveryAlertJS(AlertsObject alertFrameObject)
        {
            clickOnAlertOkJS();
            logger.Info("The user clicks on First Alert");
            alertWithDelayJS();
            logger.Info("The user clicks on Second Alert");
            alertWithConfirmJS(alertFrameObject);
            logger.Info("The user clicks on Third Alert");
            alertWithTextJS(alertFrameObject);
            logger.Info("The user clicks on Fourth Alert");
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
