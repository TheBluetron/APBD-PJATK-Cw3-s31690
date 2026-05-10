namespace APBD_PJATK_Cw3_s31690.Models;

public class Reservation
{
    public int id { get; set; }
    public int roomID { get; set; }
    public string organizerName { get; set; }
    public string topic { get; set; }
    public DateTime date { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public string status { get; set; } // planned, confirmed, cancelled
}