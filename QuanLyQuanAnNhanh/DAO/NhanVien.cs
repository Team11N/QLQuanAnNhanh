using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnNhanh.DAO
{
    public class NhanVien
    {
        public NhanVien() {
            this.id = ""; this.name = ""; this.Birthday = DateTime.Now; this.contact = "";
        }
        public NhanVien(string id, string name, DateTime birthday, string contact) {
            this.id = id;this.name = name;this.Birthday = birthday;this.contact = contact;
        }

        private string id;
        private string name;
        private DateTime birthday;
        private string contact;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        
    }
}
