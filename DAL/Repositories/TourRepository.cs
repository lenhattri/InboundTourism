using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Core.Entities;
using DAL.Interfaces;
using Base.Config;
namespace DAL.Repositories
{
    public class TourRepository : ITourRepository
    {
        public List<Tour> GetAll()
        {
            var tours = new List<Tour>();
            Console.WriteLine("Bắt đầu phương thức GetAll cho Tour.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TourID, TourName, Description FROM Tours";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tour = new Tour
                            {
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                TourName = reader.GetString(reader.GetOrdinal("TourName")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                            };
                            tours.Add(tour);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các Tour.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return tours;
        }

        public Tour GetById(Guid id)
        {
            Console.WriteLine($"Bắt đầu GetById cho TourID: {id}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT TourID, TourName, Description FROM Tours WHERE TourID = @TourID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", id);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetById.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Tìm thấy Tour cho ID: {id}");
                            return new Tour
                            {
                                TourID = reader.GetGuid(reader.GetOrdinal("TourID")),
                                TourName = reader.GetString(reader.GetOrdinal("TourName")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy Tour cho ID: {id}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetById cho TourID {id}: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(Tour tour)
        {
            Console.WriteLine($"Bắt đầu Add cho TourID: {tour.TourID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO Tours (TourID, TourName, Description) VALUES (@TourID, @TourName, @Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tour.TourID);
                command.Parameters.AddWithValue("@TourName", tour.TourName);
                command.Parameters.AddWithValue("@Description", tour.Description ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới Tour thành công với ID: {tour.TourID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add cho TourID {tour.TourID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(Tour tour)
        {
            Console.WriteLine($"Bắt đầu Update cho TourID: {tour.TourID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE Tours SET TourName = @TourName, Description = @Description WHERE TourID = @TourID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", tour.TourID);
                command.Parameters.AddWithValue("@TourName", tour.TourName);
                command.Parameters.AddWithValue("@Description", tour.Description ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật Tour thành công với ID: {tour.TourID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update cho TourID {tour.TourID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid id)
        {
            Console.WriteLine($"Bắt đầu Delete cho TourID: {id}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM Tours WHERE TourID = @TourID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TourID", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa Tour thành công với ID: {id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete cho TourID {id}: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Tour> Find(string tourName = null)
        {
            Console.WriteLine($"Bắt đầu Find với filter - TourName: {tourName}");

            var tours = GetAll();

            if (!string.IsNullOrEmpty(tourName))
            {
                tours = tours.Where(t => t.TourName.Contains(tourName, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho TourName.");
            }

            Console.WriteLine($"Phương thức Find hoàn thành với {tours.Count} kết quả");
            return tours;
        }
    }
}
