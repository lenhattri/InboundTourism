using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Core.Entities;
using DAL.Interfaces;
using Core.Enums;
using Base.Config;
namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            var users = new List<User>();
            Console.WriteLine("Bắt đầu phương thức GetAll cho User.");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT UserID, Role, FullName, PhoneNumber, Email, Password, Address FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho phương thức GetAll.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                Role = (Role)reader.GetInt32(reader.GetOrdinal("Role")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"))
                            };
                            users.Add(user);
                        }
                    }
                    Console.WriteLine("Lấy dữ liệu thành công cho tất cả các User.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetAll: {ex.Message}");
                    throw;
                }
            }
            return users;
        }

        public User GetById(Guid userId)
        {
            Console.WriteLine($"Bắt đầu GetById cho UserID: {userId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT UserID, Role, FullName, PhoneNumber, Email, Password, Address FROM Users WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetById.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                Role = (Role)reader.GetInt32(reader.GetOrdinal("Role")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy User cho ID: {userId}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetById cho UserID {userId}: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public void Add(User user)
        {
            Console.WriteLine($"Bắt đầu Add cho UserID: {user.UserID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "INSERT INTO Users (UserID, Role, FullName, PhoneNumber, Email, Password, Address) VALUES (@UserID, @Role, @FullName, @PhoneNumber, @Email, @Password, @Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@Role", (int)user.Role);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Thêm mới User thành công với ID: {user.UserID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Add cho UserID {user.UserID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Update(User user)
        {
            Console.WriteLine($"Bắt đầu Update cho UserID: {user.UserID}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "UPDATE Users SET Role = @Role, FullName = @FullName, PhoneNumber = @PhoneNumber, Email = @Email, Password = @Password, Address = @Address WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@Role", (int)user.Role);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Cập nhật User thành công với ID: {user.UserID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Update cho UserID {user.UserID}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete(Guid userId)
        {
            Console.WriteLine($"Bắt đầu Delete cho UserID: {userId}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Xóa User thành công với ID: {userId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong Delete cho UserID {userId}: {ex.Message}");
                    throw;
                }
            }
        }

        public User GetByEmail(string email)
        {
            Console.WriteLine($"Bắt đầu GetByEmail với Email: {email}");

            using (SqlConnection connection = new SqlConnection(GlobalConfig.CONNECTION_STRING))
            {
                string query = "SELECT UserID, Role, FullName, PhoneNumber, Email, Password, Address FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    Console.WriteLine("Đã mở kết nối database cho GetByEmail.");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                Role = (Role)reader.GetInt32(reader.GetOrdinal("Role")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"))
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy User cho Email: {email}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi trong GetByEmail: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public IEnumerable<User> Find(string fullName = null, string email = null, string phoneNumber = null)
        {
            Console.WriteLine($"Bắt đầu Find với filter - FullName: {fullName}, Email: {email}, PhoneNumber: {phoneNumber}");

            var users = GetAll();

            if (!string.IsNullOrEmpty(fullName))
            {
                users = users.Where(u => u.FullName.Contains(fullName, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho FullName.");
            }

            if (!string.IsNullOrEmpty(email))
            {
                users = users.Where(u => u.Email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho Email.");
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                users = users.Where(u => u.PhoneNumber.Contains(phoneNumber, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine("Đã áp dụng filter cho PhoneNumber.");
            }

            Console.WriteLine($"Phương thức Find hoàn thành với {users.Count} kết quả");
            return users;
        }
    }
}
