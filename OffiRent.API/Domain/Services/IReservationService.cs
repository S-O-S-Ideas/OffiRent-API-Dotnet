using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    interface IReservationService
    {
        Task<IEnumerable<Reservation>> ListAsync();
        Task<ReservationResponse> GetByIdAsync(int id);
        Task<ReservationResponse> SaveAsync(Reservation reservation);
        Task<ReservationResponse> UpdateAsync(int id, Reservation reservation);
        Task<ReservationResponse> DeleteAsync(int id);
    }
}
