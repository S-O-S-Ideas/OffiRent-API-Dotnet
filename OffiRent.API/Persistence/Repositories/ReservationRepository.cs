using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OffiRent.API.Persistence.Repositories
{
    public class ReservationRepository: BaseRepository, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
        }

        public async Task<Reservation> FindById(int Id)
        {
            return await _context.Reservations.FindAsync(Id);
        }

        public async Task<IEnumerable<Reservation>> ListAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public void Remove(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
        }
    }
}
