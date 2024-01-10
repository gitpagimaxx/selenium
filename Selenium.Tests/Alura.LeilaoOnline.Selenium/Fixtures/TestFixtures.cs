using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixtures : IDisposable
    {
        public IWebDriver Driver { get; set; }

        // setup
        public TestFixtures()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        // teardown
        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}