using API_Calculo.Helper;
using System;

namespace API_Calculo.Business
{
    public class Juros
    {

        private int _messes { get; set; }
        private decimal _valorInicial { get; set; }
        public string valorInicialCorrigidoComjuros {get; private set; }

        private decimal _juros { get; set; }

        public Juros(decimal valorInicial,int messes, decimal juros)
        {
            if (messes < 0 )
            {
                throw new Exception("quantidade de messes deve ser superior a 0");
            }
            if (valorInicial < 0)
            {
                throw new Exception("Valor inicial deve ser superior a 0");
            }

            _juros = juros;
            _messes = messes;
            _valorInicial = Financeiro.Truncar2CasasDecimaisSemArrendondamento(valorInicial);

            valorInicialCorrigidoComjuros = Financeiro.FormataDecimalParaString(Financeiro.Truncar2CasasDecimaisSemArrendondamento(CalculaJuros()));
        }

        private decimal CalculaJuros()
        {
            return _valorInicial * (decimal)Math.Pow(1 + (double)_juros, _messes);
        }
    }
}
