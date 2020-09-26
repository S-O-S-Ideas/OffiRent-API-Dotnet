using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task AddAsync(Tag tag);
        Task<Tag> FindById(int id);
        void Update(Tag tag);
        void Remove(Tag tag);
    }
}
