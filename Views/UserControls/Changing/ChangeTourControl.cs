
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

        public ChangeTourControl()
        {
            InitializeComponent();

            listView1.CheckBoxes = true;
            btnAdd.Click += async (sender, e) => await AddTourAsync();
            btnChange.Click += async (sender, e) => await UpdateTourAsync();
            btnChange.Visible = false;
            btnAdd.Visible = false;
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
            PopulateListView();
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

        private void PopulateListView()
        {
            listView1.Items.Clear();

            foreach (var location in _allLocations)
            {
                var item = new ListViewItem(location.LocationName)
                {
                    Tag = location.LocationID,
                    Checked = _selectedLocationIds.Contains(location.LocationID)
                };
                listView1.Items.Add(item);
            }
        }

        private List<Guid> GetSelectedLocationIds()
        {
            return listView1.CheckedItems.Cast<ListViewItem>()
                .Select(item => (Guid)item.Tag)
                .ToList();
        }

        private async Task AddTourAsync()
        {
            try
            {
                var newTour = new TourCreateRequest
                {
                    TourName = txtTourName.Text,
                    Description = txtDescription.Text,
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
                var updatedTour = new TourCreateRequest
                {
                    TourName = txtTourName.Text,
                    Description = txtDescription.Text,
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
    }
}
