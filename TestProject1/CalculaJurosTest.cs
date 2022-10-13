using API_Calculo.Business;
using API_Calculo.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class CalculaJurosTest
    {

        public static IEnumerable<object[]> GetInterestRateCalculation_InputData =>
            new[] {

                new object[] {0.01M , 100.00m, 0,        "100,00" },
                new object[] {0.01M , 100.00m, 5,        "105,10" },
                new object[] {0.01M , 100.001m, 5,        "105,10" },
                new object[] {0.01M , 100.009m, 5,        "105,10" },
                new object[] {0.00M , 100.000m, 1,        "100,00" },
                new object[] {0.00M , 100.000m, 0,        "100,00" },
                new object[] {0.10M , 1000.00M, 144,      "913159544,47" },

        };

        [TestMethod]
        [DynamicData(nameof(GetInterestRateCalculation_InputData))]
        public void GetInterestRateCalculation(decimal taxaJuros, decimal valorInicial, int messes, string resultado)
        {
            Juros juros = new Juros(valorInicial, messes, taxaJuros);

            Assert.AreEqual(resultado, juros.valorInicialCorrigidoComjuros);

        }
    }

}
