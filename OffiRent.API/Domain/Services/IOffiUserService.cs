using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    public interface IOffiUserService
    {
        Task<IEnumerable<OffiUser>> ListAsync();
        Task<OffiUserResponse> GetBySingleIdAsync(int id);
        Task<OffiUserResponse> SaveAsync(OffiUser offiUser);

        Task<OffiUserResponse> DeleteAsync(int id);

    }
}
