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


                var result = await FetchService.Instance.PutAsync<Location>($"{GlobalConfig.BASE_URL}/{_locationId}", location);


                MessageBox.Show("Location đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Lỗi khi cập nhật Location: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ChangeLocationControl_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
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


                var result = await FetchService.Instance.PostAsync<Location>($"{GlobalConfig.BASE_URL}/location", location);


                MessageBox.Show("Location đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Location: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
