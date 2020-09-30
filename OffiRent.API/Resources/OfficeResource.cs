using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class OfficeResource
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
    }
}
