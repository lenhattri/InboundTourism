using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Base.Utils.Fetch;
using API.DTO; // Assuming the LoginRequest DTO is defined here
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
            txtPassword.PasswordChar = '●';
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Validate email format
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate password
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare the login request data
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                // Call the API for login
                var response = await FetchService.Instance.PostAsync<User>($"{GlobalConfig.BASE_URL}/auth/login", loginRequest);

                // Check if the API response is successful
                if (response.Success)
                {
                    var userRole = response.Data.Role; // Assuming the role is returned as part of the response

                    // Set user data in the context
                    UserContext.Instance.SetUserData(response.Data.FullName, userRole, email);

                    // Open the appropriate form based on user role
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

                    // Close the current login form
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
