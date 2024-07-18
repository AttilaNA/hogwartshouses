using System.Runtime.InteropServices;

namespace hogwartshouses;

public class RoomSampledRepository : IRepository<Room>
{
    private RoomSampler _roomSampler { get; }

    public RoomSampledRepository()
    {
        _roomSampler = new RoomSampler();
    }

    public HashSet<Room> GetAll()
    {
        return _roomSampler.Rooms;
    }

    public Room GetById(int id)
    {
        return _roomSampler.Rooms.Where(x => x.RoomNumber == id).First();
    }

    public void Add(Room obj)
    {
        // First make sure, that the room number is incremented.
        obj.RoomNumber = _roomSampler.GetRoomNumber();
        _roomSampler.Rooms.Add(obj);
    }

    public bool DeleteById(int id)
    {
        var roomToDelete = GetById(id);
        return _roomSampler.Rooms.Remove(roomToDelete);
    }

    public void UpdateById(int id, Room obj)
    {
        var roomToUpdate = GetById(id);
        roomToUpdate.RoomCapacity = obj.RoomCapacity;
        roomToUpdate.Students = obj.Students;
    }
}