using OffiRent.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        Task<Publication> FindById(int Id);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}
