using APBD_PJATK_Cw3_s31690.Models;

namespace APBD_PJATK_Cw3_s31690.StaticLists;

public class StaticRoomsList
{
    public static List<Room> Rooms { get; } = new List<Room>()
    {
        new Room
        {
            id = 1,
            name = "Grand Saloon",
            buildingCode = "4A",
            floor = 0,
            capacity = 120,
            hasProjector = false,
            isActive = false
        },
        new Room
        {
            id = 2,
            name = "Banquet Hall",
            buildingCode = "4A",
            floor = 1,
            capacity = 80,
            hasProjector = true,
            isActive = true
        },
        new Room
        {
            id = 3,
            name = "Tent",
            buildingCode = "6B",
            floor = 0,
            capacity = 40,
            hasProjector = true,
            isActive = true
        },
        new Room
        {
            id = 4,
            name = "Top Floor",
            buildingCode = "1",
            floor = 20,
            capacity = 15,
            hasProjector = true,
            isActive = true
        }
    };
}