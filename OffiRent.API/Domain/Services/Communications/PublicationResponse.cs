using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services.Communications
{
    public class PublicationResponse: BaseResponse<Publication>
    {
        public PublicationResponse(Publication resource) : base(resource)
        {

        }
        public PublicationResponse(string message) : base(message)
        {

        }
    }
}
