using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjetoBDD.TestSteps
{
    [Binding]
    public class CadastrarContaTestSteps
    {
        private IWebDriver _driver;

        [Given(@"Acessar a página de cadastro de conta")]
        public void DadoAcessarAPaginaDeCadastroDeConta()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("http://localhost:13951/Contas/Cadastro");
        }

        [Given(@"Informar o nome da conta ""(.*)""")]
        public void DadoInformarONomeDaConta(string nome)
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"nome\"]"));
            element.Clear();
            element.SendKeys(nome);
        }

        [Given(@"Informar o valor da conta ""(.*)""")]
        public void DadoInformarOValorDaConta(int valor)
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"valor\"]"));
            element.Clear();
            element.SendKeys(valor.ToString());
        }

        [Given(@"Selecionar o tipo da conta ""(.*)""")]
        public void DadoSelecionarOTipoDaConta(string tipo)
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"tipo\"]"));
            var select = new SelectElement(element);

            select.SelectByText(tipo);
        }

        [When(@"Solicitar a realização do cadastro da conta")]
        public void QuandoSolicitarARealizacaoDoCadastroDaConta()
        {
            //gravando um screenshot do teste
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile($"c:\\temp\\{Guid.NewGuid()}.png", ScreenshotImageFormat.Png);

            var element = _driver.FindElement(By.XPath("//*[@id=\"btn-cadastro\"]"));
            if (element.Displayed && element.Enabled)
                element.Click();
        }

        [Then(@"Sistema informa que a conta foi cadastrada com sucesso")]
        public void EntaoSistemaInformaQueAContaFoiCadastradaComSucesso()
        {
            var alert = _driver.SwitchTo().Alert();
            Assert.AreEqual(alert.Text, "Dados enviados com sucesso!");

            alert.Accept();

            _driver.Close();
            _driver.Quit();
        }
    }
}
