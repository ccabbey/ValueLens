using System;
using System.Windows.Forms;


namespace ValueLens.View
{
    public partial class SplashScreen : Form
    {
        private long timeElapsedInMilliSeconds;
        public SplashScreen()
        {


            InitializeComponent();
            splashTimer.Interval = 500;
            splashTimer.Start();

        }
        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            //this.InfoLabel.Text = "检查配置文件...";
            //System.Threading.Thread.Sleep(1000);
            //this.InfoLabel.Text = "初始化ValueLens框架...";
            //System.Threading.Thread.Sleep(1000);
            //this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OnTick(object sender, EventArgs e)
        {
            timeElapsedInMilliSeconds += this.splashTimer.Interval;
            this.InfoLabel.Text += ".";

            if (timeElapsedInMilliSeconds > 3000)
            {
                this.Close();
            }
        }
    }
}
