using ShoesShop.BUS;
using ShoesShop.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesShop
{
    public partial class FQuanLyBaoCao : Form
    {
        BUS_Giay busGiay;
        public FQuanLyBaoCao()
        {
            InitializeComponent();
            busGiay = new BUS_Giay();
        }

        private void mSISanPham_Click(object sender, EventArgs e)
        {
            FBaoCaoSanPham f = new FBaoCaoSanPham();
            cRSanPham r = new cRSanPham();

            r.SetDataSource(busGiay.LayDSSanPhamReport());
            f.crystalReportViewer1.ReportSource = r;

            f.StartPosition = FormStartPosition.CenterScreen;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
