using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        public FiltroLeilaoPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Filtro = new FiltroLeilaoPO(driver);
            Menu = new MenuLogadoPO(driver);
        }

        public void IrParaTela(string tela)
            => driver.Navigate().GoToUrl($"{_urlBase}{tela}");
        
    }
}