using EscreveCheque;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EscreveChequeTest
{
    [TestClass]
    public class UnitTest1
    {
        ConversorNumero conversorN = new ConversorNumero();
        [TestMethod]
        public void DeverRetornarCentavos()
        {
            double centavo = 0.69;
            Assert.AreEqual("SESSENTA E NOVE CENTAVOS DE REAL", conversorN.EscreverExtenso(centavo));
        }
        [TestMethod]
        public void DeverRetornarValorMaiorQueOSuportado()
        {
            double valorMaior = 10000000000000000000;
            Assert.AreEqual("Valor não suportado pelo sistema.", conversorN.EscreverExtenso(valorMaior));
        }
        [TestMethod]
        public void DeverRetornarValorForaDoSuportadoNumeroNegativo()
        {
            double valorMaior = -96100;
            Assert.AreEqual("Valor não suportado pelo sistema.", conversorN.EscreverExtenso(valorMaior));
        }
        [TestMethod]
        public void DeverRetornarValorInformadoNAOConvertido()
        {
            string valorComLetras = "123.n";
            Assert.AreEqual(-1, conversorN.validaStringNumero(valorComLetras));
        }
        [TestMethod]
        public void DeverRetornarValorInformadoConvertido()
        {
            string valorComLetras = "123.6";
            Assert.AreEqual(123,6, conversorN.validaStringNumero(valorComLetras));
        }
    }
}
