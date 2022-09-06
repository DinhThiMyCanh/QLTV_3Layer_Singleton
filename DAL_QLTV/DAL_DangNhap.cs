using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QLTV;
namespace DAL_QLTV
{
   public class DAL_DangNhap
    {
        public DataTable getTaiKhoan()
        {
            string sql = "Select * from DangNhap";
            return DataProvider.Instance.getTable(sql);
        }
        public bool checkLogin(string user, string pp)
        {
            string sql = string.Format("Select count(*) from DangNhap where TenDangNhap='{0}' and MatKhau ='{1}'",user,pp);
            bool check = false;
            if (DataProvider.Instance.Ktra(sql)>0)
            {
                check = true;
            }    
            return check;
        }
        public bool themTaiKhoan(DTO_DangNhap tk)
        {
            string sql1 = string.Format("Select count(*) from DangNhap where TenDangNhap='{0}'and MatKhau='{1}' and Quyen ='{2}'", tk.TenDangNhap, tk.MatKhau, tk.Quyen);
            if (DataProvider.Instance.Ktra(sql1) == 0)
            {
                string sql2 = "insert into DangNhap(TenDangNhap,MatKhau,Quyen) values( @TenDangNhap , @MatKhau , @Quyen )";
                object[] parameter = { tk.TenDangNhap, tk.MatKhau, tk.Quyen };
                if (DataProvider.Instance.updateData(sql2, parameter) > 0)
                    return true;     
            }
             return false;
        }
        public bool suaTaiKhoan(DTO_DangNhap tk)
        {
            string sql = string.Format("update DangNhap set TenDangNhap = @TenDangNhap ,MatKhau = @MatKhau ,Quyen = @Quyen where TenDangNhap ='{0}'",tk.TenDangNhap);
            object[] parameter = { tk.TenDangNhap, tk.MatKhau, tk.Quyen };
            if (DataProvider.Instance.updateData(sql, parameter) > 0)
                return true;
            return false;
        }
        public bool xoaTaiKhoan(string TenTK)
        {
            
                string sql = string.Format("delete from DangNhap where TenDangNhap ='{0}'",TenTK);
                if (DataProvider.Instance.updateData(sql) > 0)
                    return true;
                else
                    return false;
           
        }

    }
}
