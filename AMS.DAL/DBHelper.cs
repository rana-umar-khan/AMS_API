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
        String _connStr = @"Server=02b200d4-39d9-47d3-a815-a7a80147e548.sqlserver.sequelizer.com;Database=db02b200d439d947d3a815a7a80147e548;User ID=bbctsnnnpcgrkkbw;Password=GxHD6xDBUpopbKGS8dPevtgF5vEMfxSh7zjYnBcLGKaCqqDaFDQvS7EnqcGH2Yww;";
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
