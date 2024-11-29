using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Interfaces;
using Core.Entities;
using Core.Enums;
using Base.Utils.Fetch;
using Base.Config;

namespace Views.UserControls.Changing
{
    public partial class ChangeUserControl : UserControl, IParameterReceiver
    {
        private Guid _userId;
        private Role role;
        public ChangeUserControl()
        {
            InitializeComponent();
            btnChange.Visible = false;
            btnAdd.Visible = false;

            // Gắn sự kiện cho nút
            btnChange.Click += async (sender, e) => await BtnChange_Click(sender, e);
            btnAdd.Click += async (sender, e) => await BtnAdd_Click(sender, e);
            cbRole.SelectedIndexChanged += CbRole_SelectedIndexChanged;
        }
        private void CbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRole = cbRole.SelectedItem.ToString();
            if (selectedRole == "Admin")
            {
                role = Role.Admin;
            }
            else if (selectedRole == "Customer")
            {
                role = Role.Customer;
            }
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is User user)
            {
                string roleDisplay = user.Role == Role.Admin ? "Admin" : "Customer";
                _userId = user.UserID;
                txtFullname.Text = user.FullName;
                txtPhoneNumber.Text = user.PhoneNumber;
                txtEmail.Text = user.Email;
                txtPassword.Enabled = false;
                txtAddress.Text = user.Address;

                cbRole.SelectedItem = roleDisplay;
                role = user.Role;
                btnChange.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
            }
        }


        private async Task BtnChange_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    UserID = _userId,
                    FullName = txtFullname.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Role = role
                };
                MessageBox.Show($"Thông tin người dùng chuẩn bị cập nhật:\n" +
                      $"- ID: {user.UserID}\n" +
                      $"- Tên: {user.FullName}\n" +
                      $"- SĐT: {user.PhoneNumber}\n" +
                      $"- Email: {user.Email}\n" +
                      $"- Địa chỉ: {user.Address}\n" +
                      $"- Vai trò: {role}",
                      "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var response = await FetchService.Instance.PutAsync<User>($"{GlobalConfig.BASE_URL}/user/{_userId}", user);

                if (response.Success)
                {
                    MessageBox.Show("Người dùng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    FullName = txtFullname.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Role = role,
                };
                //MessageBox.Show($"Thông tin người dùng chuẩn bị cập nhật:\n" +
                //      $"- ID: {user.UserID}\n" +
                //      $"- Tên: {user.FullName}\n" +
                //      $"- SĐT: {user.PhoneNumber}\n" +
                //      $"- Email: {user.Email}\n" +
                //      $"- Địa chỉ: {user.Address}\n" +
                //      $"- Vai trò: {user.Role}",
                //      "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var response = await FetchService.Instance.PostAsync<User>($"{GlobalConfig.BASE_URL}/user", user);

                if (response.Success)
                {
                    MessageBox.Show("Người dùng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm tải dữ liệu lên cbRole, bỏ qua giá trị None
        private void ChangeUserControl_Load(object sender, EventArgs e)
        {
            List<string> roles = new List<string> { "Admin", "Customer" };

            cbRole.DataSource = roles;
        }
    }
}
