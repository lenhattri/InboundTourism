namespace Views.UserControls.Changing
{
    partial class ChangeTourControl
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
            btnAdd = new Button();
            btnChange = new Button();
            label1 = new Label();
            txtTourName = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            listView1 = new ListView();
            colID = new ColumnHeader();
            colName = new ColumnHeader();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Desktop;
            btnAdd.Location = new Point(111, 362);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 56);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.SkyBlue;
            btnChange.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChange.ForeColor = SystemColors.Desktop;
            btnChange.Location = new Point(111, 362);
            btnChange.Margin = new Padding(4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(149, 56);
            btnChange.TabIndex = 18;
            btnChange.Text = "Sửa";
            btnChange.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 67);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 11;
            label1.Text = "Tên tour";
            // 
            // txtTourName
            // 
            txtTourName.Location = new Point(221, 60);
            txtTourName.Name = "txtTourName";
            txtTourName.Size = new Size(354, 27);
            txtTourName.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 125);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 21;
            label2.Text = "Mô tả";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(221, 118);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(354, 27);
            txtDescription.TabIndex = 20;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colID, colName });
            listView1.Location = new Point(110, 182);
            listView1.Name = "listView1";
            listView1.Size = new Size(583, 145);
            listView1.TabIndex = 22;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ChangeTourControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(label1);
            Controls.Add(txtTourName);
            Name = "ChangeTourControl";
            Size = new Size(1053, 699);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnChange;
        private Label label1;
        private TextBox txtTourName;
        private Label label2;
        private TextBox txtDescription;
        private ListView listView1;
        private ColumnHeader colID;
        private ColumnHeader colName;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
