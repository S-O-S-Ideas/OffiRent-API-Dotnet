using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace OffiRent.API.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeDistrictController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficeDistrictController(IOfficeService publicationRepository, IMapper mapper)
        {
            this._officeService = publicationRepository;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of Offices by DistrictId",
            Description = "List of Offices by DistrictId",
            Tags =new[] {"Offices"}
        )]
        [SwaggerResponse(200, "List of Offices within the District with entered DistrictId", typeof(PublicationResource))]
        [HttpGet("{districtId}")]
        public async Task<IEnumerable<OfficeResource>> GetAllByDistrictId(int districtId)
        {
            var offices = await _officeService.ListByDistrictIdAsync(districtId);
            var resources = _mapper.Map<IEnumerable<Office>, IEnumerable<OfficeResource>>(offices);
            return resources;
        }





    }
}
