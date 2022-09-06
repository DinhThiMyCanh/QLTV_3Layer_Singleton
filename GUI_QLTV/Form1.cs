using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLTV;

namespace GUI_QLTV
{
    public partial class frmDangNhap : Form
    {
        BUS_DangNhap busDangNhap = new BUS_DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (busDangNhap.checkLogin(txtTenDN.Text,txtMK.Text))
            {
                MessageBox.Show("Đăng nhập thành công");
            }    
            else
                MessageBox.Show("Đăng nhập không thành công");
        }
    }
}
