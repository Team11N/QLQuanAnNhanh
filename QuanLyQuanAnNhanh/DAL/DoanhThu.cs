using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyQuanAnNhanh.DAL
{
    public class DoanhThu : SQLConnect
    {
        
        public DataTable HienThiDoanhThuTheoNgay(DateTime ngaythanhtoan)
        {
            return ThucThiQuery("exec BCDTTheoNgay @ngaythanhtoan", new object[] { ngaythanhtoan });
        }
        public DataTable HienThiDoanhThuTheoThang(DateTime ngaythanhtoan)
        {
            return ThucThiQuery("exec BCDTTheoThang @ngaythanhtoan", new object[] { ngaythanhtoan });
        }
        public DataTable HienThiDoanhThuTheoNam(DateTime ngaythanhtoan)
        {
            return ThucThiQuery("exec BCDTTheoNam @ngaythanhtoan", new object[] { ngaythanhtoan });
        }
        public DataTable XoaDoanhThu(string maorder)
        {
            return ThucThiQuery("exec XoaDoanhThu @ID_order", new object[] { maorder });
        }
        public DataTable HienThiDoanhThu()
        {
            return ThucThiQuery("exec BaoCaoDoanhThu");

        }
        public DataTable BieuDo()
        {
            return ThucThiQuery("exec bieudo");
        }
        public void updateBieuDo()
        {
            ThucThiNonQuery("exec updatebieudo");
        }
    }
}
