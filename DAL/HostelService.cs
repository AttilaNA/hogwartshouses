using System.Runtime.CompilerServices;
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

    public void AssignStudentToRoom(int studentId, int roomNumber)
    {
        _roomRepository.GetById(roomNumber).Students.Add(_studentRepository.GetById(studentId));
    }

    public int GetNumberOfFreeBads(int roomNumber)
    {
        var room = _roomRepository.GetById(roomNumber);
        var emptyBads = room.RoomCapacity - room.Students.Count;
        return emptyBads;
    }

    public bool StudentHasRoom(int studentId)
    {
        var rooms = GetAllRooms();
        var students = rooms.SelectMany(x => x.Students).Where(x => x.StudentId == studentId);
        if(students.Count() == 0){
            return false;
        }
        return true;
    }

    public void RemoveStudentFromRoom(int studentId)
    {
        var rooms = GetAllRooms();
        var room = rooms.Select(x => x).Where(x => x.Students.Select(y => y.StudentId).Contains(studentId)).First();
        room.Students.RemoveWhere(x => x.StudentId == studentId);
    }
}
