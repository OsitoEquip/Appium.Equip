using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Equip.Tests
{
    [TestFixture]
    public class UnitTests
    {
        public WindowsDriver<AppiumWebElement> driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "WindowsPC");
            capabilities.SetCapability("platformName", "Windows");
            capabilities.SetCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            driver = new WindowsDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/"), capabilities,new TimeSpan(0,0,10));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (driver != null)
                driver.CloseApp();
        }

        [TestCase("num2Button",true)]
        [TestCase("nevergonnaget",false)]
        public void Test(string selector, bool visible)
        {
            var locator = new ByAccessibilityId(selector);
            Assert.AreEqual(visible, driver.WaitUntilVisible(locator));
        }
    }
}
