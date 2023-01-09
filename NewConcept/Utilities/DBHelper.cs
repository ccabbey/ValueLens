using System;
using System.Data;
using System.Data.SqlClient;

namespace ValueLens.NewConcept
{
    public class DBHelper
    {
        public SqlConnection Connection;

        public string hourlyVolumeSqlStringPart { get; set; }
        public string dailyVolumeSqlStringPart { get; set; }

        /// <summary>
        /// 建立一个新的数据库连接
        /// </summary>
        public void CreateConnection()
        {
            string connectionString = GetConnectionString(Config.GetAppSettingsValueByKey("default"));

            Connection = new SqlConnection();
            Connection.ConnectionString = connectionString;
            Connection.Open();
            //MessageBox.Show("State: " + Connection.State);

            //MessageBox.Show("ConnectionString: "+connection.ConnectionString);
        }

        private string GetConnectionString(string SettingName)
        {
            return Config.GetConnectionStringsConfig(SettingName);
        }

        public string GetSqlString()
        {
            return Config.GetAppSettingsValueByKey("sql");
            //@"select top 1000 * from OP110Data order by id desc ";
        }


        public DataTable QuerySqlToDataTable(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public (int hourly, int daily) GetProductionVolumeInfo()
        {
            var volumeSqlStringDateFormatString = Config.GetAppSettingsValueByKey("volumeSqlStringDateFormat");
            string today = DateTime.Today.ToString(volumeSqlStringDateFormatString);
            TimeSpan ts = new TimeSpan(1, 0, 0);
            string lastHourDateTime = (DateTime.Now - ts).ToString(volumeSqlStringDateFormatString);
            this.hourlyVolumeSqlStringPart = Config.GetAppSettingsValueByKey("hourlyVolumeSqlString");
            this.dailyVolumeSqlStringPart = Config.GetAppSettingsValueByKey("dailyVolumeSqlString");

            string sqlHourlyVolume = string.Format(hourlyVolumeSqlStringPart + " >= '{0}'", lastHourDateTime);
            string sqlDailyVolumn = string.Format(dailyVolumeSqlStringPart + " >= '{0}'", today);

            var hourlyDataTable = QuerySqlToDataTable(sqlHourlyVolume);
            var dailyDataTable = QuerySqlToDataTable(sqlDailyVolumn);

            return (hourlyDataTable.Rows.Count, dailyDataTable.Rows.Count);
        }
    }
}
