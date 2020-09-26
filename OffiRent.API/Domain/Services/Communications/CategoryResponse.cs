using System;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(Category resource) : base(resource)
        {
        }

        public CategoryResponse(string message) : base(message)
        {
        }
    }
}
