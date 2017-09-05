using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;

namespace Appium.Equip
{
    public class AppiumExpectedCondition
    {
        public static Func<AppiumDriver<AppiumWebElement>, AppiumWebElement> ElementIsVisible(ByAccessibilityId locator)
        {
            return (searchContext) =>
            {
                try
                {
                    return ElementIfVisible(searchContext.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private static AppiumWebElement ElementIfVisible(AppiumWebElement element)
        {
            return element.Displayed ? element : null;
        }
    }
}
