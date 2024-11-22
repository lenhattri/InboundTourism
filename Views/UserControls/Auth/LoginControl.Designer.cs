namespace Views.UserControls.Auth
{
    partial class LoginControl
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
            label4 = new Label();
            txtEmail = new TextBox();
            Email = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(230, 36);
            label1.Name = "label1";
            label1.Size = new Size(468, 106);
            label1.TabIndex = 0;
            label1.Text = "Đăng Nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 194);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 33;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(306, 191);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(354, 27);
            txtEmail.TabIndex = 32;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(196, 244);
            Email.Name = "Email";
            Email.Size = new Size(70, 20);
            Email.TabIndex = 35;
            Email.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(306, 237);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(354, 27);
            txtPassword.TabIndex = 34;
           
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGreen;
            btnLogin.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Desktop;
            btnLogin.Location = new Point(370, 319);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(149, 56);
            btnLogin.TabIndex = 36;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLogin);
            Controls.Add(Email);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Name = "LoginControl";
            Size = new Size(887, 543);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private TextBox txtEmail;
        private Label Email;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
