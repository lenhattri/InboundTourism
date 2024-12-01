namespace Views.Forms
{
    partial class MainForm
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
            btnTables = new Button();
            lbName = new Label();
            btnLogOut = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.Lavender;
            panelContainer.Location = new Point(246, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1514, 921);
            panelContainer.TabIndex = 0;
            panelContainer.Paint += panelContainer_Paint;
            // 
            // btnTables
            // 
            btnTables.BackColor = Color.Violet;
            btnTables.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTables.Location = new Point(36, 301);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(133, 53);
            btnTables.TabIndex = 2;
            btnTables.Text = "☰ Các bảng";
            btnTables.UseVisualStyleBackColor = false;
            btnTables.Click += btnTables_Click;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Cascadia Code", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbName.ForeColor = Color.White;
            lbName.ImageAlign = ContentAlignment.BottomLeft;
            lbName.Location = new Point(50, 174);
            lbName.Name = "lbName";
            lbName.Size = new Size(105, 33);
            lbName.TabIndex = 3;
            lbName.Text = "label1";
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Violet;
            btnLogOut.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(36, 395);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(133, 53);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "🔓Đăng xuất";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Violet;
            button1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(36, 482);
            button1.Name = "button1";
            button1.Size = new Size(133, 53);
            button1.TabIndex = 5;
            button1.Text = "✖ Thoát";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateBlue;
            ClientSize = new Size(1546, 791);
            Controls.Add(button1);
            Controls.Add(btnLogOut);
            Controls.Add(lbName);
            Controls.Add(btnTables);
            Controls.Add(panelContainer);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelContainer;
        private PictureBox pictureBox1;
        private Button btnTables;
        private Label lbName;
        private Button btnLogOut;
        private Button button1;
    }
}