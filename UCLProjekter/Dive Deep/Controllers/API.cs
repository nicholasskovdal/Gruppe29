using Microsoft.AspNetCore.Mvc;

namespace Dive_Deep.Controllers
{
    [ApiController] //Fortæller asp.net at det er en apicontroller
    [Route("productsController/[controller]")] //Definerer routing

    public class API : ControllerBase //ControllerBase bruges ved api's da der ingen view er, og den returnerer JSON
    {
        //Get endpoint
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "product A", "product B" });
        }

        //Udvid endpointed
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Product {id}");
        }
    }
}
//API-controller med attribute routing og et GET-endpoint, som returnerer JSON.
//Controllers opdages automatisk via AddControllers og MapControllers i program.cs