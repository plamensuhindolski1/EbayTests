using NUnit.Framework;

namespace EbayTests
{
    public class BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.StartWebDriver();
        }

        [TearDown]
        public void TestCleanUp()
        {
            WebDriverFactory.QuitWebDriver();
            BasePage<EbayMainPage>.Dispose();
            BasePage<ProductPage>.Dispose();
            BasePage<ShoppingCartPage>.Dispose();
        }
    }
}
