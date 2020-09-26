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
    [Route("/api/categories/{categoryId}/products")]
    public class CategoryProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all Products by Category Id",
            Description = "List of Products for a Category",
            OperationId = "ListAllProductsByCategory",
            Tags = new[] { "Categories" }
        )]
        [SwaggerResponse(200, "List of Products for a Category", typeof(IEnumerable<CategoryResource>))]
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.ListByCategoryIdAsync(categoryId);
            var resources = _mapper
                .Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }
    }
}
