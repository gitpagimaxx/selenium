﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("ChromeDriver")]
    public class AoEfetuarLogin
    {
        private readonly IWebDriver _driver;
        private readonly RegistroPageObject page;

        public AoEfetuarLogin(TestFixtures driver)
        {
            _driver = driver.Driver;
            page = new RegistroPageObject(_driver);
        }

        [Fact]
        public void AoEfetuarLoginValido()
        {
            page.Login.VisitarLogin();

            page.Login.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "123");
            page.Login.SubmeterLogin();

            Assert.Contains("Minhas Ofertas", _driver.PageSource);
        }

        [Fact]
        public void AoEfetuarLoginInvalido()
        {
            page.Login.VisitarLogin();

            page.Login.PreencherFormularioLogin(login: "diego@pagimaxx.com", password: "");
            page.Login.SubmeterLogin();

            Assert.Contains("Minhas Ofertas", _driver.PageSource);
        }
    }
}