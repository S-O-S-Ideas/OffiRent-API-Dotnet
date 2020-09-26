using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> ListAsync();
        Task AddAsync(Currency currency);
        Task<Currency> FindById(int id);
        void Remove(Currency currency);
        void Update(Currency currency);
    }
}
