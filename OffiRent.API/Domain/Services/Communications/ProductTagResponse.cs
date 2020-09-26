using System;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ProductTagResponse : BaseResponse<ProductTag>
    {
        public ProductTagResponse(ProductTag resource) : base(resource)
        {
        }

        public ProductTagResponse(string message) : base(message)
        {
        }
    }
}
