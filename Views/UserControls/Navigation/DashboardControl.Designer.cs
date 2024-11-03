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
            // NavigationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUser);
            Name = "NavigationControl";
            Size = new Size(1091, 690);
            ResumeLayout(false);
        }

        #endregion

        private Button btnUser;
    }
}
