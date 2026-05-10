using APBD_PJATK_Cw3_s31690.Enumerators;
using APBD_PJATK_Cw3_s31690.Models;
using APBD_PJATK_Cw3_s31690.StaticLists;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s31690.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(DateTime? date, Status? status, int? roomId)
    {
        if (date == null && status == null && roomId == null) return Ok(StaticReservationsList.Reservations);
        if (date == null || status == null || roomId == null) return BadRequest("All or none parameters are required");
        return Ok(StaticReservationsList.Reservations.Where(x =>
            x.Date == date && x.Status == status && x.RoomId == roomId));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if(StaticReservationsList.Reservations.FirstOrDefault(x=> x.Id == id) == null) return NotFound();
        return Ok(StaticReservationsList.Reservations.FirstOrDefault(x=> x.Id == id));
    }

    [HttpPost]
    public IActionResult AddReservation(Reservation reservation)
    {
        if(reservation == null) return BadRequest("Reservation is null");
        if (reservation.OrganizerName == null || reservation.Topic == null) return BadRequest("OrganizerName or Topic is null");
        if(reservation.StartTime.CompareTo(reservation.EndTime) >= 0) return BadRequest("EndTime has to be later than StartTime");
        //Nie wolno dodać rezerwacji dla sali, która nie istnieje:
        if(StaticRoomsList.Rooms.FirstOrDefault(x=> x.Id ==  reservation.RoomId) == null) return BadRequest("Room with this id does not exist");
        //Nie wolno dodać rezerwacji dla sali oznaczonej jako nieaktywna.
        Room room = StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == reservation.RoomId);
        if(!room.IsActive) return BadRequest("Cannot reserve an inActiveRoom");
        //Dwie rezerwacje tej samej sali nie mogą nakładać się czasowo tego samego dnia.
        foreach (var r in StaticReservationsList.Reservations)
        {
            if(reservation.Date == r.Date && reservation.StartTime.CompareTo(r.EndTime) < 0) return BadRequest("This room is already reserved for this time slot");
        }
        StaticReservationsList.Reservations.Add(reservation);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateReservation(int id, Reservation reservation)
    {
        if(reservation == null) return BadRequest("Reservation is null");
        if (reservation.OrganizerName == null || reservation.Topic == null) return BadRequest("OrganizerName or Topic is null");
        if(reservation.StartTime.CompareTo(reservation.EndTime) >= 0) return BadRequest("EndTime has to be later than StartTime");
        //Nie wolno dodać rezerwacji dla sali, która nie istnieje:
        if(StaticRoomsList.Rooms.FirstOrDefault(x=> x.Id ==  reservation.RoomId) == null) return BadRequest("Room with this id does not exist");
        //Nie wolno dodać rezerwacji dla sali oznaczonej jako nieaktywna.
        Room room = StaticRoomsList.Rooms.FirstOrDefault(x => x.Id == reservation.RoomId);
        if(!room.IsActive) return BadRequest("Cannot reserve an inActiveRoom");
        //Dwie rezerwacje tej samej sali nie mogą nakładać się czasowo tego samego dnia.
        foreach (var r in StaticReservationsList.Reservations)
        {
            if(reservation.Date == r.Date && reservation.StartTime.CompareTo(r.EndTime) < 0) return BadRequest("This room is already reserved for this time slot");
        }
        StaticReservationsList.Reservations[id] = reservation;
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteReservation(int id)
    {
        if (StaticReservationsList.Reservations.FirstOrDefault(x => x.Id == id) == null) return BadRequest("No reservation found with this id:" + id);
        StaticReservationsList.Reservations.Remove(StaticReservationsList.Reservations.FirstOrDefault(x => x.Id == id));
        return NoContent();
    }
}