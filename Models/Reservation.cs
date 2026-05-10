namespace APBD_PJATK_Cw3_s31690.Models;

public class Reservation
{
    private static int _lastId = 1;
    public int Id { get; private set; }

    public Reservation()
    {
        Id = _lastId++;
    }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Enumerators.Status Status { get; set; } // planned, confirmed, cancelled
}