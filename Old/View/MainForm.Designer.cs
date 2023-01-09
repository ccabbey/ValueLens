namespace ValueLens.View
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PointMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AllPointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ZPointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.YPointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.XPointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ActivePointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleCrosshairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleHoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryTop1000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.disableTimerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TrigerRepoPushMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TrigerDrawPlotMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.autoScaleOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.插入默认Z向测点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.DBStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProductionVolumeLabel = new System.Windows.Forms.Label();
            this.histoPlot = new ScottPlot.FormsPlot();
            this.linePlot = new ScottPlot.FormsPlot();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CoordLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointMenu,
            this.ChartConfigToolStripMenuItem,
            this.testToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PointMenu
            // 
            this.PointMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllPointsMenu,
            this.ActivePointsMenu});
            this.PointMenu.Name = "PointMenu";
            this.PointMenu.Size = new System.Drawing.Size(44, 21);
            this.PointMenu.Text = "测点";
            // 
            // AllPointsMenu
            // 
            this.AllPointsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZPointsMenu,
            this.YPointsMenu,
            this.XPointsMenu});
            this.AllPointsMenu.Name = "AllPointsMenu";
            this.AllPointsMenu.Size = new System.Drawing.Size(125, 22);
            this.AllPointsMenu.Text = "All";
            // 
            // ZPointsMenu
            // 
            this.ZPointsMenu.Name = "ZPointsMenu";
            this.ZPointsMenu.Size = new System.Drawing.Size(84, 22);
            this.ZPointsMenu.Text = "Z";
            // 
            // YPointsMenu
            // 
            this.YPointsMenu.Name = "YPointsMenu";
            this.YPointsMenu.Size = new System.Drawing.Size(84, 22);
            this.YPointsMenu.Text = "Y";
            // 
            // XPointsMenu
            // 
            this.XPointsMenu.Name = "XPointsMenu";
            this.XPointsMenu.Size = new System.Drawing.Size(84, 22);
            this.XPointsMenu.Text = "X";
            // 
            // ActivePointsMenu
            // 
            this.ActivePointsMenu.Name = "ActivePointsMenu";
            this.ActivePointsMenu.Size = new System.Drawing.Size(125, 22);
            this.ActivePointsMenu.Text = "Active(0)";
            // 
            // ChartConfigToolStripMenuItem
            // 
            this.ChartConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleCrosshairToolStripMenuItem,
            this.toggleHoverToolStripMenuItem});
            this.ChartConfigToolStripMenuItem.Name = "ChartConfigToolStripMenuItem";
            this.ChartConfigToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ChartConfigToolStripMenuItem.Text = "显示";
            // 
            // toggleCrosshairToolStripMenuItem
            // 
            this.toggleCrosshairToolStripMenuItem.Enabled = false;
            this.toggleCrosshairToolStripMenuItem.Name = "toggleCrosshairToolStripMenuItem";
            this.toggleCrosshairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleCrosshairToolStripMenuItem.Text = "光标十字线";
            // 
            // toggleHoverToolStripMenuItem
            // 
            this.toggleHoverToolStripMenuItem.Name = "toggleHoverToolStripMenuItem";
            this.toggleHoverToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleHoverToolStripMenuItem.Text = "测点信息浮动显示";
            this.toggleHoverToolStripMenuItem.Click += new System.EventHandler(this.toggleHoverToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectDBToolStripMenuItem,
            this.queryTop1000ToolStripMenuItem,
            this.toolStripSeparator1,
            this.disableTimerMenu,
            this.enableTimerToolStripMenuItem,
            this.toolStripSeparator2,
            this.TrigerRepoPushMenu,
            this.TrigerDrawPlotMenu,
            this.toolStripSeparator3,
            this.autoScaleOnToolStripMenuItem,
            this.toolStripSeparator4,
            this.插入默认Z向测点ToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.testToolStripMenuItem.Text = "设置";
            // 
            // connectDBToolStripMenuItem
            // 
            this.connectDBToolStripMenuItem.Name = "connectDBToolStripMenuItem";
            this.connectDBToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.connectDBToolStripMenuItem.Text = "连接数据库";
            this.connectDBToolStripMenuItem.Click += new System.EventHandler(this.ConnectDBToolStripMenuItem_Click);
            // 
            // queryTop1000ToolStripMenuItem
            // 
            this.queryTop1000ToolStripMenuItem.Name = "queryTop1000ToolStripMenuItem";
            this.queryTop1000ToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.queryTop1000ToolStripMenuItem.Text = "重新加载查询";
            this.queryTop1000ToolStripMenuItem.Click += new System.EventHandler(this.ReloadQueryString_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // disableTimerMenu
            // 
            this.disableTimerMenu.Name = "disableTimerMenu";
            this.disableTimerMenu.Size = new System.Drawing.Size(234, 22);
            this.disableTimerMenu.Text = "暂停自动更新";
            this.disableTimerMenu.Click += new System.EventHandler(this.DisableTimerMenu_Click);
            // 
            // enableTimerToolStripMenuItem
            // 
            this.enableTimerToolStripMenuItem.Name = "enableTimerToolStripMenuItem";
            this.enableTimerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.enableTimerToolStripMenuItem.Text = "启用自动更新";
            this.enableTimerToolStripMenuItem.Click += new System.EventHandler(this.EnableTimerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // TrigerRepoPushMenu
            // 
            this.TrigerRepoPushMenu.Name = "TrigerRepoPushMenu";
            this.TrigerRepoPushMenu.Size = new System.Drawing.Size(234, 22);
            this.TrigerRepoPushMenu.Text = "触发Repo推送";
            this.TrigerRepoPushMenu.Click += new System.EventHandler(this.TrigerRepoPushMenu_Click);
            // 
            // TrigerDrawPlotMenu
            // 
            this.TrigerDrawPlotMenu.Name = "TrigerDrawPlotMenu";
            this.TrigerDrawPlotMenu.Size = new System.Drawing.Size(234, 22);
            this.TrigerDrawPlotMenu.Text = "触发图形重绘";
            this.TrigerDrawPlotMenu.Click += new System.EventHandler(this.TrigerDrawPlotMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
            // 
            // autoScaleOnToolStripMenuItem
            // 
            this.autoScaleOnToolStripMenuItem.Name = "autoScaleOnToolStripMenuItem";
            this.autoScaleOnToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.autoScaleOnToolStripMenuItem.Text = "切换自动缩放（当前：True）";
            this.autoScaleOnToolStripMenuItem.Click += new System.EventHandler(this.autoScaleOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(231, 6);
            // 
            // 插入默认Z向测点ToolStripMenuItem
            // 
            this.插入默认Z向测点ToolStripMenuItem.Name = "插入默认Z向测点ToolStripMenuItem";
            this.插入默认Z向测点ToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.插入默认Z向测点ToolStripMenuItem.Text = "插入默认Z向测点";
            this.插入默认Z向测点ToolStripMenuItem.Click += new System.EventHandler(this.ShowDefaultZPointsToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionInfoToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // VersionInfoToolStripMenuItem
            // 
            this.VersionInfoToolStripMenuItem.Name = "VersionInfoToolStripMenuItem";
            this.VersionInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.VersionInfoToolStripMenuItem.Text = "版本信息";
            this.VersionInfoToolStripMenuItem.Click += new System.EventHandler(this.VersionInfoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar,
            this.DBStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1132, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(56, 17);
            this.StatusLabel.Text = "刷新计时";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar.Value = 88;
            // 
            // DBStatus
            // 
            this.DBStatus.Name = "DBStatus";
            this.DBStatus.Size = new System.Drawing.Size(104, 17);
            this.DBStatus.Text = "数据库状态：离线";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 430);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 184);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.CoordLabel);
            this.panel1.Controls.Add(this.ProductionVolumeLabel);
            this.panel1.Controls.Add(this.histoPlot);
            this.panel1.Controls.Add(this.linePlot);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 618);
            this.panel1.TabIndex = 7;
            // 
            // ProductionVolumeLabel
            // 
            this.ProductionVolumeLabel.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductionVolumeLabel.Location = new System.Drawing.Point(4, 6);
            this.ProductionVolumeLabel.Name = "ProductionVolumeLabel";
            this.ProductionVolumeLabel.Size = new System.Drawing.Size(955, 26);
            this.ProductionVolumeLabel.TabIndex = 7;
            this.ProductionVolumeLabel.Text = "当前时间 09:00:00，上一小时下线 00套，今日总计下线 00套";
            // 
            // histoPlot
            // 
            this.histoPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histoPlot.Location = new System.Drawing.Point(778, 35);
            this.histoPlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.histoPlot.Name = "histoPlot";
            this.histoPlot.Size = new System.Drawing.Size(348, 389);
            this.histoPlot.TabIndex = 6;
            // 
            // linePlot
            // 
            this.linePlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePlot.Location = new System.Drawing.Point(3, 35);
            this.linePlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.linePlot.Name = "linePlot";
            this.linePlot.Size = new System.Drawing.Size(769, 389);
            this.linePlot.TabIndex = 5;
            this.linePlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ValueLens.Properties.Resources.图片1;
            this.pictureBox1.Location = new System.Drawing.Point(1035, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // CoordLabel
            // 
            this.CoordLabel.AutoSize = true;
            this.CoordLabel.BackColor = System.Drawing.Color.Transparent;
            this.CoordLabel.Location = new System.Drawing.Point(531, 47);
            this.CoordLabel.Name = "CoordLabel";
            this.CoordLabel.Size = new System.Drawing.Size(29, 12);
            this.CoordLabel.TabIndex = 9;
            this.CoordLabel.Text = "坐标";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ValueLens Monitor";
            this.Load += new System.EventHandler(this.OnLoad);
            this.SizeChanged += new System.EventHandler(this.OnFormSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel DBStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private ScottPlot.FormsPlot histoPlot;
        private ScottPlot.FormsPlot linePlot;
        private System.Windows.Forms.ToolStripMenuItem ChartConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleCrosshairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleHoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PointMenu;
        private System.Windows.Forms.ToolStripMenuItem AllPointsMenu;
        private System.Windows.Forms.ToolStripMenuItem ActivePointsMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryTop1000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XPointsMenu;
        private System.Windows.Forms.ToolStripMenuItem YPointsMenu;
        private System.Windows.Forms.ToolStripMenuItem ZPointsMenu;
        private System.Windows.Forms.ToolStripMenuItem disableTimerMenu;
        private System.Windows.Forms.ToolStripMenuItem enableTimerToolStripMenuItem;
        public System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripMenuItem TrigerRepoPushMenu;
        private System.Windows.Forms.ToolStripMenuItem TrigerDrawPlotMenu;
        private System.Windows.Forms.Label ProductionVolumeLabel;
        private System.Windows.Forms.ToolStripMenuItem 插入默认Z向测点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScaleOnToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label CoordLabel;
    }
}

