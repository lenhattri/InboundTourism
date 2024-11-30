using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Base.Utils.Fetch;
using API.DTO; 
using Base.Context;
using Views.Forms;
using Core.Enums;
using Core.Entities;
using Base.Config;

namespace Views.UserControls.Auth
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●'; // Đặt ký tự mật khẩu là '●'
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra định dạng email
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Chuẩn bị dữ liệu yêu cầu đăng nhập
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                // Gọi API để đăng nhập
                var response = await FetchService.Instance.PostAsync<User>($"{GlobalConfig.BASE_URL}/auth/login", loginRequest);

                // Kiểm tra phản hồi từ API
                if (response.Success)
                {
                    var userRole = response.Data.Role; // Giả sử vai trò được trả về trong phản hồi

                    // Thiết lập dữ liệu người dùng trong context
                    UserContext.Instance.SetUserData(response.Data.FullName, userRole, email);

                    // Mở form phù hợp dựa trên vai trò người dùng
                    if (userRole == Role.Customer)
                    {
                        var customerForm = new CustomerForm();
                        customerForm.Show();
                    }
                    else if (userRole == Role.Admin)
                    {
                        var mainForm = new MainForm();
                        mainForm.Show();
                    }

                    // Đóng form đăng nhập hiện tại
                    ParentForm?.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại email hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
