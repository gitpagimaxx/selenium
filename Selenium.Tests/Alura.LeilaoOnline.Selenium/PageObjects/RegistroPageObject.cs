using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private readonly string _urlBase = TestHelper.UrlBase;
        
        private IWebDriver driver;
        public LoginPO Login { get; }
        private By byInputNome;
        private By byInputEmail;
        private By byInputPassword;
        private By byInputConfirmPassword;
        private By byBotaoRegistro;
        

        public RegistroPageObject(IWebDriver driver)
        {
            this.driver = driver;
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");            
            Login = new LoginPO(driver);
        }

        public void Visitar()
            => driver.Navigate().GoToUrl(_urlBase);


        public void SubmeteFormularioRegistro()
            => driver.FindElement(byBotaoRegistro).Click();

        public void PreencherFormulario(string nome, string email, string password, string confirmPassword)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);
        }
    }
}