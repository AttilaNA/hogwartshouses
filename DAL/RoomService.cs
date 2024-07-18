using Microsoft.AspNetCore.Mvc;

namespace hogwartshouses;

public class RoomService : IRoomService
{
    private IRepository<Room> _repository { get; }

    public RoomService(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public HashSet<Room> GetAllRooms()
    {
        return _repository.GetAll();
    }

    public Room GetRoomById(int id)
    {
        return _repository.GetById(id);
    }

    public void AddRoom(Room room)
    {
        _repository.Add(room);
    }

    public bool DeleteRoomByRoomNumber(int roomNumber)
    {
        return _repository.DeleteById(roomNumber);
    }

    public void UpdateRoom(int id, Room room)
    {
        _repository.UpdateById(id, room);
    }
}
