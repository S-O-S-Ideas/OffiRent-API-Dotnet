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
        public int Capacity { get; set; }  
        public bool AllowResource { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        
        //public List<Resource> Resources { get; set; }
    }
}
