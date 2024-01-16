using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoEfetuarRegistro
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;

        public AoEfetuarRegistro(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            // arrange
            page.Visitar();

            page.PreencherFormulario("Diego Oliveira", "diego@pagimaxx.com", "123", "123");

            // act
            page.SubmeteFormularioRegistro();

            // assert
            Assert.Contains("Obrigado", _driver.PageSource);
        }

        [Fact]
        public void DadoInfoInvalidasDeveFicarNaHome()
        {
            // arrange
            page.Visitar();

            // act
            page.SubmeteFormularioRegistro();

            // assert
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Theory]
        [InlineData("", "diego.oliveira@gmail.com", "123", "123")]
        [InlineData("Diego Oliveira", "diego.oliveira", "123", "123")]
        [InlineData("Diego Oliveira", "diego.oliveira@gmail.com", "123", "1236")]
        [InlineData("Diego Oliveira", "diego.oliveira@gmail.com", "123", "")]
        public void DadoInfoInvalidas(string pNome, string pEmail, string pSenha, string pConfirmaSenha)
        {
            // arrange
            page.Visitar();

            var nome = _driver.FindElement(By.Id("Nome"));
            var email = _driver.FindElement(By.Id("Email"));
            var password = _driver.FindElement(By.Id("Password"));
            var confirmPassword = _driver.FindElement(By.Id("ConfirmPassword"));
            var btnRegistro = _driver.FindElement(By.Id("btnRegistro"));

            nome.SendKeys(pNome);
            email.SendKeys(pEmail);
            password.SendKeys(pSenha);
            confirmPassword.SendKeys(pConfirmaSenha);

            // act
            btnRegistro.Click();

            // assert
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoInfoNomeEmBranco()
        {
            // arrange
            page.Visitar();

            // act
            page.SubmeteFormularioRegistro();

            // assert
            Assert.Equal("The Nome field is required.", page.Login.MensagemErroNome);
        }

        [Fact]
        public void DadoInfoEmailInvalido()
        {
            // arrange
            page.Visitar();

            // act
            page.SubmeteFormularioRegistro();

            // assert
            Assert.Equal("The Endereço de Email field is required.", page.Login.MensagemErroEmail);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagemDeErro()
        {
            // act
            page.Visitar();

            // assert
            var form = _driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}