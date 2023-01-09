using System;

namespace ValueLens.NewConcept
{

    /// <summary>
    /// 产能数据模型
    /// </summary>
    internal partial class VolumeData
    {
        /// <summary>
        /// 整点每小时产能 后台存储 0-23
        /// </summary>
        int[] Hourly { get; set; }

        public VolumeData()
        {
            // 初始化小时产能存储
            Hourly = new int[23];

            // 
        }

        /// <summary>
        /// 从后台查询当天下线时间信息并拆分到小时产能
        /// </summary>
        public void GetData()
        {

        }
    }



    //实现 ICanPlotHistogram 接口
    internal partial class VolumeData : ICanPlotHistogram
    {
        public (double[] hist, double[] binEdges) ProvideData()
        {
            throw new NotImplementedException();
        }
    }
}
