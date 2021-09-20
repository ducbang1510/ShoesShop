using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShoesShop.BUS;

namespace ShoesShop
{
    public partial class FQuanLyNhanVien : Form
    {
        BUS_NhanVien busNV;

        public FQuanLyNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        public void HienThiDSNhanVien()
        {
            CapNhatForm();
            dGVNhanVien.DataSource = null;
            busNV.LayDSNhanVien(dGVNhanVien);
        }

        public void CapNhatForm()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtVaiTro.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void FQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNhanVien();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Employee nv = new Employee();
            nv.EmployeeID = int.Parse(txtMaNV.Text);
            nv.FullName = txtHoTen.Text;
            nv.DateOfBirth = dtpNgaySinh.Value.Date;
            nv.Gender = txtGioiTinh.Text;
            nv.Email = txtEmail.Text;
            nv.Phone = txtSDT.Text;
            nv.Address = txtDiaChi.Text;
            nv.UserRole = txtVaiTro.Text;
            nv.Username = txtTaiKhoan.Text;
            nv.Password = txtMatKhau.Text;

            busNV.ThemNhanVien(nv);          
            HienThiDSNhanVien();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Employee nv = new Employee();
            nv.EmployeeID = int.Parse(txtMaNV.Text);
            nv.FullName = txtHoTen.Text;           
            nv.Email = txtEmail.Text;
            nv.Phone = txtSDT.Text;
            nv.Address = txtDiaChi.Text;            
            nv.Username = txtTaiKhoan.Text;
            nv.Password = txtMatKhau.Text;

            busNV.SuaThongTinNhanVien(nv);
            HienThiDSNhanVien();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(txtMaNV.Text);
            busNV.XoaNhanVien(maNV);
            HienThiDSNhanVien();
        }

        private void dGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGVNhanVien.Rows.Count)
            {
                txtMaNV.Text = dGVNhanVien.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                txtHoTen.Text = dGVNhanVien.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtGioiTinh.Text = dGVNhanVien.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                dtpNgaySinh.Text = dGVNhanVien.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
                txtEmail.Text = dGVNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSDT.Text = dGVNhanVien.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtDiaChi.Text = dGVNhanVien.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtVaiTro.Text = dGVNhanVien.Rows[e.RowIndex].Cells["UserRole"].Value.ToString();
                txtTaiKhoan.Text = dGVNhanVien.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                txtMatKhau.Text = dGVNhanVien.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            }
        }
    }
}
