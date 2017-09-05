using Appium.Equip;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.Equip;
using System;
using System.Reflection;

namespace OpenQA.Selenium.Appium
{
    public static class AppiumDriverExtension
    {
        public static bool WaitUntilVisible(this AppiumDriver<AppiumWebElement> appiumDriver, ByAccessibilityId locator, 
            int maxWaitTimeInSeconds = AppiumGlobalConstants.MaxWaitTimeInSeconds)
        {
            return appiumDriver.WaitUntil(ExpectedConditions.ElementIsVisible(locator), maxWaitTimeInSeconds);
        }

        public static bool WaitUntil<T>(this AppiumDriver<AppiumWebElement> appiumDriver, 
            Func<IWebDriver, T> condition, int maxWaitTimeInSeconds = GlobalConstants.MaxWaitTimeInSeconds)
        {
            var wait = new AppiumDriverWait(appiumDriver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            try
            {
                wait.Until(condition);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (TargetInvocationException)
            {
                return false;
            }
            return true;
        }

    }
}
