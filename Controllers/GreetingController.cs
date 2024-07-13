using Microsoft.AspNetCore.Mvc;

namespace HogwartsHouses.Controllers
{
    [Route("/")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{name?}")]
        public string Greeting(string name = "Witches and Wizards")
        {
            return $"Welcome to Hogwarts, {name}";
        }
    }
}
