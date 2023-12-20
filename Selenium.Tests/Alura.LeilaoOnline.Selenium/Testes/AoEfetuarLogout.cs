using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoEfetuarLogout
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;

        public AoEfetuarLogout(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
        }

        [Fact]
        public void AoEfetuarLogoutValido()
        {
            page.VisitarLogin();

            page.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "123");
            page.SubmeterLogin();

            Assert.Contains("Minhas Ofertas", _driver.PageSource);
        }
    }
}