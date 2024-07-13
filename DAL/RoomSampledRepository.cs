namespace hogwartshouses;

public class RoomSampledRepository : IRepository<Room>
{
    private RoomSampler _roomSampler { get; }

    public RoomSampledRepository()
    {
        _roomSampler = new RoomSampler();
    }
}
