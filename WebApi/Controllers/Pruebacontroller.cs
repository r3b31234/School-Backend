using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]  // La ruta de los end points
    [ApiController]
    public class Pruebacontroller : ControllerBase
    {
        [HttpGet("prueba")]
        public string pruebaApi()
        {
            return "Esto es una prueba de mi API";

        }
    }
}
 