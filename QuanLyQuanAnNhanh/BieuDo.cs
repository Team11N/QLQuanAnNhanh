using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAnNhanh.DAL;

namespace QuanLyQuanAnNhanh
{
    public partial class BieuDo : Form
    {
        public BieuDo()
        {
            InitializeComponent();
        }
        DoanhThu doanhThu = new DoanhThu();
        private void BieuDo_Load(object sender, EventArgs e)
        {
            charDoanhThu.DataSource = doanhThu.BieuDo();
        }
    }
}
