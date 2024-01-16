using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By byInputLogin;
        private By byInputEmail;
        private By byInputPassword;
        private By byBotaoLogin;
        private By bySpanErroNome;
        private By bySpanErroEmail;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public LoginPO VisitarLogin()
        {
            driver.Navigate().GoToUrl($"{_urlBase}/Autenticacao/Login");
            return this;
        }

        public LoginPO SubmeterLogin()
        {
            driver.FindElement(byBotaoLogin).Click();
            return this;
        }

        public LoginPO PreencherFormularioLogin(string login, string password)
        {
            return InformarLogin(login)
                .InformarPassword(password);
        }

        public string MensagemErroNome
            => driver.FindElement(bySpanErroNome).Text;

        public string MensagemErroEmail
            => driver.FindElement(bySpanErroEmail).Text;

        public LoginPO InformarLogin(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarPassword(string password)
        {
            driver.FindElement(byInputPassword).SendKeys(password);
            return this;
        }

        public void ExecutarLogin(string login, string password)
        {
            VisitarLogin()
                .PreencherFormularioLogin(login, password)
                .SubmeterLogin();
        }
    }
}