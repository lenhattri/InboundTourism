using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.Utils.Fetch;
using Core.Entities;
using Base.Config;
using Views.Interfaces;

namespace Views.UserControls.Admin
{
    public partial class TripListControl : UserControl
    {
        private readonly INavigationService _navigationService;

        public TripListControl(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        private async void TripListControl_Load(object sender, EventArgs e)
        {
            InitializeColumns();
            await LoadTripsAsync();
        }

        private void InitializeColumns()
        {
            dataGridView1.AutoGenerateColumns = false;

            AddTextBoxColumn("Tên chuyến đi", "TourName"); 
            AddTextBoxColumn("Giá", "Price");
            AddTextBoxColumn("Ngày bắt đầu", "StartDate");
            AddTextBoxColumn("Ngày kết thúc", "EndDate");
            AddTextBoxColumn("Khoảng cách", "Distance");
            AddTextBoxColumn("Khách tối đa", "MaxGuests");
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

        private async Task LoadTripsAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<Trip>>($"{GlobalConfig.BASE_URL}/trip");

                if (response.Success)
                {
                
                    dataGridView1.DataSource = response.Data;
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách trips: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteTripAsync(Guid tripId)
        {
            var confirmDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa chuyến đi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.Yes)
            {
                try
                {
                    var response = await FetchService.Instance.DeleteAsync($"{GlobalConfig.BASE_URL}/trip/{tripId}");

                    if (response.Success)
                    {
                        await LoadTripsAsync();
                        MessageBox.Show("Chuyến đi đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi xóa chuyến đi: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("ChangeTrip");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedRow = dataGridView1.SelectedRows[0];
            var trip = selectedRow.DataBoundItem as Trip;

            if (trip != null)
            {
                _navigationService.NavigateTo("ChangeTrip", trip);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedRow = dataGridView1.SelectedRows[0];
            var trip = selectedRow.DataBoundItem as Trip;

            if (trip != null)
            {
                await DeleteTripAsync(trip.TripID);
            }
        }
    }
}
