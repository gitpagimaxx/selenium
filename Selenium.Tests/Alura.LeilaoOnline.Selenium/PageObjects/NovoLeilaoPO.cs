using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
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
            //driver.FindElement(selectCategoria).SendKeys(categoria);
            driver.FindElement(fileArquivoImagem).SendKeys(arquivoImagem);
        }

        public void AoCadastrarUmNovoLeilao()
        {
            
        }
    }
}