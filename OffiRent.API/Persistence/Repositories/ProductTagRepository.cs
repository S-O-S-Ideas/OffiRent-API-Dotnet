using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductTagRepository : BaseRepository, IProductTagRepository
    {

        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(ProductTag productTag)
        {
            await _context.ProductTags.AddAsync(productTag);
        }

        public async Task AssignProductTag(int productId, int tagId)
        {
            ProductTag productTag = await _context.ProductTags.FindAsync(productId, tagId);
            if (productTag != null)
                await AddAsync(productTag);
        }

        public async Task<ProductTag> FindByProductIdAndTagId(int productId, int tagId)
        {
            return await _context.ProductTags
                .Where(pt => pt.ProductId == productId)
                .Where(pt => pt.TagId == tagId)
                .Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListAsync()
        {
            return await _context.ProductTags
                .Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId)
        {
            return await _context.ProductTags
                .Where(pt => pt.ProductId == productId)
                .Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId)
        {
            return await _context.ProductTags
                .Where(pt => pt.TagId == tagId)
                .Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public void Remove(ProductTag productTag)
        {
            _context.ProductTags.Remove(productTag);
        }

        public async void UnassignProductTag(int productId, int tagId)
        {
            ProductTag productTag = await _context.ProductTags.FindAsync(productId, tagId);
            if (productTag != null)
            {
                Remove(productTag);
            }
        }
    }
}
