using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public char Name { get; set; }

        public List<CountryCurrency> CountryCurrencies { get; set; } = new List<CountryCurrency>();

        public List<Departament> Departaments { get; set; } = new List<Departament> ();
    }
}
