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
                var location = new Location
                {
                    LocationID = _locationId,
                    LocationName = txtLocationName.Text,
                    Description = txtDescription.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };

                var response = await FetchService.Instance.PutAsync<Location>($"{GlobalConfig.BASE_URL}/location/{_locationId}", location);

                if (response.Success)
                {
                    MessageBox.Show("Location đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật Location: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var location = new Location
                {
                    LocationName = txtLocationName.Text,
                    Description = txtDescription.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };

                var response = await FetchService.Instance.PostAsync<Location>($"{GlobalConfig.BASE_URL}/location", location);

                if (response.Success)
                {
                    MessageBox.Show("Location đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm Location: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeLocationControl_Load(object sender, EventArgs e)
        {
            // Load logic if necessary
        }
    }
}
