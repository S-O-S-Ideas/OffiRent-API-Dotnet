using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;

namespace OffiRent.API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> ListByTagIdAsync(int tagId);
    }
}
