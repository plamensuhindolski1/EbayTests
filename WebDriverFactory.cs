using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EbayTests
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;

        public static void StartWebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public static void QuitWebDriver()
        {
            
            driver.Quit();
        }

        public static IWebDriver GetBrowser()
        {
            if (driver == null)
            {
                throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
            }
            return driver;
        }
    }
}
