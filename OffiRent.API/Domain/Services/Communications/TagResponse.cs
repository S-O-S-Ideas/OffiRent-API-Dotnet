using System;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class TagResponse : BaseResponse<Tag>
    {
        public TagResponse(Tag resource) : base(resource)
        {
        }

        public TagResponse(string message) : base(message)
        {
        }
    }
}
