using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services;
using OffiRent.API.Resources;
using OffiRent.AspNetCore.Annotations;

namespace OffiRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryCurrencyControler : ControllerBase
    {
        private readonly ICountryCurrencyService _countryCurrencyService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryCurrencyControler(ICountryCurrencyService countryCurrencyService,
            ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _countryCurrencyService = countryCurrencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetAllByCountryIdAsync(int countryId)
        {
            var country = await _countryService.ListByCountryIdAsync(countryId);
            var resources = _mapper
                .Map<IEnumerable<Country>, IEnumerable<CountryResource>>(country);
            return resources;
        }

        [HttpPost]
        public async Task <IActionResult> AssignCountryCurrency(int countryId, int currencyId)
        {
            var result = await _countryCurrencyService.AssignCountryCurrencyAsync(countryId, currencyId);
            if (!result.Success)
                return BadRequest(result.Message);
            Country country= _countryService.GetByIdAsync(countryId).Result.Resource;
            var resource = _mapper.Map<Country, CountryResource>(country);
            return Ok(resource);
        }
    }
}
