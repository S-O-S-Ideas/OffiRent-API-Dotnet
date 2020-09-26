using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task<IEnumerable<Tag>> ListByProductIdAsync(int productId);
        Task<TagResponse> GetByIdAsync(int id);
        Task<TagResponse> SaveAsync(Tag tag);
        Task<TagResponse> UpdateAsync(int id, Tag tag);
        Task<TagResponse> DeleteAsync(int id);

    }
}
