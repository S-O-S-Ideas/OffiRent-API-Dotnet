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
    public class OffiUserService : IOffiUserService
    {
        private readonly IOffiUserRepository _offiUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OffiUserService(IOffiUserRepository offiUserRepository, IUnitOfWork unitOfWork)
        {
            _offiUserRepository = offiUserRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OffiUserResponse> DeleteAsync(int id)
        {
            var existingOffiUser = await _offiUserRepository.GetSingleByIdAsync(id);

            if (existingOffiUser == null)
                return new OffiUserResponse("OffiUser not found");

            try
            {
                _offiUserRepository.Remove(existingOffiUser);
                await _unitOfWork.CompleteAsync();

                return new OffiUserResponse(existingOffiUser);
            }
            catch (Exception ex)
            {
                return new OffiUserResponse($"An error ocurred while deleting OffiUser: {ex.Message}");
            }
        }

        public async Task<OffiUserResponse> GetBySingleIdAsync(int id)
        {
            var existingOffiUser = await _offiUserRepository.GetSingleByIdAsync(id);
            if (existingOffiUser == null)
                return new OffiUserResponse("OffiUser not found");
            return new OffiUserResponse(existingOffiUser);
        }

        public async Task<IEnumerable<OffiUser>> ListAsync()
        {
            return await _offiUserRepository.ListAsync();
        }

        public async Task<OffiUserResponse> SaveAsync(OffiUser offiUser)
        {
            try
            {
                await _offiUserRepository.AddAsync(offiUser);
                await _unitOfWork.CompleteAsync();

                return new OffiUserResponse(offiUser);
            }
            catch (Exception ex)
            {
                return new OffiUserResponse(
                    $"An error ocurred while saving the OffiUser: {ex.Message}");
            }
        }
    }
}
