namespace Views.UserControls.Auth
{
    partial class RegisterControl
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
            label2 = new Label();
            txtFullname = new TextBox();
            label1 = new Label();
            txtPhoneNumber = new TextBox();
            Email = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtAddress = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 34);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 23;
            label2.Text = "Tên đầy đủ";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(294, 27);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(354, 27);
            txtFullname.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 104);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 25;
            label1.Text = "Số điện thoại";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(294, 97);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(354, 27);
            txtPhoneNumber.TabIndex = 24;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(184, 169);
            Email.Name = "Email";
            Email.Size = new Size(70, 20);
            Email.TabIndex = 27;
            Email.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(294, 162);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(354, 27);
            txtPassword.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 229);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 29;
            label3.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(294, 222);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(354, 27);
            txtConfirmPassword.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(208, 279);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 31;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(294, 276);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(354, 27);
            txtEmail.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(208, 348);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 33;
            label5.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(294, 345);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(354, 27);
            txtAddress.TabIndex = 32;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.LightGreen;
            btnRegister.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = SystemColors.Desktop;
            btnRegister.Location = new Point(208, 433);
            btnRegister.Margin = new Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(149, 56);
            btnRegister.TabIndex = 34;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRegister);
            Controls.Add(label5);
            Controls.Add(txtAddress);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtConfirmPassword);
            Controls.Add(Email);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label2);
            Controls.Add(txtFullname);
            Name = "RegisterControl";
            Size = new Size(847, 537);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtFullname;
        private Label label1;
        private TextBox txtPhoneNumber;
        private Label Email;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtConfirmPassword;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtAddress;
        private Button btnRegister;
    }
}
