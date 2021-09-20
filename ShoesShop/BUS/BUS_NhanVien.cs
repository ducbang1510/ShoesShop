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
    }
}
