using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using ValueLens.Model;
using ValueLens.View;

namespace ValueLens.Presenter
{
    public partial class ChartPresenter
    {
        private MainForm view;

        public List<MPoint> ActivePoints;

        public List<MPoint> AllPoints;

        public List<SerieBase> LineSeries { get; set; }
        public List<ScatterPlot> ScatterSeries { get; set; }
        public MarkerPlot HighlightedPoint;
        public bool PlotHoverEnabled;
        public int LastHighlightedIndex;

        public List<BarPlot> BarSeries { get; set; }

        public List<SerieBase> HistoSeries { get; set; }

        public ChartPresenter(MainForm view)
        {
            this.view = view;
            view.Presenter = this;
            Repo = new DataRepo();

            LineSeries = new List<SerieBase>();
            HistoSeries = new List<SerieBase>();

            ScatterSeries = new List<ScatterPlot>();
            BarSeries = new List<BarPlot>();

            LastHighlightedIndex = 0;
            PlotHoverEnabled = false;
            HighlightedPoint = new MarkerPlot();
            // Add a red circle we can move around later as a highlighted point indicator
            HighlightedPoint = view.LinePlot.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = Color.Red;
            HighlightedPoint.MarkerSize = 10;
            HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPoint.IsVisible = false;
            view.RefreshPlot(view.LinePlot);

            //使用独立线程管理Timer,并设置为后台线程，防止主线程结束时Timer线程仍然工作，导致报错
            Thread t = new Thread(InitTimer);
            t.IsBackground = true;
            t.Start();
        }

        public DataRepo Repo { get; private set; }



        //test mode
        public void ConnectDB()
        {
            bool result = Repo.ConnectDB();
            if (result)
                view.DBConnected = true;

            AllPoints = Repo.GetPointsList();
        }

        public void UpdateDataGrid()
        {
            var table = Repo.RawTable;
            view.UpdateDataGridView(Repo.RawTable);
        }
        public void QueryDefaultSQL()
        {
            Repo.UpdateRawDataTable();

            this.UpdateDataGrid();
        }

        public void DrawPlot()
        {
            var plot = view.LinePlot.Plot;
            var fixYAxisLimit = Config.GetAppSettingsValueByKey("FixYAxisLimit");
            var yAxisUpperLimit = Convert.ToDouble(Config.GetAppSettingsValueByKey("yAxisUpperLimit"));
            var yAxisLowerLimit = Convert.ToDouble(Config.GetAppSettingsValueByKey("yAxisLowerLimit"));
            plot.Palette = ScottPlot.Palette.Category10;
            List<ScatterPlot> scatterSeries = new List<ScatterPlot>();

            view.LinePlot.Plot.Clear();

            foreach (LineSerie s in LineSeries)
            {
                if (s.DataUpdated)
                {
                    var line = plot.AddScatter(s.XValues, s.YValues, label: s.Name);
                    scatterSeries.Add(line);
                    s.DataUpdated = false;
                }

            }
            //存储ScatterPlot系列的引用，以便MainForm调用
            ScatterSeries = scatterSeries;

            plot.Legend(location: Alignment.LowerLeft);
            if (fixYAxisLimit == "true") { plot.SetAxisLimitsY(yAxisLowerLimit, yAxisUpperLimit); }

            view.RefreshPlot(view.LinePlot);


            //histogram draw
            var histo = view.HistoPlot.Plot;
            histo.Palette = ScottPlot.Palette.Category10;
            histo.Clear();

            //v1.0.2 同步直方图和折线图的颜色
            for (int i = 0; i < HistoSeries.Count; i++)
            {
                HistogramSerie s = (HistogramSerie)HistoSeries[i];
                var syncColor = scatterSeries[i].Color;
                if (s.DataUpdated)
                {

                    var bar = histo.AddBar(s.YValues, s.XValues, color: syncColor);
                    bar.Label = s.Name;
                    bar.BarWidth = s.BarWidth;
                    bar.Orientation = ScottPlot.Orientation.Horizontal;
                    bar.FillColor = Color.FromArgb(50, bar.FillColor);
                    //density line
                    var curve = histo.AddScatterLines(
                        xs: s.Densities,
                        ys: s.NormEdges,
                        color: syncColor,
                        lineWidth: 1.5f,
                        lineStyle: LineStyle.Solid);
                    curve.XAxisIndex = 1;
                }
            }

            ////v1.0.1 原版直方图绘制
            //foreach(HistogramSerie s in HistoSeries)
            //{
            //    if (s.DataUpdated)
            //    {

            //        var bar = histo.AddBar(s.YValues, s.XValues);
            //        bar.Label = s.Name;
            //        bar.BarWidth = s.BarWidth;
            //        bar.Orientation = ScottPlot.Orientation.Horizontal;
            //        bar.FillColor = Color.FromArgb(50,bar.FillColor);
            //        //density line
            //        var curve = histo.AddScatterLines(
            //            xs: s.Densities,
            //            ys: s.NormEdges,
            //            color: Color.Black,
            //            lineWidth: 2f,
            //            lineStyle: LineStyle.Dash);
            //        curve.XAxisIndex = 1;
            //    }
            //}

            histo.SetAxisLimits(xMin: 0);
            if (fixYAxisLimit == "true") { histo.SetAxisLimitsY(yAxisLowerLimit, yAxisUpperLimit); }
            histo.Legend(location: Alignment.LowerRight);

            view.RefreshPlot(view.HistoPlot);
        }
    }

    //Timer implementation
    //ref : https://blog.csdn.net/zls365365/article/details/121804984

    /// <summary>
    /// <para>由于System.Timers.Timer会在独立的线程工作，而Winform不允许跨线程访问控件，因此必须引入Invoke()。</para>
    /// <see cref="https://jonskeet.uk/csharp/threads/winforms.html"/>
    /// </summary>
    public partial class ChartPresenter
    {
        private readonly int uiUpdateInterval = 100;
        public int DatebaseUpdateInterval = 1000 * 60;

        public System.Timers.Timer Timer { get; set; }
        //public Thread TimerThread { get;set; }
        private void InitTimer()
        {

            Timer = new System.Timers.Timer(uiUpdateInterval);

            Timer.Elapsed += new ElapsedEventHandler(TimerElapsed);

            Timer.AutoReset = true;

        }

        private int elapsedCount;

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Timer.Stop();
            if (elapsedCount * uiUpdateInterval > DatebaseUpdateInterval)
            {
                if (CheckConnection())
                {
                    elapsedCount = 0;
                    Repo.UpdateRawDataTable();
                    Repo.NotifyRepoUpdated(Repo.RawTable);
                    this.DrawPlot();
                    UpdateDataGrid();

                    //update volume info
                    view.UpdateProductionVolumeLabel(GetVolumnInfoString());
                }
                else
                {
                    MessageBox.Show("Database Connection Closed, Check Network!");
                    Timer.Stop();
                    return;
                }
            }
            else
                view.UpdateProgressBar(elapsedCount * uiUpdateInterval);
            view.UpdateStatusLabel((double)(DatebaseUpdateInterval - elapsedCount * uiUpdateInterval) / 1000);
            elapsedCount += 1;
            Timer.Start();
        }
        public bool CheckConnection()
        {
            if (this.Repo.Helper.Connection.State != ConnectionState.Open)
            {
                view.DBConnected = false;
                return false;
            }
            return true;
        }

        public string GetVolumnInfoString()
        {
            (int hourly, int daily) = this.Repo.Helper.GetProductionVolumeInfo();
            string volumnInfo = string.Format("当前时间 {0}，上一小时下线 {1}套，今日总计下线 {2}套", DateTime.Now.ToString("HH:mm"), hourly, daily);
            return volumnInfo;
        }
    }


}
