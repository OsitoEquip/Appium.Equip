using Appium.Equip;
using Selenium.WebDriver.Equip;

namespace OpenQA.Selenium.Appium
{
    public static class AppiumDriverExtension
    {
        public static bool WaitUntilVisible(this AppiumDriver<AppiumWebElement> appiumDriver, ByAccessibilityId locator, 
            int maxWaitTimeInSeconds = AppiumGlobalConstants.MaxWaitTimeInSeconds)
        {
            return appiumDriver.WaitUntil(ExpectedCondition.ElementIsVisible(locator), maxWaitTimeInSeconds);
        }



    }
}
