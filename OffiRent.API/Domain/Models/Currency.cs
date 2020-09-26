using System;
using System.Collections.Generic;


namespace Supermarket.API.Domain.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public char Name { get; set; }
        public char Symbol { get; set; }

        public List<CountryCurrency> CountryCurrencies { get; set; } 
    }
}
