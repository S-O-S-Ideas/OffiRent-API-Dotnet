using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public char Name { get; set; }

        public List<CountryCurrency> CountryCurrencies { get; set; }

        public List<Departament> Departaments { get; set; }
    }
}
