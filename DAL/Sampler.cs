namespace hogwartshouses.DAL
{
    public class Sampler
    {
        public HashSet<Student> Students { get; private set; }
        
        private List<string> InitializedNameOfStudents {get; set;}

        public HashSet<Room> Rooms { get; private set; }

        private int InitializedNumberOfRooms {get; set;}

        private int InitializedNumberOfRoomCapacity {get; set;}

        public Sampler()
        {
            Students = new HashSet<Student>();
            InitializedNameOfStudents = new List<string> {
                "Hermione Granger",
                "Draco Malfoy"
            };
            Rooms = new HashSet<Room>();
            InitializedNumberOfRooms = InitializedNameOfStudents.Count;
            InitializedNumberOfRoomCapacity = 1;
            InitializeStudents();
            InitializeRooms();
            for (int i = 1; i < InitializedNumberOfRooms + 1; i++)
            {
                AssigneStudentToRoom(Students.Where(x => x.StudentId == i).First(), Rooms.Where(x => x.RoomNumber == i).First());
            }
            InitializeRooms();
        }

        private void InitializeStudents()
        {
            for (int i = 0; i < InitializedNameOfStudents.Count; i++)
            {
                var newStudent = new Student()
                {
                    StudentId = GetStudentId(),
                    StudentName = InitializedNameOfStudents[i]
                };
                Students.Add(newStudent);
            }
        }

        private void InitializeRooms()
        {
            for (int i = 0; i < InitializedNumberOfRooms; i++)
            {
                var newRoom = new Room()
                {
                    RoomNumber = GetRoomNumber(),
                    RoomCapacity = InitializedNumberOfRoomCapacity
                };
                Rooms.Add(newRoom);
            }
        }

        private void AssigneStudentToRoom(Student student, Room room){
            room.Students.Add(student);
        }

        public int GetStudentId()
        {
            var studentIdMax = 0;
            try
            {
                studentIdMax = Students.OrderByDescending(x => x.StudentId).First().StudentId + 1;
            }
            catch (InvalidOperationException)
            {
                studentIdMax = 1;
            }
            
            return studentIdMax;
        }

        public int GetRoomNumber()
        {
            var roomNumberMax = 0;
            try
            {
                roomNumberMax = Rooms.OrderByDescending(x => x.RoomNumber).First().RoomNumber + 1;
            }
            catch (InvalidOperationException)
            {
                roomNumberMax = 1;
            }
            
            return roomNumberMax;
        }
    }
}