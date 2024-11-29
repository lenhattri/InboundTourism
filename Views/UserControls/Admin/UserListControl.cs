using Base.Utils.Fetch;
using Core.Entities;
using System.ComponentModel;
using Views.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.UserControls.Loading;
using Base.Config;
using System;
using System.Collections.Generic;

namespace Views.UserControls.Admin
{
    public partial class UserListControl : UserControl
    {
        private readonly INavigationService _navigationService;
        private LoadingControl loadingControl1;

        public UserListControl(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            loadingControl1 = new LoadingControl
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            Controls.Add(loadingControl1);
            loadingControl1.BringToFront();
        }

        private void UserListControl_Load(object sender, EventArgs e)
        {
            InitializeColumns();
            LoadUsersAsync();
        }

        private void InitializeColumns()
        {
            dataGridView1.AutoGenerateColumns = false;

            AddTextBoxColumn("Họ và tên", "FullName");
            AddTextBoxColumn("Số điện thoại", "PhoneNumber");
            AddTextBoxColumn("Email", "Email");
            AddTextBoxColumn("Địa chỉ", "Address");
            AddTextBoxColumn("Vai trò", "Role");
        }

        private void AddTextBoxColumn(string headerText, string dataPropertyName)
        {
            var column = new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                DataPropertyName = dataPropertyName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView1.Columns.Add(column);
        }

        private async Task LoadUsersAsync()
        {
            loadingControl1.Visible = true;
            loadingControl1.BringToFront();
            this.Enabled = false;

            try
            {
                var response = await FetchService.Instance.GetAsync<List<User>>($"{GlobalConfig.BASE_URL}/user");

                if (response.Success)
                {
                    dataGridView1.DataSource = new BindingList<User>(response.Data);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách người dùng: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingControl1.Visible = false;
                this.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("ChangeUser");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn bất kỳ người dùng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var user = selectedRow.DataBoundItem as User;

            if (user != null)
            {
                _navigationService.NavigateTo("ChangeUser", user);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn bất kỳ người dùng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var user = selectedRow.DataBoundItem as User;

            if (user != null)
            {
                DeleteUserAsync(user);
            }
        }

        private async Task DeleteUserAsync(User user)
        {
            var confirmDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.Yes)
            {
                loadingControl1.Visible = true;
                loadingControl1.BringToFront();
                this.Enabled = false;

                try
                {
                    var response = await FetchService.Instance.DeleteAsync($"{GlobalConfig.BASE_URL}/user/{user.UserID}");

                    if (response.Success)
                    {
                        await LoadUsersAsync();
                        MessageBox.Show("Người dùng đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi xóa người dùng: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    loadingControl1.Visible = false;
                    this.Enabled = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }
    }
}
