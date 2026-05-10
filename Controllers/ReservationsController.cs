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
        if (date == null || status == null || roomId == null) return BadRequest();
        return Ok(StaticReservationsList.Reservations.Where(x =>
            x.Date == date && x.Status == status && x.RoomId == roomId));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(StaticReservationsList.Reservations.FirstOrDefault(x=> x.Id == id));
    }

    [HttpPost]
    public IActionResult AddReservation(Reservation reservation)
    {
        if(reservation == null) return BadRequest();
        if (reservation.OrganizerName == null || reservation.Topic == null) return BadRequest();
        if(reservation.StartTime.CompareTo(reservation.EndTime) >= 0) return BadRequest();
        StaticReservationsList.Reservations.Add(reservation);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateReservation(int id, Reservation reservation)
    {
        if(reservation == null) return BadRequest();
        if (reservation.OrganizerName == null || reservation.Topic == null) return BadRequest();
        if(reservation.StartTime.CompareTo(reservation.EndTime) >= 0) return BadRequest();
        StaticReservationsList.Reservations[id] = reservation;
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteReservation(int id)
    {
        if (StaticReservationsList.Reservations.FirstOrDefault(x => x.Id == id) == null) return BadRequest();
        StaticReservationsList.Reservations.Remove(StaticReservationsList.Reservations.FirstOrDefault(x => x.Id == id)!);
        return NoContent();
    }
}