using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITripService _tripService;

        public BookingService(IBookingRepository bookingRepository, ITripService tripService)
        {
            _bookingRepository = bookingRepository;
            _tripService = tripService;
        }

        // Lấy danh sách tất cả các booking
        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetAll();
        }

        
        public Booking GetBookingById(Guid bookingId)
        {
            return _bookingRepository.GetById(bookingId);
        }

        
        public void AddBooking(Booking booking)
        {
            var trip = _tripService.GetTripById(booking.TripID);
            if (trip == null)
            {
               
                throw new ArgumentException("Mã chuyến đi không hợp lệ. Chuyến đi không tồn tại.");
            }

            ValidateBooking(booking, trip);

            
            _bookingRepository.Add(booking);
        }

     
        public void UpdateBooking(Booking booking)
        {
            
            var trip = _tripService.GetTripById(booking.TripID);
            if (trip == null)
            {
                throw new ArgumentException("Mã chuyến đi không hợp lệ. Chuyến đi không tồn tại.");
            }

           
            ValidateBooking(booking, trip, isUpdate: true);

            // Nếu hợp lệ, cập nhật thông tin booking
            _bookingRepository.Update(booking);
        }

        // Xóa một booking dựa trên BookingID
        public void DeleteBooking(Guid bookingId)
        {
            _bookingRepository.Delete(bookingId);
        }

        // Tìm kiếm các booking theo UserID (dành cho người dùng)
        public IEnumerable<Booking> FindBookingsByUserId(Guid userId)
        {
            return _bookingRepository.FindByUserId(userId);
        }

        // Tìm kiếm các booking theo TripID
        public IEnumerable<Booking> FindBookingsByTripId(Guid tripId)
        {
            return _bookingRepository.FindByTripId(tripId);
        }

        // Tìm kiếm các booking trong khoảng thời gian cụ thể
        public IEnumerable<Booking> FindBookings(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _bookingRepository.Find(startDate, endDate);
        }

        // Hàm kiểm tra số lượng vé có hợp lệ hay không
        private void ValidateBooking(Booking booking, Trip trip, bool isUpdate = false)
        {
          
            var totalBookedTickets = _bookingRepository
                .FindByTripId(booking.TripID)
                .Where(b => !isUpdate || b.BookingID != booking.BookingID) // Loại trừ booking hiện tại nếu đang cập nhật
                .Sum(b => b.NumberOfGuests);

            // Kiểm tra nếu tổng số vé sau khi thêm/cập nhật vượt quá số vé tối đa của chuyến đi
            if (totalBookedTickets + booking.NumberOfGuests > trip.MaxGuests)
            {
                // Ném lỗi nếu số vé không đủ
                throw new InvalidOperationException("Tổng số vé đặt cho chuyến đi vượt quá số lượng vé tối đa có thể đặt.");
            }
        }
    }
}
