namespace Views.UserControls.Changing
{
    partial class ChangeTripControl
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
            label1 = new Label();
            txtPrice = new TextBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDistance = new TextBox();
            numMaxGuests = new NumericUpDown();
            label5 = new Label();
            listViewBookings = new ListView();
            btnAdd = new Button();
            btnChange = new Button();
            ((System.ComponentModel.ISupportInitialize)numMaxGuests).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 80);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 13;
            label1.Text = "Giá";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(239, 73);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(354, 27);
            txtPrice.TabIndex = 12;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(239, 142);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 14;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(239, 220);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 147);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 16;
            label2.Text = "Ngày bắt đầu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 227);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 17;
            label3.Text = "Ngày kết thúc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(129, 289);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 19;
            label4.Text = "Độ dài chuyến đi";
            // 
            // txtDistance
            // 
            txtDistance.Location = new Point(256, 289);
            txtDistance.Name = "txtDistance";
            txtDistance.Size = new Size(354, 27);
            txtDistance.TabIndex = 18;
            // 
            // numMaxGuests
            // 
            numMaxGuests.Location = new Point(313, 356);
            numMaxGuests.Name = "numMaxGuests";
            numMaxGuests.Size = new Size(150, 27);
            numMaxGuests.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(129, 356);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 21;
            label5.Text = "Tối đa tổng hành khách";
            // 
            // listViewBookings
            // 
            listViewBookings.Location = new Point(129, 416);
            listViewBookings.Name = "listViewBookings";
            listViewBookings.Size = new Size(556, 160);
            listViewBookings.TabIndex = 22;
            listViewBookings.UseCompatibleStateImageBehavior = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Desktop;
            btnAdd.Location = new Point(129, 416);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(129, 587);
            btnChange.Margin = new Padding(4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(149, 56);
            btnChange.TabIndex = 23;
            btnChange.Text = "Sửa";
            btnChange.UseVisualStyleBackColor = false;
            // 
            // ChangeTripControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(listViewBookings);
            Controls.Add(label5);
            Controls.Add(numMaxGuests);
            Controls.Add(label4);
            Controls.Add(txtDistance);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label1);
            Controls.Add(txtPrice);
            Name = "ChangeTripControl";
            Size = new Size(970, 643);
            ((System.ComponentModel.ISupportInitialize)numMaxGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPrice;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtDistance;
        private NumericUpDown numMaxGuests;
        private Label label5;
        private ListView listViewBookings;
        private Button btnAdd;
        private Button btnChange;
    }
}
