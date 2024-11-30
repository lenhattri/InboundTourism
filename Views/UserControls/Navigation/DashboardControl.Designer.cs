namespace Views.UserControls.Navigation
{
    partial class DashboardControl
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
            btnUser = new Button();
            btnTour = new Button();
            btnLocation = new Button();
            btnBooking = new Button();
            btnTrip = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Violet;
            btnUser.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(209, 212);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(157, 80);
            btnUser.TabIndex = 4;
            btnUser.Text = "Người dùng 👤";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnTour
            // 
            btnTour.BackColor = Color.Violet;
            btnTour.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTour.Location = new Point(309, 345);
            btnTour.Name = "btnTour";
            btnTour.Size = new Size(161, 88);
            btnTour.TabIndex = 5;
            btnTour.Text = "Tour 🌍";
            btnTour.UseVisualStyleBackColor = false;
            btnTour.Click += button1_Click;
            // 
            // btnLocation
            // 
            btnLocation.BackColor = Color.Violet;
            btnLocation.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLocation.Location = new Point(441, 212);
            btnLocation.Name = "btnLocation";
            btnLocation.Size = new Size(193, 80);
            btnLocation.TabIndex = 6;
            btnLocation.Text = "Điểm du lịch 🏞️";
            btnLocation.UseVisualStyleBackColor = false;
            btnLocation.Click += btnLocation_Click;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.Violet;
            btnBooking.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBooking.Location = new Point(705, 212);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(196, 80);
            btnBooking.TabIndex = 7;
            btnBooking.Text = "Vé 🎫";
            btnBooking.UseVisualStyleBackColor = false;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnTrip
            // 
            btnTrip.BackColor = Color.Violet;
            btnTrip.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTrip.Location = new Point(581, 345);
            btnTrip.Name = "btnTrip";
            btnTrip.Size = new Size(211, 88);
            btnTrip.TabIndex = 8;
            btnTrip.Text = "Chuyến đi ✈️";
            btnTrip.UseVisualStyleBackColor = false;
            btnTrip.Click += btnTrip_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 31.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(258, 33);
            label1.Name = "label1";
            label1.Size = new Size(606, 72);
            label1.TabIndex = 9;
            label1.Text = "Bảng điều khiển :3";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 12F);
            label2.Location = new Point(225, 120);
            label2.Name = "label2";
            label2.Size = new Size(648, 27);
            label2.TabIndex = 10;
            label2.Text = "Chào mừng đến với bảng điều khiển của Bocchi The Tour";
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTrip);
            Controls.Add(btnBooking);
            Controls.Add(btnLocation);
            Controls.Add(btnTour);
            Controls.Add(btnUser);
            Name = "DashboardControl";
            Size = new Size(1091, 690);
            Load += DashboardControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUser;
        private Button btnTour;
        private Button btnLocation;
        private Button btnBooking;
        private Button btnTrip;
        private Label label1;
        private Label label2;
    }
}
