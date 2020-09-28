using System;
using System.Collections.Generic;

namespace OffiRent.API.Domain.Models
{
    public class OffiProvider
    {
        public int Id { get; set; }
        public bool PremiumStatus{ get; set; }
        public int Punctuation{ get; set; }
        public int NumberOfPublication { get; set; }
        public int NumberOfReservationCompleted { get; set; }
        public List<Publication> Publications { get; set; } = new List<Publication>();
    }
}
