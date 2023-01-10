using ScottPlot;
using System.Data;
using System.Windows.Forms;

namespace ValueLens.View
{
    //由于System.Timers.Timer会在独立的线程工作，而Winform不允许跨线程访问控件，因此必须引入Invoke()
    //ref : https://jonskeet.uk/csharp/threads/winforms.html

    public partial class MainForm : Form
    {
        delegate void ProgressBarUpdateDelegate(int value);
        delegate void StatusLabelUpdateDelegate(double value);
        delegate void ProductionVolumeLabelUpdateDelegate(string value);
        delegate void DataGridUpdateDelegate(DataTable value);

        delegate void ElementDelegate(FormsPlot plot);

        public void UpdateProgressBar(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ProgressBarUpdateDelegate(UpdateProgressBar), value);
                return;
            }

            this.ProgressBar.Value = value;
        }

        //public void UpdateProgressBar(int value)    
        //{
        //    //The "Anonymous Delegate Minimized" Pattern
        //    //https://www.codeproject.com/Articles/37642/Avoiding-InvokeRequired

        //    BeginInvoke(new MethodInvoker(delegate
        //    {
        //        this.ProgressBar.Value = value;
        //    }));
        //}

        public void UpdateStatusLabel(double value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StatusLabelUpdateDelegate(UpdateStatusLabel), new object[] { value });
                return;
            }

            this.StatusLabel.Text = string.Format("刷新计时：{0:N1} s", value);
        }

        public void UpdateProductionVolumeLabel(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ProductionVolumeLabelUpdateDelegate(UpdateProductionVolumeLabel), new object[] { value });
                return;
            }

            this.ProductionVolumeLabel.Text = value;
        }

        public void UpdateDataGridView(DataTable value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DataGridUpdateDelegate(UpdateDataGridView), value);
                return;
            }

            this.DataGrid.DataSource = value;
        }

        public void RefreshPlot(FormsPlot plot)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ElementDelegate(RefreshPlot), plot);
                return;
            }
            plot.Refresh();
        }

        private void initUIUpdate()
        {
            this.ProgressBar.Maximum = getProgressBarMaximun();

            this.ProductionVolumeLabel.Text = "产能信息将在下次刷新后显示";

        }

        private int getProgressBarMaximun()
        {
            return Presenter.DatebaseUpdateInterval;
        }
    }
}
