using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
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