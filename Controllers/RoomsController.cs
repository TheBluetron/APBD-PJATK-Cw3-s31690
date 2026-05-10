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
        return Ok(StaticRoomsList.Rooms.FirstOrDefault(x => x.id == id));
    }

    [HttpGet("/api/[controller]/building/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] string buildingCode)
    {
        return Ok(StaticRoomsList.Rooms.Where(x=> x.buildingCode ==  buildingCode).ToList());
    }
    [HttpGet]
    public IActionResult GetRoomsConditions(int? minCapacity, bool? hasProjector, bool? activeOnly)
    {
        if(minCapacity == null && hasProjector == null && activeOnly == null) return  Ok(StaticRoomsList.Rooms);
        if(minCapacity == null ||  hasProjector == null || activeOnly == null) return  BadRequest();
        if (minCapacity <= 0) return BadRequest();
        return Ok(StaticRoomsList.Rooms.Where(x=> x.capacity > minCapacity && x.hasProjector == hasProjector && x.isActive == activeOnly).ToList());
    }

    [HttpPost]
    public IActionResult AddRoom(Room room)
    {
        if(room == null) return BadRequest();
        if(room.name == null || room.buildingCode == null) return BadRequest();
        StaticRoomsList.Rooms.Add(room);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateRoom(int id, Room room)
    {
        if(room == null) return BadRequest();
        if(room.name == null || room.buildingCode == null) return BadRequest();
        StaticRoomsList.Rooms[id] = room;
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteRoom(int id)
    {
        if (StaticRoomsList.Rooms.FirstOrDefault(x => x.id == id) == null) return BadRequest();
        StaticRoomsList.Rooms.Remove(StaticRoomsList.Rooms.FirstOrDefault(x => x.id == id)!);
        return NoContent();
    }
}