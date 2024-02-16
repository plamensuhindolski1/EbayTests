using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EbayTests
{
    public abstract class BasePage<TPage> where TPage : new()
    {
        protected IWebDriver driver;
        protected readonly WebDriverWait wait;
        private static Lazy<TPage> lazyPage = new Lazy<TPage>(() => new TPage());
        private IWebElement GetSearchField() { return driver.FindElement(By.CssSelector("#gh-ac")); }
        private IWebElement GetSearchButton() { return driver.FindElement(By.CssSelector("#gh-btn")); }
        private SelectElement GetCategoryButton() { return new SelectElement(driver.FindElement(By.CssSelector("#gh-cat"))); }

        protected BasePage()
        {
            driver = WebDriverFactory.GetBrowser() ?? throw new ArgumentNullException("The wrapped IWebDriver instance is not initialized.");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public static TPage GetInstance()
        {
            return lazyPage.Value;
        }

        public static void Dispose()
        {
            lazyPage = new Lazy<TPage>(() => new TPage());
        }

        public void SearchForProduct(string productName)
        {
            GetSearchField().SendKeys(productName);
            GetSearchButton().Click();
        }

        public void SelectCategory(string category)
        {
            GetCategoryButton().SelectByText(category);
        }

        public void AssertItemTitle(string productName, IWebElement product)
        {
            wait.Until((d) => product.Displayed);
            Assert.IsTrue(product.Text.Contains(productName));
        }

        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void WaitUrlToLoad(string expectedUrl)
        {
            wait.Until(ExpectedConditions.UrlToBe(expectedUrl));
        }

        public void AssertSelectedValueFromDropDown(SelectElement element, string expectedValue)
        {
            var selectedValue = element.SelectedOption.GetAttribute("value");
            Assert.AreEqual(expectedValue, selectedValue);
        }
    }
}
