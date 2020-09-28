using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class OffiProviderResource
    {
        public int Id { get; set; }
        public bool PremiumStatus { get; set; }
        public int Punctuation { get; set; }
        public int NumberOfReservationCompleted { get; set; }
        public int NumberOfPublication { get; set; }
    }
}
