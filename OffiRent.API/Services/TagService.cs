using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TagResponse> DeleteAsync(int id)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found");
            try
            {
                _tagRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new TagResponse($"An error ocurred while deleting tag: {ex.Message}");
            }

        }

        public async Task<TagResponse> GetByIdAsync(int id)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found");
            return new TagResponse(existingTag);
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _tagRepository.ListAsync();
        }

        public async Task<IEnumerable<Tag>> ListByProductIdAsync(int productId)
        {
            var productTags = await _productTagRepository.ListByProductIdAsync(productId);
            var tags = productTags.Select(pt => pt.Tag).ToList();
            return tags;
        }

        public async Task<TagResponse> SaveAsync(Tag tag)
        {
            try
            {
                await _tagRepository.AddAsync(tag);
                await _unitOfWork.CompleteAsync();

                return new TagResponse(tag);
            }
            catch (Exception ex)
            {
                return new TagResponse($"An error ocurred while saving the tag: {ex.Message}");
            }
        }

        public async Task<TagResponse> UpdateAsync(int id, Tag tag)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found");

            try
            {
                existingTag.Name = tag.Name;
                _tagRepository.Update(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new TagResponse($"An error ocurred while updating the tag: {ex.Message}");
            }

        }
    }
}
