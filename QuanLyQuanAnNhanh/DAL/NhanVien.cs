using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnNhanh.DAL
{
    public class NhanVien : SQLConnect
    {
        public void InsertEmployees(DAO.NhanVien nv)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("InsertEmployees", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", nv.Id);
                cmd.Parameters.AddWithValue("@Name", nv.Name);
                cmd.Parameters.AddWithValue("@Birth_day", nv.Birthday);
                cmd.Parameters.AddWithValue("@Contact", nv.Contact);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                new Exception("Errors: " + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
        public void DeleteEmployees(DAO.NhanVien nv)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("DelEmployees", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", nv.Id);
                //cmd.Parameters.AddWithValue("@Name", nv.Name);
                //cmd.Parameters.AddWithValue("@Birth_day", nv.Birthday);
                //cmd.Parameters.AddWithValue("@Contact", nv.Contact);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                new Exception("Errors: " + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
        public void UpdateEmployees(DAO.NhanVien nv)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("EditEmployees", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", nv.Id);
                cmd.Parameters.AddWithValue("@Name", nv.Name);
                cmd.Parameters.AddWithValue("@birthday", nv.Birthday);
                cmd.Parameters.AddWithValue("@Contact", nv.Contact);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                new Exception("Errors: " + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
    }
}
