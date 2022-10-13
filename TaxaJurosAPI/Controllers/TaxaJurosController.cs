using Microsoft.AspNetCore.Mvc;

namespace InterestRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly TaxaJuros _taxaJuros;

        public TaxaJurosController(TaxaJuros taxaJuros)
        {
            _taxaJuros = taxaJuros;
        }

        [HttpGet]
        public dynamic ObterTaxaJuros()
        {
            return Ok(_taxaJuros.jurosAtual);
        }
    }
}
