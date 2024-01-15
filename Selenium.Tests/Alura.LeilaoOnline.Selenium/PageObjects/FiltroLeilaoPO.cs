using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeilaoPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        public By byBotaoPesquisar;

        public FiltroLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

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
    }
}