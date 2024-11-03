using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Components;

namespace Views.UserControls.Admin
{
    public partial class UserListControl : System.Windows.Forms.UserControl
    {
        private ListViewButtonHelper _buttonHelper;
        public UserListControl()
        {
            InitializeComponent();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            _buttonHelper = new ListViewButtonHelper(listView1);
            _buttonHelper.OnEditButtonClick += OnEditButtonClick;
            _buttonHelper.OnDeleteButtonClick += OnDeleteButtonClick;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OnEditButtonClick(ListViewItem item)
        {
            MessageBox.Show($"Sửa item: {item.Text}");
        }

        private void OnDeleteButtonClick(ListViewItem item)
        {
            MessageBox.Show($"Xóa item: {item.Text}");
            listView1.Items.Remove(item); // Xóa item khỏi ListView
        }

    }
}
