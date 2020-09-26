using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;
using Supermarket.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class CountryCurrencyService : ICountryCurrencyService
    {
        private readonly ICountryCurrencyRepository _countrycurrencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryCurrencyService(ICountryCurrencyRepository countrycurrencyRepository, IUnitOfWork unitOfWork)
        {
            _countrycurrencyRepository = countrycurrencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryCurrencyResponse> AssignCountryCurrencyAsync(int countryId, int currencyId)
        {
            try
            {
                await _countrycurrencyRepository.AssignCountryCurrency(countryId, currencyId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new CountryCurrencyResponse($"An error ocurred while assigning Country and Currency: {ex.Message}");
            }

            return new CountryCurrencyResponse(await _countrycurrencyRepository.FindByCountryIdAndCurrencyId(countryId, currencyId));
        }

        public async Task<IEnumerable<CountryCurrency>> ListAsync()
        {
            return await _countrycurrencyRepository.ListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId)
        {
            return await _countrycurrencyRepository.ListByCountryIdAsync(countryId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId)
        {
            return await _countrycurrencyRepository.ListByCurrencyIdAsync(currencyId);
        }

       public async Task<CountryCurrencyResponse> UnassignCountryCurrencyAsync(int countryId, int currencyId)
        {
            try
            {
                CountryCurrency countryCurrency = await _countrycurrencyRepository.FindByCountryIdAndCurrencyId(countryId, currencyId);
                _countrycurrencyRepository.Remove(countryCurrency);
                await _unitOfWork.CompleteAsync();
                return new CountryCurrencyResponse(countryCurrency);
            }
            catch (Exception ex)
            {
                return new CountryCurrencyResponse($"An error ocurred while assigning Currency to Country: {ex.Message}");
            }
        }

    }
}
