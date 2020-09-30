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
    public class OfficeRepository : BaseRepository, IOfficeRepository
    {
        public OfficeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Office office)
        {
            await _context.Offices.AddAsync(office);
        }

        public async Task<Office> FindById(int id)
        {
            return await _context.Offices.FindAsync(id);
        }

        public async Task<IEnumerable<Office>> ListAsync()
        {
            return await _context.Offices.Include(p =>p.District).ToListAsync();
        }

        public async Task<IEnumerable<Office>> ListByDistrictIdAsync(int districtId)
        {
            return await _context.Offices
                .Where(p => p.DistrictId == districtId)
                .Include(p => p.District)
                .ToListAsync();
        }

        public async Task<IEnumerable<Office>> ListByPriceEqualOrLowerThanAsync(int price)
        {
            return await _context.Offices
                .Where(p => p.Price <= price)
                .ToListAsync();
        }

        public void Remove(Office office)
        {
            _context.Offices.Remove(office);
        }

        public void Update(Office office)
        {
            _context.Offices.Update(office);
        }
    }
}
