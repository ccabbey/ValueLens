using System;
using System.Drawing;
using System.Windows.Forms;

namespace ValueLens.NewConcept
{
    public partial class StatsIndicator : UserControl
    {
        public StatsIndicator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提供更新StatsIndicator面板内容的接口引用。
        /// </summary>
        public IStatsProvider StatsProvider;

        /// <summary>
        /// 测点名称
        /// </summary>
        public new string Name { get; set; }

        private string description;

        /// <summary>
        /// 对测点简单的描述，不能超过12个字符（6个汉字），否则会显示不下
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                if (value.Length > 12)
                {
                    throw new Exception("description max char length < 12");
                }
                description = value;
            }
        }
        ///// <summary>
        ///// 最近10套平均值
        ///// </summary>
        //public double Mean10 { get; set; }

        ///// <summary>
        ///// 最近30套平均值
        ///// </summary>
        //public double Mean30 { get; set;}

        ///// <summary>
        ///// 最近10套极差
        ///// </summary>
        //public double Range10 { get; set;}

        public void SetStatsProvider(IStatsProvider provider)
        {
            StatsProvider = provider;
            this.Name = provider.Name;
            NameLabel.Text = provider.Name;
            DescriptionLabel.Text = provider.Description;
        }

        public new void Update()
        {
            if (StatsProvider != null)
            {
                Mean10Label.Text = StatsProvider.Mean10.ToString();
                Mean30Label.Text = StatsProvider.Mean30.ToString();
                Range10Label.Text = StatsProvider.Range10.ToString();

                SetColorState(StatsProvider.State);
            }
        }

        public void SetColorState(IndicatorState state)
        {

            switch (state)
            {
                case IndicatorState.Good:
                    BackColor = Color.Lime; break;

                case IndicatorState.Bad:
                    BackColor = Color.Red; break;

                case IndicatorState.Warn:
                    BackColor = Color.Yellow; break;

                case IndicatorState.NA:
                    BackColor = SystemColors.Control; break;

                default:
                    BackColor = SystemColors.Control; break;
            }
        }
    }
}
