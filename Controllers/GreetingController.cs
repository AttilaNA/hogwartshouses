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

        [HttpGet("rooms/")]
        public ActionResult<HashSet<Room>> GetRooms()
        {
            return _roomService.GetAllRooms();
        }

        [HttpGet("rooms/{id}")]
        public ActionResult<Room> GetRoombyId(int id)
        {
            try
            {
                _roomService.GetRoomById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return _roomService.GetRoomById(id);
        }

        [HttpPost("rooms/")]
        public IActionResult CreateNewRoom([FromBody] Room room)
        {
            _roomService.AddRoom(room);
            return RedirectToAction("GetRooms");
        }
    }
}
