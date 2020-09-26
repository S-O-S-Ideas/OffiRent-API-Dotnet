using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class CountryCurrencyRepository : BaseRepository, ICountryCurrencyRepository
    {
        public CountryCurrencyRepository(AppDbContext context) : base(context)
        {

        }
        public async Task AddAsync(CountryCurrency countryCurrency)
        {
            await _context.CountryCurrencies.AddAsync(countryCurrency);
        }

        public async Task AssignCountryCurrency(int countryId, int currencyId)
        {
            CountryCurrency countryCurrency = await _context.CountryCurrencies.FindAsync(countryId, currencyId);
            if (countryCurrency != null)
                await AddAsync(countryCurrency);
        }

        public async Task<CountryCurrency> FindByCountryIdAndCurrencyId(int countryId, int currencyId)
        {
            return await _context.CountryCurrencies.FindAsync(countryId, currencyId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListAsync()
        {
            return await _context.CountryCurrencies
                .Include(p => p.Currency)
                .Include(p => p.Country).ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId)
        {
            return await _context.CountryCurrencies
                .Where(p => p.CountryId == countryId)
                .Include(p => p.CountryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId)
        {
            return await _context.CountryCurrencies
                .Where(p => p.CurrencyId == currencyId)
                .Include(p => p.CurrencyId)
                .ToListAsync();
        }

        public void Remove(CountryCurrency countrycurrency)
        {
            _context.CountryCurrencies.Remove(countrycurrency);
        }

        public async void UnassignCountryCurrency(int countryId, int currencyId)
        {
            CountryCurrency countryCurrency = await _context.CountryCurrencies.FindAsync(countryId, currencyId);
            if (countryCurrency != null)
            {
                Remove(countryCurrency);
            }
        }

        public void Update(CountryCurrency countrycurrency)
        {
            _context.CountryCurrencies.Update(countrycurrency);
        }
    }
}