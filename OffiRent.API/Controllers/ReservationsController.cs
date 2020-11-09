using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services;
using OffiRent.API.Resources;
using OffiRent.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;

namespace OffiRent.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IAccountService accountService, IMapper mapper)
        {
            _reservationService = reservationService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Delete a Reservation",
            Description = "Delete a reservation given it's id",
            Tags = new[] { "Reservations" }
        )]

        [SwaggerResponse(200, "Delete a reservation made by OffiUser ", typeof(ReservationResource))]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _reservationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);
            return Ok(reservationResource);
        }


        [SwaggerOperation(
            Summary = "List all Reservations",
            Description = "List of Reservations",
            Tags = new[] { "Reservations" }

           )]
        [SwaggerResponse(200, "List of Reservations", typeof(IEnumerable<ReservationResource>))]
        [ProducesResponseType(typeof(IEnumerable<ReservationResource>), 200)]
        [EnableCors]
        [HttpGet]
        public async Task<IEnumerable<ReservationResource>> GetAllAsync()
        {
            var reservations = await _reservationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);
            return resources;
        }

        [SwaggerOperation(
            Summary = "List all Reservations made by OffiUser",
            Description = "List all Reservations made by OffiUser given it's id",
            Tags = new[] { "Reservations" }

           )]
        [SwaggerResponse(200, "List of Reservations", typeof(IEnumerable<ReservationResource>))]
        [ProducesResponseType(typeof(IEnumerable<ReservationResource>), 200)]
        [HttpGet("{accountId}")]
        public async Task<IEnumerable<ReservationResource>> GetAllReservationsByOffiUserIdAsync(int accountId, [Optional][FromQuery(Name ="status")] string status)
        {
            var reservations = await _reservationService.ListByAccountIdAsync(accountId, status);
            var resources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);
            return resources;
        }



        [SwaggerOperation(
            Summary = "Create a new Reservation",
            Description = "Create a new Reservation given a valid OffiUser id",
            Tags = new[] { "Reservations" }
        )]
        [SwaggerResponse(200, "Reservation was created", typeof(ReservationResource))]
        [HttpPost("{accountId}")]
        public async Task<IActionResult> PostAsync(int accountId, [FromBody] SaveReservationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var reservation = _mapper.Map<SaveReservationResource, Reservation>(resource);

            var result = await _reservationService.SaveAsync(accountId, reservation);

            if (!result.Success)
                return BadRequest(result.Message);

            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);

            return Ok(reservationResource);

        }

        [SwaggerOperation(
            Summary = "Update a Reservation",
            Description = "Update properties of reservation given it's id",
            Tags = new[] { "Reservations" }

        )]
        [SwaggerResponse(200, "Reservation was updated", typeof(ReservationResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReservationResource resource)
        {
            var reservation = _mapper.Map<SaveReservationResource, Reservation>(resource);
            var result = await _reservationService.UpdateAsync(id, reservation);

            if (!result.Success)
                return BadRequest(result.Message);
            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);
            return Ok(reservationResource);
        }

        [SwaggerOperation(
            Summary = "Details of a Reservation",
            Description = "Details of a Reservation given it's id",
            Tags = new[] { "Reservations" }

        )]
        [SwaggerResponse(200, "Details of a Reservation", typeof(ReservationResource))]
        [HttpPut("id")]
        public async Task<IActionResult> GetByIdAsync(int reservationId)
        {
            var result = await _reservationService.GetByIdAsync(reservationId);
            if (!result.Success)
                return BadRequest(result.Message);
            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);
            return Ok(reservationResource);
        }

    }
}
