using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OffiRent.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IReservationRepository reservationRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reservation>> ListAsync()
        {
            return await _reservationRepository.ListAsync();
        }



        public async Task<ReservationResponse> DeleteAsync(int id)
        {
            var existingReservation = await _reservationRepository.FindById(id);

            if (existingReservation == null)
                return new ReservationResponse("Reservation not found");

            try
            {
                _reservationRepository.Remove(existingReservation);
                await _unitOfWork.CompleteAsync();

                return new ReservationResponse(existingReservation);
            }
            catch (Exception ex)
            {
                return new ReservationResponse($"An error ocurred while deleting reservation: {ex.Message}");
            }
        }
        public async Task<ReservationResponse> GetByIdAsync(int id)
        {
            var existingReservation = await _reservationRepository.FindById(id);
            if (existingReservation == null)
                return new ReservationResponse("Reservation not found");
            return new ReservationResponse(existingReservation);
        }

        public async Task<ReservationResponse> SaveAsync(int accountId, Reservation reservation)
        {
            var existingAccount = await _accountRepository.GetSingleByIdAsync(accountId);

            if (existingAccount == null)
                return new ReservationResponse("Account Id not found");

            try
            {
                await _reservationRepository.AddAsync(reservation);
                await _unitOfWork.CompleteAsync();

                return new ReservationResponse(reservation);
            }
            catch (Exception ex)
            {
                return new ReservationResponse(
                    $"An error ocurred while saving the reservation: {ex.Message}");
            }
        }


        public async Task<ReservationResponse> UpdateAsync(int id, Reservation reservation)
        {
            var existingReservation = await _reservationRepository.FindById(id);

            if (existingReservation == null)
                return new ReservationResponse("Reservation not found");

            if (existingReservation == null)
                return new ReservationResponse("Category not found");


            existingReservation.InitialDate = reservation.InitialDate;
            existingReservation.FinishDate = reservation.FinishDate;
            existingReservation.Status = reservation.Status;
            

            try
            {
                _reservationRepository.Update(existingReservation);
                await _unitOfWork.CompleteAsync();

                return new ReservationResponse(existingReservation);
            }
            catch (Exception ex)
            {
                return new ReservationResponse($"An error ocurred while updating reservation : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Reservation>> ListByAccountIdAsync(int accountId)
        {
            return await _reservationRepository.ListByAccountIdAsync(accountId);
        }


    }
}
