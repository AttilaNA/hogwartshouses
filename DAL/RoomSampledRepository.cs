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
}