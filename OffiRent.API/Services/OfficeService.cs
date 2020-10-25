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
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;


        public OfficeService(IOfficeRepository officeRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public async Task<OfficeResponse> DeleteAsync(int id)
        {
            var existingOffice = await _officeRepository.FindById(id);

            if (existingOffice == null)
                return new OfficeResponse("Office not found");

            try
            {
                _officeRepository.Remove(existingOffice);
                await _unitOfWork.CompleteAsync();

                return new OfficeResponse(existingOffice);
            }
            catch (Exception ex)
            {
                return new OfficeResponse($"An error ocurred while deleting Office: {ex.Message}");
            }
        }

        public async Task<OfficeResponse> GetByIdAsync(int id)
        {
            var existingOffice = await _officeRepository.FindById(id);
            if (existingOffice == null)
                return new OfficeResponse("Office not found");
            return new OfficeResponse(existingOffice);
        }

        public async Task<IEnumerable<Office>> ListAsync()
        {
            return await _officeRepository.ListAsync();
        }

        public async Task<IEnumerable<Office>> ListByDistrictIdAsync(int districtId)
        {
            return await _officeRepository.ListByDistrictIdAsync(districtId);
        }

        public async Task<IEnumerable<Office>> ListByPriceEqualOrLowerThanAsync(int price)
        {
            return await _officeRepository.ListByPriceEqualOrLowerThanAsync(price);
        }

        public async Task<OfficeResponse> SaveAsync(Office office)
        {
            try
            {
                int accountId = office.AccountId;
                var account = await _accountRepository.GetSingleByIdAsync(accountId);
                bool isPremium = account.IsPremium;

                List<Office> accountOffices = (List<Office>)await _officeRepository.ListAccountOfficesAsync(accountId);

                if (isPremium)
                {
                    if (accountOffices.Count > 14)
                    {
                        return new OfficeResponse("Your type of account cannot have more than 15 posts at the same time");
                    }
                } 
                else
                {
                    if (accountOffices.Count > 0)
                    {
                        return new OfficeResponse("Your type of account cannot have more than 1 post at the same time");
                    }
                }
                  
                await _officeRepository.AddAsync(office);
                await _unitOfWork.CompleteAsync();
                return new OfficeResponse(office);
            }
            catch (Exception ex)
            {
                return new OfficeResponse(
                    $"An error ocurred while saving the office: {ex.Message}");
            }
        }

        public async Task<OfficeResponse> UpdateAsync(int id, Office office)
        {
            var existingOffice = await _officeRepository.FindById(id);

            if (existingOffice == null)
                return new OfficeResponse("Office not found");

            existingOffice.Address = office.Address;
            existingOffice.Floor = office.Floor;
            existingOffice.Capacity = office.Capacity;
            existingOffice.AllowResource = office.AllowResource;
            existingOffice.Score = office.Score;
            existingOffice.Description = office.Description;
            existingOffice.Price = office.Price;
            existingOffice.Comment = office.Comment;
            existingOffice.Status = office.Status;
            existingOffice.DistrictId = office.DistrictId;

            try
            {
                _officeRepository.Update(existingOffice);
                await _unitOfWork.CompleteAsync();

                return new OfficeResponse(existingOffice);
            }
            catch (Exception ex)
            {
                return new OfficeResponse($"An error ocurred while deleting Office: {ex.Message}");
            }
        }
    }
}
