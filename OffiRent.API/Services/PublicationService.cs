using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Domain.Services.Communications;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;




        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }





        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }





        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingCategory = await _publicationRepository.FindById(id);

            if (existingCategory == null)
                return new PublicationResponse("Category not found");

            try
            {
                _publicationRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting category: {ex.Message}");
            }
        }








        public async Task<PublicationResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _publicationRepository.FindById(id);
            if (existingCategory == null)
                return new PublicationResponse("Category not found");
            return new PublicationResponse(existingCategory);
        }







        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse(
                    $"An error ocurred while saving the category: {ex.Message}");
            }
        }


        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existPublication = await _publicationRepository.FindById(id);

            if (existPublication == null)
                return new PublicationResponse("Category not found");

            existPublication.Description = publication.Description;

            try
            {
                _publicationRepository.Update(existPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating category: {ex.Message}");
            }
        }
    }
}
