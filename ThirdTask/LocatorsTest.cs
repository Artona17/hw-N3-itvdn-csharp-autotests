using OpenQA.Selenium.Chrome;

namespace ThirdTask
{
    [Author("Ludmila")]
    [TestFixture]
    public class LocatorsTests
    {

        /// <summary>
        /// Setting up a Selenium Chrome WebDriver.
        /// </summary>
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver()
            {
                Url = "https://www.saucedemo.com/"
            };
        }

        /// <summary>
        /// Test that checks that if we are writing actual username and password we have successfully logged in.
        /// Test is written with XPath locators only.
        /// </summary>
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

        /// <summary>
        /// Test that checks that if we are writing actual username and password we have successfully logged in.
        /// Test is written with different types of locators - CSSSelector, XPath and Name.
        /// </summary>
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

        /// <summary>
        /// Quitting our Chrome driver.
        /// </summary>
        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            driver.Quit();
        }
    }
}