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
            SuspendLayout();
            // 
            // txtLocationName
            // 
            txtLocationName.Location = new Point(153, 108);
            txtLocationName.Name = "txtLocationName";
            txtLocationName.Size = new Size(354, 27);
            txtLocationName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 115);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên địa điểm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 195);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Mô tả";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(153, 192);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(354, 27);
            txtDescription.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 275);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên thành phố";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(153, 272);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(354, 27);
            txtCity.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 363);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 7;
            label4.Text = "Quốc gia";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(153, 360);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(354, 27);
            txtCountry.TabIndex = 6;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(43, 443);
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
            btnAdd.Location = new Point(43, 443);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // ChangeLocationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Size = new Size(1211, 667);
            Load += ChangeLocationControl_Load;
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
    }
}
