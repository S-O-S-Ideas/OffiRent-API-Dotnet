using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class OfficeResource
    {
        public int Id { get; set; }
        public char Address { get; set; }
        public int Floor { get; set; }
        public char Capacity { get; set; }
        public bool AllowResource { get; set; }
    }
}
