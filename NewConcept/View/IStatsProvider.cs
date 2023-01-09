namespace ValueLens.NewConcept
{


    /// <summary>
    /// 提供用于更新StatsIndicator控件数据的接口
    /// </summary>
    public interface IStatsProvider
    {

        string Name { get; }
        string Description { get; }
        IndicatorState State { get; }

        double Mean10 { get; }
        double Mean30 { get; }
        double Range10 { get; }

        Statistics.BasicStats Stats { get; }

        void GetStats();

    }
}
