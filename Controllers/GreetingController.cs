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

        [HttpGet("availableRooms/")]
        public ActionResult<HashSet<Room>> GetAvailableRooms()
        {
            return _hostelService.GetNotFullyBookedRooms();
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

        [HttpGet("checkin")]
        public IActionResult AssignStudentToRoom([FromQuery] int roomNumber, [FromQuery] int studentId)
        {
            // check if request is valid
            if (roomNumber == 0 || studentId == 0)
            {
                return BadRequest(new {
                    Message = "Room number and Student id must be provided.",
                    RequestWasSentFrom = $"{HttpContext.Request.Scheme}//{HttpContext.Request.Host.Value}{HttpContext.Request.Path}{HttpContext.Request.QueryString}",
                    RequestCorrectExample = $"{HttpContext.Request.Scheme}//{HttpContext.Request.Host.Value}/assignment?roomNumber=2&studentId=6",
                    Status = 400,
                    Type = 1
                });
            }

            // check if room exists
            try
            {
                _hostelService.GetRoomById(roomNumber);
            }
            catch (InvalidOperationException)
            {
                return NotFound(new {
                    Message = $"Room with number {roomNumber} does not exist.",
                    Status = 404,
                    Type = 2
                });
            }

            // check if student exists
            try
            {
                _hostelService.GetStudentById(studentId);
            }
            catch (InvalidOperationException)
            {
                return NotFound(new {
                    Message = $"Student with id {studentId} does not exist.",
                    Status = 404,
                    Type = 3
                });
            }

            // validate room capacity
            if(_hostelService.GetNumberOfFreeBads(roomNumber) == 0){
                return BadRequest(new {
                    Message = "Room is already full!",
                    Status = 400,
                    Type = 4
                });
            }

            // make sure that student has no room yet
            if(_hostelService.StudentHasRoom(studentId)){
                return BadRequest(new {
                    Message = "Student has already a room.",
                    Instruction = "Remove student from the used room first.",
                    Status = 400,
                    Type = 5
                });
            }
            _hostelService.AssignStudentToRoom(studentId, roomNumber);
            return RedirectToAction("GetRooms");
        }

        [HttpDelete("checkout/{studentId}")]
        public IActionResult RemoveStudentFromRoom(int studentId)
        {
            // check if student exists
            try
            {
                _hostelService.GetStudentById(studentId);
            }
            catch (InvalidOperationException)
            {
                return NotFound(new {
                    Message = $"Student with id {studentId} does not exist.",
                    Status = 404,
                    Type = 3
                });
            }

            // make sure that student is assigned to a room
            if(!_hostelService.StudentHasRoom(studentId)){
                return BadRequest(new {
                    Message = "Student is not checkedIn yet.",
                    Instruction = "Assign student to a room",
                    Status = 400,
                    Type = 6
                });
            }
            _hostelService.RemoveStudentFromRoom(studentId);
            return NoContent();
        }
    }
}
