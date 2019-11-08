

using MySql.Data.MySqlClient;
using System.Data;

namespace Creasoft.Utils.DBUtils
{
    //通用mysql方法
    public class MySQLHelper
    {
        public static string ConStr { get; set; } 
            = "server=rm-bp17n6bb82n3v009ao.mysql.rds.aliyuncs.com;user id=admin09;password=aco123456!;database=remotefittingsoftware;Convert Zero Datetime=True ; Allow Zero Datetime=True";

        public static int ExecuteNonQuery(string sql, params MySqlParameter[] sps)
        {
            using (var connection = new MySqlConnection(ConStr))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    if (sps != null)
                    {
                        cmd.Parameters.AddRange(sps);
                    }
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params MySqlParameter[] sps)
        {
            using (var connection = new MySqlConnection(ConStr))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    if (sps != null)
                    {
                        cmd.Parameters.AddRange(sps);
                    }
                    connection.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable FillDataTable(string sql, params MySqlParameter[] sps)
        {
            var dataTable = new DataTable();
            using (var connection = new MySqlConnection(ConStr))
            {
                using (var adapter = new MySqlDataAdapter(sql, connection))
                {
                    if (sps != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(sps);
                    }
                    connection.Open();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static DataSet FillDataSet(string sql, params MySqlParameter[] sps)
        {
            var dataSet = new DataSet();
            using (var connection = new MySqlConnection(ConStr))
            {
                using (var adapter = new MySqlDataAdapter(sql, connection))
                {
                    if (sps != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(sps);
                    }
                    connection.Open();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }
    }
}
