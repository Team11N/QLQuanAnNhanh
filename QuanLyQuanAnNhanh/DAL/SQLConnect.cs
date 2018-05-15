using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnNhanh.DAL
{
    public class SQLConnect
    {
        private string strConn =@"Data Source=.\sqlexpress;Initial Catalog=FastFoodShop;Integrated Security=True";
        private SqlConnection connection = null;
        private SqlCommand cmd = null;

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }
        public SQLConnect()
        {
            connection = new SqlConnection(strConn);
        }
        public void OpenConnect()
        {
            if (connection == null)
            {
                connection = new SqlConnection(strConn);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        
        public DataTable getDataTable(string table)
        {
            string query = "select * from " + table;
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, strConn);
            da.Fill(dt);
            CloseConnect();
            return dt;
        }

       public SqlDataReader getDataTableNV(string table)
        {
            SqlDataReader dr = null;
            string query = "select * from " + table;
            cmd = new SqlCommand(query, connection);
            this.OpenConnect();
            dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader execCommand(string sql)
        {
            SqlDataReader dr = null;
            try
            {
                this.OpenConnect();
                cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                new Exception("Errors: " + e.Message);
            }
            return dr;
        }
        //phạm ngọc đạt
        public DataTable ExecuteQuery(string query)
        {
            OpenConnect();
            cmd = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
    }
}
