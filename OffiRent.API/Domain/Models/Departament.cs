using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public char Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<District> Districts { get; set; }
    }
}
