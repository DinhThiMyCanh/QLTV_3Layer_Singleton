using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL_QLTV
{
    public class DataProvider
    {
        //Singleton
        private static DataProvider instance;//Ctrl+E+R
        public SqlConnection cn;
        public SqlDataAdapter da;
        public  SqlCommand cmd;
        private  string st = @"Data Source=CANH-DHQN\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";

        //Singleton
        public static DataProvider Instance {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set => instance = value; 
        }

        //Singleton
        private DataProvider() { }
        
        
        public DataTable getTable(string sql)
        {
            using (SqlConnection cn = new SqlConnection(st))
            {
                cn.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                cn.Close();
                return dt;
            }
        }
        //Phương thức dùng để cập nhật dl khi thêm, sửa, xóa
        public int updateData(string sql, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection cn = new SqlConnection(st))
            //Dùng using để khi giải phóng bộ nhớ khi mở và đóng kết nối
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                if (parameter != null)
                {
                    string[] listpara = sql.Split(' ');
                    int i = 0;
                    //Luu y cac tham so trong sql phải có khoảng trắng để tách, vi du @hoTen , @ns
                    foreach (string item in listpara)
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                }
                data = cmd.ExecuteNonQuery();
                cn.Close();
            }
            return data;

        }
        //Phương thức dùng để kiểm tra có tồn tại object
        public int Ktra(string sql, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection cn = new SqlConnection(st))
            //Dùng using để khi giải phóng bộ nhớ khi mở và đóng kết nối
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                if (parameter != null)
                {
                    string[] listpara = sql.Split(' ');
                    int i = 0;
                   // Luu y cac tham so trong sql, vi du @hoTen , @ns
                    foreach (string item in listpara)
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                }
                data = (int)cmd.ExecuteScalar();
                cn.Close();
            }
            return data;
        }
    }
}

