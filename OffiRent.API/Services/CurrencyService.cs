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
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CurrencyResponse> DeleteAsync(int id)
        {
            var existingCurency = await _currencyRepository.FindById(id);

            if (existingCurency == null)
                return new CurrencyResponse("Currency not found");

            try
            {
                _currencyRepository.Remove(existingCurency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(existingCurency);
            }
            catch (Exception ex)
            {
                return new CurrencyResponse($"An error ocurred while deleting currency: {ex.Message}");
            }
        }

        public async Task<CurrencyResponse> GetByIdAsync(int id)
        {
            var existingCurrency = await _currencyRepository.FindById(id);
            if (existingCurrency == null)
                return new CurrencyResponse("Currency not found");
            return new CurrencyResponse(existingCurrency);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await _currencyRepository.ListAsync();
        }

        public async Task<CurrencyResponse> SaveAsync(Currency currency)
        {
            try
            {
                await _currencyRepository.AddAsync(currency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(currency);
            }
            catch (Exception ex)
            {
                return new CurrencyResponse(
                    $"An error ocurred while saving the Currency: {ex.Message}");
            }
        }

        public async Task<CurrencyResponse> UpdateAsync(int id, Currency currency)
        {
            var existingCurrency = await _currencyRepository.FindById(id);

            if (existingCurrency == null)
                return new CurrencyResponse("Currency not found");

            existingCurrency.Name = currency.Name;

            try
            {
                _currencyRepository.Update(existingCurrency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(existingCurrency);
            }
            catch (Exception ex)
            {
                return new CurrencyResponse($"An error ocurred while updating currency: {ex.Message}");
            }
        }
    }
} 

