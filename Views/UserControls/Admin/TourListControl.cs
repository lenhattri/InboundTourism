using Base.Utils.Fetch;
using Core.Entities;
using System.ComponentModel;
using Views.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.UserControls.Loading;
using Base.Config;
using System;

namespace Views.UserControls.Admin
{
    public partial class TourListControl : UserControl
    {
        private readonly INavigationService _navigationService;
        private LoadingControl loadingControl1;

        public TourListControl(INavigationService navigationService)
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

        private void TourListControl_Load(object sender, EventArgs e)
        {
            InitializeColumns();
            LoadToursAsync();
        }

        private void InitializeColumns()
        {
            dataGridView1.AutoGenerateColumns = false;

            AddTextBoxColumn("Tên tour", "TourName");
            AddTextBoxColumn("Mô tả", "Description");
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

        private async Task LoadToursAsync()
        {
            loadingControl1.Visible = true;
            loadingControl1.BringToFront();
            this.Enabled = false;

            try
            {
                var response = await FetchService.Instance.GetAsync<List<Tour>>($"{GlobalConfig.BASE_URL}/tour");

                if (response.Success)
                {
                    dataGridView1.DataSource = new BindingList<Tour>(response.Data);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải danh sách tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingControl1.Visible = false;
                this.Enabled = true;
            }
        }

        private async Task DeleteTourAsync(Tour tour)
        {
            var confirmDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa tour này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.Yes)
            {
                loadingControl1.Visible = true;
                loadingControl1.BringToFront();
                this.Enabled = false;

                try
                {
                    var response = await FetchService.Instance.DeleteAsync($"{GlobalConfig.BASE_URL}/tour/{tour.TourID}");

                    if (response.Success)
                    {
                        await LoadToursAsync();
                        MessageBox.Show("Tour đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi xóa tour: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    loadingControl1.Visible = false;
                    this.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("ChangeTour");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tour để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var tour = selectedRow.DataBoundItem as Tour;

            if (tour != null)
            {
                _navigationService.NavigateTo("ChangeTour", tour);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tour để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var tour = selectedRow.DataBoundItem as Tour;

            if (tour != null)
            {
                DeleteTourAsync(tour);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }
    }
}
