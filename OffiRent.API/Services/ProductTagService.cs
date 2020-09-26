using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ProductTagService : IProductTagService
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductTagResponse> AssignProductTagAsync(int productId, int tagId)
        {
            try
            {
                await _productTagRepository.AssignProductTag(productId, tagId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new ProductTagResponse($"An error ocurred while assigning Product and Tag: {ex.Message}");
            }

            return new ProductTagResponse(await _productTagRepository.FindByProductIdAndTagId(productId, tagId));

        }

        public async Task<IEnumerable<ProductTag>> ListAsync()
        {
            return await _productTagRepository.ListAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId)
        {
            return await _productTagRepository.ListByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId)
        {
            return await _productTagRepository.ListByTagIdAsync(tagId);
        }

        public async Task<ProductTagResponse> UnassignProductTagAsync(int productId, int tagId)
        {
            try
            {
                ProductTag productTag = await _productTagRepository.FindByProductIdAndTagId(productId, tagId);
                _productTagRepository.Remove(productTag);
                await _unitOfWork.CompleteAsync();
                return new ProductTagResponse(productTag);
            }
            catch (Exception ex)
            {
                return new ProductTagResponse($"An error ocurred while assigning Tag to Product: {ex.Message}");
            }

        }
    }
}
