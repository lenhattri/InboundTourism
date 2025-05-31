
using System.Net.Http.Headers;
using Views.Interfaces;
using Core.Entities;
using Base.Utils.Fetch;
using Base.Config;

namespace Views.UserControls.Changing
{
    public partial class ChangeLocationControl : UserControl, IParameterReceiver
    {
        private Guid _locationId;
        private string _currentImageUrl;
        private string _lastUploadedImage;
        private string _pendingImagePath;

        public ChangeLocationControl()
        {
            InitializeComponent();
            btnChange.Click += async (s, e) => await HandleUpdateAsync();
            btnAdd.Click += async (s, e) => await HandleAddAsync();
            btnUpload.Click += async (s, e) => await HandleSelectImageAsync();
            ResetForm();
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is Location location)
                EnterEditMode(location);
            else
                EnterAddMode();
        }

        private void EnterEditMode(Location location)
        {
            _locationId = location.LocationID;
            _currentImageUrl = location.ImageUrl;
            _pendingImagePath = null;
            _lastUploadedImage = null;

            txtLocationName.Text = location.LocationName;
            txtDescription.Text = location.Description;
            txtCity.Text = location.City;
            txtCountry.Text = location.Country;
            btnChange.Visible = true;
            btnAdd.Visible = false;

            DisplayImage(_currentImageUrl, true);
        }

        private void EnterAddMode()
        {
            _locationId = Guid.Empty;
            _currentImageUrl = null;
            _pendingImagePath = null;
            _lastUploadedImage = null;
            btnChange.Visible = false;
            btnAdd.Visible = true;
            ResetForm();
        }

        private void ResetForm()
        {
            txtLocationName.Clear();
            txtDescription.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            DisplayImage(null, false);
        }

        private void DisplayImage(string source, bool isUrl)
        {
            if (pictureBox1.Image != null)
            {
                var oldImg = pictureBox1.Image;
                pictureBox1.Image = null;
                oldImg.Dispose();
            }
            try
            {
                if (string.IsNullOrWhiteSpace(source))
                {
                    pictureBox1.Image = null;
                }
                else if (isUrl)
                {
                    var baseHost = GlobalConfig.CORE_URL;
                    pictureBox1.Load(baseHost + source);
                }
                else
                {
                    using (var img = Image.FromFile(source))
                        pictureBox1.Image = (Image)img.Clone();
                }
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private async Task HandleSelectImageAsync()
        {
            using (var ofd = new OpenFileDialog()
            {
                Title = "Chọn ảnh địa điểm",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _pendingImagePath = ofd.FileName;
                    DisplayImage(_pendingImagePath, false);
                    ShowInfo("Ảnh đã được chọn. Ấn 'Sửa' để lưu ảnh lên hệ thống.");
                }
            }
            await Task.CompletedTask;
        }

        private async Task HandleUpdateAsync()
        {
            if (!ValidateForm())
                return;

            var location = new Location
            {
                LocationID = _locationId,
                LocationName = txtLocationName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                City = txtCity.Text.Trim(),
                Country = txtCountry.Text.Trim()
            };

            var updateResp = await FetchService.Instance.PutAsync<Location>(
                $"{GlobalConfig.BASE_URL}/location/{_locationId}", location);

            if (!updateResp.Success)
            {
                ShowError($"Lỗi khi cập nhật địa điểm: {updateResp.ErrorMessage}");
                return;
            }

            if (!string.IsNullOrEmpty(_pendingImagePath))
            {
                var uploadSuccess = await UploadImageAsync(_pendingImagePath, _locationId);
                if (uploadSuccess)
                    _pendingImagePath = null;
            }

            ShowInfo("Địa điểm đã được cập nhật thành công!");
        }

        private async Task HandleAddAsync()
        {
            if (!ValidateForm())
                return;

            var location = new Location
            {
                LocationName = txtLocationName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                City = txtCity.Text.Trim(),
                Country = txtCountry.Text.Trim()
            };

            var resp = await FetchService.Instance.PostAsync<Location>(
                $"{GlobalConfig.BASE_URL}/location", location);

            if (resp.Success)
                ShowInfo("Địa điểm đã được thêm thành công!");
            else
                ShowError($"Lỗi khi thêm địa điểm: {resp.ErrorMessage}");
        }

        private async Task<bool> UploadImageAsync(string imagePath, Guid locationId)
        {
            try
            {
                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StreamContent(fs)
                        {
                            Headers = { ContentType = new MediaTypeHeaderValue("application/octet-stream") }
                        }, "imageFile", Path.GetFileName(imagePath) }
                    };

                    var url = $"{GlobalConfig.BASE_URL}/location/{locationId}/upload-image";
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var resultString = await response.Content.ReadAsStringAsync();
                        _lastUploadedImage = ExtractImageUrlFromJson(resultString);
                        ShowInfo("Upload ảnh thành công!");
                        return true;
                    }
                    else
                    {
                        ShowError($"Lỗi upload ảnh: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi upload ảnh: {ex.Message}");
                return false;
            }
        }

        private string ExtractImageUrlFromJson(string json)
        {
            var marker = "\"imageUrl\":\"";
            var start = json.IndexOf(marker);
            if (start == -1) return null;
            start += marker.Length;
            var end = json.IndexOf("\"", start);
            if (end == -1) return null;
            return json.Substring(start, end - start);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocationName.Text))
                return ShowFieldError(txtLocationName, "Tên địa điểm không được để trống!");
            if (string.IsNullOrWhiteSpace(txtCity.Text))
                return ShowFieldError(txtCity, "Thành phố không được để trống!");
            if (string.IsNullOrWhiteSpace(txtCountry.Text))
                return ShowFieldError(txtCountry, "Quốc gia không được để trống!");
            return true;
        }

        private bool ShowFieldError(Control ctl, string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ctl.Focus();
            return false;
        }

        private void ShowInfo(string msg)
            => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void ShowError(string msg)
            => MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ChangeLocationControl_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
