using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace EbayTests
{
    public class EbayMainPage : BasePage<EbayMainPage>  
    {
        private readonly string url = "https://www.ebay.com/";
        public IWebElement GetFirstItemTitle() { return driver.FindElement(By.XPath("//li[@data-gr4='1']/descendant::span[@role='heading']")); }
        private IWebElement GetFirstItemShipping() { return driver.FindElement(By.XPath("//li[@data-gr4='1']/descendant::span[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'shipping')]")); }
        public IWebElement GetFirstItemPrice() { return driver.FindElement(By.XPath("//li[@data-gr4='1']/descendant::span[@class='s-item__price']")); }
        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void AssertFirstItemShippingIsVisible()
        {
            Assert.IsTrue(GetFirstItemShipping().Displayed);
        }

        public void AssertFirstItemPriceIsVisible()
        {
            Assert.IsTrue(GetFirstItemPrice().Displayed);
        }

        public void ClickOnFirstItem()
        {
            driver.FindElement(By.XPath("//li[@data-gr4='1']/div/div[@class='s-item__image-section']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

    }
}
