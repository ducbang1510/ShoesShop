using ShoesShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesShop.BUS
{
    class BUS_NhanVien
    {
        DAO_NhanVien daoNV;

        public BUS_NhanVien()
        {
            daoNV = new DAO_NhanVien();
        }

        public void HienThiDSNhanVien(ComboBox cb)
        {
            cb.DisplayMember = "FullName";
            cb.ValueMember = "EmployeeID";
            cb.DataSource = daoNV.LayDSNhanVien2();
        }

        public void LayDSNhanVien(DataGridView dg)
        {
            dg.DataSource = daoNV.LayDSNhanVien();
        }

        public void ThemNhanVien(Employee nv)
        {
            if (daoNV.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên mới thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên mới thất bại");
            }
        }

        public void SuaThongTinNhanVien(Employee nv)
        {
            if (daoNV.SuaThongTinNhanVien(nv))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại");
            }
        }

        public void XoaNhanVien(int maNV)
        {
            if (daoNV.XoaNhanVien(maNV))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }
    }
}
