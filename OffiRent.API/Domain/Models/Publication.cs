using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Puntuation { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
        public int OffiProviderId { get; set; }
        //public OffiProvider OffiProvider {get;set;}
        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
