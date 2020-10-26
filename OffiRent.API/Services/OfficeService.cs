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
        private readonly IUnitOfWork _unitOfWork;

        public OfficeService(IOfficeRepository officeRepository, IUnitOfWork unitOfWork)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OfficeResponse> ActiveOffice(int id)
        {
            var inactiveOffice = await _officeRepository.FindById(id);

            if (inactiveOffice == null)
                return new OfficeResponse("Office not found");
            
            else if (inactiveOffice.Status == true)
                return new OfficeResponse("Office is already active");

            inactiveOffice.Status = true;

            try
            {
                _officeRepository.Remove(inactiveOffice);
                await _unitOfWork.CompleteAsync();

                return new OfficeResponse(inactiveOffice);
            }
            catch (Exception ex)
            {
                return new OfficeResponse($"An error ocurred while deleting Office: {ex.Message}");
            }


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

        public async Task<IEnumerable<Office>> ListByInactiveStatus(int providerId)
        {
            return await _officeRepository.ListByInactiveStatus(providerId);
        }

        public async Task<IEnumerable<Office>> ListByPriceEqualOrLowerThanAsync(int price)
        {
            return await _officeRepository.ListByPriceEqualOrLowerThanAsync(price);
        }

        public async Task<IEnumerable<Office>> ListByProviderIdAsync(int providerId)
        {
            return await _officeRepository.ListByProviderIdAsync(providerId);
        }

        public async Task<OfficeResponse> SaveAsync(Office Office)
        {
            Office.Status = true;

            try
            {
                await _officeRepository.AddAsync(Office);
                await _unitOfWork.CompleteAsync();

                return new OfficeResponse(Office);
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
