using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindById(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
