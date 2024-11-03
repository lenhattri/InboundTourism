namespace Views.UserControls.Admin
{
    partial class UserListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            colUID = new ColumnHeader();
            colFullName = new ColumnHeader();
            colPhoneNumber = new ColumnHeader();
            colRole = new ColumnHeader();
            colAddress = new ColumnHeader();
            colPassword = new ColumnHeader();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BackColor = Color.WhiteSmoke;
            listView1.Columns.AddRange(new ColumnHeader[] { colUID, colFullName, colPhoneNumber, colRole, colAddress, colPassword });
            listView1.Font = new Font("Cascadia Mono", 9.2F);
            listView1.Location = new Point(0, 80);
            listView1.Margin = new Padding(4);
            listView1.Name = "listView1";
            listView1.Size = new Size(1195, 670);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colUID
            // 
            colUID.Text = "ID";
            // 
            // colFullName
            // 
            colFullName.Text = "Họ và tên";
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.Text = "Số điện thoại";
            // 
            // colRole
            // 
            colRole.Text = "Vai trò";
            // 
            // colAddress
            // 
            colAddress.Text = "Địa chỉ";
            // 
            // colPassword
            // 
            colPassword.Text = "Pasword";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Violet;
            btnAdd.Location = new Point(14, 21);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 35);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(btnAdd);
            Name = "UserControl1";
            Size = new Size(1195, 771);
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader colUID;
        private ColumnHeader colFullName;
        private ColumnHeader colPhoneNumber;
        private ColumnHeader colRole;
        private ColumnHeader colAddress;
        private ColumnHeader colPassword;
        private Button btnAdd;
    }
}
