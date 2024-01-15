using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
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