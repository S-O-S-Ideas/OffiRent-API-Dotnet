using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/products/{productId}/tags")]
    public class ProductTagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IProductTagService _productTagService;
        private readonly IMapper _mapper;

        public ProductTagsController(ITagService tagService, IProductTagService productTagService, IMapper mapper)
        {
            _tagService = tagService;
            _productTagService = productTagService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all Tags by Product Id",
            Description = "List of Tags for a Product",
            OperationId = "ListAllTagsByProduct",
            Tags = new[] { "Products" }
        )]
        [SwaggerResponse(200, "List of Tags for a Product", typeof(IEnumerable<TagResource>))]
        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllByProductIdAsync(int productId)
        {
            var tags = await _tagService.ListByProductIdAsync(productId);
            var resources = _mapper
                .Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Assign a Tag to a Product",
            Description = "Assign a Tag to a Product",
            OperationId = "AssignTagsToProduct",
            Tags = new[] { "Products" }
        )]
        [SwaggerResponse(200, "Tags was assigned to Product", typeof(TagResource))]
        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssignProductTag(int productId, int tagId)
        {
            var result = await _productTagService.AssignProductTagAsync(productId, tagId);
            if (!result.Success)
                return BadRequest(result.Message);
            Tag tag = _tagService.GetByIdAsync(tagId).Result.Resource;
            var resource = _mapper.Map<Tag, TagResource>(tag);
            return Ok(resource);
        }
    }
}
