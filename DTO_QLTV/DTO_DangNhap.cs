using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
   public class DTO_DangNhap
    {
        private string tenDangNhap;
        private string matKhau;
        private int quyen;

        public DTO_DangNhap()
        {

        }
        public DTO_DangNhap(string tenDN, string mk, int quyen)
        {
            this.TenDangNhap = tenDN;
            this.MatKhau = mk;
            this.Quyen = quyen;
        }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int Quyen { get => quyen; set => quyen = value; }
    }
}
