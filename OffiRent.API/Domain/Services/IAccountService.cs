using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Services.Communications;

namespace OffiRent.API.Domain.Services
{
    public interface IAccountService
    {

        Task<IEnumerable<Account>> ListAsync();
        Task<AccountResponse> GetBySingleIdAsync(int id);
        Task<AccountResponse> GetBySinglePhoneNumberAsync(string phoneNumber);
        Task<AccountResponse> GetBySingleEmailAsync(string email);
        Task<AccountResponse> SaveAsync(Account account);
        //Task<AccountResponse> UpdateAsync(int id, Category category);
        Task<AccountResponse> DeleteAsync(int id);
    }
}
