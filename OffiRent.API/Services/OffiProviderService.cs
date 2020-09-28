using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Services
{
    public class OffiProviderService : IOffiProviderService
    {
        private readonly IOffiProviderRepository _offiProviderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OffiProviderService(IOffiProviderRepository offiProviderRepository, IUnitOfWork unitOfWork)
        {
            _offiProviderRepository = offiProviderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OffiProviderResponse> DeleteAsync(int id)
        {
            var existingOffiProvider = await _offiProviderRepository.GetSingleByIdAsync(id);

            if (existingOffiProvider == null)
                return new OffiProviderResponse("OffiProvider not found");

            try
            {
                _offiProviderRepository.Remove(existingOffiProvider);
                await _unitOfWork.CompleteAsync();

                return new OffiProviderResponse(existingOffiProvider);
            }
            catch (Exception ex)
            {
                return new OffiProviderResponse($"An error ocurred while deleting OffiProvider: {ex.Message}");
            }
        }

        public async Task<OffiProviderResponse> GetBySingleIdAsync(int id)
        {
            var existingOffiProvider = await _offiProviderRepository.GetSingleByIdAsync(id);
            if (existingOffiProvider == null)
                return new OffiProviderResponse("OffiProvider not found");
            return new OffiProviderResponse(existingOffiProvider);
        }

        public async Task<IEnumerable<OffiProvider>> ListAsync()
        {
            return await _offiProviderRepository.ListAsync();
        }

        public async Task<OffiProviderResponse> SaveAsync(OffiProvider offiProvider)
        {
            try
            {
                await _offiProviderRepository.AddAsync(offiProvider);
                await _unitOfWork.CompleteAsync();

                return new OffiProviderResponse(offiProvider);
            }
            catch (Exception ex)
            {
                return new OffiProviderResponse(
                    $"An error ocurred while saving the OffiProvider: {ex.Message}");
            }
        }
    }
}
