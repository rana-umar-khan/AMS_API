using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace AMS.DAL
{
    internal class DBHelper : IDisposable
    {
        //String _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AttendanceDBConnStr"].ConnectionString;
        String _connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Umar Khan\Downloads\Compressed\Web API_2\AMS_DB\AMS.DAL\Database1.mdf';Integrated Security=True";
        SqlConnection _con;

        public DBHelper()
        {
            try
            {
                _con = new SqlConnection(_connStr);
                _con.Open();
            }
            catch (Exception ex) { }
        }

        public int ExecuteQuery(String sqlQuery)
        {
            int n = 0;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                n = command.ExecuteNonQuery();
                return n;
            }
            catch (Exception ex)
            {
                return n;
            }
        }

        public Object ExecuteScalar(String sqlQuery)
        {
            Object obj = null;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        public SqlDataReader ExecuteReader(String sqlQuery)
        {
            SqlDataReader obj = null;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                obj = command.ExecuteReader();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        public void Dispose()
        {
            if (_con != null && _con.State == System.Data.ConnectionState.Open)
                _con.Close();
        }
    }
}
