namespace Views.UserControls.Changing
{
    partial class ChangeUserControl
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
            label5 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            Email = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            txtPhoneNumber = new TextBox();
            label2 = new Label();
            txtFullname = new TextBox();
            cbRole = new ComboBox();
            label3 = new Label();
            btnAdd = new Button();
            btnChange = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 437);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 46;
            label5.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(448, 434);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(354, 27);
            txtAddress.TabIndex = 45;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 368);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 44;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(448, 365);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(354, 27);
            txtEmail.TabIndex = 43;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(338, 317);
            Email.Name = "Email";
            Email.Size = new Size(70, 20);
            Email.TabIndex = 40;
            Email.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(448, 310);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(354, 27);
            txtPassword.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 252);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 38;
            label1.Text = "Số điện thoại";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(448, 245);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(354, 27);
            txtPhoneNumber.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(338, 182);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 36;
            label2.Text = "Tên đầy đủ";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(448, 175);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(354, 27);
            txtFullname.TabIndex = 35;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(448, 481);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(151, 28);
            cbRole.TabIndex = 49;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 489);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 50;
            label3.Text = "Vai trò";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Desktop;
            btnAdd.Location = new Point(415, 590);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 52;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(415, 590);
            btnChange.Margin = new Padding(4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(149, 56);
            btnChange.TabIndex = 51;
            btnChange.Text = "Sửa";
            btnChange.UseVisualStyleBackColor = false;
            // 
            // ChangeUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(label3);
            Controls.Add(cbRole);
            Controls.Add(label5);
            Controls.Add(txtAddress);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(Email);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label2);
            Controls.Add(txtFullname);
            Name = "ChangeUserControl";
            Size = new Size(1076, 813);
            Load += ChangeUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtEmail;
        private Label Email;
        private TextBox txtPassword;
        private Label label1;
        private TextBox txtPhoneNumber;
        private Label label2;
        private TextBox txtFullname;
        private ComboBox cbRole;
        private Label label3;
        private Button btnAdd;
        private Button btnChange;
    }
}
