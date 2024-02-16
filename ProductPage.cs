using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EbayTests
{
    public class ProductPage : BasePage<ProductPage>
    {
        public IWebElement GetProductTitle() { return driver.FindElement(By.XPath("//h1/span")); }
        public IWebElement GetProductPrice() { return driver.FindElement(By.XPath("//*[@data-testid='x-price-primary']/span")); }
        private IWebElement GetShippingAndPaymentsButton() { return driver.FindElement(By.CssSelector("#TABS_SPR")); }
        public SelectElement GetSelectedCountry() { return new SelectElement(driver.FindElement(By.CssSelector("#shCountry"))); }
        private IWebElement GetQuantityField() { return driver.FindElement(By.Id("qtyTextBox")); }
        private IWebElement GetAddToCartButton() { return driver.FindElement(By.XPath("//div[@data-testid='x-atc-action']/a")); }

        public void ClickShippingAndPaymentsTab()
        {
            if (!GetShippingAndPaymentsButton().Displayed)
            {
                MoveToElement(GetShippingAndPaymentsButton());
            }
            GetShippingAndPaymentsButton().Click();
        }

        public void SetQuantityAndAddToCart(string quantity)
        {
            if (!GetQuantityField().Displayed)
            {
                MoveToElement(GetQuantityField());
            }
            GetQuantityField().Clear();
            GetQuantityField().SendKeys(quantity);
            GetAddToCartButton().Click();
        }

        public void AssertPriceIsTheSame(string price)
        {
            Assert.AreEqual(price, GetProductPrice().Text.Substring(3));
        }

    }
}
