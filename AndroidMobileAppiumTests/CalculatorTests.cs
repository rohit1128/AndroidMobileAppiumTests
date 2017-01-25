using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium; /* Appium is based on Selenium, we need to include it */
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.IO;

namespace AndroidMobileAppiumTests
{
    [TestClass]
    public class CalculatorTests
    {
        private RemoteWebDriver driver;

        private static Uri testServerAddress = new Uri("http:127.0.01:4723/wd/hub"); // If Appium is running locally
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180); /* Change this to a more reasonable value */
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);

        [TestInitialize]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "H30-U10");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "4.3");
            capabilities.SetCapability("appPackage", "com.android.calculator2");
            capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");

           

            driver = new RemoteWebDriver(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }


        [TestMethod]
        public void TestAdditionCalculator()
        { 
            // Click on DELETE/CLR button to clear result text box before running test.
            driver.FindElement(By.XPath("//android.widget.Button")).Click();

            var two = driver.FindElement(By.Name("2"));
            two.Click();
            var plus = driver.FindElement(By.Name("+"));
            plus.Click();
            var four = driver.FindElement(By.Name("4"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("="));
            equalTo.Click();

            var results = driver.FindElement(By.ClassName("android.widget.EditText"));

            Assert.AreEqual("6", results.Text, "The actual value did not match expected result of 6");
        }


        [TestMethod]
        public void TestSubtractionCalculator()
        {
            // Click on DELETE/CLR button to clear result text box before running test.
            driver.FindElement(By.XPath("//android.widget.Button")).Click();

            var two = driver.FindElement(By.Name("5"));
            two.Click();
            var plus = driver.FindElement(By.Name("-"));
            plus.Click();
            var four = driver.FindElement(By.Name("1"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("="));
            equalTo.Click();

            var results = driver.FindElement(By.ClassName("android.widget.EditText"));

            Assert.AreEqual("4", results.Text, "The actual value did not match expected result of 4");
        }

        [TestMethod]
        public void TestMultiplicationCalculator()
        {
            // Click on DELETE/CLR button to clear result text box before running test.
            driver.FindElement(By.XPath("//android.widget.Button")).Click();

            var two = driver.FindElement(By.Name("5"));
            two.Click();
            var plus = driver.FindElement(By.Name("x"));
            plus.Click();
            var four = driver.FindElement(By.Name("2"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("="));
            equalTo.Click();

            var results = driver.FindElement(By.ClassName("android.widget.EditText"));

            Assert.AreEqual("10", results.Text, "The actual value did not match expected result of 10");
        }

        [TestMethod]
        public void TestDivisionCalculator()
        {
            // Click on DELETE/CLR button to clear result text box before running test.
            driver.FindElement(By.XPath("//android.widget.Button")).Click();

            var two = driver.FindElement(By.Name("5"));
            two.Click();
            var plus = driver.FindElement(By.Name("÷"));
            plus.Click();
            var four = driver.FindElement(By.Name("2"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("="));
            equalTo.Click();

            var results = driver.FindElement(By.ClassName("android.widget.EditText"));

            Assert.AreEqual("2.5", results.Text, "The actual value did not match expected result of 2.5");
        }
    }
}
