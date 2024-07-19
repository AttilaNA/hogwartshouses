using System.ComponentModel.DataAnnotations;

namespace hogwartshouses;

[Serializable]
public class Room
{
    public int RoomNumber {get; set;}

    public HashSet<Student> Students {get; set;}

    [Range(1, 3)]
    public int RoomCapacity {get; set;}

    public Room()
    {
        Students = new HashSet<Student>();
    }

}
