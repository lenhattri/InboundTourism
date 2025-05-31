using Base.Utils.Hash;
using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;


namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingService _bookingService;

        public UserService(IUserRepository userRepository, IBookingService bookingService)
        {
            _userRepository = userRepository;
            _bookingService = bookingService;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(Guid userId)
        {
            return _userRepository.GetById(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public void AddUser(User user)
        {
            var existingPhoneUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.UserID != user.UserID)
            {
                throw new Exception("Số điện thoại đã được sử dụng bởi một người dùng khác.");
            }

            var existingEmailUser = _userRepository.GetByEmail(user.Email);
            if (existingEmailUser != null && existingEmailUser.UserID != user.UserID)
            {
                throw new Exception("Email đã được sử dụng bởi một người dùng khác.");
            }

            var usersWithSameName = _userRepository.Find(fullName: user.FullName).Where(u => u.UserID != user.UserID);
            if (usersWithSameName.Any())
            {
                throw new Exception("Tên người dùng đã tồn tại.");
            }
            user.Password = HashPassword.Hash(user.Password);
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            
            var existingPhoneUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.UserID != user.UserID)
            {
                throw new Exception("Số điện thoại đã được sử dụng bởi một người dùng khác.");
            }

            var existingEmailUser = _userRepository.GetByEmail(user.Email);
            if (existingEmailUser != null && existingEmailUser.UserID != user.UserID)
            {
                throw new Exception("Email đã được sử dụng bởi một người dùng khác.");
            }

            var usersWithSameName = _userRepository.Find(fullName: user.FullName).Where(u => u.UserID != user.UserID);
            if (usersWithSameName.Any())
            {
                throw new Exception("Tên người dùng đã tồn tại.");
            }

            _userRepository.Update(user);
        }

        public void DeleteUser(Guid userId)
        {
            // Tìm tất cả các booking của user
            var userBookings = _bookingService.FindBookingsByUserId(userId);

            // Xóa tất cả các booking liên quan đến user
            foreach (var booking in userBookings)
            {
                _bookingService.DeleteBooking(booking.BookingID);
            }

            // Sau khi xóa hết booking, tiến hành xóa user
            _userRepository.Delete(userId);
        }

        public IEnumerable<User> FindUsers(string fullName = null, string email = null, string phoneNumber = null)
        {
            return _userRepository.Find(fullName, email, phoneNumber);
        }
    }
}
