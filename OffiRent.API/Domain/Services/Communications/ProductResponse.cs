using System;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Services.Communications
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
