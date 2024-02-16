using System.Globalization;
using NUnit.Framework;

namespace EbayTests
{
    public class EbayTests : BaseTest
    {
        protected readonly string quantity = "2";
        protected readonly string productName = "Monopoly";
        protected readonly string shoppingCartPageUrl = "https://cart.payments.ebay.com/";

        [SetUp]
        public void TestsSetUp()
        {
            EbayMainPage.GetInstance().Navigate();
            EbayMainPage.GetInstance().SelectCategory("Toys & Hobbies");
            EbayMainPage.GetInstance().SearchForProduct("monopoly Wonder-fur");
        }

        [Test]
        public void AddProductToCartAndAssertPriceTest()
        {
            EbayMainPage.GetInstance().AssertItemTitle(productName, EbayMainPage.GetInstance().GetFirstItemTitle());
            EbayMainPage.GetInstance().AssertFirstItemPriceIsVisible();
            EbayMainPage.GetInstance().AssertFirstItemShippingIsVisible();
            string expectedPrice = EbayMainPage.GetInstance().GetFirstItemPrice().Text;
            decimal convertedExpectedPrice = decimal.Parse(expectedPrice.Substring(1), CultureInfo.InvariantCulture);
            EbayMainPage.GetInstance().ClickOnFirstItem();

            ProductPage.GetInstance().AssertItemTitle(productName, ProductPage.GetInstance().GetProductTitle());
            ProductPage.GetInstance().AssertPriceIsTheSame(expectedPrice);
            ProductPage.GetInstance().ClickShippingAndPaymentsTab();
            ProductPage.GetInstance().AssertSelectedValueFromDropDown(ProductPage.GetInstance().GetSelectedCountry(), "34");
            ProductPage.GetInstance().SetQuantityAndAddToCart(quantity);

            ShoppingCartPage.GetInstance().WaitUrlToLoad(shoppingCartPageUrl);
            ShoppingCartPage.GetInstance().AssertSelectedValueFromDropDown(ShoppingCartPage.GetInstance().GetQuantityDropDown(), quantity);
            ShoppingCartPage.GetInstance().AssertTotalPriceIsCorrect((convertedExpectedPrice * int.Parse(quantity)).ToString());
        }

    }
}