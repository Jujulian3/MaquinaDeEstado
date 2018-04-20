using MaquinaDeEstado.Programa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MaquinaDeEstado.Teste
{
    [TestClass]
    public class TestesDeMaquina
    {
        private Maquina maquina;
        private string palavra;
        private string resultadoObitido;
        private string resultadoEsperado;

        private IDictionary<string, string> resultadoPossivel = new Dictionary<string, string>()
        {
            {"POSITIVO", "Esta string é aceita"},
            {"NEGATIVO", "Esta string NÃO é aceita" }
        };

        [TestMethod]
        public void Processar_ComCaracteres_AlfanumericosEunderline()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComCaracteres_AlfanumericosEoutros()
        {
            maquina = new Maquina();
            palavra = "E55@String_eh1_Str!ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComCaracteres_AlfanumericosEespacoEmBranco()
        {
            maquina = new Maquina();
            palavra = "E55aString eh1_Str1ng DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComInicio_Alfabetico()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComInicio_Numerico()
        {
            maquina = new Maquina();
            palavra = "355aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComInicio_Underline()
        {
            maquina = new Maquina();
            palavra = "_E55aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComInicio_EspacoEmBranco()
        {
            maquina = new Maquina();
            palavra = " E55aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComStringVazia()
        {
            maquina = new Maquina();
            palavra = "";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComFinal_Alfabetico()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComFinal_Numerico()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3ste5";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComFinal_Underline()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes_";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["POSITIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComFinal_EspacoEmBranco()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes ";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }

        [TestMethod]
        public void Processar_ComFinal_OutrosCaracteres()
        {
            maquina = new Maquina();
            palavra = "E55aString_eh1_Str1ng_DeT3stes!";

            resultadoObitido = maquina.Verificar(palavra);
            resultadoEsperado = resultadoPossivel["NEGATIVO"];

            Assert.AreEqual(resultadoEsperado, resultadoObitido);
        }
    }
}
