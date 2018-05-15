using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAnNhanh.DAL
{
    public class Menu:SQLConnect
    {
        public void InsertDish(DAO.Menu menu)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("InsertDish",Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", menu.ID_dish1);
                cmd.Parameters.AddWithValue("@Name", menu.Name_dish1);
                cmd.Parameters.AddWithValue("@Unit", menu.Unit_dish1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
        public void DeleteDish(DAO.Menu menu)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("DeleteDish", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", menu.ID_dish1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error :" + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
        public void EditDish(DAO.Menu menu)
        {
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand("EditDish", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", menu.ID_dish1);
                cmd.Parameters.AddWithValue("@name",menu.Name_dish1);
                cmd.Parameters.AddWithValue("@unit", menu.Unit_dish1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error :" + e.Message);
            }
            finally
            {
                CloseConnect();
            }
        }

    }
}
