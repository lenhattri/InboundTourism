using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                listView2.Visible = true;
                await LoadSelectedLocationsAsync();
                await LoadTripsForTourAsync(_tourId);
            }
            else
            {
                
                _tourId = Guid.Empty;
                txtTourName.Clear();
                txtDescription.Clear();
                btnAdd.Visible = true; 
                btnChange.Visible = false;
                listView2.Visible= false;
            }

            await LoadAllLocationsAsync();
            PopulateListView(); 
        }
        private async Task LoadTripsForTourAsync(Guid tourId)
        {
            try
            {
                var trips = await FetchService.Instance.GetAsync<List<Trip>>($"{GlobalConfig.BASE_URL}/trip/tour/{tourId}");

                listView2.Items.Clear();
                foreach (var trip in trips)
                {
                    var item = new ListViewItem(trip.Price.ToString())
                    {
                        SubItems = {
                    trip.StartDate.ToShortDateString(),
                    trip.EndDate.ToShortDateString(),
                    trip.Distance.ToString(),
                    trip.MaxGuests.ToString()
                },
                        Tag = trip
                    };

                    listView2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải Trips: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAllLocationsAsync()
        {
            try
            {
                
                _allLocations = await FetchService.Instance.GetAsync<List<Location>>($"{GlobalConfig.BASE_URL}/location");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách địa điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSelectedLocationsAsync()
        {
            try
            {
                
                var tourLocations = await FetchService.Instance.GetAsync<List<TourLocation>>($"{GlobalConfig.BASE_URL}/tourlocation/{_tourId}");
                _selectedLocationIds = tourLocations.Select(tl => tl.LocationID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách địa điểm của Tour: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                await FetchService.Instance.PostAsync<TourCreateRequest>($"{GlobalConfig.BASE_URL}/tour", newTour);
                MessageBox.Show("Tour đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Tour: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                await FetchService.Instance.PutAsync<TourCreateRequest>($"{GlobalConfig.BASE_URL}/tour/{_tourId}", updatedTour);
                MessageBox.Show("Tour đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật Tour: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
