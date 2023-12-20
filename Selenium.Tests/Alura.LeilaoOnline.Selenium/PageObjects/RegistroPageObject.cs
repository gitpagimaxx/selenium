using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private readonly string _urlBase = TestHelper.UrlBase;
        
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputLogin;
        private By byInputNome;
        private By byInputEmail;
        private By byInputPassword;
        private By byInputConfirmPassword;
        private By byBotaoRegistro;
        private By byBotaoLogin;
        private By bySpanErroNome;
        private By bySpanErroEmail;
        
        public string MensagemErroNome 
            => driver.FindElement(bySpanErroNome).Text;

        public string MensagemErroEmail 
            => driver.FindElement(bySpanErroEmail).Text;

        public RegistroPageObject(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputLogin = By.Id("Login");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            byBotaoLogin = By.Id("btnLogin");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void Visitar()
            => driver.Navigate().GoToUrl(_urlBase);

        public void VisitarLogin()
            => driver.Navigate().GoToUrl($"{_urlBase}/Autenticacao/Login");

        public void SubmeteFormularioRegistro()
            => driver.FindElement(byBotaoRegistro).Click();

        public void PreencherFormulario(string nome, string email, string password, string confirmPassword)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);
        }

        public void SubmeterLogin() 
            => driver.FindElement(byBotaoLogin).Click();

        public void PreencherFormularioLogin(string login, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputPassword).SendKeys(password);
        }
    }
}