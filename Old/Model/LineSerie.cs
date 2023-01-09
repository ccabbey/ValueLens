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


            //v1.0.4 优化Repo数据表结果包含空值时或类型不匹配报错

            try //默认按字符串类型转换
            {
                string[] stringData = newDt.AsEnumerable().Select(d => d.Field<string>(Name).Trim()).ToArray();
                YValues = stringData.Select(d => Convert.ToDouble(d)).ToArray();
                DateTimes = newDt.AsEnumerable().Select(d => Convert.ToDateTime(d.Field<string>(dateTimeFieldName).Trim())).ToArray();
            }
            catch (Exception ex) //如果失败按数值型转换
            {
                Console.WriteLine($"ValueLens Warning: 数据中存在空值。或数据值存储为浮点型而非字符串。VL将使用备选方案进行处理。");
                //throw new Exception($"源错误信息：{ex.Message}\r\nValueLens Debug: 需要检查查询结果数据字段是否有空值。");
                //float[] valueData = newDt.AsEnumerable().Select(d => d.Field<float>(Name)).ToArray();
                //YValues = valueData.Select(d => Convert.ToDouble(d)).ToArray();
                YValues = newDt.AsEnumerable().Select(d => d.Field<double>(Name)).ToArray();
                DateTimes = newDt.AsEnumerable().Select(d => d.Field<DateTime>(dateTimeFieldName)).ToArray();
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
