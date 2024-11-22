
using System.Data;
using Microsoft.Data.SqlClient;
using Core.Entities;
using DAL.Interfaces;
using Base.Config;
namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();
            Console.WriteLine("Bắt đầu phương thức GetAll cho Booking.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT BookingID, TripID, UserID, BookingDate, NumberOfGuests, TotalPrice FROM Bookings";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var booking = new Booking
                            {
                                BookingID = reader.GetGuid(reader.GetOrdinal("BookingID")),
                                TripID = reader.GetGuid(reader.GetOrdinal("TripID")),
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                                NumberOfGuests = reader.GetInt32(reader.GetOrdinal("NumberOfGuests")),
                                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"))
                            };
                            bookings.Add(booking);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các Booking.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return bookings;
        }

        public Booking GetById(Guid bookingId)
        {
            Console.WriteLine($"Bắt đầu GetById cho BookingID: {bookingId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT BookingID, TripID, UserID, BookingDate, NumberOfGuests, TotalPrice FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", bookingId);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetById.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Booking
                            {
                                BookingID = reader.GetGuid(reader.GetOrdinal("BookingID")),
                                TripID = reader.GetGuid(reader.GetOrdinal("TripID")),
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                                NumberOfGuests = reader.GetInt32(reader.GetOrdinal("NumberOfGuests")),
                                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy Booking cho ID: {bookingId}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetById cho BookingID {bookingId}: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(Booking booking)
        {
            Console.WriteLine($"Bắt đầu Add cho BookingID: {booking.BookingID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO Bookings (BookingID, TripID, UserID, BookingDate, NumberOfGuests, TotalPrice) " +
                               "VALUES (@BookingID, @TripID, @UserID, @BookingDate, @NumberOfGuests, @TotalPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                command.Parameters.AddWithValue("@TripID", booking.TripID);
                command.Parameters.AddWithValue("@UserID", booking.UserID);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@NumberOfGuests", booking.NumberOfGuests);
                command.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới Booking thành công với ID: {booking.BookingID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add cho BookingID {booking.BookingID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(Booking booking)
        {
            Console.WriteLine($"Bắt đầu Update cho BookingID: {booking.BookingID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE Bookings SET TripID = @TripID, UserID = @UserID, BookingDate = @BookingDate, " +
                               "NumberOfGuests = @NumberOfGuests, TotalPrice = @TotalPrice WHERE BookingID = @BookingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                command.Parameters.AddWithValue("@TripID", booking.TripID);
                command.Parameters.AddWithValue("@UserID", booking.UserID);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@NumberOfGuests", booking.NumberOfGuests);
                command.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật Booking thành công với ID: {booking.BookingID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update cho BookingID {booking.BookingID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid bookingId)
        {
            Console.WriteLine($"Bắt đầu Delete cho BookingID: {bookingId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", bookingId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa Booking thành công với ID: {bookingId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete cho BookingID {bookingId}: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Booking> FindByUserId(Guid userId)
        {
            Console.WriteLine($"Bắt đầu FindByUserId với UserID: {userId}");

            var bookings = GetAll();
            return bookings.Where(b => b.UserID == userId);
        }

        public IEnumerable<Booking> FindByTripId(Guid tripId)
        {
            Console.WriteLine($"Bắt đầu FindByTripId với TripID: {tripId}");

            var bookings = GetAll();
            return bookings.Where(b => b.TripID == tripId);
        }

        public IEnumerable<Booking> Find(DateTime? startDate = null, DateTime? endDate = null)
        {
            Console.WriteLine($"Bắt đầu Find với filter - StartDate: {startDate}, EndDate: {endDate}");

            var bookings = GetAll();

            if (startDate.HasValue)
            {
                bookings = bookings.Where(b => b.BookingDate >= startDate.Value).ToList();
                Console.WriteLine("Đã áp dụng filter cho StartDate.");
            }

            if (endDate.HasValue)
            {
                bookings = bookings.Where(b => b.BookingDate <= endDate.Value).ToList();
                Console.WriteLine("Đã áp dụng filter cho EndDate.");
            }

            Console.WriteLine($"Phương thức Find hoàn thành với {bookings.Count} kết quả");
            return bookings;
        }
    }
}
