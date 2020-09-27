using OffiRent.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Repositories
{
    public interface IOffiUserRepository
    {
        Task<IEnumerable<OffiUser>> ListAsync();
        Task<OffiUser> GetSingleByIdAsync(int offiUserId);
        Task AddAsync(OffiUser offiUser);
        void Remove(OffiUser offiUser);
    }
}
