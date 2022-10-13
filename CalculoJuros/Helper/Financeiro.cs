using System;

namespace API_Calculo.Helper
{
    public static class Financeiro
    {
        public static decimal Truncar2CasasDecimaisSemArrendondamento(decimal valor)
        {
            return Math.Truncate(valor * 100) / 100;
        }

        public static string FormataDecimalParaString(decimal valor)
        {
            return string.Format("{0:0.00}", valor);
        }
    }
}
