using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Core.Entities;
using DAL.Interfaces;
using Base.Config;

namespace DAL.Repositories
{
    public class TripRepository : ITripRepository
    {
        public List<Trip> GetAll()
        {
            var trips = new List<Trip>();
            Console.WriteLine("Bắt đầu phương thức GetAll cho Trip.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TripID, TourID, Price, StartDate, EndDate, Distance, MaxGuests FROM Trips";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var trip = new Trip
                            {
                                TripID = reader.GetGuid(reader.GetOrdinal("TripID")),
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                Distance = reader.GetDouble(reader.GetOrdinal("Distance")),
                                MaxGuests = reader.GetInt32(reader.GetOrdinal("MaxGuests"))
                            };
                            trips.Add(trip);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các Trip.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return trips;
        }

        public Trip GetById(Guid tripId)
        {
            Console.WriteLine($"Bắt đầu GetById cho TripID: {tripId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TripID, TourID, Price, StartDate, EndDate, Distance, MaxGuests FROM Trips WHERE TripID = @TripID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripID", tripId);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetById.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Trip
                            {
                                TripID = reader.GetGuid(reader.GetOrdinal("TripID")),
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                Distance = reader.GetDouble(reader.GetOrdinal("Distance")),
                                MaxGuests = reader.GetInt32(reader.GetOrdinal("MaxGuests"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy Trip cho ID: {tripId}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetById cho TripID {tripId}: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(Trip trip)
        {
            Console.WriteLine($"Bắt đầu Add cho TripID: {trip.TripID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO Trips (TripID, TourID, Price, StartDate, EndDate, Distance, MaxGuests) " +
                               "VALUES (@TripID, @TourID, @Price, @StartDate, @EndDate, @Distance, @MaxGuests)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripID", trip.TripID);
                command.Parameters.AddWithValue("@TourID", trip.TourID);
                command.Parameters.AddWithValue("@Price", trip.Price);
                command.Parameters.AddWithValue("@StartDate", trip.StartDate);
                command.Parameters.AddWithValue("@EndDate", trip.EndDate);
                command.Parameters.AddWithValue("@Distance", trip.Distance);
                command.Parameters.AddWithValue("@MaxGuests", trip.MaxGuests);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới Trip thành công với ID: {trip.TripID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add cho TripID {trip.TripID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(Trip trip)
        {
            Console.WriteLine($"Bắt đầu Update cho TripID: {trip.TripID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE Trips SET TourID = @TourID, Price = @Price, StartDate = @StartDate, EndDate = @EndDate, Distance = @Distance, MaxGuests = @MaxGuests " +
                               "WHERE TripID = @TripID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripID", trip.TripID);
                command.Parameters.AddWithValue("@TourID", trip.TourID);
                command.Parameters.AddWithValue("@Price", trip.Price);
                command.Parameters.AddWithValue("@StartDate", trip.StartDate);
                command.Parameters.AddWithValue("@EndDate", trip.EndDate);
                command.Parameters.AddWithValue("@Distance", trip.Distance);
                command.Parameters.AddWithValue("@MaxGuests", trip.MaxGuests);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật Trip thành công với ID: {trip.TripID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update cho TripID {trip.TripID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid tripId)
        {
            Console.WriteLine($"Bắt đầu Delete cho TripID: {tripId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM Trips WHERE TripID = @TripID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripID", tripId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa Trip thành công với ID: {tripId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete cho TripID {tripId}: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Trip> FindByTourId(Guid tourId)
        {
            Console.WriteLine($"Bắt đầu FindByTourId với TourID: {tourId}");

            var trips = GetAll();
            return trips.Where(t => t.TourID == tourId);
        }

        public IEnumerable<Trip> Find(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null)
        {
            Console.WriteLine($"Bắt đầu Find với filter - StartDate: {startDate}, EndDate: {endDate}, MaxPrice: {maxPrice}");

            var trips = GetAll();

            if (startDate.HasValue)
            {
                trips = trips.Where(t => t.StartDate >= startDate.Value).ToList();
                Console.WriteLine("Đã áp dụng filter cho StartDate.");
            }

            if (endDate.HasValue)
            {
                trips = trips.Where(t => t.EndDate <= endDate.Value).ToList();
                Console.WriteLine("Đã áp dụng filter cho EndDate.");
            }

            if (maxPrice.HasValue)
            {
                trips = trips.Where(t => t.Price <= maxPrice.Value).ToList();
                Console.WriteLine("Đã áp dụng filter cho MaxPrice.");
            }

            Console.WriteLine($"Phương thức Find hoàn thành với {trips.Count} kết quả");
            return trips;
        }
    }
}
