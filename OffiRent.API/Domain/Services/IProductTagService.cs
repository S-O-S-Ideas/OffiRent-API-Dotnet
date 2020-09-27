using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;

namespace OffiRent.API.Domain.Services
{
    public interface IProductTagService
    {
        Task<IEnumerable<ProductTag>> ListAsync();
        Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId);
        Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId);
        Task<ProductTagResponse> AssignProductTagAsync(int productId, int tagId);
        Task<ProductTagResponse> UnassignProductTagAsync(int productId, int tagId);
    }
}
