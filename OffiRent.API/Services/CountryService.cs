using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryResponse> DeleteAsync(int id)
        {
            var existingCountry = await _countryRepository.FindById(id);

            if (existingCountry == null)
                return new CountryResponse("Country not found");

            try
            {
                _countryRepository.Remove(existingCountry);
                await _unitOfWork.CompleteAsync();

                return new CountryResponse(existingCountry);
            }
            catch (Exception ex)
            {
                return new CountryResponse($"An error ocurred while deleting country: {ex.Message}");
            }
        }

        public async Task<CountryResponse> GetByIdAsync(int id)
        {
            var existingCountry = await _countryRepository.FindById(id);
            if (existingCountry == null)
                return new CountryResponse("Country not found");
            return new CountryResponse(existingCountry);
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _countryRepository.ListAsync();
        }

        public async Task<CountryResponse> SaveAsync(Country country)
        {
            try
            {
                await _countryRepository.AddAsync(country);
                await _unitOfWork.CompleteAsync();

                return new CountryResponse(country);
            }
            catch (Exception ex)
            {
                return new CountryResponse(
                    $"An error ocurred while saving the Country: {ex.Message}");
            }
        }

        public async Task<CountryResponse> UpdateAsync(int id, Country country)
        {
            var existingCountry = await _countryRepository.FindById(id);

            if (existingCountry == null)
                return new CountryResponse("Country not found");

            existingCountry.Name = country.Name;

            try
            {
                _countryRepository.Update(existingCountry);
                await _unitOfWork.CompleteAsync();

                return new CountryResponse(existingCountry);
            }
            catch (Exception ex)
            {
                return new CountryResponse($"An error ocurred while updating country: {ex.Message}");
            }
        }
    }
}
