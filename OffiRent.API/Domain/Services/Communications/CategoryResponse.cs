using System;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Services.Communications
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
