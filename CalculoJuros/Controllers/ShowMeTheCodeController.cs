using Microsoft.AspNetCore.Mvc;

namespace API_Calculo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public dynamic GetGitHubUrl()
        {
            return Ok("https://github.com/marcosWilian/Granito");
        }
    }
}
