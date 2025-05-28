using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Interfaces;
using Core.Entities;
using Base.Utils.Fetch;
using Base.Config;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Views.UserControls.Changing
{
    public partial class ChangeLocationControl : UserControl, IParameterReceiver
    {
        private Guid _locationId;
        private string _currentImageUrl = null;    // Để show lại khi nhận Location
        private string _lastUploadedImage = null;  // Để track ảnh vừa upload

        public ChangeLocationControl()
        {
            InitializeComponent();
            btnChange.Visible = false;
            btnAdd.Visible = false;

            btnChange.Click += async (sender, e) => await BtnChange_Click(sender, e);
            btnAdd.Click += async (sender, e) => await BtnAdd_Click(sender, e);
            btnUpload.Click += async (sender, e) => await BtnUploadImage_Click(sender, e);
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is Location location)
            {
                _locationId = location.LocationID;
                txtLocationName.Text = location.LocationName;
                txtDescription.Text = location.Description;
                txtCity.Text = location.City;
                txtCountry.Text = location.Country;
                btnChange.Visible = true;

                _currentImageUrl = location.ImageUrl;
                if (!string.IsNullOrEmpty(_currentImageUrl))
                {
                    // Hiển thị ảnh hiện tại (giả sử BASE_URL trả file ảnh)
                    try
                    {
                        string baseImageHost = "http://localhost:5173"; 
                        pictureBox1.Load(baseImageHost + _currentImageUrl);
                    }
                    catch
                    {
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                btnAdd.Visible = true;
                pictureBox1.Image = null;
            }
        }

        private async Task BtnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var location = new Location
                {
                    LocationID = _locationId,
                    LocationName = txtLocationName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                var response = await FetchService.Instance.PutAsync<Location>($"{GlobalConfig.BASE_URL}/location/{_locationId}", location);

                if (response.Success)
                {
                    MessageBox.Show("Địa điểm đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật địa điểm: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var location = new Location
                {
                    LocationName = txtLocationName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                var response = await FetchService.Instance.PostAsync<Location>($"{GlobalConfig.BASE_URL}/location", location);

                if (response.Success)
                {
                    MessageBox.Show("Địa điểm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm địa điểm: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocationName.Text))
            {
                MessageBox.Show("Tên địa điểm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocationName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Thành phố không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("Quốc gia không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
                return false;
            }

            return true;
        }

        private async Task BtnUploadImage_Click(object sender, EventArgs e)
        {
            // Bắt buộc đã có Location (đã lưu hoặc đã chọn để sửa)
            if (_locationId == Guid.Empty)
            {
                MessageBox.Show("Bạn cần lưu hoặc chọn địa điểm trước khi upload ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh địa điểm";
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        using (var client = new HttpClient())
                        {
                            var content = new MultipartFormDataContent();
                            var fileContent = new StreamContent(fs);
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            content.Add(fileContent, "imageFile", Path.GetFileName(ofd.FileName));

                            var url = $"{GlobalConfig.BASE_URL}/location/{_locationId}/upload-image";
                            var response = await client.PostAsync(url, content);

                            if (response.IsSuccessStatusCode)
                            {
                                var resultString = await response.Content.ReadAsStringAsync();
                                // Bạn có thể parse lại JSON, ví dụ dùng Newtonsoft.Json hoặc System.Text.Json nếu muốn
                                // Ở đây giả sử server trả về: { "imageUrl": "/images/locations/{id}.jpg" }
                                var imageUrl = ExtractImageUrlFromJson(resultString);
                                _lastUploadedImage = imageUrl;
                                // Hiển thị ngay ảnh mới
                                if (!string.IsNullOrEmpty(imageUrl))
                                {
                                    pictureBox1.Load(GlobalConfig.BASE_URL.TrimEnd('/') + imageUrl);
                                }
                                MessageBox.Show("Upload ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Lỗi upload ảnh: {response.ReasonPhrase}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi upload ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Extract "imageUrl" from returned JSON string. (Simple parse, replace bằng JSON parser nếu muốn chắc ăn hơn)
        /// </summary>
        private string ExtractImageUrlFromJson(string json)
        {
            // Giả sử kết quả là: {"imageUrl":"/images/locations/xxx.jpg"}
            var marker = "\"imageUrl\":\"";
            var start = json.IndexOf(marker);
            if (start == -1) return null;
            start += marker.Length;
            var end = json.IndexOf("\"", start);
            if (end == -1) return null;
            return json.Substring(start, end - start);
        }

        private void ChangeLocationControl_Load(object sender, EventArgs e)
        {
            // Optionally: auto load ảnh khi mở form nếu có _currentImageUrl
            if (!string.IsNullOrEmpty(_currentImageUrl))
            {
                try
                {
                    pictureBox1.Load(GlobalConfig.BASE_URL.TrimEnd('/') + _currentImageUrl);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Có thể mở to ảnh, hoặc chọn lại ảnh...
        }
    }
}
