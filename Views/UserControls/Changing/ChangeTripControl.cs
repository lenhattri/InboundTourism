using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Interfaces;
using Core.Entities;
using Base.Utils.Fetch;
using Base.Config;

namespace Views.UserControls.Changing
{
    public partial class ChangeTripControl : UserControl, IParameterReceiver
    {
        private Guid _tripId;
        private Guid _tourId;

        public ChangeTripControl()
        {
            InitializeComponent();

           


            listViewBookings.View = View.Details;
            listViewBookings.Columns.Add("Booking ID", 200);
            listViewBookings.Columns.Add("User ID", 200);
            listViewBookings.Columns.Add("Ngày đặt", 150);
            listViewBookings.Columns.Add("Số khách", 100);
            listViewBookings.Columns.Add("Tổng giá", 150);

            listViewBookings.FullRowSelect = true;
        }

        public async void ReceiveParameter(object parameter)
        {
            if (parameter is Trip trip)
            {
                
                _tripId = trip.TripID;
                _tourId = trip.TourID;

                txtPrice.Text = trip.Price.ToString();
                dtpStartDate.Value = trip.StartDate;
                dtpEndDate.Value = trip.EndDate;
                txtDistance.Text = trip.Distance.ToString();
                numMaxGuests.Value = trip.MaxGuests;



            
                await LoadBookingsForTripAsync(_tripId);
            }
            else if (parameter is Guid tourId)
            {
           
                _tripId = Guid.Empty;
                _tourId = tourId;

                txtPrice.Clear();
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now.AddDays(1);
                txtDistance.Clear();
                numMaxGuests.Value = 1;



                
                listViewBookings.Items.Clear();
            }
        }

        private async Task btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var trip = new Trip
                {
                    TripID = _tripId == Guid.Empty ? Guid.NewGuid() : _tripId,
                    TourID = _tourId,
                    Price = decimal.Parse(txtPrice.Text),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Distance = double.Parse(txtDistance.Text),
                    MaxGuests = (int)numMaxGuests.Value
                };

                if (_tripId == Guid.Empty)
                {
                    // Add new trip
                    await FetchService.Instance.PostAsync<Trip>($"{GlobalConfig.BASE_URL}/trip", trip);
                    MessageBox.Show("Trip đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing trip
                    await FetchService.Instance.PutAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{_tripId}", trip);
                    MessageBox.Show("Trip đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu Trip: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrWhiteSpace(txtPrice.Text)
                && decimal.TryParse(txtPrice.Text, out _)
                && !string.IsNullOrWhiteSpace(txtDistance.Text)
                && decimal.TryParse(txtDistance.Text, out _)
                && dtpStartDate.Value <= dtpEndDate.Value;
        }

        private async Task LoadBookingsForTripAsync(Guid tripId)
        {
            try
            {
                var bookings = await FetchService.Instance.GetAsync<List<Booking>>($"{GlobalConfig.BASE_URL}/booking/trip/{tripId}");

                listViewBookings.Items.Clear();
                foreach (var booking in bookings)
                {
                    ListViewItem item = new ListViewItem(booking.BookingID.ToString())
                    {
                        SubItems = {
                            booking.UserID.ToString(),
                            booking.BookingDate.ToShortDateString(),
                            booking.NumberOfGuests.ToString(),
                            booking.TotalPrice.ToString("C")
                        },
                        Tag = booking
                    };

                    listViewBookings.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Booking: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
