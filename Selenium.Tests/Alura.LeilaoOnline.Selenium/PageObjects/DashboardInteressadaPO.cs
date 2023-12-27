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
        }

        public void IrParaTela(string tela)
            => driver.Navigate().GoToUrl($"{_urlBase}{tela}");

        public void PesquisarLeiloes(List<string> categorias)
        {
            // capturar o elemento wrapper
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            Thread.Sleep(2000);

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();

            // desmarcar as opções
            opcoes.ForEach(o => { o.Click(); });

            Thread.Sleep(2000);

            // procurar as categorias enviadas por parametro
            categorias.ForEach(c => 
            { 
                opcoes.Where(o => 
                    o.Text.Contains(c))
                    .ToList()
                    .ForEach(selecionar => 
                    {
                        selecionar.Click(); 
                    }
                ); 
            });

            Thread.Sleep(2000);

            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);

            Thread.Sleep(8000);
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