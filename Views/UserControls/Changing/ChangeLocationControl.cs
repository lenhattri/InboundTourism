using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Interfaces;
using Core.Entities;
using Base.Utils.Fetch;
using Base.Config;

namespace Views.UserControls.Changing
{
    public partial class ChangeLocationControl : UserControl, IParameterReceiver
    {
        private Guid _locationId;

        public ChangeLocationControl()
        {
            InitializeComponent();
            btnChange.Visible = false;
            btnAdd.Visible = false;

            btnChange.Click += async (sender, e) => await BtnChange_Click(sender, e);
            btnAdd.Click += async (sender, e) => await BtnAdd_Click(sender, e);
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is Location location)
            {
                _locationId = location.LocationID;
                txtLocationName.Text = location.LocationName;
                txtDescription.Text = location.Description;
                txtCity.Text = location.City;
                txtCountry.Text = location.Country;
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
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var location = new Location
                {
                    LocationID = _locationId,
                    LocationName = txtLocationName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                var response = await FetchService.Instance.PutAsync<Location>($"{GlobalConfig.BASE_URL}/location/{_locationId}", location);

                if (response.Success)
                {
                    MessageBox.Show("Địa điểm đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật địa điểm: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var location = new Location
                {
                    LocationName = txtLocationName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                var response = await FetchService.Instance.PostAsync<Location>($"{GlobalConfig.BASE_URL}/location", location);

                if (response.Success)
                {
                    MessageBox.Show("Địa điểm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm địa điểm: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocationName.Text))
            {
                MessageBox.Show("Tên địa điểm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocationName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Thành phố không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("Quốc gia không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
                return false;
            }

           

            return true;
        }

        private void ChangeLocationControl_Load(object sender, EventArgs e)
        {
            // Logic tải dữ liệu nếu cần thiết
        }
    }
}
