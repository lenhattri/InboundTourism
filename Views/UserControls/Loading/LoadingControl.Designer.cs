namespace Views.UserControls.Loading
{
    partial class LoadingControl
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 90F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Plum;
            label1.Location = new Point(108, 240);
            label1.Name = "label1";
            label1.Size = new Size(963, 198);
            label1.TabIndex = 0;
            label1.Text = "Loading...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._物語シリーズ_まよいキャンディー___TosTosのイラスト___pixiv;
            pictureBox1.Location = new Point(354, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // LoadingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "LoadingControl";
            Size = new Size(1153, 549);
            Load += LoadingControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
    }
}
