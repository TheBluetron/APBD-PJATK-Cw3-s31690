using APBD_PJATK_Cw3_s31690.Models;

namespace APBD_PJATK_Cw3_s31690.StaticLists;

public class StaticRoomsList
{
    public static List<Room> Rooms { get; } = new List<Room>()
    {
        new Room
        {
            Name = "Grand Saloon",
            BuildingCode = "4A",
            Floor = 0,
            Capacity = 120,
            HasProjector = false,
            IsActive = false
        },
        new Room
        {
            Name = "Banquet Hall",
            BuildingCode = "4A",
            Floor = 1,
            Capacity = 80,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Name = "Tent",
            BuildingCode = "6B",
            Floor = 0,
            Capacity = 40,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Name = "Top Floor",
            BuildingCode = "1",
            Floor = 20,
            Capacity = 15,
            HasProjector = true,
            IsActive = true
        }
    };
}