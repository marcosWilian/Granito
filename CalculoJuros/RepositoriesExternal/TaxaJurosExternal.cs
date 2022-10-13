
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace API_Calculo.RepositoriesExternal
{
    public class TaxaJurosExternal
    {
        private readonly string _URL;
        private readonly string _Port;

        public TaxaJurosExternal(IConfiguration config)
        {
            _URL = config.GetSection("TaxaJurosAPI:URL").Get<string>();
            _Port = config.GetSection("TaxaJurosAPI:PORT").Get<string>();

        }

        public decimal ObterTaxaJurosExterna()
        {

            var client = new RestClient($"{_URL}:{_Port}");
            var request = new RestRequest("TaxaJuros", Method.Get);

            var queryResult = client.Execute<decimal>(request);
            return queryResult.Data;
        }

    }
}
