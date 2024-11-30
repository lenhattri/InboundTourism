using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.Utils.Fetch;
using Core.Entities;
using Base.Config;
using Views.Interfaces;
using Views.DTO;

namespace Views.UserControls.Admin
{
    public partial class BookingListControl : UserControl
    {
        private readonly INavigationService _navigationService;

        public BookingListControl(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        private async void BookingListControl_Load(object sender, EventArgs e)
        {
            InitializeColumns();
            await LoadBookingsAsync();
        }

        private void InitializeColumns()
        {
            dataGridView1.AutoGenerateColumns = false;

            AddTextBoxColumn("Tên chuyến đi", "TripName"); 
            AddTextBoxColumn("Tên người đặt vé", "UserName"); 
            AddTextBoxColumn("Ngày đặt", "BookingDate");
            AddTextBoxColumn("Số người", "NumberOfGuests");
            AddTextBoxColumn("Tổng giá", "TotalPrice");
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

        private async Task LoadBookingsAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<Booking>>($"{GlobalConfig.BASE_URL}/booking");

                if (response.Success)
                {

                    var bookingsWithDetails = new List<BookingViewModel>();
                    foreach (var booking in response.Data)
                    {
                        var trip = await FetchService.Instance.GetAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{booking.TripID}");
                        var user = await FetchService.Instance.GetAsync<User>($"{GlobalConfig.BASE_URL}/user/{booking.UserID}");

                        bookingsWithDetails.Add(new BookingViewModel
                        {
                            BookingID = booking.BookingID,
                            TripName = trip.Data?.TourName ?? "Unknown Trip",
                            UserName = user.Data?.FullName ?? "Unknown User",
                            BookingDate = booking.BookingDate,
                            NumberOfGuests = booking.NumberOfGuests,
                            TotalPrice = booking.TotalPrice
                        });
                    }
                    dataGridView1.DataSource = bookingsWithDetails;

                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách đặt chỗ: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteBookingAsync(Guid bookingId)
        {
            var confirmDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa đặt chỗ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.Yes)
            {
                try
                {
                    var response = await FetchService.Instance.DeleteAsync($"{GlobalConfig.BASE_URL}/booking/{bookingId}");

                    if (response.Success)
                    {
                        await LoadBookingsAsync();
                        MessageBox.Show("Đặt chỗ đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi xóa đặt chỗ: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _navigationService.NavigateTo("ChangeBooking");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedRow = dataGridView1.SelectedRows[0];
            var booking = selectedRow.DataBoundItem as BookingViewModel;

            if (booking != null)
            {
                _navigationService.NavigateTo("ChangeBooking", booking);
            }
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedRow = dataGridView1.SelectedRows[0];
            var bookingId = (Guid)((dynamic)selectedRow.DataBoundItem).BookingID;

            if (bookingId != Guid.Empty)
            {
                await DeleteBookingAsync(bookingId);
            }
        }
    }
}
