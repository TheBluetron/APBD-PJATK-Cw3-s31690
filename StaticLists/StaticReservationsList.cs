using APBD_PJATK_Cw3_s31690.Enumerators;
using APBD_PJATK_Cw3_s31690.Models;

namespace APBD_PJATK_Cw3_s31690.StaticLists;

public class StaticReservationsList
{
    public static List<Reservation> Reservations { get; } = new List<Reservation>()
    {
        new Reservation
        {
            RoomId = 1,
            OrganizerName = "Captain America",
            Topic = "Avengers Assemble",
            Date = new DateTime(2026, 6, 1),
            StartTime = new TimeOnly(8, 0),
            EndTime = new TimeOnly(12, 0),
            Status = Status.Confirmed
        }, 
        new Reservation 
        {
            RoomId = 4,
            OrganizerName = "Galileo",
            Topic = "Galileo Galilei",
            Date = new DateTime(1642, 1, 9),
            StartTime = new TimeOnly(20, 0),
            EndTime = new TimeOnly(23, 45),
            Status = Status.Cancelled
        }, 
        new Reservation 
        {
            RoomId = 2,
            OrganizerName = "Weddings",
            Topic = "Wedding venue",
            Date = new DateTime(2026, 4, 1),
            StartTime = new TimeOnly(0, 0),
            EndTime = new TimeOnly(23, 59),
            Status = Status.Active
        }, 
        new Reservation
        {
            RoomId = 3,
            OrganizerName = "ZUS",
            Topic = "Honorowe oddawanie krwi",
            Date = new DateTime(2026, 11, 22),
            StartTime = new TimeOnly(6, 0),
            EndTime = new TimeOnly(18, 0),
            Status = Status.Confirmed
        }, 
        new Reservation 
        {
            RoomId = 4,
            OrganizerName = "PJATK",
            Topic = "Impreza zarządu",
            Date = new DateTime(2026, 8, 10),
            StartTime = new TimeOnly(16, 0),
            EndTime = new TimeOnly(23, 59),
            Status = Status.Planned
        }
    };
}