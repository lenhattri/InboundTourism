using Core.Entities;
using Views.Interfaces;
using Base.Utils.Fetch;
using Base.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views.UserControls.Changing
{
    public partial class ChangeBookingControl : UserControl, IParameterReceiver
    {
        private Guid _bookingId;
        private Guid _tripId;
        private Guid _userId;
        private List<Trip> _allTrips;
        private List<User> _allUsers;

        public ChangeBookingControl()
        {
            InitializeComponent();

            listTrip.FullRowSelect = true;
            listTrip.HideSelection = false;

            listUser.FullRowSelect = true;
            listUser.HideSelection = false;

            btnAdd.Click += async (sender, e) => await AddBookingAsync();
            btnChange.Click += async (sender, e) => await UpdateBookingAsync();

            listTrip.SelectedIndexChanged += OnTripSelected;
            listUser.SelectedIndexChanged += OnUserSelected;

            txtTripFilter.TextChanged += (sender, e) => FilterTrips();
            txtUserFilter.TextChanged += (sender, e) => FilterUsers();
        }

        public async void ReceiveParameter(object parameter)
        {
            if (parameter is Booking booking)
            {
                _bookingId = booking.BookingID;
                _tripId = booking.TripID;
                _userId = booking.UserID;
                numGuests.Value = booking.NumberOfGuests;
                dtpBookingDate.Value = booking.BookingDate;
                btnChange.Visible = true;
                btnAdd.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
                btnChange.Visible = false;
            }

            await LoadAllTripsAsync();
            await LoadAllUsersAsync();

            PopulateListViews();
        }

        private async Task LoadAllTripsAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<Trip>>($"{GlobalConfig.BASE_URL}/trip");

                if (response.Success)
                {
                    _allTrips = response.Data;
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách chuyến đi: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAllUsersAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<User>>($"{GlobalConfig.BASE_URL}/user");

                if (response.Success)
                {
                    _allUsers = response.Data;
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
        }

        private void PopulateListViews()
        {
            PopulateTrips(_allTrips);
            PopulateUsers(_allUsers);
        }

        private void PopulateTrips(List<Trip> trips)
        {
            listTrip.Items.Clear();
            listTrip.Columns.Clear();
            listTrip.Columns.Add("Tên Chuyến Đi", 200);
            listTrip.Columns.Add("Ngày Bắt Đầu", 150);
            listTrip.Columns.Add("Ngày Kết Thúc", 150);

            foreach (var trip in trips)
            {
                var item = new ListViewItem(trip.TourName)
                {
                    Tag = trip.TripID
                };
                item.SubItems.Add(trip.StartDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(trip.EndDate.ToString("yyyy-MM-dd"));

                if (trip.TripID == _tripId)
                {
                    item.Selected = true;
                }

                listTrip.Items.Add(item);
            }
        }

        private void PopulateUsers(List<User> users)
        {
            listUser.Items.Clear();
            listUser.Columns.Clear();
            listUser.Columns.Add("Tên Người Dùng", 200);
            listUser.Columns.Add("Email", 250);

            foreach (var user in users)
            {
                var item = new ListViewItem(user.FullName)
                {
                    Tag = user.UserID
                };
                item.SubItems.Add(user.Email);

                if (user.UserID == _userId)
                {
                    item.Selected = true;
                }

                listUser.Items.Add(item);
            }
        }

        private void FilterTrips()
        {
            var keyword = txtTripFilter.Text.ToLower();
            var filteredTrips = _allTrips.Where(trip =>
                trip.TourName.ToLower().Contains(keyword) ||
                trip.StartDate.ToString("yyyy-MM-dd").Contains(keyword) ||
                trip.EndDate.ToString("yyyy-MM-dd").Contains(keyword)
            ).ToList();

            PopulateTrips(filteredTrips);
        }

        private void FilterUsers()
        {
            var keyword = txtUserFilter.Text.ToLower();
            var filteredUsers = _allUsers.Where(user =>
                user.FullName.ToLower().Contains(keyword) ||
                user.Email.ToLower().Contains(keyword)
            ).ToList();

            PopulateUsers(filteredUsers);
        }

        private void OnTripSelected(object sender, EventArgs e)
        {
            if (listTrip.SelectedItems.Count > 0)
            {
                _tripId = (Guid)listTrip.SelectedItems[0].Tag;
            }
        }

        private void OnUserSelected(object sender, EventArgs e)
        {
            if (listUser.SelectedItems.Count > 0)
            {
                _userId = (Guid)listUser.SelectedItems[0].Tag;
            }
        }

        private async Task AddBookingAsync()
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newBooking = new Booking
                {
                    TripID = _tripId,
                    UserID = _userId,
                    BookingDate = dtpBookingDate.Value,
                    NumberOfGuests = (int)numGuests.Value,
                    TotalPrice = CalculateTotalPrice()
                };

                var response = await FetchService.Instance.PostAsync<Booking>($"{GlobalConfig.BASE_URL}/booking", newBooking);

                if (response.Success)
                {
                    MessageBox.Show("Đặt chỗ đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm đặt chỗ: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateBookingAsync()
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedBooking = new Booking
                {
                    BookingID = _bookingId,
                    TripID = _tripId,
                    UserID = _userId,
                    BookingDate = dtpBookingDate.Value,
                    NumberOfGuests = (int)numGuests.Value,
                    TotalPrice = CalculateTotalPrice()
                };

                var response = await FetchService.Instance.PutAsync<Booking>($"{GlobalConfig.BASE_URL}/booking/{_bookingId}", updatedBooking);

                if (response.Success)
                {
                    MessageBox.Show("Đặt chỗ đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật đặt chỗ: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (_tripId == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn một chuyến đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_userId == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn một người đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numGuests.Value <= 0)
            {
                MessageBox.Show("Số người đặt phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private decimal CalculateTotalPrice()
        {
            var selectedTrip = _allTrips.FirstOrDefault(t => t.TripID == _tripId);
            return selectedTrip != null ? selectedTrip.Price * (int)numGuests.Value : 0;
        }
    }
}
