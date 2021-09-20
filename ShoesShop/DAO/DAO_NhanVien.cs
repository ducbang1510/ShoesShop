﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesShop.DAO
{
    class DAO_NhanVien
    {
        ShoesShopDBEntities db;

        public DAO_NhanVien()
        {
            db = new ShoesShopDBEntities();
        }

        public dynamic LayDSNhanVien()
        {
            var ds = db.Employees.Select(e => new
            {
                e.EmployeeID,
                e.FullName,
                e.Gender,
                e.DateOfBirth,
                e.Phone,
                e.Email,
                e.Address,
                e.UserRole,
                e.Username,
                e.Password,
            }).ToList();      

            return ds;
        }

        public bool ThemNhanVien(Employee nv)
        {
            bool tinhTrang = false;
            try
            {
                db.Employees.Add(nv);
                db.SaveChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool SuaThongTinNhanVien(Employee nv)
        {
            bool tinhTrang = false;
            try
            {
                Employee e = db.Employees.Find(nv.EmployeeID);
                e.FullName = nv.FullName;
                e.Phone = nv.Phone;
                e.Email = nv.Email;
                e.Address = nv.Address;
                e.Username = nv.Username;
                e.Password = nv.Password;
                
                db.SaveChanges();
                tinhTrang = true;
            }
            catch (Exception ex)
            {
                tinhTrang = false;
                MessageBox.Show(ex.Message);
            }

            return tinhTrang;
        }

        public bool XoaNhanVien(int maNV)
        {
            bool tinhTrang = false;
            try
            {
                Employee e = db.Employees.Find(maNV);

                db.Employees.Remove(e);
                db.SaveChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }
    }
}
