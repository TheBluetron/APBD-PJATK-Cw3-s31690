namespace APBD_PJATK_Cw3_s31690.Models;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Enumerators.Status Status { get; set; } // planned, confirmed, cancelled
}