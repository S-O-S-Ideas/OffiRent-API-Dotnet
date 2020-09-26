using System;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product resource) : base(resource)
        {
        }

        public ProductResponse(string message) : base(message)
        {
        }
    }
}
