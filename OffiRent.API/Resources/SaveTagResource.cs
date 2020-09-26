using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveTagResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
