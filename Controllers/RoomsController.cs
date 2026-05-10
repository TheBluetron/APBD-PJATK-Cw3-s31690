using APBD_PJATK_Cw3_s31690.Models;
using APBD_PJATK_Cw3_s31690.StaticLists;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s31690.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if (StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == id) == null) return NotFound();
        return Ok(StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == id));
    }

    [HttpGet("/api/[controller]/building/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] string buildingCode)
    {
        if(StaticRoomsList.Rooms.Where(x=> x.BuildingCode ==  buildingCode)==null) return NotFound();
        return Ok(StaticRoomsList.Rooms.Where(x=> x.BuildingCode ==  buildingCode).ToList());
    }
    [HttpGet]
    public IActionResult GetRoomsConditions(int? minCapacity, bool? hasProjector, bool? activeOnly)
    {
        if(minCapacity == null && hasProjector == null && activeOnly == null) return  Ok(StaticRoomsList.Rooms);
        if(minCapacity == null ||  hasProjector == null || activeOnly == null) return  BadRequest("All or none parameters are required");
        if (minCapacity <= 0) return BadRequest("Minimum capacity of room has to be greater than 0");
        return Ok(StaticRoomsList.Rooms.Where(x=> x.Capacity > minCapacity && x.HasProjector == hasProjector && x.IsActive == activeOnly).ToList());
    }

    [HttpPost]
    public IActionResult AddRoom(Room room)
    {
        if(room == null) return BadRequest("Room is null");
        if(room.Name == null || room.BuildingCode == null) return BadRequest("Room name or building code is null");
        StaticRoomsList.Rooms.Add(room);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateRoom(int id, Room room)
    {
        if(room == null) return BadRequest("Room is null");
        if(room.Name == null || room.BuildingCode == null) return BadRequest("Room name or building code is null");
        int index = 0;
        foreach (var r in StaticRoomsList.Rooms)
        {
            if (r.Id == id)
            {
                StaticRoomsList.Rooms[index] = room;
                return Ok();
            }
            index++;
        }
        return NotFound("Room with that id not found");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteRoom(int id)
    {
        if (StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == id) == null) return BadRequest("No room found with this id:" + id);
        //nie pozwalać usuwać sali z powiązanymi rezerwacjami.
        foreach (var reservation in StaticReservationsList.Reservations)
        {
            if (id == reservation.RoomId) return Conflict("Cannot delete a room with future reservations");
        }
        StaticRoomsList.Rooms.Remove(StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == id));
        return NoContent();
    }
}