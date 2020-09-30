using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public string Capacity { get; set; }
        public bool AllowResource { get; set; }
        public string Punctuation { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public List<Reservation> Reservations { get; set; }
        
    }
}
