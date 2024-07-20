using System.Runtime.InteropServices;
using hogwartshouses.DAL;

namespace hogwartshouses;

public class RoomSampledRepository : IRepository<Room>
{
    private Sampler _sampler { get; }

    public RoomSampledRepository(Sampler sampler)
    {
        _sampler = sampler;
    }

    public HashSet<Room> GetAll()
    {
        return _sampler.Rooms;
    }

    public Room GetById(int id)
    {
        return _sampler.Rooms.Where(x => x.RoomNumber == id).First();
    }

    public void Add(Room obj)
    {
        // First make sure, that the room number is incremented.
        obj.RoomNumber = _sampler.GetRoomNumber();
        obj.Students = new HashSet<Student>();
        _sampler.Rooms.Add(obj);
    }

    public bool DeleteById(int id)
    {
        var roomToDelete = GetById(id);
        return _sampler.Rooms.Remove(roomToDelete);
    }

    public void UpdateById(int id, Room obj)
    {
        var roomToUpdate = GetById(id);
        roomToUpdate.RoomCapacity = obj.RoomCapacity;
    }
}