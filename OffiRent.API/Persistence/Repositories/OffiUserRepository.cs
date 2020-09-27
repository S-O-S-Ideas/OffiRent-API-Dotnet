using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Persistence.Contexts;
using OffiRent.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Persistence.Repositories
{
    public class OffiUserRepository : BaseRepository, IOffiUserRepository
    {
        public OffiUserRepository(AppDbContext context) : base(context)
        {

        }
        public async Task AddAsync(OffiUser offiUser)
        {
            await _context.OffiUsers.AddAsync(offiUser);
        }

        public async Task<OffiUser> GetSingleByIdAsync(int offiUserId)
        {
            return await _context.OffiUsers.FindAsync(offiUserId);
        }

        public async Task<IEnumerable<OffiUser>> ListAsync()
        {
            return await _context.OffiUsers.ToListAsync();
        }

        public void Remove(OffiUser offiUser)
        {
            _context.Remove(offiUser);
        }
    }
}
