using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services;
using OffiRent.API.Resources;
using OffiRent.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController: ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }


        [SwaggerOperation(
           Summary = "List all Reservations"

           )]
        [SwaggerResponse(200, "List of Reservtions", typeof(IEnumerable<ReservationResource>))]
        [ProducesResponseType(typeof(IEnumerable<ReservationResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<ReservationResource>> GetAllAsync()
        {
            var reservations = await _reservationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Create a Reservation"

        )]
        [SwaggerResponse(200, "Reservation was created", typeof(ReservationResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveReservationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var reservation = _mapper.Map<SaveReservationResource, Reservation>(resource);

            var result = await _reservationService.SaveAsync(reservation);

            if (!result.Success)
                return BadRequest(result.Message);

            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);

            return Ok(reservationResource);

        }

        [SwaggerOperation(
            Summary = "Update a Reservation"

        )]
        [SwaggerResponse(200, "Reservation was updated", typeof(ReservationResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReservationResource resource)
        {
            var reservation = _mapper.Map<SaveReservationResource, Reservation>(resource);
            var result = await _reservationService.UpdateAsync(id, reservation);

            if (!result.Success)
                return BadRequest(result.Message);
            var reservationResource = _mapper.Map<Reservation, ReservationResource>(result.Resource);
            return Ok(reservationResource);
        }
    }
}
