using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTV;
using DTO_QLTV;
namespace BUS_QLTV
{
   public class BUS_DangNhap
    {
        DAL_DangNhap dalDangNhap = new DAL_DangNhap();
        public DataTable getTaiKhoan()
        {
            return dalDangNhap.getTaiKhoan();
        }
        public bool checkLogin(string user, string pp)
        {
            return dalDangNhap.checkLogin(user, pp);
        }
        public bool themTaiKhoan(DTO_DangNhap tk)
        {
            return dalDangNhap.themTaiKhoan(tk);
        }
        public bool xoaTaiKhoan(string TenTK)
        {
            return dalDangNhap.xoaTaiKhoan(TenTK);
        }
        public bool suaTaiKhoan(DTO_DangNhap tk)
        {
            return dalDangNhap.suaTaiKhoan(tk);
        }

    }
}
