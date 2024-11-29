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
        private List<Tour> _allTours;

        public ChangeTripControl()
        {
            InitializeComponent();

            listView1.CheckBoxes = false;
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
            btnAdd.Click += async (sender, e) => await AddTripAsync();
            btnChange.Click += async (sender, e) => await UpdateTripAsync();
            btnChange.Visible = false;
            btnAdd.Visible = false;

            listView1.SelectedIndexChanged += OnTourSelected;

            // Kết nối sự kiện lọc với txtTourFilter
            txtTourFilter.TextChanged += (sender, e) => FilterTours();
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
                btnChange.Visible = true;
                btnAdd.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
                btnChange.Visible = false;
            }

            await LoadAllToursAsync();
            PopulateListView(_allTours);
        }

        private async Task LoadAllToursAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<Tour>>($"{GlobalConfig.BASE_URL}/tour");

                if (response.Success)
                {
                    _allTours = response.Data;
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách Tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateListView(List<Tour> tours)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();

            listView1.Columns.Add("Tên Tour", 200);
            listView1.Columns.Add("Mô tả", 300);
            listView1.Columns.Add("Mã Tour", 150);

            foreach (var tour in tours)
            {
                var item = new ListViewItem(tour.TourName)
                {
                    Tag = tour.TourID
                };
                item.SubItems.Add(tour.Description);
                item.SubItems.Add(tour.TourID.ToString());

                if (tour.TourID == _tourId)
                {
                    item.Selected = true;
                }

                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FilterTours()
        {
            var keyword = txtTourFilter.Text.ToLower();

            // Lọc danh sách tour dựa trên từ khóa
            var filteredTours = _allTours.Where(tour =>
                tour.TourName.ToLower().Contains(keyword) ||
                tour.Description.ToLower().Contains(keyword) ||
                tour.TourID.ToString().ToLower().Contains(keyword)
            ).ToList();

            PopulateListView(filteredTours); // Hiển thị danh sách đã lọc
        }

        private void OnTourSelected(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                _tourId = (Guid)listView1.SelectedItems[0].Tag;
                MessageBox.Show($"Bạn đã chọn Tour: {listView1.SelectedItems[0].Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task AddTripAsync()
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newTrip = new Trip
                {
                    TourID = _tourId,
                    Price = decimal.Parse(txtPrice.Text),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Distance = double.Parse(txtDistance.Text),
                    MaxGuests = (int)numMaxGuests.Value
                };

                var response = await FetchService.Instance.PostAsync<Trip>($"{GlobalConfig.BASE_URL}/trip", newTrip);

                if (response.Success)
                {
                    MessageBox.Show("Chuyến đi đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm chuyến đi: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateTripAsync()
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedTrip = new Trip
                {
                    TripID = _tripId,
                    TourID = _tourId,
                    Price = decimal.Parse(txtPrice.Text),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Distance = double.Parse(txtDistance.Text),
                    MaxGuests = (int)numMaxGuests.Value
                };

                var response = await FetchService.Instance.PutAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{_tripId}", updatedTrip);

                if (response.Success)
                {
                    MessageBox.Show("Chuyến đi đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật chuyến đi: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0 || price > 99999999999999.99m)
            {
                MessageBox.Show("Giá không hợp lệ! Giá phải lớn hơn 0 và không vượt quá 99 nghìn tỷ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtDistance.Text, out double distance) || distance <= 0 || distance > 10000000.0)
            {
                MessageBox.Show("Khoảng cách không hợp lệ! Khoảng cách phải lớn hơn 0 và không vượt quá 10 triệu km.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_tourId == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn một Tour từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMaxGuests.Value <= 0)
            {
                MessageBox.Show("Số khách tối đa phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ChangeTripControl_Load(object sender, EventArgs e)
        {
        }
    }
}
