using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.WebAuthn;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void IrParaTela(string tela)
            => driver.Navigate().GoToUrl($"{_urlBase}{tela}");

        public void PesquisarLeiloes(List<string> categorias, string termo, bool andamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();
            Thread.Sleep(2000);
            categorias.ForEach(c => { select.SelectByText(c); });
            Thread.Sleep(2000);
            driver.FindElement(byInputTermo).SendKeys(termo);
            Thread.Sleep(2000);
            if (andamento)
                driver.FindElement(byInputAndamento).Click();

            Thread.Sleep(2000);

            driver.FindElement(byBotaoPesquisar).Click();
        }

        public void EfeturarLogout()
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(byMeuPerfilLink))
                .MoveToElement(driver.FindElement(byLogoutLink))
                .Click()
                .Build()
                .Perform();
        }
    }
}