using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.DOM;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private readonly string _urlBase = TestHelper.UrlBase;

        private IWebDriver driver;
        private By inputTitulo;
        private By inputDescricao;
        private By inputValorInicial;
        private By inputInicioPregao;
        private By inputTerminoPregao;
        private By selectCategoria;
        private By fileArquivoImagem;
        private By selectCategoriaClick;
        private By btnSalvar;

        public NovoLeilaoPO(IWebDriver _driver)
        {
            driver = _driver;
            inputTitulo = By.Id("Titulo");
            inputDescricao = By.Id("Descricao");
            inputValorInicial = By.Id("ValorInicial");
            inputInicioPregao = By.Id("InicioPregao");
            inputTerminoPregao = By.Id("TerminoPregao");
            selectCategoria = By.Id("Categoria");
            fileArquivoImagem = By.Id("ArquivoImagem");
            selectCategoriaClick = By.XPath("/html/body/form/div/div[1]/div/div[1]/div[3]/div[1]/div/input");
            btnSalvar = By.CssSelector("button[type=submit]");
        }

        public void IrParaTelaNovoLeilao()
            => driver.Navigate().GoToUrl($"{_urlBase}/Leiloes/novo");

        public void PreencherFormularioCadastroLeilao(
            string titulo, string descricao, 
            double valorInicial, DateTime inicioPregao,
            DateTime terminoPregao, string categoria, string arquivoImagem)
        {
            driver.FindElement(inputTitulo).SendKeys(titulo);
            driver.FindElement(inputDescricao).SendKeys(descricao);
            driver.FindElement(inputValorInicial).SendKeys(valorInicial.ToString());
            driver.FindElement(inputInicioPregao).SendKeys(inicioPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(inputTerminoPregao).SendKeys(terminoPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(fileArquivoImagem).SendKeys(arquivoImagem);

            var elementoCategoria = new SelectElement(driver.FindElement(selectCategoria));
            var selecionado = elementoCategoria.SelectedOption;

            driver.FindElement(selectCategoria).SendKeys(elementoCategoria.SelectedOption.Selected.ToString());
        }

        public void AoCadastrarUmNovoLeilao()
        {
            
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(btnSalvar).Click();
        }

        public IEnumerable<string> Categorias
        {
            get 
            {
                var elementoCategoria = new SelectElement(driver.FindElement(selectCategoria));
                //elementoCategoria.FindElements(By.TagName("option"));
                var selecionado = elementoCategoria.SelectedOption;
                return elementoCategoria.Options.Select(o => o.Text);
            }
        }

        public IEnumerable<string> CategoriaSelecionada
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(selectCategoria));
                //elementoCategoria.FindElements(By.TagName("option"));
                var selecionado = elementoCategoria.SelectedOption;
                return elementoCategoria.Options.Select(o => o.Text);
            }
        }
    }
}