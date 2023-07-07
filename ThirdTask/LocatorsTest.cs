using OpenQA.Selenium.Chrome;

namespace ThirdTask
{
    [Author("Ludmila")]
    [TestFixture]
    public class LocatorsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver()
            {
                Url = "https://www.saucedemo.com/"
            };
        }

        [Test]
        public void LoginForm_ExistingLoginAndPassword_ShowsShopPage_AllLocatorsInXpath()
        {
            string TitleOfNewPage = "Products";

            IWebElement loginTxt = driver.FindElement(By.XPath("//input[@name='user-name']"));
            IWebElement passwordTxt = driver.FindElement(By.XPath("//input[@name='password']"));

            loginTxt.SendKeys("standard_user");
            passwordTxt.SendKeys("secret_sauce");
            loginTxt.SendKeys(Keys.Enter);

            IWebElement newPageTitle = driver.FindElement(By.XPath("//span[@class='title']"));

            Assert.That(newPageTitle.Text == TitleOfNewPage);
        }

        [Test]
        public void LoginForm_ExistingLoginAndPassword_ShowsShopPage_UsingDifferentLocators()
        {
            string TitleOfNewPage = "Products";

            IWebElement loginTxt = driver.FindElement(By.CssSelector("#user-name"));
            IWebElement passwordTxt = driver.FindElement(By.Name("password"));

            loginTxt.SendKeys("standard_user");
            passwordTxt.SendKeys("secret_sauce");
            loginTxt.SendKeys(Keys.Enter);

            IWebElement newPageTitle = driver.FindElement(By.XPath("//span[@class='title']"));

            Assert.That(newPageTitle.Text == TitleOfNewPage);
        }

        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            driver.Quit();
        }
    }
}