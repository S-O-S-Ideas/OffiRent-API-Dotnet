using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> ListAsync();
        Task<IEnumerable<Office>> ListByDistrictIdAsync(int districtId);
        Task<IEnumerable<Office>> ListByPriceEqualOrLowerThanAsync(int price);
        Task<OfficeResponse> GetByIdAsync(int id);
        Task<OfficeResponse> SaveAsync(int accountId, Office Office);
        Task<OfficeResponse> UpdateAsync(int id, Office Office);
        Task<OfficeResponse> UpdateScoreAsync(int accountId, int officeId, Office office);
        Task<OfficeResponse> DeleteAsync(int id);
    }
}
