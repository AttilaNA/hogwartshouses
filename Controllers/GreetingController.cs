using hogwartshouses;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsHouses.Controllers
{
    [Route("/")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        IHostelService _hostelService {get;}
        
        public GreetingController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }
        
        [HttpGet("{name?}")]
        public string Greeting(string name = "Witches and Wizards")
        {
            return $"Welcome to Hogwarts, {name}";
        }

        [HttpGet("rooms/")]
        public ActionResult<HashSet<Room>> GetRooms()
        {
            return _hostelService.GetAllRooms();
        }

        [HttpGet("rooms/{id}")]
        public ActionResult<Room> GetRoombyId(int id)
        {
            try
            {
                _hostelService.GetRoomById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return _hostelService.GetRoomById(id);
        }

        [HttpPost("rooms/")]
        public IActionResult CreateNewRoom([FromBody] Room room)
        {
            _hostelService.AddRoom(room);
            return RedirectToAction("GetRooms");
        }

        [HttpDelete("rooms/{id}")]
        public IActionResult DeleteRoomByRoomNumber(int id)
        {
            try
            {
                _hostelService.DeleteRoomByRoomNumber(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("rooms/{id}")]
        public IActionResult UpdateRoomByRoomNumber(int id, [FromBody] Room room)
        {
            try
            {
                _hostelService.GetRoomById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            _hostelService.UpdateRoom(id, room);
            return NoContent();
        }

        [HttpGet("students/")]
        public ActionResult<HashSet<Student>> GetStudents()
        {
            return _hostelService.GetAllStudents();
        }

        [HttpGet("students/{id}")]
        public ActionResult<Student> GetStudentbyId(int id)
        {
            try
            {
                _hostelService.GetStudentById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return _hostelService.GetStudentById(id);
        }

        [HttpPost("students/")]
        public IActionResult RegisterNewStudent([FromBody] Student student)
        {
            _hostelService.AddStudent(student);
            return RedirectToAction("GetStudents");
        }
    }
}
