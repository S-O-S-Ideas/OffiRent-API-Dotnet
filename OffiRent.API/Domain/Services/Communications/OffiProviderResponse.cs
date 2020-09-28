using OffiRent.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services.Communications
{
    public class OffiProviderResponse : BaseResponse<OffiProvider>
    {
        public OffiProviderResponse(OffiProvider resource) : base(resource)
        {
        }

        public OffiProviderResponse(string message) : base(message)
        {
        }
    }
}
