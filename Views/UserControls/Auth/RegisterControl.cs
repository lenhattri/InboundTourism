using System;
using System.Windows.Forms;
using Core.Entities;
using System.Text.RegularExpressions;
using Base.Auth;

using Views.Forms;
using Base.Context;

namespace Views.UserControls.Auth
{
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●';
            txtConfirmPassword.PasswordChar = '●';
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
           
            string fullName = txtFullname.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string address = txtAddress.Text.Trim();

          
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng nhập tên đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 10 đến 11 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            var user = new User
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password,
                Address = address,
                Role = Core.Enums.Role.Customer 
            };

            try
            {
                
                await Base.Auth.Authentication.SignUp(user);

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UserContext.Instance.SetUserData(fullName, Core.Enums.Role.Customer, email);
                if (ParentForm != null)
                {

                    var mainForm = new MainForm();
                    mainForm.Show();

                    
                    ParentForm.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
