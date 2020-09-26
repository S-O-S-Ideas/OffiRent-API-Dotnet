using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CurrencyResource>> GetAllAsync()
        {
            var currencies = await _currencyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCurrencyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var currency = _mapper.Map<SaveCurrencyResource, Currency>(resource);
            var result = await _currencyService.SaveAsync(currency);

            if (!result.Success)
                return BadRequest(result.Message);

            var currencyResource = _mapper.Map<Currency, CurrencyResource>(result.Resource);

            return Ok(currencyResource);

        }
    }
}
