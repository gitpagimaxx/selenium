using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoFiltrarLeiloes
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject _page;
        private readonly NovoLeilaoPO _novoLeilaoPO;
        private readonly DashboardInteressadaPO _dashboardInteressadaPO;

        public AoFiltrarLeiloes(
            TestFixtures fixtures)
        {
            _driver = fixtures.Driver;
            _page = new RegistroPageObject(_driver);
            _novoLeilaoPO = new NovoLeilaoPO(_driver);
            _dashboardInteressadaPO = new DashboardInteressadaPO(_driver);
        }

        [Fact]
        public void MostrarPainelResultado()
        {
            _page.Login.ExecutarLogin(login: "fulano@example.org", password: "123");

            _page.Login.VisitarLogin()
                .InformarLogin("fulano@example.org")
                .InformarPassword(password: "123")
                .SubmeterLogin();

            _dashboardInteressadaPO.IrParaTela("/Interessadas");

            _dashboardInteressadaPO.Filtro.PesquisarLeiloes(new List<string> { "Automóveis", "Coleções" }, "", true);

            //assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);
        }
    }
}