using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    public interface IOffiProviderService
    {
        Task<IEnumerable<OffiProvider>> ListAsync();
        Task<OffiProviderResponse> GetBySingleIdAsync(int id);
        Task<OffiProviderResponse> SaveAsync(OffiProvider offiProvider);
       
        Task<OffiProviderResponse> DeleteAsync(int id);

    }
}
