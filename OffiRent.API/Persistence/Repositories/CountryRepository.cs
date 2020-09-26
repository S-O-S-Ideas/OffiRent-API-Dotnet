using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task AddAsync(Country country) { 
            
            await _context.Countries.AddAsync(country); 
        }

       public async Task<Country> FindById(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }

        public void Remove(Country country)
        {
            _context.Countries.Remove(country);
        }
    }
}
