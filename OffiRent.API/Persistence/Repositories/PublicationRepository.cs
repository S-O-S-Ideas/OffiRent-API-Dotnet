using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Persistence.Repositories
{
    public class PublicationRepository : BaseRepository,IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindById(int Id)
        {
            return await _context.Publications.FindAsync(Id);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }
    }
}
