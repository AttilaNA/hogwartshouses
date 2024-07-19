using Microsoft.AspNetCore.Mvc;

namespace hogwartshouses;

public class HostelService : IHostelService
{
    private IRepository<Room> _roomRepository { get; }

    private IRepository<Student> _studentRepository { get; }

    public HostelService(IRepository<Room> roomRepository, IRepository<Student> studentRepository)
    {
        _roomRepository = roomRepository;
        _studentRepository = studentRepository;
    }

    public HashSet<Room> GetAllRooms()
    {
        return _roomRepository.GetAll();
    }

    public Room GetRoomById(int id)
    {
        return _roomRepository.GetById(id);
    }

    public void AddRoom(Room room)
    {
        _roomRepository.Add(room);
    }

    public bool DeleteRoomByRoomNumber(int roomNumber)
    {
        return _roomRepository.DeleteById(roomNumber);
    }

    public void UpdateRoom(int id, Room room)
    {
        _roomRepository.UpdateById(id, room);
    }

    public HashSet<Student> GetAllStudents()
    {
        return _studentRepository.GetAll();
    }

    public Student GetStudentById(int id)
    {
        return _studentRepository.GetById(id);
    }

    public void AddStudent(Student student)
    {
        _studentRepository.Add(student);
    }

    public void AssignStudentToRoom(Student student, Room room)
    {
        throw new NotImplementedException();
    }
}
