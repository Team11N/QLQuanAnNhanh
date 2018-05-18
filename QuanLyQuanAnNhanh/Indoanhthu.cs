using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAnNhanh
{
    public partial class Indoanhthu : Form
    {
        public Indoanhthu()
        {
            InitializeComponent();
        }

        private void Indoanhthu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FastFoodShopDataSet.ReportDoanhThu' table. You can move, or remove it, as needed.
            this.ReportDoanhThuTableAdapter.Fill(this.FastFoodShopDataSet.ReportDoanhThu);

            this.rpvDoanhThu.RefreshReport();
        }
    }
}
