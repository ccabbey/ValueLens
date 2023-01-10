using System;
using System.Data;
using System.Linq;
//using MathNet.Numerics.Statistics;

namespace ValueLens.Model
{
    public class HistogramSerie : SerieBase
    {
        public HistogramSerie(string name) : base(name) { }

        public double BarWidth { get; set; }

        public double[] Densities { get; set; }

        public double[] BinEdges { get; set; }

        public double[] NormEdges { get; private set; }

        double[] values;

        double binSize;

        public override void OnNext(DataTable dt)
        {
            
            var dataTableSortKey = Config.GetAppSettingsValueByKey("DataTableSortKey");
            dt.DefaultView.Sort = dataTableSortKey + " ASC";
            DataTable newdt = dt.DefaultView.ToTable();
            //values = newdt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();

            //v1.0.4 优化Repo数据表结果包含空值时或类型不匹配报错
            try
            {
                values = newdt.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(Name).Trim())).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ValueLens Warning: 数据中存在空值。或数据值存储为浮点型而非字符串。VL将使用备选方案进行处理。");
                values = newdt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();
            }

            //v1.0.3 优化数据波动很小时或很大时直方图binsize取值不合理问题
            var range = values.Max() - values.Min();

            binSize = range / 20;
            //binSize = 0.1d;

            (double[] probabilities, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(
                values, min: values.Min(), max: values.Max(), binSize: binSize, density: true);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            //density curve
            double[] densities = ScottPlot.Statistics.Common.ProbabilityDensity(values, binEdges);

            //normal dist curve
            Random rand = new Random(0);
            var stats = new ScottPlot.Statistics.BasicStats(values);
            //double[] normDistCurve = ScottPlot.DataGen.RandomNormal(rand,500, stats.Mean, stats.StDev);
            double[] normDistEdges = ScottPlot.DataGen.Range(start: binEdges.First(), stop: binEdges.Last(), step: 0.05, includeStop: true);
            double[] normDistDensities = ScottPlot.Statistics.Common.ProbabilityDensity(values, normDistEdges, percent: true);

            XValues = leftEdges;
            YValues = probabilities;
            NormEdges = normDistEdges;
            Densities = normDistDensities;
            BinEdges = binEdges;

            DataUpdated = true;
            BarWidth = XValues[1] - XValues[0];
        }
    }
}
