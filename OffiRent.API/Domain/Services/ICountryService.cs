using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync(int countryId);
        Task<CountryResponse> GetByIdAsync(int id);
        Task<CountryResponse> SaveAsync(Country country);
        Task<CountryResponse> UpdateAsync(int id, Country country);
        Task<CountryResponse> DeleteAsync(int id);
        Task ListByCountryIdAsync(int countryId);
    }
}

