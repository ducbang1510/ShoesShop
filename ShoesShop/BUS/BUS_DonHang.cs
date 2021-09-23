using ShoesShop.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesShop.BUS
{
    class BUS_DonHang
    {
        DAO_DonHang daoDH;

        public BUS_DonHang()
        {
            daoDH = new DAO_DonHang();
        }

        public void HienThiDSDonHang(DataGridView dg)
        {
            dg.DataSource = daoDH.LayDSDonHang();
        }

        public bool ThemDonHang(Order d)
        {
            try
            {
                daoDH.ThemDonHang(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void XoaDonHang(int maDH)
        {
            if (daoDH.XoaDonHang(maDH))
            {
                MessageBox.Show("Xóa đơn hàng thành công");
            }
            else
            {
                MessageBox.Show("Không thấy đơn hàng để xóa");
            }
        }

        public bool SuaDonHang(Order donHang)
        {
            //if (daoDH.KTDonHang(donHang))
            //{
            try
            {
                daoDH.SuaDonHang(donHang);
                return true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            //}
            //else
            //{
            //    return false;
            //}
        }

        public List<Order> LayDSDonHangReport()
        {
            return daoDH.LayDSDonHangReport();
        }
    }
}
