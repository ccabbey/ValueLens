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

            //v1.0.5 优化datatable字段数据类型检测

            string dataTypeStr = newdt.Columns[Name].DataType.Name;

            switch (dataTypeStr)
            {
                case "String":
                    values = newdt.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(Name).Trim())).ToArray();
                    break;
                case "Double":
                    values = newdt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();
                    break;
                case "Int32":
                    values = newdt.AsEnumerable().Select(d => Convert.ToDouble(d.Field<int>(Name))).ToArray();
                    break;
                default: throw new Exception($"数据类型转换失败，数据源类型为：{dataTypeStr}");
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
