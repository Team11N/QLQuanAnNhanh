﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using xlapp = Microsoft.Office.Interop.Excel.Application;
using xlworksheet = Microsoft.Office.Interop.Excel.Worksheet;
using xlworkbook = Microsoft.Office.Interop.Excel.Workbook;
using QuanLyQuanAnNhanh.Properties;
using QuanLyQuanAnNhanh.DAL;

namespace QuanLyQuanAnNhanh
{
    public partial class MainForm : Form
    {

        //string check;
        bool check;
        BanHang banHang = new BanHang();
        public MainForm()
        {
            InitializeComponent();

        }

        //phạm ngọc đạt
        #region tabPage BanHang

        public void LoadComboBox()
        {
            try
            {
                DAL.SQLConnect provider = new DAL.SQLConnect();
                string query = "select Name_dish,Unit_price from tbDish";
                cbbNameEat.DataSource = provider.ExecuteQuery(query);
                cbbNameEat.DisplayMember = "Name_dish";
                cbbNameEat.ValueMember = "Name_dish";
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.ToString());
            }
        }

        public void AddGia()
        {
           
            txtGia.DataBindings.Add(new Binding("Text", cbbNameEat.DataSource, "Unit_price"));
        }

        public void AddMaNV()
        {
            
            txtMaNV.DataBindings.Add(new Binding("Text", cbbNameEmployees.DataSource, "ID_employees"));
        }

        public void LoadComboBox2()
        {
            try
            {
                DAL.SQLConnect provider = new DAL.SQLConnect();
                string query = ("select Name_employees,ID_employees from tbEmployees");
                cbbNameEmployees.DataSource = provider.ExecuteQuery(query);
                cbbNameEmployees.DisplayMember = "Name_employees";
                cbbNameEmployees.ValueMember = "Name_employees";
            }
            catch (Exception ex)
            {
                new Exception("Error " + ex.ToString());
            }
        }

        private void btnInsertOrder_Click(object sender, EventArgs e)
        {
            if (txtIDOrder.Text != "")
            {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(new string[] {
                txtIDOrder.Text ,cbbNameEmployees.Text,cbbNameEat.Text,txtGia.Text,numericUpDown1.Text,dateTimePicker1.Text });

                this.listViewBanHang.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                item
                });
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã order!!!");
            }
            int thanhtien = 0;
            foreach(ListViewItem item in listViewBanHang.Items)
            {
                thanhtien = Convert.ToInt32(item.SubItems[3].Text.ToString()) * Convert.ToInt32(item.SubItems[4].Text.ToString());
            }
            textBox10.Text = Convert.ToString(thanhtien);

        }


        private void listViewBanHang_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            txtIDOrder.Text = item.Text;
            cbbNameEmployees.Text = item.SubItems[1].Text;
            cbbNameEat.Text = item.SubItems[2].Text;
            txtGia.Text = item.SubItems[3].Text;
            numericUpDown1.Text = item.SubItems[4].Text;
        }

        private void brnDelOrder_Click(object sender, EventArgs e)
        {
            string maOrder = txtIDOrder.Text;
            if (maOrder.Length == 0)
            {
                MessageBox.Show("Chưa chọn mã order");
                return;
            }


            foreach (ListViewItem it in listViewBanHang.Items)
            {
                if (it.Text == maOrder)
                {
                    it.Remove();
                    textBox10.Text = "0";
                    MessageBox.Show("Xóa thành công");
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy dữ liệu cần xóa!!!");
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            int i = 0;

            for (i = 0; i < listViewBanHang.Items.Count; i++)
            {
                if (listViewBanHang.Items[i].Text == txtIDOrder.Text)
                {
                    listViewBanHang.Items[i].SubItems[1].Text = cbbNameEmployees.Text;
                    listViewBanHang.Items[i].SubItems[2].Text = cbbNameEat.Text;
                    listViewBanHang.Items[i].SubItems[3].Text = txtGia.Text;
                    listViewBanHang.Items[i].SubItems[4].Text = numericUpDown1.Text;
                    listViewBanHang.Items[i].SubItems[5].Text = dateTimePicker1.Text;

                    textBox10.Text = Convert.ToString(Convert.ToInt32(listViewBanHang.Items[i].SubItems[3].Text.ToString()) * Convert.ToInt32(listViewBanHang.Items[i].SubItems[4].Text.ToString()));
                    return;
                }
            }
            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(new string[] {
                txtIDOrder.Text ,cbbNameEmployees.Text,cbbNameEat.Text,txtGia.Text,numericUpDown1.Text });
            //Thêm đối tượng
            this.listViewBanHang.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                item
                });
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            int total = 0;
            int thanhtien = 0;
            try
            {
                foreach (ListViewItem item in listViewBanHang.Items)
                {
                    if (item.Text == txtIDOrder.Text)
                    {
                        thanhtien = Convert.ToInt32(Convert.ToInt32(item.SubItems[3].Text.ToString()) * Convert.ToInt32(item.SubItems[4].Text.ToString()));
                        total += thanhtien;
                    }
                    textBox10.Text = total.ToString();
                }
                string idorder = txtIDOrder.Text;
                string tendonhang = cbbNameEat.Text;
                string manv = txtMaNV.Text;
                int soluong = Convert.ToInt32(numericUpDown1.Text.ToString());
                int tongtien = Convert.ToInt32(textBox10.Text);
                DateTime thoigianthanhtoan = dateTimePicker1.Value;
                banHang.ThanhToan(idorder, tendonhang, manv, soluong, tongtien, thoigianthanhtoan);
                doanhThu.updateBieuDo();
                MessageBox.Show("Đã thanh toán");
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã order đã tồn tại!", "THÔNG BÁO", MessageBoxButtons.OK);
                foreach (ListViewItem it in listViewBanHang.Items)
                {
                    if (it.Text == txtIDOrder.Text)
                    {
                        it.Remove();
                        textBox10.Text = "0";
                        return;
                    }
                }
            }
            if (rBtnNgay.Checked == true)
            {
                LoadDoanhThuTheoNgay(dtpkDoanhThu.Value);
                return;
            }
            else if (rBtnThang.Checked == true)
            {
                LoadDoanhThuTheoThang(dtpkDoanhThu.Value);
                return;
            }
            else if (rBtnNam.Checked == true)
            {
                LoadDoanhThuTheoNam(dtpkDoanhThu.Value);
                return;
            }
            else
            {
                LoadDoanhThu();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //Inhoadon hoadon = new Inhoadon();
            //hoadon.Show();
            for (int i = 0; i < listViewBanHang.Items.Count; i++)
            {
                listViewBanHang.Items[i].Remove();
                i--;
            }
            MessageBox.Show("In thành công!!!");
        }

        #endregion

        //Trần Phương Thảo
        #region tabPage Menu
        public void showListMenu()
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            dGvMenu.DataSource = conn.getDataTable("tbDish");

        }
        public void ADD_DISH()
        {
            txtIDDish.DataBindings.Add(new Binding("Text", dGvMenu.DataSource, "ID_dish", true, DataSourceUpdateMode.Never));
            txtNameDish.DataBindings.Add(new Binding("Text", dGvMenu.DataSource, "Name_dish", true, DataSourceUpdateMode.Never));
            txtUnitPrice.DataBindings.Add(new Binding("Text", dGvMenu.DataSource, "Unit_price", true, DataSourceUpdateMode.Never));

        }
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            conn.OpenConnect();
            string sqlAdd = "insert into tbDish values(@ID_dish,@Name_dish,@Unit_price)";
            SqlCommand cmd = new SqlCommand(sqlAdd, conn.Connection);//sqlconnection
            cmd.Parameters.AddWithValue("ID_dish", txtIDDish.Text);
            cmd.Parameters.AddWithValue("Name_dish", txtNameDish.Text);
            cmd.Parameters.AddWithValue("Unit_price", txtUnitPrice.Text);
            cmd.ExecuteNonQuery();
            showListMenu();
        }

        private void btnEditMenu_Click(object sender, EventArgs e)
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            conn.OpenConnect();
            string sqlEdit = "update tbDish set Name_dish=@Name_dish, Unit_price=@Unit_price where ID_dish=@ID_dish";
            SqlCommand cmd = new SqlCommand(sqlEdit, conn.Connection);//sqlconnection
            cmd.Parameters.AddWithValue("ID_dish", txtIDDish.Text);
            cmd.Parameters.AddWithValue("Name_dish", txtNameDish.Text);
            cmd.Parameters.AddWithValue("Unit_price", txtUnitPrice.Text);
            cmd.ExecuteNonQuery();
            showListMenu();
        }

        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            conn.OpenConnect();
            string sqlDelete = "delete from tbDish where ID_dish=@ID_dish";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn.Connection);//sqlconnection
            cmd.Parameters.AddWithValue("ID_dish", txtIDDish.Text);
            cmd.Parameters.AddWithValue("Name_dish", txtNameDish.Text);
            cmd.Parameters.AddWithValue("Unit_price", txtUnitPrice.Text);
            cmd.ExecuteNonQuery();
            showListMenu();
        }

        private void btnExitMenu_Click(object sender, EventArgs e)
        {
            txtIDDish.ResetText();
            txtNameDish.ResetText();
            txtUnitPrice.ResetText();
            showListMenu();
        }
        private void btnSearchDish_Click(object sender, EventArgs e)
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            conn.OpenConnect();
            string sqlSearchID = "select* from tbDish where ID_dish=@ID_dish";
            SqlCommand cmd = new SqlCommand(sqlSearchID, conn.Connection);//sqlconnection
            cmd.Parameters.AddWithValue("ID_dish", txtSearchDish.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dGvMenu.DataSource = dt;
        }


        #endregion


        //nguyễn Văn Lộc
        #region tabPage NV

        public void lockTxtTabPageNV()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            dtmBirthDay.Enabled = false;
            txtContact.Enabled = false;
        }
        public void openTxtTabPageNV()
        {
            //txtID.Enabled = false;
            txtName.Enabled = true;
            dtmBirthDay.Enabled = true;
            txtContact.Enabled = true;
        }
        public void ResetTxtTabPageNV()
        {
            txtID.ResetText();
            txtName.ResetText();
            dtmBirthDay.ResetText();
            txtContact.ResetText();
        }

        public void clearLsvNhanVien()
        {
            lsvNhanVien.Items.Clear();
        }

        public void addlist(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            //item.Text = dr["STT"].ToString();
            item.Text = dr["ID_employees"].ToString();
            item.SubItems.Add(dr["Name_employees"].ToString());
            item.SubItems.Add(dr["Birth_day_employees"].ToString());
            item.SubItems.Add(dr["Contact_employees"].ToString());
            lsvNhanVien.Items.Add(item);
        }

        public void showListNhanVien()
        {
            //DAL.SQLConnect conn = new DAL.SQLConnect();
            //dataGridViewNV.DataSource = conn.getDataTable("tbEmployees");

            clearLsvNhanVien();
            DAL.SQLConnect conn = new DAL.SQLConnect();
            SqlDataReader dr = conn.getDataTableNV("tbEmployees");
            while (dr.Read())
            {
                addlist(dr);
            }
        }

        public void showEnableBtn(string name)
        {
            if (name == "insert")
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnSave.Enabled = true;
                btnExit.Enabled = true;
            }
            //if (name == "delete")
            //{
            //    btnInsert.Enabled = false;
            //    btnUpdate.Enabled = false;
            //    btnSave.Enabled = true;
            //    btnExit.Enabled = true;
            //}
            if (name == "update")
            {
                btnDelete.Enabled = false;
                btnInsert.Enabled = false;
                btnSave.Enabled = true;
                btnExit.Enabled = true;
            }
        }

        public void resetEnableBtn(string name)
        {
            if (name == "done")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                btnExit.Enabled = false;
            }

        }
        //tự động tăng ID nhân viên khi insert
        public string tangIDNV()
        {
            DAL.SQLConnect conn = new DAL.SQLConnect();
            conn.OpenConnect();
            string sql = "select * from tbEmployees";
            SqlCommand cmd = new SqlCommand(sql, conn.Connection);//sqlconnection
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            string id = "";
            if (dt.Rows.Count <= 0)
            {
                id = "NV01";
            }
            else
            {
                int k = 0;
                id = "NV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 2));
                k += 1;
                if (k < 10)
                {
                    id += "0";
                }
                id += k.ToString();
            }
            return id;
        }
        //check insert,update
        public bool CheckIn_Up()
        {
            if (txtID.Text == "" || txtName.Text == "" || txtContact.Text == "")
            {
                return false;
            }
            return true;
        }

        //check delete
        public bool CheckDel()
        {
            if (txtID.Text == "")
            {
                return false;
            }
            return true;
        }

        //private void dataGridViewNV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    dataGridViewNV.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        //}

        private void btnInsert_Click(object sender, EventArgs e)
        {
            check = true;
            openTxtTabPageNV();
            ResetTxtTabPageNV();
            showEnableBtn("insert");
            txtID.Enabled = false;
            txtName.Focus();
            txtID.Text = tangIDNV();
            //txtID.Enabled = false;
            //check = "insert";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (CheckIn_Up())
            //{
            check = false;
            openTxtTabPageNV();
            showEnableBtn("update");
            //}
            //else
            //{
            //    MessageBox.Show("Bạn phải chọn nhân viên cần update trước!");
            //}
            ////check = "update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check = "delete";
            if (CheckDel())
            {
                //showEnableBtn("delete");
                DialogResult kt = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kt == DialogResult.Yes)
                {
                    DAO.NhanVien dao_nv = new DAO.NhanVien();
                    dao_nv.Id = txtID.Text.Trim();
                    DAL.NhanVien dal_nv = new DAL.NhanVien();
                    dal_nv.DeleteEmployees(dao_nv);
                }

                showListNhanVien();
                lockTxtTabPageNV();
                ResetTxtTabPageNV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn id của nhân viên bạn muốn xóa!");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAO.NhanVien dao_nv = new DAO.NhanVien();
            dao_nv.Id = txtID.Text.Trim();
            dao_nv.Name = txtName.Text.Trim();
            dao_nv.Birthday = Convert.ToDateTime(dtmBirthDay.Value);
            dao_nv.Contact = txtContact.Text.Trim();

            DAL.NhanVien dal_nv = new DAL.NhanVien();
            if (check == true)
            {
                if (CheckIn_Up())
                {
                    dal_nv.InsertEmployees(dao_nv);
                    resetEnableBtn("done");
                }
                else
                {
                    MessageBox.Show("Bạn phải điền đầy đủ thông tin!");
                }

            }
            else
            {
                if (CheckIn_Up())
                {
                    dal_nv.UpdateEmployees(dao_nv);
                    resetEnableBtn("done");
                }
                else
                {
                    MessageBox.Show("Bạn phải điền đầy đủ thông tin!");
                }
            }
            //else
            //{
            //    dal_nv.DeleteEmployees(dao_nv);
            //    btnUpdate.Enabled = true;
            //    btnInsert.Enabled = true;
            //}

            showListNhanVien();
            lockTxtTabPageNV();
            ResetTxtTabPageNV();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            lockTxtTabPageNV();
            ResetTxtTabPageNV();
            resetEnableBtn("done");
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                txtID.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
                txtName.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                dtmBirthDay.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                txtContact.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
            }
        }

        //private void dataGridViewNV_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        txtID.Text = dataGridViewNV.CurrentRow.Cells[1].Value.ToString();
        //        txtName.Text = dataGridViewNV.CurrentRow.Cells[2].Value.ToString();
        //        txtBirthday.Text = dataGridViewNV.CurrentRow.Cells[3].Value.ToString();
        //        txtContact.Text = dataGridViewNV.CurrentRow.Cells[4].Value.ToString();
        //    }
        //    catch
        //    {
        //    }
        //}


        #endregion

        //Phạm Văn Thành
        #region DoanhThu
        DoanhThu doanhThu = new DoanhThu();
        void LoadDoanhThu()
        {
            grvDoanhThu.DataSource = doanhThu.HienThiDoanhThu();
        }
        void LoadDoanhThuTheoNgay(DateTime ngaythanhtoan)
        {
            grvDoanhThu.DataSource = doanhThu.HienThiDoanhThuTheoNgay(ngaythanhtoan);
        }
        void LoadDoanhThuTheoThang(DateTime ngaythanhtoan)
        {
            grvDoanhThu.DataSource = doanhThu.HienThiDoanhThuTheoThang(ngaythanhtoan);
        }
        void LoadDoanhThuTheoNam(DateTime ngaythanhtoan)
        {
            grvDoanhThu.DataSource = doanhThu.HienThiDoanhThuTheoNam(ngaythanhtoan);
        }
        void updateBieuDo()
        {
            
        }
        void BindingData()
        {
            txtmaorder.DataBindings.Clear();
            txtmaorder.DataBindings.Add("Text", grvDoanhThu.DataSource, "Mã đơn hàng");
            txttennv.DataBindings.Clear();
            txttennv.DataBindings.Add("Text", grvDoanhThu.DataSource, "Tên nhân viên");
            txttongtien.DataBindings.Clear();
            txttongtien.DataBindings.Add("Text", grvDoanhThu.DataSource, "Tổng tiền");
            dtpkIndoanhthu.DataBindings.Clear();
            dtpkIndoanhthu.DataBindings.Add("Text", grvDoanhThu.DataSource, "Thời gian thanh toán");
        }
        private void rBtnNgay_CheckedChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoNgay(dtpkDoanhThu.Value);
            BindingData();
        }

        private void rBtnThang_CheckedChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoThang(dtpkDoanhThu.Value);
            BindingData();
        }

        private void rBtnNam_CheckedChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoNam(dtpkDoanhThu.Value);
            BindingData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doanhThu.XoaDoanhThu(txtmaorder.Text.Trim());
            if (rBtnNgay.Checked == true)
            {
                LoadDoanhThuTheoNgay(dtpkDoanhThu.Value);
                return;
            }
            else if (rBtnThang.Checked == true)
            {
                LoadDoanhThuTheoThang(dtpkDoanhThu.Value);
                return;
            }
            else if (rBtnNam.Checked == true)
            {
                LoadDoanhThuTheoNam(dtpkDoanhThu.Value);
                return;
            }
            else
            {
                LoadDoanhThu();
            }
            BindingData();
        }

        private void dtpkDoanhThu_ValueChanged(object sender, EventArgs e)
        {
            if (rBtnNgay.Checked == true)
            {
                LoadDoanhThuTheoNgay(dtpkDoanhThu.Value);
                BindingData();
                return;
            }
            else if (rBtnThang.Checked == true)
            {
                LoadDoanhThuTheoThang(dtpkDoanhThu.Value);
                BindingData();
                return;
            }
            else if (rBtnNam.Checked == true)
            {
                LoadDoanhThuTheoNam(dtpkDoanhThu.Value);
                BindingData();
                return;
            }
            
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            BieuDo bieuDo = new BieuDo();
            bieuDo.Show();
        }

        private void btnXuatEL_Click(object sender, EventArgs e)
        {
            exportExcel(grvDoanhThu, @"E:\Code VS\QLQuanAnNhanh", "doanhthu");
        }

        private void exportExcel(DataGridView g, string duongDan, string tenTep)
        {
            xlapp obj = new xlapp();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTep + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            Indoanhthu doanhThu = new Indoanhthu();
            doanhThu.Show();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            showListNhanVien();
            showListMenu();
            ADD_DISH();
            lockTxtTabPageNV();
            btnExit.Enabled = false;
            btnSave.Enabled = false;
            LoadComboBox();
            LoadComboBox2();
            AddMaNV();
            AddGia();
            LoadDoanhThu();
            BindingData();
        }


    }
}
