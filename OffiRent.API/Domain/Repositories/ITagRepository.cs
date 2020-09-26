using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
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
