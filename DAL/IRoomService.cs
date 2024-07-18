using Microsoft.AspNetCore.Mvc;

namespace hogwartshouses;

public interface IRoomService
{
    HashSet<Room> GetAllRooms();
    Room GetRoomById(int id);
    void AddRoom(Room room);
    bool DeleteRoomByRoomNumber(int roomNumber);
    void UpdateRoom(int id, Room room);
}
