using Microsoft.AspNetCore.Mvc;

namespace hogwartshouses;

public interface IHostelService
{
    HashSet<Room> GetAllRooms();
    Room GetRoomById(int id);
    void AddRoom(Room room);
    bool DeleteRoomByRoomNumber(int roomNumber);
    void UpdateRoom(int id, Room room);
    HashSet<Student> GetAllStudents();
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void AssignStudentToRoom(int studentId, int roomNumber);
    int GetNumberOfFreeBads(int roomNumber);
    bool StudentHasRoom(int studentId);
    void RemoveStudentFromRoom(int studentId);
}
