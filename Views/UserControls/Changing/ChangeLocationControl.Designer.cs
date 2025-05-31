namespace Views.UserControls.Changing
{
    partial class ChangeLocationControl
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
            txtLocationName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            txtCity = new TextBox();
            label4 = new Label();
            txtCountry = new TextBox();
            btnChange = new Button();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            btnUpload = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtLocationName
            // 
            txtLocationName.Location = new Point(142, 48);
            txtLocationName.Name = "txtLocationName";
            txtLocationName.Size = new Size(354, 27);
            txtLocationName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 55);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên địa điểm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 135);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Mô tả";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(142, 132);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(354, 27);
            txtDescription.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 215);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên thành phố";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(142, 212);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(354, 27);
            txtCity.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 303);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 7;
            label4.Text = "Quốc gia";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(142, 300);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(354, 27);
            txtCountry.TabIndex = 6;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(32, 475);
            btnChange.Margin = new Padding(4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(149, 56);
            btnChange.TabIndex = 8;
            btnChange.Text = "Sửa";
            btnChange.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Desktop;
            btnAdd.Location = new Point(32, 475);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(560, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(455, 285);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.Violet;
            btnUpload.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpload.ForeColor = SystemColors.Desktop;
            btnUpload.Location = new Point(32, 401);
            btnUpload.Margin = new Padding(4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(149, 40);
            btnUpload.TabIndex = 11;
            btnUpload.Text = "Upload ảnh";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // ChangeLocationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUpload);
            Controls.Add(pictureBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(label4);
            Controls.Add(txtCountry);
            Controls.Add(label3);
            Controls.Add(txtCity);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label1);
            Controls.Add(txtLocationName);
            Name = "ChangeLocationControl";
            Size = new Size(1059, 548);
            Load += ChangeLocationControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLocationName;
        private Label label1;
        private Label label2;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtCity;
        private Label label4;
        private TextBox txtCountry;
        private Button btnChange;
        private Button btnAdd;
        private PictureBox pictureBox1;
        private Button btnUpload;
    }
}
