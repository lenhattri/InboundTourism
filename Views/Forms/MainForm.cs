


using Views.UserControls.Navigation;
using Views.Navigation;
using Views.UserControls.Admin;
using Views.Interfaces;
using System.Drawing.Drawing2D;
using Base.Context;

namespace Views.Forms
{
    public partial class MainForm : Form
    {
        private readonly INavigationService _navigationService;

        public MainForm()
        {
            InitializeComponent();

            _navigationService = new NavigationService(panelContainer);


            Router router = new Router(_navigationService);
            router.RegisterViews();
            lbName.Text = UserContext.Instance.Username;
            _navigationService.NavigateTo("Dashboard");

        }




        private void btnTables_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo("Dashboard");
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi đăng xuất
            DialogResult confirmResult = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                // Xóa dữ liệu người dùng
                UserContext.Instance.ClearUserData();

                // Thông báo đã đăng xuất
                MessageBox.Show("Bạn đã đăng xuất thành công", "Đăng Xuất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Điều hướng trở lại form đăng nhập
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide(); // Ẩn form chính
            }
            // Nếu người dùng chọn "No", không làm gì cả
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
               "Bạn có muốn thoát không?",
               "Xác nhận thoát",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );



            this.Close();
        }
    }
}
