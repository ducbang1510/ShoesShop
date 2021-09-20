using ShoesShop.BUS;
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
    public partial class FQuanLyDonHang : Form
    {
        BUS_DonHang busDH;
        public FQuanLyDonHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }

        private void HienThiDSDonHang()
        {
            gVDH.DataSource = null;
            busDH.HienThiDSDonHang(gVDH);
            gVDH.Columns[0].Width = (int)(0.1 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[4].Width = (int)(0.2 * gVDH.Width);
        }

        private void FQuanLyDonHang_Load(object sender, EventArgs e)
        {
            HienThiDSDonHang();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.CustomerID = int.Parse(cbKhachHang.SelectedValue.ToString());
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            d.OrderDate = dtpNgayDatHang.Value;
            d.TotalPrice = decimal.Parse(txtTongTien.Text);

            if (busDH.ThemDonHang(d))
            {
                MessageBox.Show("Tạo đơn hàng thành công");
                HienThiDSDonHang();
            }
            else
            {
                MessageBox.Show("Tạo đơn hàng thất bại");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.OrderID = int.Parse(txtMaDH.Text);
            d.OrderDate = dtpNgayDatHang.Value;
            d.CustomerID = int.Parse(cbKhachHang.SelectedValue.ToString());
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            busDH.SuaDonHang(d);
            busDH.HienThiDSDonHang(gVDH);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text != "")
            {
                busDH.XoaDonHang(Int32.Parse(txtMaDH.Text));
                busDH.HienThiDSDonHang(gVDH);
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn hàng để xóa");
            }
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Enabled = false;
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDatHang.Text = gVDH.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells["Customer"].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["Employee"].Value.ToString();
                txtTongTien.Text = gVDH.Rows[e.RowIndex].Cells["TotalPrice"].Value.ToString();
            }
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int maDH;
            maDH = int.Parse(gVDH.CurrentRow.Cells["OrderID"].Value.ToString());

            FChiTietDonHang c = new FChiTietDonHang();
            c.maDH = maDH;
            c.ShowDialog();
        }
    }
}
