using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnNhanh.DAO
{
    public class BanHang
    {
        private string idOrder;
        private string nameEat;
        private int soLuong;
        private string nameNV;
        private DateTime ngayBan;

        public string IdOrder
        {
            get
            {
                return idOrder;
            }

            set
            {
                idOrder = value;
            }
        }

        public string NameEat
        {
            get
            {
                return nameEat;
            }

            set
            {
                nameEat = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public string NameNV
        {
            get
            {
                return nameNV;
            }

            set
            {
                nameNV = value;
            }
        }

        public DateTime NgayBan
        {
            get
            {
                return ngayBan;
            }

            set
            {
                ngayBan = value;
            }
        }
    }
}
