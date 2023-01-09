using System;
using System.Data;
using System.Data.SqlClient;

namespace ValueLens.Model
{
    [Obsolete("SPC.Model.DBHelper is now SPC.NewConcept.DBHelper", false)]
    public class NewConceptDBHelper
    {
        public SqlConnection Connection;
        public string hourlyVolumeSqlStringPart { get; set; }
        public string dailyVolumeSqlStringPart { get; set; }

        /// <summary>
        /// 建立数据库连接。使用AppSetting文件的默认连接字符串。
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

        /// <summary>
        /// 建立数据库连接。使用自定义的连接字符串。
        /// </summary>
        public void CreateConnection(string connectionString)
        {
            Connection = new SqlConnection();
            Connection.ConnectionString = connectionString;
            Connection.Open();
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

        public (int, int) GetProductionVolumeInfo()
        {
            string today = DateTime.Today.ToString();
            TimeSpan ts = new TimeSpan(1, 0, 0);
            string lastHourDateTime = (DateTime.Now - ts).ToString();
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
