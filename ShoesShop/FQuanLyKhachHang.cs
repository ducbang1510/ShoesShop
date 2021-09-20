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
    public partial class FQuanLyKhachHang : Form
    {
        BUS_KhachHang busKH;
        public FQuanLyKhachHang()
        {
            InitializeComponent();
            busKH = new BUS_KhachHang();
        }

        public void HienThiDSKhachHang()
        {
            dGVKhachHang.DataSource = null;
            busKH.LayDSKhachHang(dGVKhachHang);
            dGVKhachHang.Columns[0].Width = (int)(dGVKhachHang.Width * 0.1);
            dGVKhachHang.Columns[1].Width = (int)(dGVKhachHang.Width * 0.2);
            dGVKhachHang.Columns[2].Width = (int)(dGVKhachHang.Width * 0.15);
            dGVKhachHang.Columns[3].Width = (int)(dGVKhachHang.Width * 0.15);
            dGVKhachHang.Columns[4].Width = (int)(dGVKhachHang.Width * 0.15);
            dGVKhachHang.Columns[5].Width = (int)(dGVKhachHang.Width * 0.25);
        }

        private void FQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKhachHang();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();

            c.FullName = txtHoTen.Text;
            c.DateOfBirth = dtpNgaySinh.Value.Date;
            c.Email = txtEmail.Text;
            c.Phone = txtSDT.Text;
            c.Address = txtDiaChi.Text;

            busKH.ThemKhachHang(c);
            HienThiDSKhachHang();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();

            c.CustomerID = int.Parse(dGVKhachHang.Rows[dGVKhachHang.CurrentRow.Index].Cells[0].Value.ToString());
            c.FullName = txtHoTen.Text;
            c.DateOfBirth = dtpNgaySinh.Value.Date;
            c.Email = txtEmail.Text;
            c.Phone = txtSDT.Text;
            c.Address = txtDiaChi.Text;

            busKH.SuaThongTinKhachHang(c);
            HienThiDSKhachHang();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maKH = int.Parse(dGVKhachHang.Rows[dGVKhachHang.CurrentRow.Index].Cells[0].Value.ToString());
            busKH.XoaThongTinKhachHang(maKH);
            HienThiDSKhachHang();
        }

        private void dGVKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGVKhachHang.Rows.Count)
            {
                txtMaKH.Enabled = false;
                txtMaKH.Text = dGVKhachHang.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
                txtHoTen.Text = dGVKhachHang.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                dtpNgaySinh.Text = dGVKhachHang.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
                txtEmail.Text = dGVKhachHang.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSDT.Text = dGVKhachHang.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtDiaChi.Text = dGVKhachHang.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }

        private void dGVKhachHang_DoubleClick(object sender, EventArgs e)
        {
            int maKH;
            string tenKH;
            maKH = int.Parse(dGVKhachHang.CurrentRow.Cells["CustomerID"].Value.ToString());
            tenKH = dGVKhachHang.CurrentRow.Cells["FullName"].Value.ToString();
            //goi Form
            FDatHang fDatHang = new FDatHang();
            //truyen bien
            fDatHang.maKH = maKH;
            fDatHang.tenKH = tenKH;
            fDatHang.ShowDialog();
        }
    }
}
