using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(30)]
        public string Puntuation { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
    }
}
