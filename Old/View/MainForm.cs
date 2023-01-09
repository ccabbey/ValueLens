using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ValueLens.Model;
using ValueLens.Presenter;


namespace ValueLens.View
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            if (Config.GetAppSettingsValueByKey("ShowSplashScreen").ToString() == "true")
            {
                showSplash();
            }

        }

        private void showSplash()
        {
            SplashScreen welcome = new SplashScreen();
            try
            {
                welcome = new SplashScreen();
                welcome.StartPosition = FormStartPosition.CenterScreen;
                welcome.ShowDialog();
                //等待两秒，使主线程充分显示
                //Thread.Sleep(3000);
                //welcome.Close();
            }
            catch (ThreadAbortException e)
            {
                throw e;
            }
            finally
            {
                welcome = null;
            }
        }

        /// <summary>
        /// 图表控制器在MainForm的引用，为了方便TestMenu的手工触发命令，目前设为public。
        /// 后期可改为private。
        /// </summary>
        public ChartPresenter Presenter { private get; set; }


        #region AutoSize Control

        /// <summary>
        /// 自动缩放控制器的引用
        /// </summary>
        private AutoSizeController autoSizeController;

        /// <summary>
        /// 注册需要自动缩放的控件
        /// </summary>
        private void addControlsToControllerStub()
        {

            autoSizeController.AddControl(dataGridView1);
            autoSizeController.AddControl(linePlot);
            autoSizeController.AddControl(histoPlot);
            autoSizeController.AddControl(panel1);
            autoSizeController.AddControl(pictureBox1);
            //_autoSizeController.AddControl(button1);
        }

        private bool AutoSizeEnabled = true;

        private void OnFormSizeChanged(object sender, EventArgs e)
        {
            if (AutoSizeEnabled)
                autoSizeController.AutoSize();
        }

        #endregion

        private void OnLoad(object sender, EventArgs e)
        {
            autoSizeController = new AutoSizeController(this);

            addControlsToControllerStub();

            initUIUpdate();

            //linePlot.MouseMove += new MouseEventHandler(OnMouseMove);

        }
        private void OnAuto(object sender, EventArgs e)
        {

        }

        private bool dbConnected;
        public bool DBConnected
        {
            get { return dbConnected; }
            set
            {
                dbConnected = value;
                if (dbConnected)
                {
                    this.DBStatus.Text = "数据库状态：在线";
                }
                else
                {
                    this.DBStatus.Text = "数据库状态：离线";
                }
            }
        }

        public DataGridView DataGrid
        {
            get { return dataGridView1; }
        }

        public FormsPlot LinePlot
        {
            get { return linePlot; }
        }

        public FormsPlot HistoPlot
        {
            get { return histoPlot; }
        }

        private void ConnectDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.ConnectDB();
            Presenter.QueryDefaultSQL();

            var list = Presenter.Repo.GetPointsList();
            AddAllPointsToMenu(list);
        }

        private void QueryTop1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Presenter.QueryTop1000();

            //var list = Presenter.Repo.GetPointsList();
            //AddAllPointsToMenu(list);
        }

        public void AddAllPointsToMenu(List<MPoint> list)
        {
            foreach (MPoint point in list)
            {
                AddPointItemToMenu(point);
            }
        }
        public void AddPointItemToMenu(MPoint point)
        {
            var newPointItem = new ToolStripMenuItem(point.name)
            {
                Name = point.name
            };
            newPointItem.Click += delegate (object sender, EventArgs e)
            {
                OnClickAddPoint(point, newPointItem);

            };

            ToolStripMenuItem baseMenu;
            switch (point.direction)
            {
                case "X":
                    baseMenu = XPointsMenu;
                    break;
                case "Y":
                    baseMenu = YPointsMenu;
                    break;
                case "Z":
                    baseMenu = ZPointsMenu;
                    break;
                default:
                    //throw new Exception("Incorrect MP Name.");
                    baseMenu = ZPointsMenu;
                    break;
            }

            baseMenu.DropDownItems.Add(newPointItem);
            //newPointItem.Checked = false;
        }
        public void OnClickAddPoint(MPoint point, ToolStripMenuItem item)
        {
            //FIXME isActive is always true, why?
            //point.isActive = !point.isActive;
            item.Checked = true;

            //add same item to 'remove' menu
            AddPointItemToActiveMenu(point, ActivePointsMenu);

            //create LineChart instance
            LineSerie line = new LineSerie(point.name);
            //Presenter.Repo.Subscribe(line);
            line.Subscribe(Presenter.Repo);
            Presenter.LineSeries.Add(line);

            //histo
            HistogramSerie histo = new HistogramSerie(point.name);
            histo.Subscribe(Presenter.Repo);
            Presenter.HistoSeries.Add(histo);


            Presenter.Repo.UpdateRawDataTable();
            Presenter.DrawPlot();
        }

        public void AddPointItemToActiveMenu(MPoint point, ToolStripMenuItem menu)
        {
            ToolStripMenuItem newPointItem = new ToolStripMenuItem(point.name);
            newPointItem.Name = point.name;
            newPointItem.Click += delegate (object sender, EventArgs e)
            {
                OnClickRemovePoint(point, newPointItem);
            };

            menu.DropDownItems.Add(newPointItem);
            newPointItem.Checked = true;

            int count = menu.DropDownItems.Count;

            menu.Text = $"Active({count})";

        }

        /// <summary>
        /// 点击激活测点菜单中的测点，触发删除测点动作。
        /// </summary>
        /// <param name="point">要删除的测点</param>
        /// <param name="item">测点对应的菜单项</param>
        private void OnClickRemovePoint(MPoint point, ToolStripMenuItem item)
        {
            //TODO: Prensenter.LineSeries 和 HistoSeries有些重复，需要优化

            ActivePointsMenu.DropDownItems.Remove(item);
            foreach (ToolStripMenuItem ite in AllPointsMenu.DropDownItems)
            {
                foreach (ToolStripMenuItem it in ite.DropDownItems)
                {
                    if (it.Name == item.Name)
                    {
                        it.Checked = false;
                    }
                }
                SerieBase serieToRemove = null;
                foreach (SerieBase serie in Presenter.LineSeries)
                {
                    if (serie.Name == point.name)
                    {
                        serie.Unsubscribe();
                        serieToRemove = serie;
                    }
                }

                if (serieToRemove != null)
                    Presenter.LineSeries.Remove(serieToRemove);
                this.linePlot.Plot.Clear();

                foreach (SerieBase serie in Presenter.HistoSeries)
                {
                    if (serie.Name == point.name)
                    {
                        serie.Unsubscribe();
                        serieToRemove = serie;
                    }
                }

                if (serieToRemove != null)
                    Presenter.HistoSeries.Remove(serieToRemove);
                this.linePlot.Plot.Clear();

                Presenter.Repo.UpdateRawDataTable();
                Presenter.DrawPlot();
            }

            //Presenter.LineSeries.Remove()

            int count = ActivePointsMenu.DropDownItems.Count;
            ActivePointsMenu.Text = $"Active({count})";
        }

        private void DisableTimerMenu_Click(object sender, EventArgs e)
        {
            Presenter.Timer.Enabled = false;
        }

        private void EnableTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.Timer.Enabled = true;
        }

        private void TrigerRepoPushMenu_Click(object sender, EventArgs e)
        {
            Presenter.Repo.UpdateRawDataTable();
            this.UpdateProductionVolumeLabel(Presenter.GetVolumnInfoString());
        }

        private void TrigerDrawPlotMenu_Click(object sender, EventArgs e)
        {
            Presenter.DrawPlot();
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Presenter.PlotHoverEnabled == false) return;
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = linePlot.GetMouseCoordinates();

            double xyRatio = linePlot.Plot.XAxis.Dims.PxPerUnit / linePlot.Plot.YAxis.Dims.PxPerUnit;

            List<(ScatterPlot, double, double, double, int)> distanceTuples = new List<(ScatterPlot, double, double, double, int)>();
            foreach (var scatter in Presenter.ScatterSeries)
            {
                (double pointX, double pointY, int pointIndex) = scatter.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
                var distance = Math.Pow(pointX - mouseCoordX, 2) + Math.Pow(pointY - mouseCoordY, 2);
                //Console.WriteLine("distance:{0}",distance);
                distanceTuples.Add((scatter, distance, pointX, pointY, pointIndex));
            }

            if (distanceTuples.Count > 0)
            {
                var res = distanceTuples.OrderBy(x => x.Item2).First();
                if (Presenter.PlotHoverEnabled == true)
                {

                    // place the highlight over the point of interest
                    Presenter.HighlightedPoint.X = res.Item3;
                    Presenter.HighlightedPoint.Y = res.Item4;
                    Console.WriteLine($"{Presenter.HighlightedPoint.X}, {Presenter.HighlightedPoint.Y}");
                    Presenter.HighlightedPoint.IsVisible = true;

                    // render if the highlighted point chnaged
                    if (Presenter.LastHighlightedIndex != res.Item5)
                    {
                        Presenter.LastHighlightedIndex = res.Item5;
                        linePlot.Render();
                    }

                    // update the GUI to describe the highlighted point
                    var line = (LineSerie)Presenter.LineSeries[0];
                    if (res.Item2 < 1)
                    {
                        CoordLabel.Visible = true;
                        CoordLabel.Text = $"{line.FrameSNs[res.Item5]}\r\n{line.DateTimes[res.Item5]}\r\n{res.Item4:N2}";
                        CoordLabel.Left = e.X;
                        CoordLabel.Top = e.Y;
                    }
                    else
                    {
                        CoordLabel.Visible = false;

                    }

                }
            }


        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            for (var i = 0; i < e.RowCount; i++)
            {
                dgv.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }

            for (var i = e.RowIndex + e.RowCount; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void ShowDefaultZPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPoint CreateMP(string name)
            {
                MPoint mp = new MPoint();
                mp.name = name;
                return mp;
            }
            var list = Presenter.Repo.GetPointsList();

            //ongoing
            //OnClickAddPoint(CreateMP("MP75Z"),this.["MP75Z"]);
        }

        private void autoScaleOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AutoSizeEnabled = !AutoSizeEnabled;
            autoScaleOnToolStripMenuItem.Text = string.Format("切换自动缩放（当前：{0}）", AutoSizeEnabled);
        }

        private void ReloadQueryString_Click(object sender, EventArgs e)
        {
            Presenter.QueryDefaultSQL();
        }

        private void VersionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new Old.View.AboutForm();
            aboutForm.ShowDialog();
        }

        private void toggleHoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.PlotHoverEnabled = !Presenter.PlotHoverEnabled;
            toggleHoverToolStripMenuItem.Checked = !toggleHoverToolStripMenuItem.Checked;

            if (Presenter.PlotHoverEnabled == false)
            {
                CoordLabel.Visible = false;
                Presenter.HighlightedPoint.IsVisible = false;
            }
            else
            {
                CoordLabel.Visible = true;
                Presenter.HighlightedPoint.IsVisible = true;
            }

        }
    }
}
