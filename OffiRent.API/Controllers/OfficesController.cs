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
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficesController(IOfficeService officeService, IMapper mapper)
        {
            _officeService = officeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OfficeResource>> GetAllAsync()
        {
            var offices = await _officeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Office>, IEnumerable<OfficeResource>>(offices);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOfficeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var office = _mapper.Map<SaveOfficeResource, Office>(resource);
            var result = await _officeService.SaveAsync(office);

            if (!result.Success)
                return BadRequest(result.Message);

            var officeResource = _mapper.Map<Office, OfficeResource>(result.Resource);

            return Ok(officeResource);
        }
    }
}
