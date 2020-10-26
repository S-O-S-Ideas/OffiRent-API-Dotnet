using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OffiRent.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }




        public async Task<IEnumerable<Reservation>> ListAsync()
        {
            return await _reservationRepository.ListAsync();
        }





        public async Task<ReservationResponse> DeleteAsync(int id)
        {
            var existingCategory = await _reservationRepository.FindById(id);

            if (existingCategory == null)
                return new ReservationResponse("Reservation not found");

            try
            {
                _reservationRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ReservationResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new ReservationResponse($"An error ocurred while deleting reservation: {ex.Message}");
            }
        }
        public async Task<ReservationResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _reservationRepository.FindById(id);
            if (existingCategory == null)
                return new ReservationResponse("Reservation not found");
            return new ReservationResponse(existingCategory);
        }







        public async Task<ReservationResponse> SaveAsync(Reservation reservation)
        {
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
            var existReservation = await _reservationRepository.FindById(id);

            if (existReservation == null)
                return new ReservationResponse("Reservation not found");

            existReservation.Id = reservation.Id;

            try
            {
                _reservationRepository.Update(existReservation);
                await _unitOfWork.CompleteAsync();

                return new ReservationResponse(existReservation);
            }
            catch (Exception ex)
            {
                return new ReservationResponse($"An error ocurred while updating reservation : {ex.Message}");
            }
        }
    }
}
