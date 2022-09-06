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
using DTO_QLTV;
namespace GUI_QLTV
{
    public partial class frmMain : Form
    {
        BUS_DangNhap busDangNhap = new BUS_DangNhap();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dataDN.DataSource = busDangNhap.getTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string user = txtTenDN.Text;
            string mk = txtMK.Text;
            int q = int.Parse(cboQuyen.SelectedItem.ToString());
            DTO_DangNhap tk = new DTO_DangNhap(txtTenDN.Text,txtMK.Text,q);
            if (busDangNhap.themTaiKhoan(tk) == true)
            {
                MessageBox.Show("Thêm thành công");
                dataDN.DataSource = busDangNhap.getTaiKhoan();
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string user = txtTenDN.Text;
            if (busDangNhap.xoaTaiKhoan(user) == true)
            {
                MessageBox.Show("Xóa thành công");
                dataDN.DataSource = busDangNhap.getTaiKhoan();
            }
            else
                MessageBox.Show("Xóa không thành công");
        }

        private void dataDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataDN.CurrentCell.RowIndex;
            txtTenDN.Text = dataDN.Rows[i].Cells[0].Value.ToString();
            txtMK.Text = dataDN.Rows[i].Cells[1].Value.ToString();
            cboQuyen.Text = dataDN.Rows[i].Cells[2].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Chỉ được cập nhật lại mật khẩu và quyền đăng nhập
            string user = txtTenDN.Text;
            string mk = txtMK.Text;
            int q = int.Parse(cboQuyen.SelectedItem.ToString());
            DTO_DangNhap tk = new DTO_DangNhap(txtTenDN.Text, txtMK.Text, q);
            if (busDangNhap.suaTaiKhoan(tk)==true)
            {
                MessageBox.Show("Sửa thành công");
                dataDN.DataSource = busDangNhap.getTaiKhoan();
            }
            else
                MessageBox.Show("Sửa thất bại");
        }
    }
}
