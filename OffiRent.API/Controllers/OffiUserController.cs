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

namespace OffiRent.API.Controllers
{
    namespace OffiRent.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class OffiUserController : ControllerBase
        {
            private readonly IOffiUserService _offiUserService;

            private readonly IMapper _mapper;

            public OffiUserController(IOffiUserService offiUserService, IMapper mapper)
            {
                _offiUserService = offiUserService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IEnumerable<OffiUserResource>> GetAllAsync()
            {
                var offiUsers = await _offiUserService.ListAsync();
                var resources = _mapper.Map<IEnumerable<OffiUser>, IEnumerable<OffiUserResource>>(offiUsers);
                return resources;
            }

            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] SaveOffiUserResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var offiUser = _mapper.Map<SaveOffiUserResource, OffiUser>(resource);
                var result = await _offiUserService.SaveAsync(offiUser);

                if (!result.Success)
                    return BadRequest(result.Message);

                var offiUserResource = _mapper.Map<OffiUser, OffiUserResource>(result.Resource);

                return Ok(offiUserResource);

            }
        }
    }
