using Appium.Equip.SauceLabs;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Selenium.WebDriver.Equip.SauceLabs;
using System;
using System.Reflection;

namespace Appium.Equip.Tests
{
    public class RitalinTests
    {
        public AndroidDriver<AppiumWebElement> driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //SauceLabsProxy.UploadAndriodPackage();
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("appiumVersion", "1.6.4");
            capabilities.SetCapability("deviceName", "Android Emulator");
            capabilities.SetCapability("deviceOrientation", "portrait");
           // capabilities.SetCapability("browserName", "");
            capabilities.SetCapability("platformVersion", "6.0");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("app", "http://www.ositoproperties.com/Ritalin-Signed.apk");
            capabilities.SetCapability("build", Assembly.GetAssembly(typeof(RitalinTests)).GetName().Version.ToString());
            // add these two enviorment variables and there values to use Sauce Labs
            capabilities.SetCapability("username", SauceDriverKeys.SAUCELABS_USERNAME);
            capabilities.SetCapability("accessKey", SauceDriverKeys.SAUCELABS_ACCESSKEY);
            capabilities.SetCapability("name", "testName");
            driver = new AndroidDriver<AppiumWebElement>(new Uri("https://us1.appium.testobject.com/wd/hub"), capabilities, new TimeSpan(0, 0, 60));
            //capabilities.SetCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            //driver = new WindowsDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/"), capabilities, new TimeSpan(0, 0, 10));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome == ResultState.Success;

            if (driver != null)
                driver.CloseApp();
            CloseCurrentDriver(outcome);
        }

        [TestCase("AboutTab", true)]
        [TestCase("nevergonnaget", false)]
        [TestCase("BrowseTab", true)]
        public void Test(string selector, bool visible)
        {
            var locator = new ByAccessibilityId(selector);
            Assert.AreEqual(visible, driver.WaitUntilVisible(locator));
        }

        public void CloseCurrentDriver(bool? outcome = null)
        {
            if (outcome != null)
                UpDateJob(Boolean.Parse(outcome.ToString()));
            if (driver != null) driver.Quit();
            driver = null;
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
