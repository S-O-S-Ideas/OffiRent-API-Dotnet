using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Domain.Services.Communications;

namespace OffiRent.API.Services
{
    public class AccountService : IAccountService 
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountPaymentMethodRepository _accountPaymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IAccountPaymentMethodRepository accountPaymentMethodRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _accountPaymentMethodRepository = accountPaymentMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Account account)
        {
            await _accountRepository.AddAsync(account);
        }

        //premium status
        public async Task<AccountResponse> UpdateSync(int id)
        {
                var existingAccount = await _accountRepository.GetSingleByIdAsync(id);

                if (existingAccount == null)
                    return new AccountResponse("Account not found");

                existingAccount.IsPremium = true;

                try
                {
                    _accountRepository.Update(existingAccount);
                    await _unitOfWork.CompleteAsync();

                    return new AccountResponse(existingAccount);
                }
                catch (Exception ex)
                {
                    return new AccountResponse($"An error ocurred while updating OffiProvider: {ex.Message}");
                }
            
        }


        public async Task<AccountResponse> DeleteAsync(int id)
        {
            var existingAccount = await _accountRepository.GetSingleByIdAsync(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");

            try
            {
                _accountRepository.Remove(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while deleting account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> GetBySingleEmailAsync(string email)
        {
            var existingAccount = await _accountRepository.GetByEmailAsync(email);
            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }

        public async Task<AccountResponse> GetBySingleIdAsync(int id)
        {
            var existingAccount = await _accountRepository.GetSingleByIdAsync(id);
            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }

        public async Task<AccountResponse> GetBySinglePhoneNumberAsync(string phoneNumber)
        {
            var existingAccount = await _accountRepository.GetByPhoneNumerAsync(phoneNumber);
            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }


        public async Task<AccountResponse> SaveAsync(Account account)
        {
            try
            {
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(account);
            }
            catch (Exception ex)
            {
                return new AccountResponse(
                    $"An error ocurred while saving the account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> UpdateAsync(int id, Account account)
        {
            var existingAccount = await _accountRepository.GetSingleByIdAsync(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");

            existingAccount.FirstName = account.FirstName;
            existingAccount.LastName = account.LastName;
            existingAccount.Email = account.Email;
            existingAccount.Password = account.Password;
            existingAccount.Identification = account.Identification;
            existingAccount.IsPremium = account.IsPremium;
            existingAccount.PhoneNumber = account.PhoneNumber;

            try
            {
                _accountRepository.Update(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while updating the account: {ex.Message}");
            }
        }


    }
}
