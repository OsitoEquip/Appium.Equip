using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Appium.Equip
{
    public class AppiumDriverWait : DefaultWait<AppiumDriver<AppiumWebElement>>
    {
        public AppiumDriverWait(AppiumDriver<AppiumWebElement> appiumDriver, TimeSpan timeout)
            : this(new SystemClock(), appiumDriver, timeout, DefaultSleepTimeout)
        {
        }

        public AppiumDriverWait(IClock clock, AppiumDriver<AppiumWebElement> appiumDriver, 
            TimeSpan timeout, TimeSpan sleepInterval)
            : base(appiumDriver, clock)
        {
            this.Timeout = timeout;
            this.PollingInterval = sleepInterval;
            this.IgnoreExceptionTypes(typeof(NotFoundException));
        }

        private static TimeSpan DefaultSleepTimeout
        {
            get { return TimeSpan.FromMilliseconds(500); }
        }
    }
}
