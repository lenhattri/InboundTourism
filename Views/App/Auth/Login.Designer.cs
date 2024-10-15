namespace Views.App.Auth
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
            this.components = new System.ComponentModel.Container();
            this.inboundTourismDataSet = new Views.InboundTourismDataSet();
            this.inboundTourismDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inboundTourismDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inboundTourismDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // inboundTourismDataSet
            // 
            this.inboundTourismDataSet.DataSetName = "InboundTourismDataSet";
            this.inboundTourismDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inboundTourismDataSetBindingSource
            // 
            this.inboundTourismDataSetBindingSource.DataSource = this.inboundTourismDataSet;
            this.inboundTourismDataSetBindingSource.Position = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Login";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inboundTourismDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inboundTourismDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InboundTourismDataSet inboundTourismDataSet;
        private System.Windows.Forms.BindingSource inboundTourismDataSetBindingSource;
    }
}