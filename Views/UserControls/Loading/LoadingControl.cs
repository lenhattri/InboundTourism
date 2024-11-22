using System;
using System.Windows.Forms;

namespace Views.UserControls.Loading
{
    public partial class LoadingControl : UserControl
    {
        private int dotCount = 0;

        public LoadingControl()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            label1.Text = "Loading";
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            label1.Text = "Loading" + new string('.', dotCount);
        }

        private void LoadingControl_Load(object sender, EventArgs e)
        {

        }
    }
}
