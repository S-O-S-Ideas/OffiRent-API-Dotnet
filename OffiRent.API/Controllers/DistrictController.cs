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
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        private readonly IMapper _mapper;

        public DistrictsController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DistrictResource>> GetAllAsync()
        {
            var districts = await _districtService.ListAsync();
            var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);
            return resources;
        }




        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDistrictResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var district = _mapper.Map<SaveDistrictResource, District>(resource);
            var result = await _districtService.SaveAsync(district);

            if (!result.Success)
                return BadRequest(result.Message);

            var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);

            return Ok(districtResource);

        }
    }
}
