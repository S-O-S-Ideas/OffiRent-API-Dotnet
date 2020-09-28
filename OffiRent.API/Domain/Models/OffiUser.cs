using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class OffiUser
    {
        public int Id { get; set; }
        public float UserPunctuation { get; set; }
        public bool HasDiscount { get; set; }
        //public int ReservationId { get; set; }
        //public Reservation Reservation { get; set; }
        public int DiscountId { get; set; }
        //public Discount Discount { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}