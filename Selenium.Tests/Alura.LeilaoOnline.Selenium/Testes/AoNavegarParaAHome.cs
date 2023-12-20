using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoNavegarParaAHome
    {
        private readonly IWebDriver _driver;
        private readonly string _url = TestHelper.UrlBase;

        public AoNavegarParaAHome(TestFixtures driver)
        {
            _driver = driver.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // arrange

            // act
            _driver.Navigate().GoToUrl(_url);

            // assert
            Assert.Contains("Leilões", _driver.Title);
        }

        //TearDown



        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // arrange

            // act
            _driver.Navigate().GoToUrl(_url);

            // assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
