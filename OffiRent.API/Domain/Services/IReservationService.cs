using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> ListAsync();
        Task<ReservationResponse> GetByIdAsync(int id);
        Task<ReservationResponse> SaveAsync(Reservation reservation);
        Task<ReservationResponse> UpdateAsync(int id, Reservation reservation);
        Task<ReservationResponse> DeleteAsync(int id);
        Task<ReservationResponse> ActiveReservation(int accountId, int id);
        Task<bool> AccountHasReservation(int x, Account account);
    }
}
