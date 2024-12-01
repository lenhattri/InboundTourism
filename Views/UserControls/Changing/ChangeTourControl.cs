using Views.Interfaces;
using Core.Entities;
using Base.Utils.Fetch;
using Base.Config;
using API.DTO;

namespace Views.UserControls.Changing
{
    public partial class ChangeTourControl : UserControl, IParameterReceiver
    {
        private Guid _tourId;
        private List<Guid> _selectedLocationIds;
        private List<Location> _allLocations;
        private List<ListViewItem> _checkedItemsInOrder;


        public ChangeTourControl()
        {
            InitializeComponent();

            listView1.CheckBoxes = true;
            btnAdd.Click += async (sender, e) => await AddTourAsync();
            btnChange.Click += async (sender, e) => await UpdateTourAsync();
            btnChange.Visible = false;
            btnAdd.Visible = false;
            _checkedItemsInOrder = new List<ListViewItem>();


            txtLocationFilter.TextChanged += (sender, e) => FilterLocations();
        }

        public async void ReceiveParameter(object parameter)
        {
            _selectedLocationIds = new List<Guid>();

            if (parameter is Tour tour)
            {
                _tourId = tour.TourID;
                txtTourName.Text = tour.TourName;
                txtDescription.Text = tour.Description;
                btnChange.Visible = true;
                btnAdd.Visible = false;

                await LoadSelectedLocationsAsync();
            }
            else
            {
                btnAdd.Visible = true;
                btnChange.Visible = false;
            }

            await LoadAllLocationsAsync();
            PopulateListView(_allLocations); // Hiển thị tất cả địa điểm ban đầu
        }

        private async Task LoadAllLocationsAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<Location>>($"{GlobalConfig.BASE_URL}/location");

                if (response.Success)
                {
                    _allLocations = response.Data;
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách địa điểm: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSelectedLocationsAsync()
        {
            try
            {
                var response = await FetchService.Instance.GetAsync<List<TourLocation>>($"{GlobalConfig.BASE_URL}/tourlocation/tour/{_tourId}");

                if (response.Success)
                {
                    _selectedLocationIds = response.Data.Select(tl => tl.LocationID).ToList();
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách địa điểm của Tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateListView(List<Location> locations)
        {
            listView1.Items.Clear();

            foreach (var location in locations)
            {
                var item = new ListViewItem(location.LocationName)
                {
                    Tag = location.LocationID,
                    Checked = _selectedLocationIds.Contains(location.LocationID)
                };
                listView1.Items.Add(item);
            }
        }

        private void FilterLocations()
        {
            var keyword = txtLocationFilter.Text.ToLower();

            // Lọc danh sách địa điểm dựa trên từ khóa
            var filteredLocations = _allLocations.Where(location =>
                location.LocationName.ToLower().Contains(keyword)
            ).ToList();

            PopulateListView(filteredLocations); // Cập nhật danh sách hiển thị
        }

        private List<Guid> GetSelectedLocationIds()
        {
            return listView1.CheckedItems.Cast<ListViewItem>()
                .Select(item => (Guid)item.Tag)
                .ToList();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTourName.Text))
            {
                MessageBox.Show("Tên tour không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTourName.Focus();
                return false;
            }

            if (GetSelectedLocationIds().Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một địa điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listView1.Focus();
                return false;
            }

            if (txtDescription.Text.Length > 500)
            {
                MessageBox.Show("Mô tả không được vượt quá 500 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private async Task AddTourAsync()
        {
            try
            {
                if (!ValidateForm()) return;

                var newTour = new TourCreateRequest
                {
                    TourName = txtTourName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    LocationIds = GetSelectedLocationIds()
                };

                var response = await FetchService.Instance.PostAsync<TourCreateRequest>($"{GlobalConfig.BASE_URL}/tour", newTour);

                if (response.Success)
                {
                    MessageBox.Show("Tour đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm Tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateTourAsync()
        {
            try
            {
                if (!ValidateForm()) return;

                var updatedTour = new TourCreateRequest
                {
                    TourName = txtTourName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    LocationIds = GetSelectedLocationIds()
                };

                var response = await FetchService.Instance.PutAsync<TourCreateRequest>($"{GlobalConfig.BASE_URL}/tour/{_tourId}", updatedTour);

                if (response.Success)
                {
                    MessageBox.Show("Tour đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật Tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                // Nếu item được check, thêm vào danh sách
                _checkedItemsInOrder.Add(e.Item);
            }
            else
            {
                // Nếu item bị uncheck, xóa khỏi danh sách
                _checkedItemsInOrder.Remove(e.Item);
            }

            // Cập nhật hiển thị
            UpdateCheckedItemsDisplay();
        }
        private void UpdateCheckedItemsDisplay()
        {
            // Reset tên hiển thị của tất cả các item
            foreach (ListViewItem item in listView1.Items)
            {
                var location = _allLocations.FirstOrDefault(loc => loc.LocationID == (Guid)item.Tag);
                if (location != null)
                {
                    item.Text = location.LocationName;
                }
            }

            // Cập nhật tên hiển thị của các item được chọn với số thứ tự
            for (int i = 0; i < _checkedItemsInOrder.Count; i++)
            {
                var item = _checkedItemsInOrder[i];
                var location = _allLocations.FirstOrDefault(loc => loc.LocationID == (Guid)item.Tag);
                if (location != null)
                {
                    item.Text = $"{i + 1}. {location.LocationName}";
                }
            }
        }

    }
}
