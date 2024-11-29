namespace Views.UserControls.Changing
{
    partial class ChangeBookingControl
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
            btnAdd = new Button();
            btnChange = new Button();
            listTrip = new ListView();
            label5 = new Label();
            numGuests = new NumericUpDown();
            label2 = new Label();
            dtpBookingDate = new DateTimePicker();
            label1 = new Label();
            label3 = new Label();
            listUser = new ListView();
            txtTripFilter = new TextBox();
            txtUserFilter = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numGuests).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Desktop;
            btnAdd.Location = new Point(56, 300);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(56, 300);
            btnChange.Margin = new Padding(4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(149, 56);
            btnChange.TabIndex = 18;
            btnChange.Text = "Sửa";
            btnChange.UseVisualStyleBackColor = false;
            // 
            // listTrip
            // 
            listTrip.Location = new Point(494, 71);
            listTrip.Name = "listTrip";
            listTrip.Size = new Size(435, 176);
            listTrip.TabIndex = 20;
            listTrip.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 207);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 23;
            label5.Text = "Số người";
            // 
            // numGuests
            // 
            numGuests.Location = new Point(161, 205);
            numGuests.Name = "numGuests";
            numGuests.Size = new Size(150, 27);
            numGuests.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 93);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 25;
            label2.Text = "Ngày bắt đầu";
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.Location = new Point(161, 93);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(250, 27);
            dtpBookingDate.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(494, 39);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 26;
            label1.Text = "Tuyến";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 264);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 27;
            label3.Text = "Người đặt";
            // 
            // listUser
            // 
            listUser.Location = new Point(494, 300);
            listUser.Name = "listUser";
            listUser.Size = new Size(435, 176);
            listUser.TabIndex = 28;
            listUser.UseCompatibleStateImageBehavior = false;
            // 
            // txtTripFilter
            // 
            txtTripFilter.Location = new Point(563, 36);
            txtTripFilter.Name = "txtTripFilter";
            txtTripFilter.Size = new Size(250, 27);
            txtTripFilter.TabIndex = 29;
            // 
            // txtUserFilter
            // 
            txtUserFilter.Location = new Point(577, 264);
            txtUserFilter.Name = "txtUserFilter";
            txtUserFilter.Size = new Size(250, 27);
            txtUserFilter.TabIndex = 30;
            // 
            // ChangeBookingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtUserFilter);
            Controls.Add(txtTripFilter);
            Controls.Add(listUser);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dtpBookingDate);
            Controls.Add(label5);
            Controls.Add(numGuests);
            Controls.Add(listTrip);
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Name = "ChangeBookingControl";
            Size = new Size(990, 582);
            ((System.ComponentModel.ISupportInitialize)numGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnChange;
        private ListView listTrip;
        private Label label5;
        private NumericUpDown numGuests;
        private Label label2;
        private DateTimePicker dtpBookingDate;
        private Label label1;
        private Label label3;
        private ListView listUser;
        private TextBox txtTripFilter;
        private TextBox txtUserFilter;
    }
}
