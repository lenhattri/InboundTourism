using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Views.Components
{
    public class ListViewButtonHelper
    {
        private readonly ListView _listView;

        public ListViewButtonHelper(ListView listView)
        {
            _listView = listView;
            InitializeListView();
        }

        private void InitializeListView()
        {
            _listView.OwnerDraw = true;
            _listView.DrawColumnHeader += ListView_DrawColumnHeader;
            _listView.DrawSubItem += ListView_DrawSubItem;
            _listView.MouseClick += ListView_MouseClick;
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Kiểm tra nếu cột là cột cuối
            if (e.ColumnIndex == _listView.Columns.Count - 1) // Cột cuối cùng
            {
                // Vẽ nút "Sửa"
                Rectangle editButtonRect = new Rectangle(e.Bounds.Left, e.Bounds.Top, 50, e.Bounds.Height - 4);
                ButtonRenderer.DrawButton(e.Graphics, editButtonRect, "Sửa", _listView.Font, false, PushButtonState.Normal);

                // Vẽ nút "Xóa"
                Rectangle deleteButtonRect = new Rectangle(e.Bounds.Left + 60, e.Bounds.Top, 50, e.Bounds.Height - 4);
                ButtonRenderer.DrawButton(e.Graphics, deleteButtonRect, "Xóa", _listView.Font, false, PushButtonState.Normal);
            }
            else
            {
                e.DrawDefault = true; // Vẽ mặc định cho các cột khác
            }
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = _listView.GetItemAt(e.X, e.Y);
            if (item != null && item.SubItems.Count > 2)
            {
                int lastColumnIndex = _listView.Columns.Count - 1;
                Rectangle editButtonRect = new Rectangle(item.SubItems[lastColumnIndex].Bounds.Left, item.SubItems[lastColumnIndex].Bounds.Top, 50, item.SubItems[lastColumnIndex].Bounds.Height - 4);
                Rectangle deleteButtonRect = new Rectangle(item.SubItems[lastColumnIndex].Bounds.Left + 60, item.SubItems[lastColumnIndex].Bounds.Top, 50, item.SubItems[lastColumnIndex].Bounds.Height - 4);

                if (editButtonRect.Contains(e.Location))
                {
                    // Thực hiện hành động sửa
                    OnEditButtonClick?.Invoke(item);
                }
                else if (deleteButtonRect.Contains(e.Location))
                {
                    // Thực hiện hành động xóa
                    OnDeleteButtonClick?.Invoke(item);
                }
            }
        }

        // Các sự kiện để xử lý trong Form chính
        public event Action<ListViewItem> OnEditButtonClick;
        public event Action<ListViewItem> OnDeleteButtonClick;
    }
}
