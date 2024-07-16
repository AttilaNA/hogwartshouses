namespace hogwartshouses;

public class RoomSampler
{
    public HashSet<Room> Rooms { get; private set; }

    public RoomSampler()
    {
        Rooms = new HashSet<Room>();
        Initialize();
    }

    public void Initialize()
    {
        var numberOfRooms = new Random().Next(1, 10);
        for (int i = 1; i < numberOfRooms + 1; i++)
        {
            var newRoom = new Room()
            {
                RoomNumber = i,
                RoomCapacity = new Random().Next(1, 3)
            };
            Rooms.Add(newRoom);
        }
    }
}
