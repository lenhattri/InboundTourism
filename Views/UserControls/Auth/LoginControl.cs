using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Base.Auth;
using Base.Context;
using Views.Forms;
using Core.Enums;

namespace Views.UserControls.Auth
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●'; // Hiển thị dạng mật khẩu
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thực hiện đăng nhập và nhận vai trò
                (bool isSuccess, Role userRole) = await Authentication.SignIn(email, password);

                if (isSuccess)
                {
                    // Lưu thông tin người dùng
                    UserContext.Instance.SetUserData(email, userRole, email);

                    // Điều hướng dựa trên vai trò
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

                    // Ẩn form hiện tại
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
