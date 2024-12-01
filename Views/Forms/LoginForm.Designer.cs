namespace Views.Forms
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContainer = new Panel();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(0, 3);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(897, 507);
            panelContainer.TabIndex = 0;
            panelContainer.Paint += panel1_Paint;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 510);
            Controls.Add(panelContainer);
            ImeMode = ImeMode.NoControl;
            Name = "Login";
            Text = "LoginForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
    }
}