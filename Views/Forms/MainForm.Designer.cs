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
            lbName.Location = new Point(50, 118);
            lbName.Name = "lbName";
            lbName.Size = new Size(105, 33);
            lbName.TabIndex = 3;
            lbName.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateBlue;
            ClientSize = new Size(1347, 610);
            Controls.Add(lbName);
            Controls.Add(btnTables);
            Controls.Add(panelContainer);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelContainer;
        private PictureBox pictureBox1;
        private Button btnTables;
        private Label lbName;
    }
}