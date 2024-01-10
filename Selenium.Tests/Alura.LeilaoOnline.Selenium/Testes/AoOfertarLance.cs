using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoOfertarLance
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;
        private readonly DetalheLeilaoPO detalheLeilao;

        public AoOfertarLance(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
            detalheLeilao = new DetalheLeilaoPO(_driver);
        }

        [Fact]
        public void DadoLoginRealizadoDeveAtualizarLanceAtual()
        {
            page.VisitarLogin();

            page.PreencherFormularioLogin(login: "admin@example.org", password: "123");
            page.SubmeterLogin();

            detalheLeilao.Visitar(1);

            // act
            detalheLeilao.OfertarLance(valor: 300);

            // assert
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));

            bool iguais = wait.Until(drv => detalheLeilao.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}