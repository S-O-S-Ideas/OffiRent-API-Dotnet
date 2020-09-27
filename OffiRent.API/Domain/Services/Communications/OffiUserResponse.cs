using OffiRent.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services.Communications
{
    public class OffiUserResponse : BaseResponse<OffiUser>
    {
        public OffiUserResponse(OffiUser resource) : base(resource)
        {
        }

        public OffiUserResponse(string message) : base(message)
        {
        }
    }
}
