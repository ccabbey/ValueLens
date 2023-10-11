using System;
using System.Data;
using System.Linq;


namespace ValueLens.Model
{
    public class LineSerie : SerieBase
    {
        public LineSerie(string name) : base(name)
        {
            this.Name = name;
            this.DataUpdated = false;
        }



        public double UTol { get; set; }

        public double LTol { get; set; }

        public string[] FrameSNs { get; set; }

        public DateTime[] DateTimes { get; set; }

        public override void OnNext(DataTable dt)
        {
            var dataTableSortKey = Config.GetAppSettingsValueByKey("DataTableSortKey");

            var dateTimeFieldName = Config.GetAppSettingsValueByKey("DateTimeFieldName");
            var frameSNFieldName = Config.GetAppSettingsValueByKey("FrameSNFieldName");

            dt.DefaultView.Sort = dataTableSortKey + " ASC";
            DataTable newDt = dt.DefaultView.ToTable();


            var idFieldExist = Config.GetAppSettingsValueByKey("IDFieldExist");
            var idFieldName = Config.GetAppSettingsValueByKey("IDFieldName");

            //v1.0.5 优化datatable字段数据类型检测

            string dataTypeStr = dt.Columns[Name].DataType.Name;

            switch (dataTypeStr)
            {
                case "String":
                    string[] stringData = newDt.AsEnumerable().Select(d => d.Field<string>(Name).Trim()).ToArray();
                    YValues = stringData.Select(d => Convert.ToDouble(d)).ToArray();
                    DateTimes = newDt.AsEnumerable().Select(d => Convert.ToDateTime(d.Field<string>(dateTimeFieldName).Trim())).ToArray();
                    break;
                case "Double":
                    YValues = newDt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();
                    DateTimes = newDt.AsEnumerable().Select(d => d.Field<DateTime>(dateTimeFieldName)).ToArray();
                    break;
                case "Int":
                    int[] intData = newDt.AsEnumerable().Select(d => d.Field<int>(Name)).ToArray();
                    YValues = intData.Select(d => Convert.ToDouble(d)).ToArray();
                    DateTimes = newDt.AsEnumerable().Select(d => d.Field<DateTime>(dateTimeFieldName)).ToArray();
                    break;
                default: throw new Exception($"数据类型转换失败，数据源类型为：{dataTypeStr}");
            }
                 
            FrameSNs = newDt.AsEnumerable().Select(d => d.Field<string>(frameSNFieldName)).ToArray();

            ////适用L551&L233 GLUE，后续需要参数化
            //YValues= newDt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();
            //DateTimes = newDt.AsEnumerable().Select(d => d.Field<DateTime>("EntryTime")).ToArray();
            //FrameSNs = newDt.AsEnumerable().Select(d => d.Field<string>("Frame_SerialNumber")).ToArray();

            if (idFieldExist == "true")
            {
                int[] id = newDt.AsEnumerable().Select(d => d.Field<int>(idFieldName)).ToArray();
                XValues = id.Select(i => (double)i).ToArray();
            }
            else
            {
                var seq = Enumerable.Range(1, newDt.Rows.Count);
                XValues = seq.Select(s => Convert.ToDouble(s)).ToArray();
            }

            DataUpdated = true;
        }

    }
}
