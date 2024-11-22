using Base.Utils.Fetch;
using Core.Entities;
using System.ComponentModel;
using Views.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.UserControls.Loading;

namespace Views.UserControls.Admin
{
    public partial class LocationListControl : UserControl
    {
        private readonly INavigationService _navigationService;
        private LoadingControl loadingControl1;

        public LocationListControl(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            loadingControl1 = new LoadingControl
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            Controls.Add(loadingControl1);
            loadingControl1.BringToFront(); 
        }

        private void LocationListControl_Load(object sender, EventArgs e)
        {
            InitializeColumns();
            LoadLocationsAsync();
        }

        private void InitializeColumns()
        {
            dataGridView1.AutoGenerateColumns = false;

            AddTextBoxColumn("Tên địa điểm", "LocationName");
            AddTextBoxColumn("Mô tả", "Description");
            AddTextBoxColumn("Thành phố", "City");
            AddTextBoxColumn("Quốc gia", "Country");
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

        private async Task LoadLocationsAsync()
        {

            loadingControl1.Visible = true;
            loadingControl1.BringToFront();
            this.Enabled = false;

            try
            {
                
                var locations = await FetchService.Instance.GetAsync<List<Location>>("http://localhost:5173/api/v1/location");
                dataGridView1.DataSource = new BindingList<Location>(locations);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách địa điểm: {ex.Message}");
            }
            finally
            {
              
                loadingControl1.Visible = false;
                this.Enabled = true;
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Handle selection change if needed
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = dataGridView1.Columns[e.ColumnIndex];
            var location = dataGridView1.Rows[e.RowIndex].DataBoundItem as Location;
            // Handle cell click if needed
        }

        private async Task DeleteLocationAsync(Location location)
        {
            var confirmDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa địa điểm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.Yes)
            {
                // Show LoadingControl and disable interaction while deleting
                loadingControl1.Visible = true;
                loadingControl1.BringToFront();
                this.Enabled = false;

                try
                {
                    await FetchService.Instance.DeleteAsync($"http://localhost:5173/api/v1/location/{location.LocationID}");
                    await LoadLocationsAsync(); // Reload list after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa địa điểm: {ex.Message}");
                }
                finally
                {
                    // Hide LoadingControl and re-enable interaction
                    loadingControl1.Visible = false;
                    this.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("ChangeLocation");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Bạn chưa chọn bất kỳ data nào");
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow == null) return;
            var location = selectedRow.DataBoundItem as Location;

            if (location != null)
            {
                _navigationService.NavigateTo("ChangeLocation", location);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn bất kỳ data nào");
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            var location = selectedRow.DataBoundItem as Location;

            if (location != null)
            {
                DeleteLocationAsync(location);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
