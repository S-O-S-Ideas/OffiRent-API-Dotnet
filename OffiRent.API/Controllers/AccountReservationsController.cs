using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services;
using OffiRent.API.Extensions;
using OffiRent.API.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace OffiRent.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountReservationsController(IReservationService reservationService, IAccountService accountService, IMapper mapper)
        {
            _reservationService = reservationService;
            _accountService = accountService;
            _mapper = mapper;
        }



        [SwaggerOperation(
            Summary = "Create a new Reservation",
            Description = "Create a new Reservation given a valid OffiUser id",
            Tags = new[] { "Accounts" }
        )]
        [SwaggerResponse(200, "Reservation was created", typeof(ReservationResource))]
        [HttpPost("accounts/{accountId}/reservations")]
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
    }
}
