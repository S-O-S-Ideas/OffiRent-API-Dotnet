using System;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Services.Communications
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
