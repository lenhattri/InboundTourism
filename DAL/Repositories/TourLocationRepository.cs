using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Core.Entities;
using DAL.Interfaces;
using Base.Config;

namespace DAL.Repositories
{
    public class TourLocationRepository : ITourLocationRepository
    {
        public List<TourLocation> GetAll()
        {
            var tourLocations = new List<TourLocation>();
            Console.WriteLine("Bắt đầu phương thức GetAll cho TourLocation.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TourID, LocationID, LocationIndex FROM TourLocations";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tourLocation = new TourLocation
                            {
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                LocationID = reader.GetGuid(reader.GetOrdinal("LocationID")),
                                LocationIndex = reader.GetInt32(reader.GetOrdinal("LocationIndex"))
                            };
                            tourLocations.Add(tourLocation);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các TourLocation.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return tourLocations;
        }

        public TourLocation GetByTourAndLocationId(Guid tourId, Guid locationId)
        {
            Console.WriteLine($"Bắt đầu GetByTourAndLocationId cho TourID: {tourId} và LocationID: {locationId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TourID, LocationID, LocationIndex FROM TourLocations WHERE TourID = @TourID AND LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tourId);
                command.Parameters.AddWithValue("@LocationID", locationId);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetByTourAndLocationId.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TourLocation
                            {
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                LocationID = reader.GetGuid(reader.GetOrdinal("LocationID")),
                                LocationIndex = reader.GetInt32(reader.GetOrdinal("LocationIndex"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy TourLocation cho TourID: {tourId} và LocationID: {locationId}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetByTourAndLocationId: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(TourLocation tourLocation)
        {
            Console.WriteLine($"Bắt đầu Add cho TourID: {tourLocation.TourID} và LocationID: {tourLocation.LocationID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO TourLocations (TourID, LocationID, LocationIndex) VALUES (@TourID, @LocationID, @LocationIndex)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tourLocation.TourID);
                command.Parameters.AddWithValue("@LocationID", tourLocation.LocationID);
                command.Parameters.AddWithValue("@LocationIndex", tourLocation.LocationIndex);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới TourLocation thành công với TourID: {tourLocation.TourID} và LocationID: {tourLocation.LocationID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(TourLocation tourLocation)
        {
            Console.WriteLine($"Bắt đầu Update cho TourID: {tourLocation.TourID} và LocationID: {tourLocation.LocationID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE TourLocations SET LocationIndex = @LocationIndex WHERE TourID = @TourID AND LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tourLocation.TourID);
                command.Parameters.AddWithValue("@LocationID", tourLocation.LocationID);
                command.Parameters.AddWithValue("@LocationIndex", tourLocation.LocationIndex);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật TourLocation thành công với TourID: {tourLocation.TourID} và LocationID: {tourLocation.LocationID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid tourId, Guid locationId)
        {
            Console.WriteLine($"Bắt đầu Delete cho TourID: {tourId} và LocationID: {locationId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM TourLocations WHERE TourID = @TourID AND LocationID = @LocationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tourId);
                command.Parameters.AddWithValue("@LocationID", locationId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa TourLocation thành công với TourID: {tourId} và LocationID: {locationId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<TourLocation> FindByTourId(Guid tourId)
        {
            Console.WriteLine($"Bắt đầu FindByTourId với TourID: {tourId}");

            var tourLocations = GetAll();
            return tourLocations.Where(tl => tl.TourID == tourId);
        }

        public IEnumerable<TourLocation> FindByLocationId(Guid locationId)
        {
            Console.WriteLine($"Bắt đầu FindByLocationId với LocationID: {locationId}");

            var tourLocations = GetAll();
            return tourLocations.Where(tl => tl.LocationID == locationId);
        }
    }
}
