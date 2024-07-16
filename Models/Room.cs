namespace hogwartshouses;

[Serializable]
public class Room
{
    public int RoomNumber {get; set;}

    public List<Student> Students {get; set;}

    public int RoomCapacity {get; set;}

    public Room()
    {
        Students = new List<Student>(){};
    }

}
