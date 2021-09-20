using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.DAO
{
    class DAO_NhanVien
    {
        ShoesShopDBEntities db;

        public DAO_NhanVien()
        {
            db = new ShoesShopDBEntities();
        }

        public dynamic LayDSNhanVien2() // Data for ComboBox
        {
            dynamic ds = db.Employees.Select(e => new
            {
                e.EmployeeID,
                e.FullName
            }).ToList();

            return ds;
        }
    }
}
