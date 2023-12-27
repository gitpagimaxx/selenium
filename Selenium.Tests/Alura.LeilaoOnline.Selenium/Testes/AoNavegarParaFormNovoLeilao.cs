using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject _page;
        private readonly NovoLeilaoPO _novoLeilaoPO;

        public AoNavegarParaFormNovoLeilao(TestFixtures fixture)
        {
            _driver = fixture.Driver;
            _page = new RegistroPageObject(_driver);
            _novoLeilaoPO = new NovoLeilaoPO(_driver);
        }

        [Fact]
        public void DadoLoginDeveMostrarTresCategprias()
        {
            _page.VisitarLogin();
            _page.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "123");
            _page.SubmeterLogin();

            _novoLeilaoPO.IrParaTelaNovoLeilao();

            // assert
            Assert.Equal(3, _novoLeilaoPO.Categorias.Count());
        }
    }
}