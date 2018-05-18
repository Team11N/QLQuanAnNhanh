using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanAnNhanh.DAL
{
    public class BanHang : SQLConnect
    {
        SQLConnect cnn = new SQLConnect();
        public void ThanhToan(string idorder, string tenmon, string manv, int soluong, int tongtien, DateTime thoigianthanhtoan)
        {
            cnn.ThucThiNonQuery("exec ThanhToan @madonhang , @tenmon , @manv ,  @soluong , @tongtien , @thoigianthanhtoan", new object[] { idorder, tenmon, manv, soluong, tongtien, thoigianthanhtoan });
        }

    }
}
