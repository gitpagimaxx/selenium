using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;


namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoCriarLeilao
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;
        private readonly DashboardInteressadaPO dashboardInteressadaPO;
        private readonly NovoLeilaoPO novoLeilaoPO;

        public AoCriarLeilao(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
            novoLeilaoPO = new NovoLeilaoPO(_driver);
        }

        [Fact]
        public void CriarUmNovoLeilao()
        {
            // arrange
            page.Login.VisitarLogin();
            page.Login.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "123");
            page.Login.SubmeterLogin();

            novoLeilaoPO.IrParaTelaNovoLeilao();
            novoLeilaoPO.PreencherFormularioCadastroLeilao("tit", "desc", 1000, DateTime.Now, DateTime.Now.AddDays(20), "Arte e Pintura", "C:\\_dev\\gitpagimaxx\\selenium\\profile-pic.png");

            // act
            novoLeilaoPO.SubmeteFormulario();

            // assert
            Assert.Contains("Leilões cadastrados", _driver.PageSource);
        }
    }
}