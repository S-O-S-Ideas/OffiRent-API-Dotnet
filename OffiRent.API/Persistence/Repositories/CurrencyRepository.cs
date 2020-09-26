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
    public class CurrencyRepository : BaseRepository, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context)
        {

        }
        public async Task AddAsync(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
        }

        public async Task<Currency> FindById(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public void Update(Currency currency)
        {
            _context.Currencies.Update(currency);
        }

        public void Remove(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }
    }
}
