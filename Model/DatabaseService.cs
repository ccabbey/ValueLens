using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPC.Model
{
    public class DatabaseService
    {

        public SqlConnection Connection;
        /// <summary>
        /// 建立数据库连接
        /// </summary>
        public void CreateConnection()
        {
            string connectionString = getConnectionString();

            Connection = new SqlConnection();
            Connection.ConnectionString = connectionString;
            Connection.Open();
            //MessageBox.Show("State: " + Connection.State);

            //MessageBox.Show("ConnectionString: "+connection.ConnectionString);
        }
        
        private string getConnectionString()
        {
            return @"Data Source= PC-ALEX\SQLEXPRESS;Initial Catalog=testDB;" + "Integrated Security=true;";
        }

        public string GetSqlString()
        {
            return @"select top 100 * from OP110Data order by id desc ";
        }


        public DataTable QuerySqlToDataTable(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            return dt;



        }
    }
}
