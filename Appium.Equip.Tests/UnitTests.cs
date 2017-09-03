using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Selenium.WebDriver.Equip.SauceLabs;
using System;

namespace Appium.Equip.Tests
{
    [TestFixture]
    public class UnitTests
    {
        public WindowsDriver<AppiumWebElement> driver;

        [Test]
        public void Test()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("deviceName", "Local");
            capabilities.SetCapability("platformName", "Windows");
            capabilities.SetCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            //capabilities.SetCapability("username", SauceDriverKeys.SAUCELABS_USERNAME);
            //capabilities.SetCapability("accessKey", SauceDriverKeys.SAUCELABS_ACCESSKEY);
            //capabilities.SetCapability("name", "test");

            driver = new WindowsDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"),capabilities, new TimeSpan(0, 0, 10));
            //);new Uri("http://ondemand.saucelabs.com:80/wd/hub"
            driver.CloseApp();
            UpDateJob(true);

        }

        public void UpDateJob(bool outcome)
        {
            var sessionId = (string)((RemoteWebDriver)driver).Capabilities.GetCapability("webdriver.remote.sessionid");
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (outcome ? "passed" : "failed"));
            }
            finally
            {
            }
        }
    }
}
