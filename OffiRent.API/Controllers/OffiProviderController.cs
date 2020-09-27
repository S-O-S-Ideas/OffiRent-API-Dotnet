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
    public class OffiProviderController : ControllerBase
    {
        private readonly IOffiProviderService _offiProviderService;

        private readonly IMapper _mapper;

        public OffiProviderController(IOffiProviderService offiProviderService, IMapper mapper)
        {
            _offiProviderService = offiProviderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OffiProviderResource>> GetAllAsync()
        {
            var offiProviders = await _offiProviderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<OffiProvider>, IEnumerable<OffiProviderResource>>(offiProviders);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOffiProviderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var offiProvider = _mapper.Map<SaveOffiProviderResource, OffiProvider>(resource);
            var result = await _offiProviderService.SaveAsync(offiProvider);

            if (!result.Success)
                return BadRequest(result.Message);

            var offiProviderResource = _mapper.Map<OffiProvider, OffiProviderResource>(result.Resource);

            return Ok(offiProviderResource);

        }
    }
}
