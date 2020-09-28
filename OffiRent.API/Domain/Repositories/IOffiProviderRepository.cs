using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Repositories
{
    public interface IOffiProviderRepository
    {
        Task<IEnumerable<OffiProvider>> ListAsync();
        Task<OffiProvider> GetSingleByIdAsync(int offiProviderId);
        Task AddAsync(OffiProvider offiProvider);
        void Remove(OffiProvider offiProvider);
    }
}
