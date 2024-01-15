using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoEfetuarLogout
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;
        private readonly DashboardInteressadaPO dashboardInteressadaPO;

        public AoEfetuarLogout(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
            dashboardInteressadaPO = new DashboardInteressadaPO(_driver);
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaAHomeNaoLogada()
        {
            // arrange
            page.VisitarLogin();
            page.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "123");
            page.SubmeterLogin();

            // act
            dashboardInteressadaPO.Menu.EfeturarLogout();    

            // assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}