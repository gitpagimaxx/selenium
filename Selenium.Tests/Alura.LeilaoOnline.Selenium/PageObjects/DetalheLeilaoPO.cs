using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;

        public double LanceAtual
        {
            get
            {
                return double.Parse(driver.FindElement(byLanceAtual).Text, System.Globalization.NumberStyles.Currency);
            }
        }

        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public void Visitar(int id)
            => driver.Navigate().GoToUrl($"{_urlBase}/Home/Detalhes/{id}");

        public void OfertarLance(double valor)
        {
            driver.FindElement(byInputValor).SendKeys(valor.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}