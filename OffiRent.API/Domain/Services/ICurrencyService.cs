using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> ListAsync();
        Task<CurrencyResponse> GetByIdAsync(int id);
        Task<CurrencyResponse> SaveAsync(Currency currency);
        Task<CurrencyResponse> UpdateAsync(int id, Currency currency);
        Task<CurrencyResponse> DeleteAsync(int id);
    }
}
