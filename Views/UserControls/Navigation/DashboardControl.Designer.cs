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
            SuspendLayout();
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Violet;
            btnUser.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Location = new Point(123, 86);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(109, 47);
            btnUser.TabIndex = 4;
            btnUser.Text = "Người dùng";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnTour
            // 
            btnTour.BackColor = Color.Violet;
            btnTour.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTour.Location = new Point(123, 148);
            btnTour.Name = "btnTour";
            btnTour.Size = new Size(109, 47);
            btnTour.TabIndex = 5;
            btnTour.Text = "Tour";
            btnTour.UseVisualStyleBackColor = false;
            btnTour.Click += button1_Click;
            // 
            // btnLocation
            // 
            btnLocation.BackColor = Color.Violet;
            btnLocation.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLocation.Location = new Point(338, 86);
            btnLocation.Name = "btnLocation";
            btnLocation.Size = new Size(162, 47);
            btnLocation.TabIndex = 6;
            btnLocation.Text = "Điểm du lịch";
            btnLocation.UseVisualStyleBackColor = false;
            btnLocation.Click += btnLocation_Click;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.Violet;
            btnBooking.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBooking.Location = new Point(605, 86);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(162, 47);
            btnBooking.TabIndex = 7;
            btnBooking.Text = "Vé";
            btnBooking.UseVisualStyleBackColor = false;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnTrip
            // 
            btnTrip.BackColor = Color.Violet;
            btnTrip.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTrip.Location = new Point(338, 148);
            btnTrip.Name = "btnTrip";
            btnTrip.Size = new Size(162, 47);
            btnTrip.TabIndex = 8;
            btnTrip.Text = "Chuyến đi";
            btnTrip.UseVisualStyleBackColor = false;
            btnTrip.Click += btnTrip_Click;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnTrip);
            Controls.Add(btnBooking);
            Controls.Add(btnLocation);
            Controls.Add(btnTour);
            Controls.Add(btnUser);
            Name = "DashboardControl";
            Size = new Size(1091, 690);
            Load += DashboardControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnUser;
        private Button btnTour;
        private Button btnLocation;
        private Button btnBooking;
        private Button btnTrip;
    }
}
