using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> options;

        public SelectMaterialize(IWebDriver _driver, By locatorSelectWrapper)
        {
            driver = _driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            options = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options 
            => options;

        private void OpenWrapper()
            => selectWrapper.Click();

        private void LoseFocus()
        {
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            options.ToList().ForEach(o => { o.Click(); });
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            options.Where(o =>
                    o.Text.Contains(option))
                    .ToList()
                    .ForEach(selecionar =>
                    {
                        selecionar.Click();
                    }
                );
            LoseFocus();
        }
    }
}