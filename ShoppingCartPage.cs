using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EbayTests
{
    public class ShoppingCartPage : BasePage<ShoppingCartPage>
    {
        public SelectElement GetQuantityDropDown() { return new SelectElement(driver.FindElement(By.XPath("//div[@class='grid-item-quantity']/descendant::select"))); }
        private IWebElement GetTotalCostLabel() { return driver.FindElement(By.CssSelector("div[class^='item-price'] > span > span > span")); }

        public void AssertTotalPriceIsCorrect(string expectedTotalPrice)
        {
            string totalCost = GetTotalCostLabel().Text.Substring(4).Replace('.', ',');
            Assert.AreEqual(expectedTotalPrice, totalCost);
        }

    }
}
