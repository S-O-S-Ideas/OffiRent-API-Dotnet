using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Persistence.Contexts;
using OffiRent.API.Domain.Repositories;

namespace OffiRent.API.Persistence.Repositories
{
    public class OffiProviderRepository : BaseRepository, IOffiProviderRepository
    {
        public OffiProviderRepository(AppDbContext context) : base(context)
        {

        }
        public async Task AddAsync(OffiProvider offiProvider)
        {
            await _context.OffiProviders.AddAsync(offiProvider);
        }

        public async Task<OffiProvider> GetSingleByIdAsync(int offiProviderId)
        {
            return await _context.OffiProviders.FindAsync(offiProviderId);
        }

        public async Task<IEnumerable<OffiProvider>> ListAsync()
        {
            return await _context.OffiProviders.ToListAsync();
        }

        public void Remove(OffiProvider offiProvider)
        {
            _context.Remove(offiProvider);
        }
    }
}
