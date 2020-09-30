using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class SaveOfficeResource
    {
        [Required]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        public int Floor { get; set; }
        [Required]
        [MaxLength(30)]
        public string Capacity { get; set; }

        [Required]
        public bool AllowResource { get; set; }
    }
}
