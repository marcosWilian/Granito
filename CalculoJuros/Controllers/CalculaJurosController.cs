using API_Calculo.Business;
using API_Calculo.Helper;
using API_Calculo.RepositoriesExternal;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_Calculo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly TaxaJurosExternal _taxaJurosExternal;
    
        public CalculaJurosController(TaxaJurosExternal taxaJurosExternal)
        {
            _taxaJurosExternal = taxaJurosExternal;
        }

        [HttpGet]
        public dynamic GetInterestRateCalculation([FromQuery] decimal valorInicial, [FromQuery] int messes)
        {
            try
            {
                decimal taxaJuros = _taxaJurosExternal.ObterTaxaJurosExterna();

                if (taxaJuros == 0)
                {
                    return BadRequest("Taxa de Juros inválida");
                }

                Juros juros = new Juros(valorInicial,messes,taxaJuros);

                return Ok(juros.valorInicialCorrigidoComjuros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
