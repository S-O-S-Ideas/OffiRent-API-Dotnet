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

        public int Capacity { get; set; }

        [Required]
        public bool AllowResource { get; set; }
        public float Score { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
    }
}
