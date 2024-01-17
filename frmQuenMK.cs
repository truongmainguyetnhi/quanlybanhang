using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    public partial class frmQuenMK : Form
    {
        public frmQuenMK()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void btnLayMK_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text.ToString();
            if(tenTK == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string query = "Select * from Taikhoan where tentaikhoan = '" + tenTK + "'";
                SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-4IN8B14\SQLEXPRESS;Initial Catalog=SAB;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("Select * from Taikhoan where tentaikhoan = N'" + txtTenTK.Text + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Mật khẩu: " + dt.Rows[0][1];
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Tài khoản chưa được đăng ký!";
                }
            }
        }


    }
}
