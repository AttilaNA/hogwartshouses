using hogwartshouses;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsHouses.Controllers
{
    [Route("/")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        IRoomService _roomService {get;}
        
        public GreetingController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        
        [HttpGet("{name?}")]
        public string Greeting(string name = "Witches and Wizards")
        {
            return $"Welcome to Hogwarts, {name}";
        }

        [HttpGet]
        public ActionResult<HashSet<Room>> GetRooms()
        {
            return _roomService.GetAllRooms();
        }
    }
}
