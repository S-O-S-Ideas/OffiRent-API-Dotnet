using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class OffiUserResource
    {
        public int Id { get; set; }
        public float UserPunctuation { get; set; }
        public bool HasDiscount { get; set; }
        public int ReservationId { get; set; }
    }
}
