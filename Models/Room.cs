namespace APBD_PJATK_Cw3_s31690.Models;

public class Room
{
    private static int _lastId = 1;
    public int Id  { get; private set; }

    public Room()
    {
        Id = _lastId++;
    }
    public string Name { get; set; }
    public string BuildingCode { get; set; }
    public int Floor{get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}