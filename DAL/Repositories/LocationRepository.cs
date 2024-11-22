using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;
using Base.Config;
namespace DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public List<Location> GetAll()
        {
            var locations = new List<Location>();
            Console.WriteLine("Bắt đầu phương thức GetAll.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT LocationID, LocationName, Description, City, Country FROM Locations";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var location = new Location
                            {
                                LocationID = reader.GetGuid(reader.GetOrdinal("LocationID")),
                                LocationName = reader.GetString(reader.GetOrdinal("LocationName")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Country = reader.GetString(reader.GetOrdinal("Country"))
                            };
                            locations.Add(location);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các Location.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return locations;
        }

        public Location GetById(Guid id)
        {
            Console.WriteLine($"Bắt đầu GetById cho LocationID: {id}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT LocationID, LocationName, Description, City, Country FROM Locations WHERE LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", id);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetById.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Tìm thấy Location cho ID: {id}");
                            return new Location
                            {
                                LocationID = reader.GetGuid(reader.GetOrdinal("LocationID")),
                                LocationName = reader.GetString(reader.GetOrdinal("LocationName")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Country = reader.GetString(reader.GetOrdinal("Country"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy Location cho ID: {id}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetById cho LocationID {id}: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(Location location)
        {
            Console.WriteLine($"Bắt đầu Add cho LocationID: {location.LocationID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO Locations (LocationID, LocationName, Description, City, Country) " +
                               "VALUES (@LocationID, @LocationName, @Description, @City, @Country)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", location.LocationID);
                command.Parameters.AddWithValue("@LocationName", location.LocationName);
                command.Parameters.AddWithValue("@Description", location.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@City", location.City);
                command.Parameters.AddWithValue("@Country", location.Country);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới Location thành công với ID: {location.LocationID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add cho LocationID {location.LocationID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(Location location)
        {
            Console.WriteLine($"Bắt đầu Update cho LocationID: {location.LocationID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE Locations SET LocationName = @LocationName, Description = @Description, City = @City, Country = @Country " +
                               "WHERE LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", location.LocationID);
                command.Parameters.AddWithValue("@LocationName", location.LocationName);
                command.Parameters.AddWithValue("@Description", location.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@City", location.City);
                command.Parameters.AddWithValue("@Country", location.Country);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật Location thành công với ID: {location.LocationID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update cho LocationID {location.LocationID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid id)
        {
            Console.WriteLine($"Bắt đầu Delete cho LocationID: {id}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM Locations WHERE LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa Location thành công với ID: {id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete cho LocationID {id}: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Location> Find(string locationName = null, string city = null, string country = null)
        {
            Console.WriteLine($"Bắt đầu Find với filter - LocationName: {locationName}, City: {city}, Country: {country}");

            var locations = GetAll();

            if (!string.IsNullOrEmpty(locationName))
            {
                locations = locations.Where(l => l.LocationName.Contains(locationName, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho LocationName.");
            }

            if (!string.IsNullOrEmpty(city))
            {
                locations = locations.Where(l => l.City.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho City.");
            }

            if (!string.IsNullOrEmpty(country))
            {
                locations = locations.Where(l => l.Country.Contains(country, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho Country.");
            }

            Console.WriteLine($"Phương thức Find hoàn thành với {locations.Count} kết quả");
            return locations;
        }
    }
}
